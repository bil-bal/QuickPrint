using Autodesk.AutoCAD.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickPrint
{
    public partial class QuickPrintUI : Form
    {
        public Document doc { get; set; } = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
        public TextBox _colorBox { get; set; }
        public Button _quickViewButton { get; set; }
        public Button _printButton { get; set; }
        public QuickPrintUI()
        {
            InitializeComponent();
            this.TopMost = true;
            _colorBox = colorBox;
            _quickViewButton = quickViewButton;
            _printButton = printButton;
            colorBox.BackColor = Color.White;
            colorBox.ReadOnly = true;
            colorBox.Cursor = Cursors.Arrow;
            colorBox.GotFocus += colorBox_Enter;
        }

        private void quickViewButton_Click(object sender, EventArgs e)
        {            
            doc.SendStringToExecute("QuickView\n", true, false, false);
        }

        private void QuickPrintUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            doc.SendStringToExecute("SetColor\n", true, false, false);
        }

        private void colorBox_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            {
                colorBox.BackColor = colorDialog1.Color;
            }
        }

        private void colorBox_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).Parent.Focus();
        }

        private void linearButton_Click(object sender, EventArgs e)
        {
            doc.SendStringToExecute("AnnoDimLinear\n", true, false, false);
        }

        private void alignedButton_Click(object sender, EventArgs e)
        {
            doc.SendStringToExecute("AnnoDimAligned\n", true, false, false);
        }

        private void angularButton_Click(object sender, EventArgs e)
        {
            doc.SendStringToExecute("AnnoDimAngular\n", true, false, false);
        }

        private void radiusButton_Click(object sender, EventArgs e)
        {
            doc.SendStringToExecute("AnnoDimRadius\n", true, false, false);
        }

        private void diameterButton_Click(object sender, EventArgs e)
        {
            doc.SendStringToExecute("AnnoDimDiameter\n", true, false, false);
        }

        private void arcLengthButton_Click(object sender, EventArgs e)
        {
            doc.SendStringToExecute("AnnoDimArc\n", true, false, false);
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            doc.SendStringToExecute("PrintToPdf\n", true, false, false);
        }
    }
}
