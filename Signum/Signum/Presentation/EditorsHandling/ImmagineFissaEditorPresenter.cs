using ModelManaging;
using Signum.Model;
using Signum.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signum.Presentation.EditorsHandling
{
    [NameAttribute("immagineFissa")]
    class ImmagineFissaEditorPresenter : IEditorPresenter
    {
        private readonly ElementEditor _editor;
        private FrameEditorPresenter _presenter;

        private IInformazione Informazione => _editor.DateHourCheckBox.Checked ? (IInformazione)new InformazioneDataOra() : new InformazioneTestuale(_editor.InfoBox.Text);
        public EventHandler OnSave => OnSaveHandler;
        public Control Editor => _editor;

        public ImmagineFissaEditorPresenter(Modello modello)
        {
            _presenter = new FrameEditorPresenter(modello);
            _editor = new ElementEditor(_presenter.Editor);
            _editor.Dock = DockStyle.Fill;
            _editor.DateHourCheckBox.CheckedChanged += OnCheckedChanged;
        }

        private void OnSaveHandler(object sender, EventArgs args)
        {
            MessageBox.Show(new ImmagineFissa(_presenter.CurrentResultFrame, Informazione).ToString());
        }

        public void OnCheckedChanged(object sender, EventArgs args)
        {
            _editor.InfoBox.Enabled = !_editor.DateHourCheckBox.Checked;
        }
    }
}
