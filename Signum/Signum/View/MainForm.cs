using Signum.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signum.View
{
    public partial class MainForm : Form
    {

        public MainContainer MainContainer => _mainContainer;

        public MainForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Documento.getInstance().ModelChanged += OnModelChanged;
            OnModelChanged(this, EventArgs.Empty);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void OnModelChanged(object sender, EventArgs args)
        {
            _modelLabel.Text = Documento.getInstance().ModelloRiferimento.ToString();
        }
    }
}
