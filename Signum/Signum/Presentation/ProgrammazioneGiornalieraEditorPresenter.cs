using Signum.Presentation.EditorsHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Signum.Model;
using System.Windows.Forms;
using Signum.View;
using ModelManaging;
using System.Drawing;

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


        public Control Editor => _editor;

        public ProgrammazioneGiornalieraEditorPresenter(Modello modello)
        {
            _editor = new ProgrammazioneGiornalieraEditor();
            _editor.Dock = DockStyle.Fill;
            ProgrammazioneGiornaliera progr = new ProgrammazioneGiornaliera();
            progr.InserisciSequenza(Sequenza.Default, new FasciaOraria(0, 4));
            CaricaProgrammazione(new PersisterMapper<ProgrammazioneGiornaliera>(progr));
            VisualizzaEditorPer(progr.Sequenze.ElementAt(0));
            _editor.StartPicker.ValueChanged += OnPickerChange;
            _editor.EndPicker.ValueChanged += OnPickerChange;
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

            for (uint i = fasciaOraria.StartQuarter; i < fasciaOraria.EndQuarter; i++)
            {
                char content = i - fasciaOraria.StartQuarter < s.Nome.Length ? s.Nome.ToCharArray()[i - fasciaOraria.StartQuarter] : ' ';
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
            _editor.Start = new DateTime(1753, 1, 1, (int)fo.StartQuarter*15 / 60, (int)fo.StartQuarter * 15, 0);
            _editor.End = new DateTime(1753, 1, 1, (int)(fo.EndQuarter * 15 / 60), (int)(fo.EndQuarter * 15 % 60), 0);
            _currentSequenza = s;
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

        public void CaricaProgrammazione(PersisterMapper<ProgrammazioneGiornaliera> progr)
        {
            _wrapper = progr;
            UpdateLabels();
        }
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
            if (null == s) throw new ArgumentException("Il tag della label selezionata non è una sequenza");
            VisualizzaEditorPer(s);
        }
        private void OnPickerChange(object sender, EventArgs args)
        {
            FasciaOraria oldFascia = _wrapper.Element.GetFasciaOrariaOf(_currentSequenza);
            FasciaOraria newFascia;
            if(sender == _editor.StartPicker)
            {
                newFascia = new FasciaOraria((uint)(_editor.Start.Hour * 60 / 15 + _editor.Start.Minute / 15), oldFascia.EndQuarter);
            }
            else
            {
                newFascia = new FasciaOraria(oldFascia.StartQuarter, (uint)(_editor.End.Hour * 60 / 15 + _editor.End.Minute / 15));
                Console.WriteLine(newFascia);
            }
            _wrapper.Element.UpdateFasciaOraria(_currentSequenza, newFascia);
            UpdateLabels();
        }

        public void OnSave(object sender, EventArgs args)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
