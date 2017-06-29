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
        private Control _editor;

        private Modello _modelloFrame;
        private Frame _frame;
        private int _latoCella;
        private Point _puntoAncoraggio;
        private bool _pressedMouse;

        public Frame CurrentResultFrame => _frame;
        public Control Editor => _editor;

        public FrameEditorPresenter(Frame frame, Modello modello)
        {
            Debug.Assert(null != modello);
            _editor = new DoubleBufferControl();
            _editor.Dock = DockStyle.Fill;
            _modelloFrame = modello;
            _frame = frame;
            _pressedMouse = false;
            AttachHandlers();
        }
        public FrameEditorPresenter(Modello modello) : this(new Frame(modello.Size), modello)
        {
        }

        private void AttachHandlers()
        {
            _editor.Paint += ShowEditorGrid;
            _editor.SizeChanged += OnSizeChanged;
            _editor.MouseDown += OnMouseDown;
            _editor.MouseMove += OnMouseMove;
            _editor.MouseUp += OnMouseUp;
        }

        private void ResolveMouseAction(Point mouseLocation, Control editor, MouseButtons button)
        {
            mouseLocation.Offset(-_puntoAncoraggio.X, -_puntoAncoraggio.Y);
            int x = mouseLocation.X / _latoCella, y = mouseLocation.Y / _latoCella;
            if (_modelloFrame[x, y])
            {
                _frame[x, y] = button == MouseButtons.Left;
            }
            editor.SuspendLayout();
            editor.Refresh();
            editor.ResumeLayout();
        }

        #region EventHandlers
        public void OnSizeChanged(object sender, EventArgs args)
        {
            _latoCella = Math.Min((_editor.Width - 20) / _modelloFrame.Size.Width, (_editor.Height - 20) / _modelloFrame.Size.Height);
            _puntoAncoraggio = new Point(_editor.Width / 2 - _modelloFrame.Size.Width * _latoCella / 2, _editor.Height / 2 - _modelloFrame.Size.Height * _latoCella / 2);
        }
        public void OnMouseDown(object sender, MouseEventArgs args)
        {
            _pressedMouse = true;
            ResolveMouseAction(args.Location, (Control)sender, args.Button);
            
        }
        public void OnMouseMove(object sender, MouseEventArgs args)
        {
            if (!_pressedMouse) return;
            ResolveMouseAction(args.Location, (Control)sender, args.Button);

        }
        public void OnMouseUp(object sender, MouseEventArgs args)
        {
            _pressedMouse = false;
        }
        public void ShowEditorGrid(object sender, PaintEventArgs args)
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
