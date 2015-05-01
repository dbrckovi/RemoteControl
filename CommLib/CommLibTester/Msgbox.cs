using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommLibTester
{
  public static class Msgbox
  {
    public static DialogResult Show(Exception ex)
    {
      return MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static DialogResult Show(string text)
    {
      return Show(text, "Information");
    }

    public static DialogResult Show(string text, string title)
    {
      return MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static DialogResult Show(string text, string title, MessageBoxButtons buttons, MessageBoxIcon icon)
    {
      return MessageBox.Show(text, title, buttons, icon);
    }
  }
}
