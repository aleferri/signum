using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelManaging
{
    internal partial class ModelDialog : Form
    {
        public Button PreviewButton => _previewButton;
        public Button OkButton => _okButton;
        public ComboBox Combo => _modelControl.Combo;
        public Panel PreviewPanel => _modelControl.PreviewPanel;
        public ModelControl Control => _modelControl;
        public TableLayoutPanel TablePanel => _modelControl.TablePanel;
        public ModelDescriptor SelectedModel => _modelControl.SelectedModel;
        public ModelDialog()
        {
            InitializeComponent();
        }
    }
}
