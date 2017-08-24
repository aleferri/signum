using System.Windows.Forms;

namespace Signum.View
{
    public partial class MainContainer : UserControl
    {
        public TreeView LibreriaView => _libreriaTreeView;
        public Panel LeftPanel => _outerSplitContainer.Panel1;
        public Panel RightPanel => _outerSplitContainer.Panel2;
        public ToolStripButton BackButton => _leftArrowButton;
        public ToolStripButton ForwardButton => _rightArrowButton;
        public ToolStripMenuItem CambiaModelloButton => _cambiaModelloDiRiferimentoToolStripMenuItem;
        public ToolStripMenuItem MenuModifica => _modificaToolStripMenuItem;
        public ToolStripMenuItem NuovoMenu => _nuovoToolStripMenuItem;
        public ToolStripItem[] SaveItems => new ToolStripItem[] { _salvaToolStripMenuItem, _salvaTooltipButton };
        public ToolStripItem Elimina => _eliminaToolStripMenuItem;
        public ToolStripItem NuovoProgetto => _nuovoProgettoToolStripMenuItem;
        public ToolStripItem ApriProgetto => _apriProgettoToolStripMenuItem;

        public MainContainer()
        {
            InitializeComponent();
        }
    }
}
