using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Button
{
    public partial class SaveMap : Form
    {
        private string mFileName = "default";
        public string FileName
        {
            get{ return mFileName + ".xml"; }
            set { mFileName = value; }
        }

        private bool mDone = false;
        public bool Done
        {
            get { return mDone; }
        }

        public SaveMap()
        {
            IsAccessible = false;
            InitializeComponent();
            this._Sample.Text = "";
            _FileNameInput.Text = "";
        }

        private void _Save_Click(object sender, EventArgs e)
        {
            IsAccessible = false;
            mDone = true;
        }

        private void _FileNameInput_TextChanged(object sender, EventArgs e)
        {
            FileName = _FileNameInput.Text;
            this._Sample.Text = FileName;
        }

        public void On()
        {
            IsAccessible = true;
            Show();
        }

        public void Off()
        {
            IsAccessible = false;
            Hide();
            FileName = "";
            _FileNameInput.Text = "";
            mDone = false;
        }
    }
}
