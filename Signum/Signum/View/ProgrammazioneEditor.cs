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
    public partial class ProgrammazioneEditor : UserControl
    {

        private ComboBox[] _days;

        public ComboBox[] Days => _days;

        public ToolStripMenuItem Nuovo => _nuovaProgrammazioneGiornaliera;

        public Control SottoEditorControl => _sottoEditorPanel;

        public ProgrammazioneEditor()
        {
            InitializeComponent();
            _days = new ComboBox[7];
            _days[0] = _lunCombo;
            _days[1] = _marCombo;
            _days[2] = _merCombo;
            _days[3] = _gioCombo;
            _days[4] = _venCombo;
            _days[5] = _sabCombo;
            _days[6] = _domCombo;
        }

    }
}
