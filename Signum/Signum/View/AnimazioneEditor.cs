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
    public partial class AnimazioneEditor : UserControl
    {
        public TabPage TabAggiungi => _tabNewPage;
        public TabControl Pannello => _tabControl;
        public NumericUpDown FramerateNumeric => _framerateNumeric;
        public ContextMenuStrip TabContextMenu => _tabContextMenu;

        public AnimazioneEditor()
        {
            InitializeComponent();
            FramerateNumeric.Maximum = UInt32.MaxValue;
        }
    }
}
