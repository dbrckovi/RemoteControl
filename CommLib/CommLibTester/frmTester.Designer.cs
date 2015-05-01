namespace CommLibTester
{
  partial class frmTester
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
      this.label1 = new System.Windows.Forms.Label();
      this.lblListenPort = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.pnlConnections = new System.Windows.Forms.FlowLayoutPanel();
      this.txtLog = new System.Windows.Forms.RichTextBox();
      this.mnuMain = new System.Windows.Forms.MenuStrip();
      this.mnuConnection = new System.Windows.Forms.ToolStripMenuItem();
      this.mnuNewLocalConnection = new System.Windows.Forms.ToolStripMenuItem();
      this.groupBox1.SuspendLayout();
      this.mnuMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(8, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(59, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Listen port:";
      // 
      // lblListenPort
      // 
      this.lblListenPort.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblListenPort.Location = new System.Drawing.Point(80, 16);
      this.lblListenPort.Name = "lblListenPort";
      this.lblListenPort.Size = new System.Drawing.Size(80, 16);
      this.lblListenPort.TabIndex = 1;
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.lblListenPort);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox1.Location = new System.Drawing.Point(0, 24);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(820, 40);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      // 
      // pnlConnections
      // 
      this.pnlConnections.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlConnections.Location = new System.Drawing.Point(0, 64);
      this.pnlConnections.Name = "pnlConnections";
      this.pnlConnections.Size = new System.Drawing.Size(820, 344);
      this.pnlConnections.TabIndex = 3;
      // 
      // txtLog
      // 
      this.txtLog.BackColor = System.Drawing.SystemColors.Window;
      this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtLog.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.txtLog.Location = new System.Drawing.Point(0, 408);
      this.txtLog.Name = "txtLog";
      this.txtLog.ReadOnly = true;
      this.txtLog.Size = new System.Drawing.Size(820, 81);
      this.txtLog.TabIndex = 4;
      this.txtLog.Text = "";
      // 
      // mnuMain
      // 
      this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConnection});
      this.mnuMain.Location = new System.Drawing.Point(0, 0);
      this.mnuMain.Name = "mnuMain";
      this.mnuMain.Size = new System.Drawing.Size(820, 24);
      this.mnuMain.TabIndex = 5;
      this.mnuMain.Text = "menuStrip1";
      // 
      // mnuConnection
      // 
      this.mnuConnection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewLocalConnection});
      this.mnuConnection.Name = "mnuConnection";
      this.mnuConnection.Size = new System.Drawing.Size(81, 20);
      this.mnuConnection.Text = "Connection";
      // 
      // mnuNewLocalConnection
      // 
      this.mnuNewLocalConnection.Name = "mnuNewLocalConnection";
      this.mnuNewLocalConnection.Size = new System.Drawing.Size(152, 22);
      this.mnuNewLocalConnection.Text = "New local";
      this.mnuNewLocalConnection.Click += new System.EventHandler(this.mnuNewLocalConnection_Click);
      // 
      // frmTester
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(820, 489);
      this.Controls.Add(this.pnlConnections);
      this.Controls.Add(this.txtLog);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.mnuMain);
      this.MainMenuStrip = this.mnuMain;
      this.Name = "frmTester";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.frmTester_Load);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTester_FormClosed);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.mnuMain.ResumeLayout(false);
      this.mnuMain.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblListenPort;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.FlowLayoutPanel pnlConnections;
    private System.Windows.Forms.RichTextBox txtLog;
    private System.Windows.Forms.MenuStrip mnuMain;
    private System.Windows.Forms.ToolStripMenuItem mnuConnection;
    private System.Windows.Forms.ToolStripMenuItem mnuNewLocalConnection;
  }
}

