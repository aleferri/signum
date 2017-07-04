using ModelManaging;
using Signum.Common;
using Signum.Model;
using Signum.Persistence;
using Signum.Presentation.EditorsHandling;
using Signum.View;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Signum.Presentation
{
    [NameTagAttribute("Immagine Fissa", "immagineFissa")]
    class ImmagineFissaEditorPresenter : IEditorPresenter
    {
        private readonly ElementEditor _editor;
        private FrameEditorPresenter _presenter;
        private ImmagineFissa _img;
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
            _img = _img ?? new ImmagineFissa(_presenter.CurrentResultFrame, Informazione);
            if(null == _img.Nome)
            {
                string nome = InputPrompt.ShowInputDialog("Scegli il nome dell'elemento:", "Immagine Fissa", "OK", "Annulla");
                if (null == nome) return;
                _img.Nome = nome;
            }
            using(BinaryWriter bw = new BinaryWriter(new FileStream(Documento.LIBRARY_PATH + _img.Nome + ".elem", FileMode.Create), Encoding.UTF8))
            {
                PersisterFactory.GetPersister(PersisterFactory.IMMAGINE_FISSA).Save(_img, bw);
            }
        }

        public void OnCheckedChanged(object sender, EventArgs args)
        {
            _editor.InfoBox.Enabled = !_editor.DateHourCheckBox.Checked;
        }
    }
}
