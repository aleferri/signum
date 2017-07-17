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
        public override event EventHandler EditorChange;

        private readonly AnimazioneEditor _animationEditor;
        private Animazione _animazione;
        private readonly Modello _modello;

        private int _draggedTabIndex;

        public AnimazioneEditorPresenter(Modello modello)
        {
            _animationEditor = new AnimazioneEditor();
            _animationEditor.Dock = DockStyle.Fill;
            _animationEditor.Pannello.CreateControl();

            _draggedTabIndex = -1;

            InstallHandlers();
            SetEditor(_animationEditor);
            _modello = modello;
            CaricaElemento(new MementoWrapper<Elemento>(new Animazione(10)));
            AddFrame();
        }

        private void InstallHandlers()
        {
            _animationEditor.Pannello.Selected += OnTabChanged;
            _animationEditor.Pannello.MouseDown += OnMouseDown;
            _animationEditor.Pannello.MouseMove += OnMouseMove;
            _animationEditor.Pannello.MouseUp += OnMouseUp;
            _animationEditor.EliminaOption.Click += OnEliminaClick;
            _animationEditor.MoveRightOption.Click += OnMoveRightClick;
            _animationEditor.MoveLeftOption.Click += OnMoveLeftClick;
        }
        private TabPage CreateTab(int n)
        {
            Frame nuovo = new Frame(_modello.Size);
            _animazione.Frames.Add(nuovo);
            return CreateTab(n, nuovo);
        }
        private TabPage CreateTab(int n, Frame frame)
        {
            TabPage nuovaTab = new TabPage();
            nuovaTab.Text = String.Format("Frame {0}", n);
            FrameEditorPresenter fp = new FrameEditorPresenter(frame, _modello);
            fp.Editor.Dock = DockStyle.Fill;
            nuovaTab.Controls.Add(fp.Editor);
            nuovaTab.Tag = fp;
            fp.FrameChange += OnFrameChange;
            return nuovaTab;
        }
        private void AddFrame()
        {      
            TabPage nuovaTab = CreateTab(_animationEditor.Pannello.TabCount);
            _animationEditor.Pannello.TabPages.Insert(_animationEditor.Pannello.TabCount - 1, nuovaTab);
            _animationEditor.Pannello.SelectedTab = nuovaTab;
        }
        private void AddFrame(Frame frame)
        {
            TabPage nuovaTab = CreateTab(_animationEditor.Pannello.TabPages.Count, frame);
            _animationEditor.Pannello.TabPages.Insert(_animationEditor.Pannello.TabPages.Count - 1, nuovaTab);
            _animationEditor.Pannello.SelectedTab = nuovaTab;
        }
        private void NameTabs()
        {
            foreach (TabPage tab in _animationEditor.Pannello.TabPages)
            {
                if (tab != _animationEditor.TabAggiungi)
                {
                    tab.Text = String.Format("Frame {0}", _animationEditor.Pannello.TabPages.IndexOf(tab) + 1);
                }
            }
        }
        private void Move(bool left, int tabIndex)
        {
            int offset = left ? -1 : 1;

            TabPage tab = _animationEditor.Pannello.TabPages[tabIndex];
            _animationEditor.Pannello.TabPages.Remove(tab);
            _animationEditor.Pannello.TabPages.Insert(tabIndex + offset, tab);
            _animationEditor.Pannello.SelectedTab = tab;

            Frame moving = _animazione.Frames[tabIndex];
            _animazione.Frames.Remove(moving);
            _animazione.Frames.Insert(tabIndex + offset, moving);
        }
        private void CreateMemento()
        {
            Wrapper.AddStep(_animazione);
            CaricaElemento(Wrapper);
        }
        private bool IsMouseHoverSelected(Point point)
        {
            return _animationEditor.Pannello.GetTabRect(_animationEditor.Pannello.SelectedIndex).Contains(point);
        }
        private int GetTabIndexByPoint(Point point)
        {
            TabControl tabControl = _animationEditor.Pannello;
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                TabPage page = tabControl.TabPages[i];
                if (tabControl.GetTabRect(i).Contains(point))
                    return i;
            }
            return -1;
        }
        public override void CaricaElemento(MementoWrapper<Elemento> element)
        {
            Animazione animazione = element.Memento as Animazione;
            Wrapper = element;
            _animazione = animazione ?? throw new ArgumentException("Elemento non compatibile con l'editor delle animazioni");
            _animationEditor.Pannello.TabPages.Clear();
            _animationEditor.Pannello.TabPages.Add(_animationEditor.TabAggiungi);
            foreach(Frame f in _animazione.Frames)
            {
                AddFrame(f);
            }
            _animationEditor.FramerateNumeric.Value = _animazione.FrameRate;
            EditorChange?.Invoke(this, EventArgs.Empty);
        }

        #region EventHandlers
        private void OnTabChanged(object sender, TabControlEventArgs args)
        {
            if (_animationEditor.Pannello.SelectedTab == _animationEditor.TabAggiungi)
            {
                _animazione.Frames.Add(new Frame(_modello.Size));
                CreateMemento();
            }
            int sIndex = _animationEditor.Pannello.SelectedIndex; 
            _animationEditor.MoveRightOption.Enabled = sIndex < _animationEditor.Pannello.TabCount - 2;
            _animationEditor.MoveLeftOption.Enabled = sIndex > 0;
            
        }
        private void OnMouseDown(object sender, MouseEventArgs args)
        {
            if (IsMouseHoverSelected(new Point(args.X, args.Y)) && args.Button == MouseButtons.Left)
            {
                _draggedTabIndex = _animationEditor.Pannello.SelectedIndex;
            }
        }
        private void OnMouseMove(object sender, MouseEventArgs args)
        {
            if (0 > _draggedTabIndex) return;
            int currentHoverIndex = GetTabIndexByPoint(new Point(args.X, args.Y));
            if (currentHoverIndex != _draggedTabIndex && currentHoverIndex >= 0 && currentHoverIndex != _animationEditor.Pannello.TabCount - 1)
            {
                Move(_draggedTabIndex - currentHoverIndex > 0, _draggedTabIndex);
                _draggedTabIndex = currentHoverIndex;
            }
        }
        private void OnMouseUp(object sender, MouseEventArgs args)
        {
            if(_draggedTabIndex >= 0) NameTabs();
            _draggedTabIndex = -1;
            if (args.Button == MouseButtons.Right)
            {
                if (IsMouseHoverSelected(new Point(args.X, args.Y)))
                {
                    _animationEditor.TabContextMenu.Show(_animationEditor.Pannello, args.X, args.Y);
                }
            }
        }
        private void OnEliminaClick(object sender, EventArgs args)
        {
            _animazione.Frames.RemoveAt(_animationEditor.Pannello.SelectedIndex);
            _animationEditor.Pannello.TabPages.Remove(_animationEditor.Pannello.SelectedTab);
            CreateMemento();
            NameTabs();
        }
        public void OnMoveRightClick(object sender, EventArgs args)
        {
            Move(false, _animationEditor.Pannello.SelectedIndex);
            NameTabs();
        }
        public void OnMoveLeftClick(object sender, EventArgs args)
        {
            Move(true, _animationEditor.Pannello.SelectedIndex);
            NameTabs();
        }

        private void OnFrameChange(object sender, EventArgs args)
        {
            int index = _animationEditor.Pannello.SelectedIndex;
            CreateMemento();
            _animationEditor.Pannello.SelectedIndex = index;
        }
        #endregion
    }
}
