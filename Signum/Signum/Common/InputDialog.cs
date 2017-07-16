using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signum.Common
{
    internal partial class InputDialog : Form
    {
        public TextBox InputField => _inputField;
        public Button OK => _OKButton;
        public Button Cancel => _cancelButton;
        public Label MessageLabel => _messageLabel;

        public InputDialog()
        {
            InitializeComponent();
            _inputField.Focus();
        }
    }
}
