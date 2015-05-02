using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using CommLib;

namespace CommLibTester
{
  public partial class frmTester : Form
  {
    private int LISTEN_PORT = 56708;
    private Color GOOD_COLOR = Color.Black;
    private Color BAD_COLOR = Color.Red;
    ConnectionManager _connManager = null;

    public frmTester()
    {
      InitializeComponent();
    }

    private void AddLog(string text)
    {
      AddLog(text, true);
    }

    private void AddLog(string text, bool good)
    {
      txtLog.AppendText(text + "\r\n", good ? GOOD_COLOR : BAD_COLOR);
    }

    private void frmTester_Load(object sender, EventArgs e)
    {
      try
      {
        _connManager = new ConnectionManager(LISTEN_PORT);
        _connManager.ExceptionOccured += new Delegates.ExceptionDelegate(_tcpManager_ExceptionOccured);
        _connManager.ConnectionEstablished += new Delegates.NetConnectionDelegate(_connManager_ConnectionEstablished);
        _connManager.NetDataReceived += new Delegates.NetDataDelegate(_connManager_DataReceived);
        lblListenPort.Text = _connManager.ListeningPort.ToString();
        AddLog("Started listening");
      }
      catch (Exception ex)
      {
        Msgbox.Show(ex);
      }
    }

    void _connManager_ConnectionEstablished(NetConnection connection)
    {
      if (this.InvokeRequired)
      {
        this.BeginInvoke(new MethodInvoker(delegate { _connManager_ConnectionEstablished(connection); }));
        return;
      }

      ConnectionControl ctl = new ConnectionControl(connection);
      pnlConnections.Controls.Add(ctl);
      AddLog(string.Format("Tcp connection established: {0} --> {1}", connection.LocalEndPoint.ToString(), connection.RemoteEndPoint.ToString()));
    }

    void _connManager_DataReceived(NetConnection connection, byte[] data)
    {
      if (this.InvokeRequired)
      {
        this.BeginInvoke(new MethodInvoker(delegate { _connManager_DataReceived(connection, data); }));
        return;
      }

      foreach (ConnectionControl ctl in pnlConnections.Controls)
      {
        if (ctl.Connection == connection) ctl.DataReceived(data);
      }
    }

    void _tcpManager_ExceptionOccured(Exception ex)
    {
      if (this.InvokeRequired)
      {
        this.BeginInvoke(new MethodInvoker(delegate { _tcpManager_ExceptionOccured(ex); }));
        return;
      }
      AddLog(ex.Message, false);
    }

    private void frmTester_FormClosed(object sender, FormClosedEventArgs e)
    {
      if (_connManager != null) _connManager.Close();
    }

    private void mnuNewLocalConnection_Click(object sender, EventArgs e)
    {
      try
      {
        _connManager.TcpConnect(IPAddress.Loopback, LISTEN_PORT);
      }
      catch (Exception ex)
      {
        Msgbox.Show(ex);
      }
    }
  }
}
