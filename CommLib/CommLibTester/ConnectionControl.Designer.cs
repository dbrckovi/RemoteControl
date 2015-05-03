namespace CommLibTester
{
  partial class ConnectionControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.txtHistory = new System.Windows.Forms.RichTextBox();
      this.panel2 = new System.Windows.Forms.Panel();
      this.lblLocalAddress = new System.Windows.Forms.Label();
      this.lblLocalPort = new System.Windows.Forms.Label();
      this.lblRemoteAddress = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lblRemotePort = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.txtSendBox = new System.Windows.Forms.TextBox();
      this.btnSend = new System.Windows.Forms.Button();
      this.panel3 = new System.Windows.Forms.Panel();
      this.linkLabel1 = new System.Windows.Forms.LinkLabel();
      this.groupBox1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.txtHistory);
      this.groupBox1.Controls.Add(this.panel2);
      this.groupBox1.Controls.Add(this.panel1);
      this.groupBox1.Controls.Add(this.panel3);
      this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.groupBox1.Location = new System.Drawing.Point(0, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(1, 0, 1, 3);
      this.groupBox1.Size = new System.Drawing.Size(185, 316);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      // 
      // txtHistory
      // 
      this.txtHistory.BackColor = System.Drawing.SystemColors.Window;
      this.txtHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.txtHistory.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtHistory.Location = new System.Drawing.Point(1, 45);
      this.txtHistory.Name = "txtHistory";
      this.txtHistory.ReadOnly = true;
      this.txtHistory.Size = new System.Drawing.Size(183, 227);
      this.txtHistory.TabIndex = 11;
      this.txtHistory.Text = "";
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.lblLocalAddress);
      this.panel2.Controls.Add(this.lblLocalPort);
      this.panel2.Controls.Add(this.lblRemoteAddress);
      this.panel2.Controls.Add(this.label2);
      this.panel2.Controls.Add(this.lblRemotePort);
      this.panel2.Controls.Add(this.label1);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel2.Location = new System.Drawing.Point(1, 13);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(183, 32);
      this.panel2.TabIndex = 10;
      // 
      // lblLocalAddress
      // 
      this.lblLocalAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblLocalAddress.Location = new System.Drawing.Point(47, 0);
      this.lblLocalAddress.Name = "lblLocalAddress";
      this.lblLocalAddress.Size = new System.Drawing.Size(96, 16);
      this.lblLocalAddress.TabIndex = 2;
      // 
      // lblLocalPort
      // 
      this.lblLocalPort.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblLocalPort.Location = new System.Drawing.Point(143, 0);
      this.lblLocalPort.Name = "lblLocalPort";
      this.lblLocalPort.Size = new System.Drawing.Size(40, 16);
      this.lblLocalPort.TabIndex = 3;
      // 
      // lblRemoteAddress
      // 
      this.lblRemoteAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblRemoteAddress.Location = new System.Drawing.Point(47, 16);
      this.lblRemoteAddress.Name = "lblRemoteAddress";
      this.lblRemoteAddress.Size = new System.Drawing.Size(96, 16);
      this.lblRemoteAddress.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(0, 16);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(44, 13);
      this.label2.TabIndex = 7;
      this.label2.Text = "Remote";
      // 
      // lblRemotePort
      // 
      this.lblRemotePort.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblRemotePort.Location = new System.Drawing.Point(143, 16);
      this.lblRemotePort.Name = "lblRemotePort";
      this.lblRemotePort.Size = new System.Drawing.Size(40, 16);
      this.lblRemotePort.TabIndex = 5;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(0, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(33, 13);
      this.label1.TabIndex = 6;
      this.label1.Text = "Local";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.txtSendBox);
      this.panel1.Controls.Add(this.btnSend);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel1.Location = new System.Drawing.Point(1, 272);
      this.panel1.Name = "panel1";
      this.panel1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
      this.panel1.Size = new System.Drawing.Size(183, 24);
      this.panel1.TabIndex = 9;
      // 
      // txtSendBox
      // 
      this.txtSendBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.txtSendBox.Location = new System.Drawing.Point(0, 2);
      this.txtSendBox.Name = "txtSendBox";
      this.txtSendBox.Size = new System.Drawing.Size(136, 20);
      this.txtSendBox.TabIndex = 1;
      this.txtSendBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
      // 
      // btnSend
      // 
      this.btnSend.Dock = System.Windows.Forms.DockStyle.Right;
      this.btnSend.Location = new System.Drawing.Point(136, 2);
      this.btnSend.Name = "btnSend";
      this.btnSend.Size = new System.Drawing.Size(47, 22);
      this.btnSend.TabIndex = 0;
      this.btnSend.Text = "Send";
      this.btnSend.UseVisualStyleBackColor = true;
      this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
      // 
      // panel3
      // 
      this.panel3.Controls.Add(this.linkLabel1);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel3.Location = new System.Drawing.Point(1, 296);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(183, 17);
      this.panel3.TabIndex = 12;
      // 
      // linkLabel1
      // 
      this.linkLabel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.linkLabel1.Location = new System.Drawing.Point(0, 0);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new System.Drawing.Size(61, 17);
      this.linkLabel1.TabIndex = 0;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Disconnect";
      // 
      // ConnectionControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.groupBox1);
      this.Name = "ConnectionControl";
      this.Size = new System.Drawing.Size(185, 316);
      this.Load += new System.EventHandler(this.ConnectionControl_Load);
      this.groupBox1.ResumeLayout(false);
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblRemotePort;
    private System.Windows.Forms.Label lblRemoteAddress;
    private System.Windows.Forms.Label lblLocalPort;
    private System.Windows.Forms.Label lblLocalAddress;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TextBox txtSendBox;
    private System.Windows.Forms.Button btnSend;
    private System.Windows.Forms.RichTextBox txtHistory;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.LinkLabel linkLabel1;
  }
}
