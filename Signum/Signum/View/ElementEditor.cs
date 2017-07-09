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
    public partial class ElementEditor : UserControl
    {
        private Control _specificEditor;

        public TextBox InfoBox => _infoTextBox;
        public CheckBox DateHourCheckBox => _dateHourCheck;
        public Control SpecificEditor
        {
            get => _specificEditor;
            set
            {
                _tableLayoutPanel.Controls.Remove(SpecificEditor);
                _specificEditor = value;
                _specificEditor.Dock = DockStyle.Fill;
                _tableLayoutPanel.Controls.Add(SpecificEditor);
            }
        }

        public ElementEditor()
        {
            InitializeComponent();
        } 
    }
}
