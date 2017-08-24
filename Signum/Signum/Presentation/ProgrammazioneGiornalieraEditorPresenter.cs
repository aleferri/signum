using Signum.Presentation.EditorsHandling;
using System;
using System.Linq;
using Signum.Model;
using System.Windows.Forms;
using Signum.View;
using ModelManaging;
using System.Drawing;
using Signum.Common;

namespace Signum.Presentation
{
    [NameTagAttribute("Programmazione Giornaliera", typeof(ProgrammazioneGiornaliera))]
    class ProgrammazioneGiornalieraEditorPresenter : IEditorPresenter
    {
        private static readonly int ALPHA_CHANNEL = 255 << 24;

        private ProgrammazioneGiornalieraEditor _editor;
        private IEditorPresenter _sequenzaEditor;
        private PersisterMapper<ProgrammazioneGiornaliera> _wrapper;
        private Sequenza _currentSequenza;
        private int _selectedLabel;

        public Control Editor => _editor;

        public ProgrammazioneGiornalieraEditorPresenter(Modello modello)
        {
            _editor = new ProgrammazioneGiornalieraEditor();
            _editor.Dock = DockStyle.Fill;          
            _editor.EndPicker.MinuteInterval = _editor.StartPicker.MinuteInterval = ProgrammazioneGiornaliera.QUARTER_DURATION / 60;
            ProgrammazioneGiornaliera progr = new ProgrammazioneGiornaliera();
            progr.InserisciSequenza(Sequenza.Default, new FasciaOraria(0, 96));
            CaricaProgrammazione(new PersisterMapper<ProgrammazioneGiornaliera>(progr));
            SetEventHandlers();
            OnLibreriaChange(null, EventArgs.Empty);
            VisualizzaEditorPer(progr.Sequenze.ElementAt(0));
            _selectedLabel = -1;
        }

        private void SetEventHandlers()
        {
            Documento.getInstance().LibreriaChanged += OnLibreriaChange;
            _editor.StartPicker.ValueChanged += OnPickerChange;
            _editor.EndPicker.ValueChanged += OnPickerChange;
            _editor.Labels.ToList().ForEach(l => l.MouseUp += OnLabelMouseUp);
            _editor.EliminaSequenzaOption.Click += OnEliminaSequenzaClick;
            _editor.RinominaSequenzaOption.Click += OnRinominaSequenzaClick;
            _editor.NuovaSequenzaOption.Click += OnNuovaSequenzaClick;
        }
        private void SetEmptyLabel(int index)
        {
            if (null == _editor.Labels[index].Tag) return;
            _editor.Labels[index].Text = "-";
            _editor.Labels[index].BackColor = SystemColors.Control;
            _editor.Labels[index].BorderStyle = BorderStyle.FixedSingle;
            _editor.Labels[index].ForeColor = Color.Black;
            _editor.Labels[index].Tag = null;
            _editor.ToolTip.SetToolTip(_editor.Labels[index], "Slot vuoto");
            _editor.Labels[index].DoubleClick -= OnLabelDoubleClick;
        }
        private void SetSequenzaOnLabels(Sequenza s, FasciaOraria fasciaOraria, bool odd)
        {
            _editor.SuspendLayout();
            int argb = ALPHA_CHANNEL | 200 << (odd ? 16 : 0);
            int startingNameIndex = fasciaOraria.CoveredQuarters < s.Nome.Length ? 0 : ((int)fasciaOraria.CoveredQuarters - s.Nome.Length) / 2;

            for (uint i = fasciaOraria.StartQuarter; i < fasciaOraria.EndQuarter; i++)
            {
                uint relativeIndex = i - fasciaOraria.StartQuarter;
                bool isInside = relativeIndex >= startingNameIndex && relativeIndex <= startingNameIndex + s.Nome.Length - 1;
                char content = isInside ? s.Nome.ToCharArray()[relativeIndex - startingNameIndex] : ' ';
                _editor.Labels[i].Text = String.Format("{0}", content);
                _editor.Labels[i].BackColor = Color.FromArgb(argb);
                _editor.Labels[i].BorderStyle = BorderStyle.None;
                _editor.Labels[i].ForeColor = Color.White;
                _editor.Labels[i].Tag = s;
                _editor.ToolTip.SetToolTip(_editor.Labels[i], s.Nome);
                _editor.Labels[i].DoubleClick += OnLabelDoubleClick;
            }
            _editor.ResumeLayout();
        }
        private void VisualizzaEditorPer(Sequenza s)
        {
            if (null != _sequenzaEditor) _editor.EditorContainer.Controls.Remove(_sequenzaEditor.Editor);
            _sequenzaEditor = Documento.getInstance().EditorFactory.GetEditorHandler(s.GetType(), Documento.getInstance().ModelloRiferimento);
            _sequenzaEditor.CaricaModello(new PersisterMapper<Sequenza>(s));
            _editor.EditorContainer.Controls.Add(_sequenzaEditor.Editor);
            _sequenzaEditor.Editor.BringToFront();
            _editor.NomeField.Text = s.Nome;
            FasciaOraria fo = _wrapper.Element.GetFasciaOrariaOf(s);
            _currentSequenza = s;
            _editor.StartPicker.InitValue = fo.StartToDateTime();
            _editor.EndPicker.InitValue = fo.EndToDateTime();
            ControllaPickers(fo);
        }
        private void UpdateLabels()
        {
            ProgrammazioneGiornaliera pg = _wrapper.Element;
            bool odd = false;
            foreach (Sequenza s in pg.Sequenze)
            {
                SetSequenzaOnLabels(s, pg.GetFasciaOrariaOf(s), odd);
                odd = !odd;
            }
            foreach(int i in pg.EmptySlots)
            {
                SetEmptyLabel(i);
            }
        }
        private void ControllaPickers(FasciaOraria fo)
        {
            _editor.StartPicker.CanGoDown = fo.StartQuarter != 0 &&
                _wrapper.Element[fo.StartQuarter - 1] == ProgrammazioneGiornaliera.SEQUENZA_DUMMY;
            _editor.StartPicker.CanGoUp = fo.CoveredQuarters != 1;
            _editor.EndPicker.CanGoDown = fo.CoveredQuarters != 1;
            _editor.EndPicker.CanGoUp = fo.EndQuarter != ProgrammazioneGiornaliera.QUARTERS_IN_DAY &&
                _wrapper.Element[fo.EndQuarter] == ProgrammazioneGiornaliera.SEQUENZA_DUMMY;
        }

        /// <summary>
        /// Carica nell'editor una programmazione giornaliera
        /// </summary>
        /// <param name="progr"></param>
        public void CaricaProgrammazione(PersisterMapper<ProgrammazioneGiornaliera> progr)
        {
            _wrapper = progr;
            UpdateLabels();
        }
        /// <summary>
        /// Carica nell'editor l'oggetto contenuto nel PersisterMapper, se è una programmazione giornaliera
        /// </summary>
        /// <param name="oggettoModello"></param>
        public void CaricaModello(PersisterMapper oggettoModello)
        {
            PersisterMapper<ProgrammazioneGiornaliera> tmp = oggettoModello as PersisterMapper<ProgrammazioneGiornaliera>;
            CaricaProgrammazione(tmp ?? throw new ArgumentException("Oggetto passato non compatibile all'editor delle sequenze"));
        }

        #region EventHandlers
        private void OnLabelDoubleClick(object sender, EventArgs args)
        {
            Label clicked = (Label)sender;
            Sequenza s = clicked.Tag as Sequenza;
            if (null == s) return;
            VisualizzaEditorPer(s);
        }
        private void OnLabelMouseUp(object sender, MouseEventArgs args)
        {
            if(args.Button == MouseButtons.Right)
            {
                Label label = (Label)sender;
                bool isEmpty = null == label.Tag;
                _selectedLabel = _editor.Labels.ToList().IndexOf(label);

                _editor.EliminaSequenzaOption.Enabled = !isEmpty;
                _editor.EliminaSequenzaOption.Tag = label.Tag;
                _editor.RinominaSequenzaOption.Enabled = !isEmpty;
                _editor.RinominaSequenzaOption.Tag = label.Tag;
                _editor.NuovaSequenzaOption.Enabled = isEmpty;
                _editor.NuovaSequenzaOption.Tag = _selectedLabel;
                _editor.AggiungiSequenzaOption.Enabled = isEmpty;
                _editor.LabelMenuStrip.Show(label, args.X, args.Y);
            }
        }
        private void OnEliminaSequenzaClick(object sender, EventArgs args)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            Sequenza s = item.Tag as Sequenza;
            _wrapper.Element.Remove(s ?? throw new ArgumentNullException("La label selezionata non ha un tag valido"));
            if(0 == _wrapper.Element.Sequenze.Count())
            {
                _wrapper.Element.InserisciSequenza(Sequenza.Default, new FasciaOraria(0, 4));
                VisualizzaEditorPer(_wrapper.Element.Sequenze.ElementAt(0));
            }
            UpdateLabels();
        }
        private void OnRinominaSequenzaClick(object sender, EventArgs args)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            Sequenza s = item.Tag as Sequenza;
            if (null == s) throw new ArgumentNullException("La label selezionata non ha un tag valido");
            string newName = InputPrompt.ShowInputDialog("Inserisci il nuovo nome per la sequenza selezionata","Modifica nome","OK","Annulla",s.Nome);
            s.Nome = newName ?? s.Nome;
            if(s == _currentSequenza)
            {
                _editor.NomeField.Text = newName;
            }
            UpdateLabels();
        }
        private void OnNuovaSequenzaClick(object sender, EventArgs args)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            int index = (int)item.Tag;
            Sequenza s = new Sequenza();
            s.AggiungiElemento(Elemento.Default, 10);
            string name = InputPrompt.ShowInputDialog("Inserisci un nome per la nuova sequenza","Nuova sequenza","OK","annulla");
            if (null == name) return;
            s.Nome = name;
            _wrapper.Element.InserisciSequenza(s, new FasciaOraria((uint)index, (uint)++index));
            VisualizzaEditorPer(s);
            UpdateLabels();
        }
        private void OnAggiungiSequenzaClick(object sender, EventArgs args)
        {
            if (0 > _selectedLabel) return;
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            Sequenza s = item.Tag as Sequenza;
            if(null == s) throw new ArgumentException("Tag nullo nella lista delle sequenze da libreria");
            _wrapper.Element.InserisciSequenza(s, new FasciaOraria((uint)_selectedLabel, (uint)++_selectedLabel));
            VisualizzaEditorPer(s);
            UpdateLabels();
            _selectedLabel = -1;
        }
        private void OnPickerChange(object sender, EventArgs args)
        {
            DateTime start = _editor.StartPicker.Value;
            DateTime end = _editor.EndPicker.Value;
            FasciaOraria fo = FasciaOraria.FromDateTime(start, end);
            _wrapper.Element.UpdateFasciaOraria(_currentSequenza, fo);
            UpdateLabels();
            ControllaPickers(fo);
        }
        private void OnLibreriaChange(object sender, EventArgs args)
        {
            _editor.AggiungiSequenzaOption.DropDownItems.Clear();
            foreach(PersisterMapper<Sequenza> s in Documento.getInstance().Libreria.Sequenze)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = s.Element.Nome;
                item.Tag = s.Element;
                item.Click += OnAggiungiSequenzaClick;
                _editor.AggiungiSequenzaOption.DropDownItems.Add(item);
            }
        }

        public void OnSave(object sender, EventArgs args)
        {
            if (null == _wrapper.Element.Nome || "" == _wrapper.Element.Nome)
            {
                string nome = InputPrompt.ShowInputDialog("Inserisci il nome per la programmazione", "Nuova Programmazione", "Salva", "Annulla");
                if (null == nome) return;
                _wrapper.Element.Nome = nome;
            }
            Documento.getInstance().Libreria.AggiungiProgrGiornaliera(_wrapper);
            MessageBox.Show(null, "Salvataggio terminato", "Successo");
        }
        #endregion
    }
}
