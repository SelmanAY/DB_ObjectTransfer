namespace DB_ObjectTransfer
{
    partial class LogWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fastDataListView1 = new BrightIdeasSoftware.FastDataListView();
            ((System.ComponentModel.ISupportInitialize)(this.fastDataListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // fastDataListView1
            // 
            this.fastDataListView1.CellEditUseWholeCell = false;
            this.fastDataListView1.DataSource = null;
            this.fastDataListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fastDataListView1.Location = new System.Drawing.Point(0, 0);
            this.fastDataListView1.Name = "fastDataListView1";
            this.fastDataListView1.ShowGroups = false;
            this.fastDataListView1.Size = new System.Drawing.Size(284, 261);
            this.fastDataListView1.TabIndex = 0;
            this.fastDataListView1.UseCompatibleStateImageBehavior = false;
            this.fastDataListView1.View = System.Windows.Forms.View.Details;
            this.fastDataListView1.VirtualMode = true;
            // 
            // LogWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.Controls.Add(this.fastDataListView1);
            this.Name = "LogWindow";
            this.Text = "LogWindow";
            this.Load += new System.EventHandler(this.LogWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fastDataListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.FastDataListView fastDataListView1;
    }
}