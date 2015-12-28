using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CivilFac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void utileriasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void impuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmImpuestos Impuestos = new FrmImpuestos();
            //Impuestos.MdiParent = this;
            Impuestos.WindowState = FormWindowState.Maximized;
            Impuestos.Show();
        }
    }
}
