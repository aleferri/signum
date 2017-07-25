using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signum.View.Utils
{
    public partial class TimePicker : UserControl
    {
        public event EventHandler ValueChanged;

        private DateTime _initValue;
        private DateTime _currentValue;

        public DateTime InitValue
        {
            get => _initValue;
            set
            {
                _dateTimePicker.ValueChanged -= OnValueChange;

                _dateTimePicker.Value = value;
                _currentValue = value;
                _initValue = value;

                _dateTimePicker.ValueChanged += OnValueChange;
            }
        }
        public DateTime Value => _currentValue;
        public int MinuteInterval { get; set; } = 1;
        public bool CanGoDown { get; set; } = true;
        public bool CanGoUp { get; set; } = true;

        public TimePicker()
        {
            InitializeComponent();
            InitValue = new DateTime(1970, 1, 1, 0, 0, 0);
        }

        public void OnValueChange(object sender, EventArgs args)
        {
            _dateTimePicker.ValueChanged -= OnValueChange;

            DateTime pickerValue = _dateTimePicker.Value;
            int minuteOffset;
            Console.WriteLine(pickerValue.Minute % MinuteInterval);
            if (pickerValue.Minute % MinuteInterval == MinuteInterval - 1 && CanGoDown) minuteOffset = -1;
            else if(pickerValue.Minute % MinuteInterval == 1 && CanGoUp) minuteOffset = 1;
            else minuteOffset = 0;
            _dateTimePicker.Value = _currentValue.AddMinutes(MinuteInterval * minuteOffset);
            _currentValue = _dateTimePicker.Value;

            _dateTimePicker.ValueChanged += OnValueChange;

            if(minuteOffset != 0) ValueChanged?.Invoke(sender, args);
        }
    }
}
