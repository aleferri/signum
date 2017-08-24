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
    class ProgrammazioneEditorPresenter
    {

        private readonly ProgrammazioneEditor _editor;

        private IList<ProgrammazioneGiornaliera> _inSandbox;

        private readonly EditorFactory _eFactory;

        public Control Editor => _editor;

        public ProgrammazioneEditorPresenter(EditorFactory eFactory)
        {
            _eFactory = eFactory;
            _editor = new ProgrammazioneEditor();
            _inSandbox = new List<ProgrammazioneGiornaliera>();
            UpdateCombo();
            RegisterCombo();
        }

        private IEnumerable<PersisterMapper<ProgrammazioneGiornaliera>> CollectProgrammazioniGiornaliere()
        {
            return (from PersisterMapper<ProgrammazioneGiornaliera> p in Documento.getInstance().Libreria.ProgrGiornaliere
                    select p).Union(from ProgrammazioneGiornaliera p in _inSandbox select new PersisterMapper<ProgrammazioneGiornaliera>(p.Copy()));
        }

        private void UpdateCombo()
        {
            foreach (ComboBox box in _editor.Days)
            {
                box.DataSource = CollectProgrammazioniGiornaliere().ToList();
            }
        }

        private void RegisterCombo()
        {
            foreach (ComboBox box in _editor.Days)
            {
                box.SelectedValueChanged += OnValueChanged;
            }
        }

        private void OnValueChanged(object sender, EventArgs args)
        {
            var combo = sender as ComboBox;
            if (null == combo)
            {
                throw new Exception("Voglio euro non le lire, sono un messaggio di errore filosofo");
            }
            var prog = combo.SelectedItem as ProgrammazioneGiornaliera;
            if (null == prog)
            {
                throw new Exception("Vedi sopra, e comunque come è possibile?");
            }
            var editor = _eFactory.GetEditorHandler(typeof(ProgrammazioneGiornaliera), Documento.getInstance().ModelloRiferimento);
            _editor.SottoEditorControl.Controls.Clear();
            _editor.SottoEditorControl.Controls.Add(editor.Editor);
        }

        public void OnSave(object sender, EventArgs args)
        {
            
        }

    }
}
