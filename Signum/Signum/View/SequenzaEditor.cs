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
    public partial class SequenzaEditor : UserControl
    {

        private Control _editor;

        public ToolStripMenuItem AggiungiMenu => _aggiungiToolStripMenuItem;
        public ListBox Lista => _elementList;
        public NumericUpDown DurataNumeric => _durataUpDown;
        public TextBox NomeField => _nomeField;
        public TextBox SequenzaNomeField => _nomeSequenza;

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
