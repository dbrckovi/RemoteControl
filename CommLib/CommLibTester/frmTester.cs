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
    TcpManager _tcpManager = null;

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
        _tcpManager = new TcpManager(LISTEN_PORT);
        _tcpManager.ExceptionOccured += new Delegates.ExceptionDelegate(_tcpManager_ExceptionOccured);
        _tcpManager.TcpClientConnected += new Delegates.TcpClientDelegate(_tcpManager_TcpClientConnected);
        _tcpManager.TcpDataReceived += new Delegates.TcpDataDelegate(_tcpManager_TcpDataReceived);
        lblListenPort.Text = _tcpManager.ListeningPort.ToString();
        AddLog("Started listening");
      }
      catch (Exception ex)
      {
        Msgbox.Show(ex);
      }
    }
    void _tcpManager_TcpClientConnected(System.Net.Sockets.TcpClient client)
    {
      if (this.InvokeRequired)
      {
        this.BeginInvoke(new MethodInvoker(delegate { _tcpManager_TcpClientConnected(client); }));
        return;
      }
      
      ConnectionControl ctl = new ConnectionControl(client);
      pnlConnections.Controls.Add(ctl);
      AddLog(string.Format("Tcp connection established: {0} --> {1}", client.Client.LocalEndPoint.ToString(), client.Client.RemoteEndPoint.ToString()));
    }

    void _tcpManager_TcpDataReceived(System.Net.Sockets.TcpClient client, byte[] data)
    {
      if (this.InvokeRequired)
      {
        this.BeginInvoke(new MethodInvoker(delegate { _tcpManager_TcpDataReceived(client, data); }));
        return;
      }

      foreach (ConnectionControl ctl in pnlConnections.Controls)
      {
        if (ctl.Client == client) ctl.DataReceived(data);
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
      if (_tcpManager != null) _tcpManager.Close();
    }

    private void mnuNewLocalConnection_Click(object sender, EventArgs e)
    {
      try
      {
        _tcpManager.Connect(IPAddress.Loopback, LISTEN_PORT);
      }
      catch (Exception ex)
      {
        Msgbox.Show(ex);
      }
    }
  }
}
