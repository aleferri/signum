using ModelManaging;
using Signum.Model;
using Signum.Presentation.EditorsHandling;
using Signum.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signum.Presentation
{
    [NameTagAttribute("Animazione", typeof(Animazione))]
    class AnimazioneEditorPresenter : ElementoEditorPresenter
    { 
        private readonly AnimazioneEditor _editor;
        private Animazione _animazione;
        private readonly Modello _modello;

        private int _draggedTabIndex;

        public AnimazioneEditorPresenter(Modello modello)
        {
            _editor = new AnimazioneEditor();
            _editor.Dock = DockStyle.Fill;
            _editor.Pannello.CreateControl();

            _draggedTabIndex = -1;

            InstallHandlers();
            SetEditor(_editor);
            _modello = modello;
            CaricaElemento(new PersisterMapper<Elemento>(new Animazione(10)));
            AddFrame();
        }

        private void InstallHandlers()
        {
            _editor.Pannello.Selected += OnTabChanged;
            _editor.Pannello.MouseDown += OnMouseDown;
            _editor.Pannello.MouseMove += OnMouseMove;
            _editor.Pannello.MouseUp += OnMouseUp;
            _editor.EliminaOption.Click += OnEliminaClick;
            _editor.MoveRightOption.Click += OnMoveRightClick;
            _editor.MoveLeftOption.Click += OnMoveLeftClick;
        }
        private TabPage CreateTab(int n)
        {
            Frame nuovo = new Frame(_modello.Size);
            _animazione.Frames.Add(nuovo);
            return CreateTab(n, nuovo);
        }
        private TabPage CreateTab(int n, Frame frame)
        {
            FrameEditorPresenter fp = new FrameEditorPresenter(frame, _modello);
            fp.Editor.Dock = DockStyle.Fill;
            TabPage nuovaTab = new TabPage()
            {
                Text = String.Format("Frame {0}", n),
                Tag = fp
            };
            nuovaTab.Controls.Add(fp.Editor);
            return nuovaTab;
        }
        private void AddFrame()
        {      
            TabPage nuovaTab = CreateTab(_editor.Pannello.TabCount);
            _editor.Pannello.TabPages.Insert(_editor.Pannello.TabCount - 1, nuovaTab);
            _editor.Pannello.SelectedTab = nuovaTab;
        }
        private void AddFrame(Frame frame)
        {
            TabPage nuovaTab = CreateTab(_editor.Pannello.TabPages.Count, frame);
            _editor.Pannello.TabPages.Insert(_editor.Pannello.TabPages.Count - 1, nuovaTab);
            _editor.Pannello.SelectedTab = nuovaTab;
        }
        private void NameTabs()
        {
            foreach (TabPage tab in _editor.Pannello.TabPages)
            {
                if (tab != _editor.TabAggiungi)
                {
                    tab.Text = String.Format("Frame {0}", _editor.Pannello.TabPages.IndexOf(tab) + 1);
                }
            }
        }
        private void Move(bool left, int tabIndex)
        {
            int offset = left ? -1 : 1;

            TabPage tab = _editor.Pannello.TabPages[tabIndex];
            _editor.Pannello.TabPages.Remove(tab);
            _editor.Pannello.TabPages.Insert(tabIndex + offset, tab);
            _editor.Pannello.SelectedTab = tab;

            Frame moving = _animazione.Frames[tabIndex];
            _animazione.Frames.Remove(moving);
            _animazione.Frames.Insert(tabIndex + offset, moving);
        }
        private bool IsMouseHoverSelected(Point point)
        {
            return _editor.Pannello.GetTabRect(_editor.Pannello.SelectedIndex).Contains(point);
        }
        private int GetTabIndexByPoint(Point point)
        {
            TabControl tabControl = _editor.Pannello;
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                TabPage page = tabControl.TabPages[i];
                if (tabControl.GetTabRect(i).Contains(point))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Dato il PersisterMapper di un Elemento, se esso è un'animazione verrà caricato nell'editor
        /// </summary>
        /// <param name="element"></param>
        public override void CaricaElemento(PersisterMapper<Elemento> element)
        {
            Animazione animazione = element.Element as Animazione;
            Mapper = element;
            _animazione = animazione ?? throw new ArgumentException("Elemento non compatibile con l'editor delle animazioni");
            _editor.Pannello.TabPages.Clear();
            _editor.Pannello.TabPages.Add(_editor.TabAggiungi);
            foreach(Frame f in _animazione.Frames)
            {
                AddFrame(f);
            }
            _editor.FramerateNumeric.Value = _animazione.FrameRate;
        }

        #region EventHandlers
        private void OnTabChanged(object sender, TabControlEventArgs args)
        {
            if (_editor.Pannello.SelectedTab == _editor.TabAggiungi)
            {
                AddFrame();
            }
            int sIndex = _editor.Pannello.SelectedIndex; 
            _editor.MoveRightOption.Enabled = sIndex < _editor.Pannello.TabCount - 2;
            _editor.MoveLeftOption.Enabled = sIndex > 0;
            
        }
        private void OnMouseDown(object sender, MouseEventArgs args)
        {
            if (IsMouseHoverSelected(new Point(args.X, args.Y)) && args.Button == MouseButtons.Left)
            {
                _draggedTabIndex = _editor.Pannello.SelectedIndex;
            }
        }
        private void OnMouseMove(object sender, MouseEventArgs args)
        {
            if (0 > _draggedTabIndex) return;
            int currentHoverIndex = GetTabIndexByPoint(new Point(args.X, args.Y));
            if (currentHoverIndex != _draggedTabIndex && currentHoverIndex >= 0 && currentHoverIndex != _editor.Pannello.TabCount - 1)
            {
                Move(_draggedTabIndex - currentHoverIndex > 0, _draggedTabIndex);
                _draggedTabIndex = currentHoverIndex;
            }
        }
        private void OnMouseUp(object sender, MouseEventArgs args)
        {
            if (_draggedTabIndex >= 0)
            {
                NameTabs();
            }
            _draggedTabIndex = -1;
            if (args.Button == MouseButtons.Right)
            {
                if (IsMouseHoverSelected(new Point(args.X, args.Y)))
                {
                    _editor.TabContextMenu.Show(_editor.Pannello, args.X, args.Y);
                }
            }
        }
        private void OnEliminaClick(object sender, EventArgs args)
        {
            int index = _editor.Pannello.SelectedIndex;
            _animazione.Frames.RemoveAt(index);
            _editor.Pannello.TabPages.RemoveAt(index);
            NameTabs();
        }
        private void OnMoveRightClick(object sender, EventArgs args)
        {
            Move(false, _editor.Pannello.SelectedIndex);
            NameTabs();
        }
        private void OnMoveLeftClick(object sender, EventArgs args)
        {
            Move(true, _editor.Pannello.SelectedIndex);
            NameTabs();
        }
        #endregion
    }
}
