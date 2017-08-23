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

        private void OnModelChanged(object sender, EventArgs args)
        {
            _modelLabel.Text = Documento.getInstance().ModelloRiferimento.ToString();
        }

        private void _mainContainer_Load(object sender, EventArgs args)
        {

        }

    }
}
