using System;
using System.Windows.Forms;

namespace Signum.View
{
    public partial class SequenzaEditor : UserControl
    {

        private Control _editor;

        public ToolStripMenuItem AggiungiOption => _aggiungiToolStripMenuItem;
        public ToolStripMenuItem DaLibreriaOption => _daLibreriaToolStripMenuItem;
        public ListBox Lista => _elementList;
        public NumericUpDown DurataNumeric => _durataUpDown;
        public TextBox NomeField => _nomeField;
        public ToolStripMenuItem EliminaOption => _eliminaToolStripMenuItem;
        public ToolStripMenuItem MoveUpOption => _spostaSuToolStripMenuItem;
        public ToolStripMenuItem MoveDownOption => _spostaGiuToolStripMenuItem;

        public SequenzaEditor()
        {
            InitializeComponent();
            _durataUpDown.Maximum = Int32.MaxValue;
        }

        public void SetEditor(Control editor)
        {
           if(null != _editor) _splitContainer.Panel2.Controls.Remove(_editor);
            _splitContainer.Panel2.Controls.Add(editor);
            _editor = editor;
            editor.Dock = DockStyle.Fill;
            editor.BringToFront();
        }
    }
}
