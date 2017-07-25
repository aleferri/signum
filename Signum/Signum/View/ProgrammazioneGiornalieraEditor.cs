using Signum.View.Utils;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Signum.View
{
    public partial class ProgrammazioneGiornalieraEditor : UserControl
    {
        private Label[] _labels;
        

        public Label[] Labels => _labels;
        public ToolTip ToolTip => _toolTip;
        public Panel EditorContainer => _editorContainer;
        public TextBox NomeField => _nomeField;
        public TimePicker StartPicker => _startPicker;
        public TimePicker EndPicker => _endPicker;
        public ContextMenuStrip LabelMenuStrip => _labelMenuStrip;
        public ToolStripMenuItem EliminaSequenzaOption => _eliminaSequenzaToolStripMenuItem;
        public ToolStripMenuItem RinominaSequenzaOption => _rinominaSequenzaToolStripMenuItem;
        public ToolStripMenuItem NuovaSequenzaOption => _nuovaSequenzaToolStripMenuItem;
        public ToolStripMenuItem AggiungiSequenzaOption => _aggiungiSequenzaToolStripMenuItem;

        public ProgrammazioneGiornalieraEditor()
        {
            InitializeComponent();
            _labels = new Label[Signum.Model.ProgrammazioneGiornaliera.QUARTERS_IN_DAY];
            FillLabels();
            AddLabels();
            OnResize(this, EventArgs.Empty);
            _sequenzaFlowTop.SizeChanged += OnResize;
        }

        private void FillLabels()
        {
            for(int i = 0; i < _labels.Length; i++)
            {
                _labels[i] = new Label()
                {
                    Text = "-",
                    AutoSize = false,
                    BorderStyle = BorderStyle.FixedSingle,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                    Margin = Padding.Empty,
                };
                _toolTip.SetToolTip(_labels[i], "Slot vuoto");
            }
        }
        private void AddLabels()
        {
            FlowLayoutPanel[] panes = { _sequenzaFlowTop, _sequenzaFlowBottom };

            _sequenzaFlowTop.Controls.Clear();
            _sequenzaFlowTop.Controls.Add(_midnightLabel);
            _sequenzaFlowBottom.Controls.Clear();
            _sequenzaFlowBottom.Controls.Add(_middayLabel2);

            for (int i = 0; i < _labels.Length; i++)
            {
                panes[i / 48].Controls.Add(_labels[i]);
            }
            _sequenzaFlowTop.Controls.Add(_middayLabel);
            _sequenzaFlowBottom.Controls.Add(_midnightLabel2);
        }

        private void OnResize(object sender, EventArgs args)
        {
            _sequenzaFlowBottom.SuspendLayout();
            _sequenzaFlowTop.SuspendLayout();
            for (int i = 0; i < _labels.Length; i++)
            {
                _labels[i].Size = new System.Drawing.Size((Width - 70) / _labels.Length * 2, _sequenzaFlowTop.Height);
            }
            _sequenzaFlowBottom.ResumeLayout();
            _sequenzaFlowTop.ResumeLayout();
        }
    }
}
