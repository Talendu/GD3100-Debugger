using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GD3100Debugger
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            this.Deactivate += new EventHandler(Form1_Deactivate);
        }
        void Form1_Deactivate(object sender, EventArgs e)
        {
            this.Visible = false;
        }

    }
}
