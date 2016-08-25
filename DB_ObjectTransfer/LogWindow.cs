using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_ObjectTransfer
{
    public partial class LogWindow : Form
    {
        public BrightIdeasSoftware.IRenderer LogTypeRenderer { get; set; }

        public BindingList<LogModel> Logs { get; set; }
        public LogWindow()
        {
            InitializeComponent();

            this.LogTypeRenderer = new BrightIdeasSoftware.MappedImageRenderer(new Object[] {
                LogType.Error, Properties.Resources.Error,
                LogType.Warning, Properties.Resources.Warning,
                LogType.Info, Properties.Resources.Info                
            });
            
            this.Logs = new BindingList<LogModel>();
            this.fastDataListView1.DataSource = this.Logs;
            this.fastDataListView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.fastDataListView1.CellRendererGetter = delegate (object rowObject, BrightIdeasSoftware.OLVColumn column) {
                if (column.Name == "LogType")
                {
                    return this.LogTypeRenderer;
                }
                else
                {
                    return this.fastDataListView1.DefaultRenderer;
                }
            };
        }

        private void LogWindow_Load(object sender, EventArgs e)
        {
            
        }

        public void Log(LogType logType, string message, string details, [CallerMemberName] string callerName = "", [CallerLineNumber] int callerLineNumber = 0)
        {
            var l = new LogModel();
            l.Message = message;
            l.Details = details;
            l.LogType = logType;
            l.Timestamp = DateTime.Now;
            l.CallerMethodName = callerName;
            l.CallerLineNumber = callerLineNumber;

            this.Logs.Add(l);
            if (this.Logs.Count >= 1000)
            {
                this.Logs.RemoveAt(0);
            }
        }
    }

    public class LogModel
    {
        public LogType LogType { get; set; }
        public string Message { get; set; }
        public string Details { get; set; }
        public DateTime Timestamp { get; set; }
        public string CallerMethodName { get; set; }
        public int CallerLineNumber { get; set; }
    }

    public enum LogType
    {
        Error,
        Warning,
        Info
    }
}
