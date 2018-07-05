using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace Story_Crafter {
    public partial class DebugLog: Form {
        public DebugLog() {
            InitializeComponent();
        }
        public void Log(params object[] msgParts) {
            string msg = "";
            try {
                foreach(object part in msgParts) {
                    msg += part.ToString();
                }
            }
            catch(Exception e) {
                msg = e.ToString();
            }
            this.listView1.Items.Insert(0, DateTime.Now.ToString("hh:mm:ss")).SubItems.Add(msg);
        }
    }
}
