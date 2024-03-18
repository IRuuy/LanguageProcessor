using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Menu
{
    public partial class DiagnosticsAndNeutralizationOfErrors : Form
    {
        public DiagnosticsAndNeutralizationOfErrors()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://dispace.edu.nstu.ru/didesk/file/get/390826?ysclid=ltx3q422tg591602025");
        }
    }
}
