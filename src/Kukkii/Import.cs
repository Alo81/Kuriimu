﻿using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Kukkii.Properties;

namespace Kukkii
{
    public partial class Import : Form
    {
        private string _filename = string.Empty;

        public Import(string filename)
        {
            InitializeComponent();

            _filename = filename;
        }

        private void Import_Load(object sender, EventArgs e)
        {
            Icon = Resources.kukkii;

            if (File.Exists(_filename))
            {
                var bmp = Image.FromFile(_filename);
                imbPreview.Image = bmp;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }
    }
}