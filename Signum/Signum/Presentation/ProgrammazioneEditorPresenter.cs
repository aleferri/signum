using Signum.Common;
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

        public event EventHandler NuovaProgrammazioneGiornaliera;
        private readonly ProgrammazioneEditor _editor;
        private IDictionary<string, ProgrammazioneGiornaliera> _inSandbox;
        private readonly EditorFactory _eFactory;

        public Control Editor => _editor;

        public ProgrammazioneEditorPresenter(EditorFactory eFactory)
        {
            _eFactory = eFactory;
            _editor = new ProgrammazioneEditor();
            _editor.Dock = DockStyle.Fill;
            _inSandbox = new Dictionary<string, ProgrammazioneGiornaliera>();
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
                box.DisplayMember = "Element";
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
            var prog = combo.SelectedItem as PersisterMapper<ProgrammazioneGiornaliera>;
            if (null == prog)
            {
                throw new Exception("Vedi sopra, e comunque come è possibile?");
            }
            if (!_inSandbox.ContainsKey(prog.Element.Nome) && !_inSandbox.ContainsKey(prog.Element.Nome + "{Sandbox}"))
            {
                _inSandbox.Add(prog.Element.Nome + "{Sandbox}", prog.Element);
            }
            var editor = _eFactory.GetEditorHandler(typeof(ProgrammazioneGiornaliera), Documento.getInstance().ModelloRiferimento);
            editor.CaricaModello(prog);
            _editor.SottoEditorControl.Controls.Clear();
            _editor.SottoEditorControl.Controls.Add(editor.Editor);
        }

        private void OnNuovaProgrammazioneGiornaliera()
        {
            string name = InputPrompt.ShowInputDialog("Inserisci il nome per la nuova programmazione", "Nome", "OK", "Annulla");
            if(null == name || "" == name)
            {
                return;
            }
            ProgrammazioneGiornaliera p = new ProgrammazioneGiornaliera();
            p.Nome = name;
            _inSandbox.Add(name, p);
            UpdateCombo();
            NuovaProgrammazioneGiornaliera(p, EventArgs.Empty);
        }

        public void OnSave(object sender, EventArgs args)
        {
            
        }

    }
}
