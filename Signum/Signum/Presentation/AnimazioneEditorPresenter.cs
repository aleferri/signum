using ModelManaging;
using Signum.Model;
using Signum.Presentation.EditorsHandling;
using Signum.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signum.Presentation
{
    [NameTagAttribute("Animazione", "animazione")]
    class AnimazioneEditorPresenter : IEditorPresenter
    {
        private readonly ElementEditor _elementEditor;
        private readonly AnimazioneEditor _animationEditor;
        private Animazione _animazione;
        private readonly Modello _modello;

        public EventHandler OnSave => Save;
        public Control Editor => _elementEditor;

        public AnimazioneEditorPresenter(Modello modello)
        {
            _animationEditor = new AnimazioneEditor();
            _animationEditor.Dock = DockStyle.Fill;
            _animationEditor.Pannello.CreateControl();
            _elementEditor = new ElementEditor(_animationEditor);
            _elementEditor.Dock = DockStyle.Fill;
            _modello = modello;
            InstallHandlers();
            AddFrame();
        }

        private void InstallHandlers()
        {
            _elementEditor.DateHourCheckBox.CheckedChanged += OnCheckedChanged;
            _animationEditor.Pannello.Selected += OnTabChanged;

        }

        private TabPage CreateTab(int n)
        {
            TabPage nuovaTab = new TabPage();
            nuovaTab.Text = String.Format("Frame {0}", n);
            FrameEditorPresenter fp = new FrameEditorPresenter(_modello);
            fp.Editor.Dock = DockStyle.Fill;
            nuovaTab.Controls.Add(fp.Editor);
            nuovaTab.Tag = fp;
            //nuovaTab.ContextMenuStrip = _animationEditor.TabContextMenu;
            return nuovaTab;
        }
        private void AddFrame()
        {      
            TabPage nuovaTab = CreateTab(_animationEditor.Pannello.TabPages.Count);
            _animationEditor.Pannello.TabPages.Insert(_animationEditor.Pannello.TabPages.Count - 1, nuovaTab);
            _animationEditor.Pannello.SelectedTab = nuovaTab;
        }

        #region EventHandlers
        private void OnTabChanged(object sender, TabControlEventArgs args)
        {
            if(args.TabPageIndex == _animationEditor.Pannello.TabCount - 1)
            {
                AddFrame();
            }
        }
        private void OnCheckedChanged(object sender, EventArgs args)
        {
            _elementEditor.InfoBox.Enabled = !_elementEditor.DateHourCheckBox.Checked;
        }
        private void Save(object sender, EventArgs args)
        {
            IInformazione info = _elementEditor.DateHourCheckBox.Checked ? (IInformazione) new InformazioneDataOra() : new InformazioneTestuale(_elementEditor.InfoBox.Text);
            if (null == _animazione) _animazione = new Animazione((uint)_animationEditor.FramerateNumeric.Value);

            _animazione.InformazioneAssociata = info;
            _animazione.FrameRate = (uint)_animationEditor.FramerateNumeric.Value;
            _animazione.Frames.Clear();
            foreach(TabPage tab in _animationEditor.Pannello.TabPages)
            {
                if (tab == _animationEditor.TabAggiungi) continue;
                FrameEditorPresenter p = (FrameEditorPresenter)tab.Tag;
                _animazione.Frames.Add(p.CurrentResultFrame);
            }
            String recap = String.Format("Animazione ({0} fps, {1} frame) -> {2}", _animazione.FrameRate, _animazione.Frames.Count, _animazione.InformazioneAssociata.Accept(new ValutatoreInformazione()));
            MessageBox.Show(recap);
        }
        #endregion
    }
}
