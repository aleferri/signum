using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signum.View
{
    public partial class MainContainer : UserControl
    {

        public Panel LeftPanel => _outerSplitContainer.Panel1;
        public Panel RightPanel => _outerSplitContainer.Panel2;
        public ToolStripButton BackButton => _leftArrowButton;
        public ToolStripButton ForwardButton => _rightArrowButton;
        public ToolStripMenuItem CambiaModelloButton => _cambiaModelloDiRiferimentoToolStripMenuItem;
        public ToolStripMenuItem MenuModifica => _modificaToolStripMenuItem;
        public ToolStripMenuItem NuovoImmagine => _immagineFissaToolStripMenuItem;
        public ToolStripItem[] SaveItems => new ToolStripItem[] { _salvaToolStripMenuItem, _salvaTooltipButton };

        public MainContainer()
        {
            InitializeComponent();
        }
    }
}
