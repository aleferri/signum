using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace ModelManaging
{
    internal partial class ModelControl : UserControl
    {
        public ComboBox Combo => _comboBox;

        public TableLayoutPanel TablePanel => _tablePanel;
        public ModelDescriptor SelectedModel => Combo.SelectedValue as ModelDescriptor;
        public Panel PreviewPanel => _previewPanel;

        public ModelControl()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            _previewPanel, new object[] { true });
        }
    }
}
