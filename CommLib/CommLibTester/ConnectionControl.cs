using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using CommLib;

namespace CommLibTester
{
  public partial class ConnectionControl : UserControl
  {
    private NetConnection _connection = null;

    public NetConnection Connection
    {
      get { return _connection; } 
    }

    #region Constructor
    public ConnectionControl()
    {
      InitializeComponent();
    }

    public ConnectionControl(NetConnection connection) : this()
    {
      _connection = connection;
    }
    #endregion Constructor

    private void Send()
    {
      if (_connection == null || txtSendBox.Text.Length == 0) return;
      UnicodeEncoding enc = new UnicodeEncoding();
      byte[] data = enc.GetBytes(txtSendBox.Text);
      txtHistory.AppendText("  " + txtSendBox.Text + "\r\n", Color.Gray);
      txtSendBox.Text = "";
      _connection.Send(data);
    }

    public void DataReceived(byte[] data)
    {
      UnicodeEncoding enc = new UnicodeEncoding();
      string str = enc.GetString(data);
      txtHistory.AppendText(str + "\r\n", Color.Black);
    }

    private void textBox1_KeyUp(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return) Send();
    }

    private void btnSend_Click(object sender, EventArgs e)
    {
      Send();
    }

    private void ConnectionControl_Load(object sender, EventArgs e)
    {
      if (_connection != null)
      {
        IPEndPoint localEP = (IPEndPoint)_connection.LocalEndPoint;
        IPEndPoint remoteEP = (IPEndPoint)_connection.RemoteEndPoint;

        lblLocalAddress.Text = localEP.Address.ToString();
        lblLocalPort.Text = localEP.Port.ToString();
        lblRemoteAddress.Text = remoteEP.Address.ToString();
        lblRemotePort.Text = remoteEP.Port.ToString();
      }
    }
  }
}
