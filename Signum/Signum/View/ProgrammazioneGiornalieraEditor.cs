using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Signum.View
{
    public partial class ProgrammazioneGiornalieraEditor : UserControl
    {
        private Label[] _labels;
        private DateTime _currentStart, _currentEnd;
        private bool _alreadyChangingStart, _alreadyChangingEnd;

        public Label[] Labels => _labels;
        public ToolTip ToolTip => _toolTip;
        public Panel EditorContainer => _editorContainer;
        public TextBox NomeField => _nomeField;
        public DateTimePicker StartPicker => _startPicker;
        public DateTimePicker EndPicker => _endPicker;

        public DateTime Start
        {
            get => _currentStart;
            set
            {
                _currentStart = value;
                _alreadyChangingStart = true;
                _startPicker.Value = value;
                _alreadyChangingStart = false;
            }
        }
        public DateTime End
        {
            get => _currentEnd;
            set
            {
                _currentEnd = value;
                _alreadyChangingEnd = true;
                _endPicker.Value = value;
                _alreadyChangingEnd = false;
            }


        }

        public ProgrammazioneGiornalieraEditor()
        {
            InitializeComponent();
            _labels = new Label[Signum.Model.ProgrammazioneGiornaliera.QUARTERS_IN_DAY];
            _alreadyChangingStart = false;
            _alreadyChangingEnd = false;
            FillLabels();
            AddLabels();
            OnResize(this, EventArgs.Empty);
            _sequenzaFlowTop.SizeChanged += OnResize;
            _startPicker.ValueChanged += OnTimePickerValueChanged;
            _endPicker.ValueChanged += OnTimePickerValueChanged;
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
        private void ChangePicker(DateTimePicker picker, DateTime current)
        {
            bool adder = picker.Value.Hour == current.AddHours(1).Hour;
            int offset = adder ? 1 : -1;
            picker.Value = current.AddMinutes(15 * offset);
        }

        private void OnTimePickerValueChanged(object sender, EventArgs e)
        {
            DateTimePicker picker = (DateTimePicker)sender;
            DateTime current = picker == _startPicker ? _currentStart : _currentEnd;
            
            if(picker == _startPicker)
            {
                if (_alreadyChangingStart) return;
                _alreadyChangingStart = true;
                ChangePicker(picker, current);
                _currentStart = picker.Value;
                _alreadyChangingStart = false;
            }
            else
            {
                if (_alreadyChangingEnd) return;
                _alreadyChangingEnd = true;
                ChangePicker(picker, current);
                _currentEnd = picker.Value;
                _alreadyChangingEnd = false;
            } 
        }
    }
}
