﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LatihanLKS
{
    public partial class Form_Invoice : Form
    {
        public Form_Invoice()
        {
            InitializeComponent();
        }

        private void Form_Invoice_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
