using ModelManaging;
using Signum.Model;
using Signum.View;
using Signum.View.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signum.Presentation.EditorsHandling
{
    class FrameEditorPresenter
    {
        private DoubleBufferControl _editor;

        private Modello _modelloFrame;
        private Frame _frame;
        private int _latoCella;
        private Point _puntoAncoraggio;

        public Frame CurrentResultFrame => _frame;
        public Control Editor => _editor;

        public FrameEditorPresenter(Frame frame, Modello modello)
        {
            Debug.Assert(null != modello);
            _editor = new DoubleBufferControl();
            _editor.Dock = DockStyle.Fill;
            _modelloFrame = modello;
            _frame = frame;
            AttachHandlers();
        }
        public FrameEditorPresenter(Modello modello) : this(new Frame(modello.Size), modello)
        {
        }

        private void AttachHandlers()
        {
            _editor.Paint += ShowEditorGrid;
            _editor.SizeChanged += OnSizeChanged;
            _editor.MouseDown += OnMouseAction;
            _editor.MouseDrag += OnMouseAction;
        }

        #region EventHandlers
        private void OnSizeChanged(object sender, EventArgs args)
        {
            _latoCella = Math.Min((_editor.Width - 20) / _modelloFrame.Size.Width, (_editor.Height - 20) / _modelloFrame.Size.Height);
            _puntoAncoraggio = new Point(_editor.Width / 2 - _modelloFrame.Size.Width * _latoCella / 2, _editor.Height / 2 - _modelloFrame.Size.Height * _latoCella / 2);
        }
        private void OnMouseAction(object sender, MouseEventArgs args)
        { 
            Point mouseLocation = args.Location;
            Control editor = (Control)sender;
            mouseLocation.Offset(-_puntoAncoraggio.X, -_puntoAncoraggio.Y);
            int x = mouseLocation.X / _latoCella, y = mouseLocation.Y / _latoCella;
            if (_modelloFrame[x, y])
            {
                _frame[x, y] = args.Button == MouseButtons.Left;
                editor.SuspendLayout();
                editor.Refresh();
                editor.ResumeLayout();
            }
        }
        private void ShowEditorGrid(object sender, PaintEventArgs args)
        {
            Graphics g = args.Graphics;
            for (int i = 0; i < _frame.Size.Width; i++)
            {
                for (int k = 0; k < _frame.Size.Height; k++)
                {
                    Rectangle r = new Rectangle(_puntoAncoraggio.X + _latoCella * i, _puntoAncoraggio.Y + _latoCella * k, _latoCella, _latoCella);
                    if (_frame[i, k])
                    {
                        g.FillRectangle(Brushes.DarkGreen, r);
                    }
                    else if (_modelloFrame[i, k])
                    {
                        g.FillRectangle(Brushes.LightGray, r);
                    }
                    if (_modelloFrame[i, k])
                    {
                        g.DrawRectangle(Pens.Black, r);
                    }
                }
            }
        }
        #endregion
    }
}
