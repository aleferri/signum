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
    public partial class DoubleBufferControl : UserControl
    {
        private bool _isDragging;

        public event MouseEventHandler MouseDrag;

        public DoubleBufferControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            _isDragging = false;
        }

        private void OnMouseDown(object sender, MouseEventArgs args)
        {
            _isDragging = true;
        }
        public void OnMouseMoved(object sender, MouseEventArgs args)
        {
            if (_isDragging) MouseDrag(sender, args);
        }
        private void OnMouseUp(object sender, MouseEventArgs args)
        {
            _isDragging = false;
        }
    }
}
