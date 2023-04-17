using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTMLRenderer
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisible(true)]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser1.AllowWebBrowserDrop = false;
            webBrowser1.IsWebBrowserContextMenuEnabled = false;
            webBrowser1.WebBrowserShortcutsEnabled = false;
            webBrowser1.ObjectForScripting = this;
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog_Import = new OpenFileDialog();

            openFileDialog_Import.Filter = "CSV files (*.csv)|*.csv";

            if (openFileDialog_Import.ShowDialog() == DialogResult.OK)
            {
                File.Copy(openFileDialog_Import.FileName, Path.Combine(Directory.GetCurrentDirectory(), "local", "File.csv"),true);
            }
            string applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            string myFile = Path.Combine(applicationDirectory, "Test.html");
            webBrowser1.ScriptErrorsSuppressed = true;
            webBrowser1.Url = new Uri("file:///" + myFile);
        //    webBrowser1.Navigate(webBrowser1.Url);
        }
    }
}
