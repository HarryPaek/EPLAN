namespace Eplan.EplAddin.ManagerApp
{
    partial class formMainWindow
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnLogging = new System.Windows.Forms.Button();
            this.btnDB = new System.Windows.Forms.Button();
            this.btnConfiguration = new System.Windows.Forms.Button();
            this.tboxLoggingArea = new System.Windows.Forms.TextBox();
            this.btnExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnExcel);
            this.splitContainer1.Panel1.Controls.Add(this.btnLogging);
            this.splitContainer1.Panel1.Controls.Add(this.btnDB);
            this.splitContainer1.Panel1.Controls.Add(this.btnConfiguration);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tboxLoggingArea);
            this.splitContainer1.Size = new System.Drawing.Size(784, 561);
            this.splitContainer1.SplitterDistance = 263;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnLogging
            // 
            this.btnLogging.Location = new System.Drawing.Point(48, 181);
            this.btnLogging.Name = "btnLogging";
            this.btnLogging.Size = new System.Drawing.Size(153, 37);
            this.btnLogging.TabIndex = 2;
            this.btnLogging.Text = "Logging Test";
            this.btnLogging.UseVisualStyleBackColor = true;
            this.btnLogging.Click += new System.EventHandler(this.btnLogging_Click);
            // 
            // btnDB
            // 
            this.btnDB.Location = new System.Drawing.Point(48, 109);
            this.btnDB.Name = "btnDB";
            this.btnDB.Size = new System.Drawing.Size(153, 37);
            this.btnDB.TabIndex = 1;
            this.btnDB.Text = "Database Test";
            this.btnDB.UseVisualStyleBackColor = true;
            this.btnDB.Click += new System.EventHandler(this.btnDB_Click);
            // 
            // btnConfiguration
            // 
            this.btnConfiguration.Location = new System.Drawing.Point(48, 39);
            this.btnConfiguration.Name = "btnConfiguration";
            this.btnConfiguration.Size = new System.Drawing.Size(153, 37);
            this.btnConfiguration.TabIndex = 0;
            this.btnConfiguration.Text = "Configuration Test";
            this.btnConfiguration.UseVisualStyleBackColor = true;
            this.btnConfiguration.Click += new System.EventHandler(this.btnConfiguration_Click);
            // 
            // tboxLoggingArea
            // 
            this.tboxLoggingArea.BackColor = System.Drawing.Color.Teal;
            this.tboxLoggingArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tboxLoggingArea.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tboxLoggingArea.Location = new System.Drawing.Point(0, 0);
            this.tboxLoggingArea.Multiline = true;
            this.tboxLoggingArea.Name = "tboxLoggingArea";
            this.tboxLoggingArea.Size = new System.Drawing.Size(784, 294);
            this.tboxLoggingArea.TabIndex = 0;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(238, 109);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(153, 37);
            this.btnExcel.TabIndex = 3;
            this.btnExcel.Text = "Excel Test";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // formMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.Name = "formMainWindow";
            this.Text = "EPLAN Manager";
            this.Load += new System.EventHandler(this.formMainWindow_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnLogging;
        private System.Windows.Forms.Button btnDB;
        private System.Windows.Forms.Button btnConfiguration;
        private System.Windows.Forms.TextBox tboxLoggingArea;
        private System.Windows.Forms.Button btnExcel;
    }
}

