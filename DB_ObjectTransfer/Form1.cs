using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Collections.Specialized;
using System.Data.SqlClient;

namespace DB_ObjectTransfer
{
    public partial class Form1 : Form
    {
        public BindingList<MetadataModel> Tables { get; set; }

        public Microsoft.SqlServer.Management.Smo.Server SourceServer { get; set; }

        public Microsoft.SqlServer.Management.Smo.Server DestinationServer { get; set; }

        private SystemMenu SystemMenu { get; set; }

        public LogWindow LogWindow { get; set; }

        public BrightIdeasSoftware.MappedImageRenderer StatusRenderer { get; set; }

        public Form1()
        {
            this.SystemMenu = new SystemMenu(this);
            this.SystemMenu.AddCommand("Logger", SwitchLogger, true);

            this.LogWindow = new LogWindow();
            this.LogWindow.Visible = false;

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.LogWindow.Log(LogType.Info, "Form loaded...", "");

            this.Tables = new BindingList<MetadataModel>();
            this.cbxSrcAuth.SelectedIndex = 0;
            this.cbxDstAuth.SelectedIndex = 0;

            this.StatusRenderer = new BrightIdeasSoftware.MappedImageRenderer(new Object[] {
                MetadataModelStatus.Pending, Properties.Resources.time,
                MetadataModelStatus.Running, Properties.Resources.bullet_go,
                MetadataModelStatus.Success, Properties.Resources.tick,
                MetadataModelStatus.Failed, Properties.Resources.cross
            });

            this.fastDataListView1.CellRendererGetter = delegate (object rowObject, BrightIdeasSoftware.OLVColumn column) {
                if (column.Name == "Percentage")
                {
                    return this.barRenderer1;
                }
                else if (column.Name == "Status")
                {
                    return this.StatusRenderer;
                }
                else
                {
                    return this.fastDataListView1.DefaultRenderer;
                }
            };
        }

        private void btnLoadCsv_Click(object sender, EventArgs e)
        {
            this.LogWindow.Log(LogType.Info, "CSV loading...", "");

            var filePath = @"c:\Users\selman.ay\Desktop\logo_db.csv";
            using (var ofd = new OpenFileDialog { Filter = "Comma Seperated Values (*.csv)|*.csv|All files (*.*)|*.*" })
            {
                if (ofd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                filePath = ofd.FileName;
            }
            
            var lines = new List<string>(System.IO.File.ReadLines(filePath));
            
            lines.ForEach(l => {
                if (string.IsNullOrEmpty(l) || string.IsNullOrWhiteSpace(l) || l.Equals("SchemaName;TableName", StringComparison.InvariantCultureIgnoreCase))
                {
                    return;
                }

                var tmpModel = new MetadataModel();
                var tokens = l.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length >= 1 && !string.IsNullOrEmpty(tokens[0].Trim()))
                {
                    tmpModel.SchemaName = tokens[0];
                }

                if (tokens.Length > 1 && !string.IsNullOrEmpty(tokens[1].Trim()))
                {
                    tmpModel.TableName = tokens[1];
                }

                this.Tables.Add(tmpModel);
            });

            this.fastDataListView1.DataSource = this.Tables;
            this.fastDataListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void cbxSrcDatabases_ClearItems(object sender, EventArgs e)
        {
            this.cbxSrcDatabases.Items.Clear();
        }
        
        private void cbxDstDatabases_ClearItems(object sender, EventArgs e)
        {
            this.cbxDstDatabases.Items.Clear();
        }

        private void cbxSrcAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cbx = sender as ComboBox;
            if (cbx == null)
            {
                return;
            }

            if (cbx.SelectedItem.Equals("Windows Authentication"))
            {
                txtSrcLogin.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                txtSrcPass.Text = "";

                txtSrcLogin.Enabled = txtSrcPass.Enabled = false;
            }
            else
            {
                txtSrcLogin.Text = "";
                txtSrcPass.Text = "";

                txtSrcLogin.Enabled = txtSrcPass.Enabled = true;
            }
        }

        private void cbxDstAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cbx = sender as ComboBox;
            if (cbx == null)
            {
                return;
            }

            if (cbx.SelectedItem.Equals("Windows Authentication"))
            {
                txtDstLogin.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                txtDstPass.Text = "";

                txtDstLogin.Enabled = txtDstPass.Enabled = false;
            }
            else
            {
                txtDstLogin.Text = "";
                txtDstPass.Text = "";

                txtDstLogin.Enabled = txtDstPass.Enabled = true;
            }
        }
        
        private async void btnTransfer_Click(object sender, EventArgs e)
        {
            pbTotal.Maximum = this.Tables.Count;
            pbTotal.Value = 0;

            foreach (var table in this.Tables)
            {
                try
                {
                    table.Status = MetadataModelStatus.Running;
                    this.fastDataListView1.UpdateObject(table);

                    if (imAutoScroll.Checked)
                    {
                        this.fastDataListView1.EnsureModelVisible(table);
                    }
                    
                    var srcdbName = this.cbxSrcDatabases.SelectedItem as string;
                    var dstdbName = this.cbxDstDatabases.SelectedItem as string;

                    var script = await GenerateScript(srcdbName, table.TableName);
                    await ExecuteScript(this.DestinationServer, dstdbName, script);

                    table.RowCount = await GetRowCount(this.SourceServer, srcdbName, table.TableName);
                    this.fastDataListView1.UpdateObject(table);

                    await TransferData(this.SourceServer, this.DestinationServer, srcdbName, dstdbName, table);

                    table.RowsCopied = table.RowCount;
                    this.fastDataListView1.UpdateObject(table);

                    if (table.ReSeed)
                    {
                        await ReseedTable(this.DestinationServer, dstdbName, table.TableName);
                    }

                    table.Status = MetadataModelStatus.Success;
                    this.fastDataListView1.UpdateObject(table);
                }
                catch (AggregateException ex)
                {
                    foreach (var exx in ex.InnerExceptions)
                    {
                        LogWindow.Log(LogType.Error, exx.Message, (exx.InnerException != null) ? exx.InnerException.Message : "");
                    }

                    table.Status = MetadataModelStatus.Failed;
                    this.fastDataListView1.UpdateObject(table);
                }
                catch (Exception ex)
                {
                    LogWindow.Log(LogType.Error, ex.Message, (ex.InnerException != null) ? ex.InnerException.Message : "");

                    table.Status = MetadataModelStatus.Failed;
                    this.fastDataListView1.UpdateObject(table);
                }
                
                pbTotal.PerformStep();
            }

            MessageBox.Show("Done");
        }

        private Task ReseedTable(Server destinationServer, string dstdbName, string tableName)
        {
            return Task.Factory.StartNew(()=> {
                if (!destinationServer.Databases.Contains(dstdbName))
                {
                    throw new ApplicationException(string.Format("Database with name {0} on destination server not found", dstdbName));
                }

                if (!destinationServer.Databases[dstdbName].Tables.Contains(tableName))
                {
                    throw new ApplicationException(string.Format("Table with name {0} in database with name {1} on destination server not found", tableName, dstdbName));
                }

                foreach (Column column in destinationServer.Databases[dstdbName].Tables[tableName].Columns)
                {
                    if (column.Identity)
                    {
                        destinationServer.Databases[dstdbName].ExecutionManager.ConnectionContext.ExecuteNonQuery(string.Format("DBCC CHECKIDENT ('{0}', RESEED)", tableName));
                        break;
                    }
                }
            });
        }

        private Task TransferData(Server sourceServer, Server destinationServer, string srcdbName, string dstdbName, MetadataModel table)
        {
            var srcConnStr = new System.Data.SqlClient.SqlConnectionStringBuilder(sourceServer.ConnectionContext.ConnectionString) { InitialCatalog = srcdbName, ConnectTimeout = 0 }.ToString();
            var dstConnStr = new System.Data.SqlClient.SqlConnectionStringBuilder(destinationServer.ConnectionContext.ConnectionString) { InitialCatalog = dstdbName, ConnectTimeout = 0 }.ToString();
            
            var srcConn = new System.Data.SqlClient.SqlConnection(srcConnStr);
            var srcCommand = srcConn.CreateCommand();
            var copier = new System.Data.SqlClient.SqlBulkCopy(dstConnStr, System.Data.SqlClient.SqlBulkCopyOptions.KeepIdentity | System.Data.SqlClient.SqlBulkCopyOptions.KeepNulls | System.Data.SqlClient.SqlBulkCopyOptions.TableLock);
            copier.NotifyAfter = 100;
            copier.EnableStreaming = true;
            copier.BulkCopyTimeout = 0;
            copier.SqlRowsCopied += delegate (object sender, System.Data.SqlClient.SqlRowsCopiedEventArgs e)
            {
                table.RowsCopied = e.RowsCopied;
                this.fastDataListView1.UpdateObject(table);
            };

            copier.DestinationTableName = table.TableName;

            srcCommand.CommandText = string.Format("SELECT * FROM [{0}].[{1}]", table.SchemaName, table.TableName);
            srcCommand.CommandType = CommandType.Text;
            srcCommand.CommandTimeout = 0;

            srcConn.Open();
            return copier.WriteToServerAsync(srcCommand.ExecuteReader());
        }

        private Task<long> GetRowCount(Server smo, string dbName, string tableName)
        {
            if (!(smo.Databases.Contains(dbName) && smo.Databases[dbName].Tables.Contains(tableName)))
            {
                throw new ApplicationException(string.Format("Table not found with name {0} in database named {1}", tableName, dbName));
            }

            return Task<long>.Factory.StartNew(() => {
                return smo.Databases[dbName].Tables[tableName].RowCount;
            });
        }

        private Task<StringCollection> GenerateScript(string dbName, string tableName)
        {
            var task = Task<StringCollection>.Factory.StartNew(() => {
                ScriptingOptions options = new ScriptingOptions();
                options.ClusteredIndexes = true;
                options.Default = true;
                options.DriAll = true;
                options.Indexes = true;
                options.IncludeHeaders = true;
                options.ExtendedProperties = true;
                options.Triggers = true;
                options.NoFileGroup = true;

                if (!(this.SourceServer.State == SqlSmoState.Existing && this.SourceServer.Databases.Contains(dbName) && this.SourceServer.Databases[dbName].Tables.Contains(tableName)))
                {
                    return null;
                }

                StringCollection coll = this.SourceServer.Databases[dbName].Tables[tableName].Script(options);

                return coll;
            });

            return task;
        }

        private Task ExecuteScript(Server smo, string dbName, StringCollection script)
        {
            return Task.Factory.StartNew(() => {
                if (!smo.Databases.Contains(dbName))
                {
                    return;
                }

                var dstConnStr = new System.Data.SqlClient.SqlConnectionStringBuilder(smo.ConnectionContext.ConnectionString) { InitialCatalog = dbName, ConnectTimeout = 0 }.ToString();

                SqlConnection connection = null;
                SqlTransaction transaction = null;
                SqlCommand command = null;

                try
                {
                    connection = new System.Data.SqlClient.SqlConnection(dstConnStr);
                    connection.Open();

                    transaction = connection.BeginTransaction();

                    foreach (var s in script)
                    {
                        command = connection.CreateCommand();
                        command.Transaction = transaction;
                        command.CommandText = s;
                        command.CommandTimeout = 0;
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;    
                }
                finally
                {
                    if (transaction != null)
                    {
                        transaction.Dispose();
                    }

                    if (connection != null && connection.State != ConnectionState.Closed)
                    {
                        connection.Close();
                        connection.Dispose();
                    }

                    if (command != null)
                    {
                        command.Dispose();
                    }
                }
            });
        }

        private void btnSrcConnect_Click(object sender, EventArgs e)
        {
            Button b = sender as Button; if (b == null) return;

            if (b.Text == "Connect")
            {
                ConnectToSourceServer();
                FillSourceDatabases();

                b.Text = "Disconnect";
            }
            else
            {
                this.SourceServer.ConnectionContext.Disconnect();
                this.cbxSrcDatabases.Items.Clear();
                b.Text = "Connect";
            }
        }

        private void btnDstConnect_Click(object sender, EventArgs e)
        {
            Button b = sender as Button; if (b == null) return;

            if (b.Text == "Connect")
            {
                ConnectToDestionatinServer();
                FillDestinationDatabases();

                b.Text = "Disconnect";
            }
            else
            {
                this.DestinationServer.ConnectionContext.Disconnect();
                this.cbxDstDatabases.Items.Clear();
                b.Text = "Connect";
            }
        }

        private void FillSourceDatabases()
        {
            if (this.SourceServer != null && this.SourceServer.State != SqlSmoState.Existing)
            {
                return;
            }

            foreach (Database d in this.SourceServer.Databases)
            {
                cbxSrcDatabases.Items.Add(d.Name);
            }
        }

        private void FillDestinationDatabases()
        {
            if (this.SourceServer != null && this.DestinationServer.State != SqlSmoState.Existing)
            {
                return;
            }

            foreach (Database d in this.DestinationServer.Databases)
            {
                cbxDstDatabases.Items.Add(d.Name);
            }
        }

        private void ConnectToSourceServer()
        {
            if (cbxSrcDatabases.Items.Count == 0
                            && !string.IsNullOrEmpty(txtSrcServer.Text)
                            && ((cbxSrcAuth.SelectedIndex == 1 && !string.IsNullOrEmpty(txtSrcLogin.Text) && !string.IsNullOrEmpty(txtSrcPass.Text))
                                || cbxSrcAuth.SelectedIndex == 0
                                ))
            {
                try
                {
                    this.SourceServer = new Microsoft.SqlServer.Management.Smo.Server();
                    this.SourceServer.ConnectionContext.StateChange += SourceConnectionContext_StateChange;
                    this.SourceServer.ConnectionContext.ServerInstance = txtSrcServer.Text;
                    if (cbxSrcAuth.SelectedIndex == 0)
                    {
                        this.SourceServer.ConnectionContext.LoginSecure = true;
                    }
                    else
                    {
                        this.SourceServer.ConnectionContext.LoginSecure = false;
                        this.SourceServer.ConnectionContext.Login = txtSrcLogin.Text;
                        this.SourceServer.ConnectionContext.Password = txtSrcPass.Text;
                    }

                    this.SourceServer.ConnectionContext.Connect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception connecting to source server");
                }
            }
            else
            {
                MessageBox.Show("Fill the connection form appropriately");
            }
        }
        
        private void ConnectToDestionatinServer()
        {
            if (cbxDstDatabases.Items.Count == 0
                            && !string.IsNullOrEmpty(txtDstServer.Text)
                            && ((cbxDstAuth.SelectedIndex == 1 && !string.IsNullOrEmpty(txtDstLogin.Text) && !string.IsNullOrEmpty(txtDstPass.Text))
                                || cbxDstAuth.SelectedIndex == 0
                                ))
            {
                try
                {
                    this.DestinationServer = new Microsoft.SqlServer.Management.Smo.Server();
                    this.DestinationServer.ConnectionContext.StateChange += DestinationConnectionContext_StateChange;
                    this.DestinationServer.ConnectionContext.ServerInstance = txtDstServer.Text;
                    if (cbxDstAuth.SelectedIndex == 0)
                    {
                        this.DestinationServer.ConnectionContext.LoginSecure = true;
                    }
                    else
                    {
                        this.DestinationServer.ConnectionContext.LoginSecure = false;
                        this.DestinationServer.ConnectionContext.Login = txtDstLogin.Text;
                        this.DestinationServer.ConnectionContext.Password = txtDstPass.Text;
                    }

                    this.DestinationServer.ConnectionContext.Connect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception connecting to destination server");
                }
            }
            else
            {
                MessageBox.Show("Fill the connection form appropriately");
            }
        }

        private void DestinationConnectionContext_StateChange(object sender, StateChangeEventArgs e)
        {
            if (e.CurrentState == ConnectionState.Open)
            {
                txtDstServer.Enabled = false;
                cbxDstAuth.Enabled = false;
                txtDstLogin.Enabled = false;
                txtDstPass.Enabled = false;
            }
            else
            {
                txtDstServer.Enabled = true;
                cbxDstAuth.Enabled = true;
                txtDstLogin.Enabled = cbxDstAuth.SelectedIndex == 1;
                txtDstPass.Enabled = cbxDstAuth.SelectedIndex == 1;
            }
        }

        private void SourceConnectionContext_StateChange(object sender, StateChangeEventArgs e)
        {
            if (e.CurrentState == ConnectionState.Open)
            {
                txtSrcServer.Enabled = false;
                cbxSrcAuth.Enabled = false;
                txtSrcLogin.Enabled = false;
                txtSrcPass.Enabled = false;
            }
            else
            {
                txtSrcServer.Enabled = true;
                cbxSrcAuth.Enabled = true;
                txtSrcLogin.Enabled = cbxSrcAuth.SelectedIndex == 1;
                txtSrcPass.Enabled = cbxSrcAuth.SelectedIndex == 1;
            }
        }
        
        protected override void WndProc(ref Message msg)
        {
            base.WndProc(ref msg);

            // Let it know all messages so it can handle WM_SYSCOMMAND
            // (This method is inlined)
            this.SystemMenu.HandleMessage(ref msg);
        }
        
        private void SwitchLogger()
        {
            this.LogWindow.Visible = !this.LogWindow.Visible;
        }

        private void btnLoadFromDb_Click(object sender, EventArgs e)
        {
            var dbName = cbxSrcDatabases.SelectedItem as string;
            if (!(this.SourceServer.State == SqlSmoState.Existing && this.SourceServer.Databases.Contains(dbName)))
            {
                return;
            }

            foreach (Table table in this.SourceServer.Databases[dbName].Tables)
            {
                var tmpModel = new MetadataModel();
                tmpModel.SchemaName = table.Schema;
                tmpModel.TableName = table.Name;
                this.Tables.Add(tmpModel);
            }

            this.fastDataListView1.DataSource = this.Tables;
            this.fastDataListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void miClearAll_Click(object sender, EventArgs e)
        {
            this.Tables.Clear();
        }

        private void miClearSelected_Click(object sender, EventArgs e)
        {
            this.fastDataListView1.RemoveObjects(this.fastDataListView1.SelectedObjects);
        }

        private void miClearSucceded_Click(object sender, EventArgs e)
        {
            var objects = (from n in this.Tables where n.Status == MetadataModelStatus.Success select n).ToList();

            this.fastDataListView1.RemoveObjects(objects);
        }

        private void miClearFailed_Click(object sender, EventArgs e)
        {
            var objects = (from n in this.Tables where n.Status == MetadataModelStatus.Failed select n).ToList();

            this.fastDataListView1.RemoveObjects(objects);
        }

        private void imAutoScroll_Click(object sender, EventArgs e)
        {
            var s = sender as ToolStripMenuItem;
            if (s == null)
            {
                return;
            }

            s.Checked = !s.Checked;
        }

        private void miReseedAll_Click(object sender, EventArgs e)
        {
            this.Tables.ToList().ForEach(t => { t.ReSeed = true; });
        }

        private void miUnreseedAll_Click(object sender, EventArgs e)
        {
            this.Tables.ToList().ForEach(t => { t.ReSeed = false; });
        }

        private void miReseedSelected_Click(object sender, EventArgs e)
        {
            var iterator = this.fastDataListView1.SelectedObjects.GetEnumerator();
            while (iterator.MoveNext())
            {
                ((MetadataModel)iterator.Current).ReSeed = true;
            }
                
        }

        private void miUnreseedSelected_Click(object sender, EventArgs e)
        {
            var iterator = this.fastDataListView1.SelectedObjects.GetEnumerator();
            while (iterator.MoveNext())
            {
                ((MetadataModel)iterator.Current).ReSeed = false;
            }
        }
    }

    public class MetadataModel
    {
        [BrightIdeasSoftware.OLVColumn(DisplayIndex = 1, TextAlign = HorizontalAlignment.Center)]
        public MetadataModelStatus Status { get; set; }

        [BrightIdeasSoftware.OLVColumn(DisplayIndex = 2)]
        public string SchemaName { get; set; }

        [BrightIdeasSoftware.OLVColumn(DisplayIndex = 3)]
        public string TableName { get; set; }

        [BrightIdeasSoftware.OLVColumn(DisplayIndex = 4)]
        public long RowCount { get; set; }

        [BrightIdeasSoftware.OLVColumn(DisplayIndex = 5)]
        public long RowsCopied { get; set; }

        [BrightIdeasSoftware.OLVColumn(DisplayIndex = 6, CheckBoxes = true, TriStateCheckBoxes = true)]
        public bool ReSeed { get; set; }

        [BrightIdeasSoftware.OLVColumn("Rows Copied (%)", FillsFreeSpace = true, DisplayIndex = 8)]
        public long Percentage
        {
            get
            {
                if (this.RowCount == 0 || this.RowsCopied == 0)
                {
                    return 0;
                }

                return ((long)((((decimal)this.RowsCopied) / this.RowCount) * 100));
            }
        }
    }

    public enum MetadataModelStatus
    {
        Pending = 0,
        Running = 1,
        Success = 2,
        Failed = 3
    }
}

