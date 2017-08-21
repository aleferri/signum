using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelManaging
{
    internal class ModelControlPresenter
    {
        private readonly ModelDialog _control;
        private readonly GestoreModelli _gestoreModelli;
        public ModelDialog ModelDialog => _control;
        public Modello Result { get; set; }

        public ModelControlPresenter(ModelDialog control)
        {
            _control = control;
            _gestoreModelli = new GestoreModelli();
            InitializeControl();
        }

        public ModelControlPresenter(ModelDialog control, Modello precedente) : this(control)
        {
            int index = ((List<ModelDescriptor>)ModelDialog.Combo.DataSource).IndexOf(_gestoreModelli.GetFromModello(precedente));
            if(index >= 0)
            {
                ModelDialog.Combo.SelectedIndex = index;
                Result = precedente;
                ModelDialog.PreviewPanel.Refresh();
            }
        }

        /// <summary>
        /// Inizializza il controllo applicando gli event handler e popolando combobox e tabelle
        /// </summary>
        private void InitializeControl()
        {
            ModelDialog.Combo.SelectionChangeCommitted += OnComboChanging;
            ModelDialog.Combo.DisplayMember = "Nome";
            ModelDialog.PreviewButton.Click += OnPreviewClicked;
            ModelDialog.OkButton.Click += OnPreviewClicked;
            ModelDialog.PreviewPanel.Paint += Preview;
            PopulateCombo(_gestoreModelli.Descrittori);
            PopulateTable(_control.SelectedModel);
        }

        /// <summary>
        /// Popola la combobox contenente i nomi dei vari possibili modelli.
        /// </summary>
        private void PopulateCombo(IEnumerable<ModelDescriptor> modelli)
        {
            ModelDialog.Combo.DataSource = modelli.ToList();
        }

        /// <summary>
        /// Popola la tabella che deve contenere tutti i controlli il cui compito è 
        /// quello di valorizzare i parametri del rispettivo costruttore.
        /// </summary>
        private void PopulateTable(ModelDescriptor model)
        {
            ConstructorInfo []ctorInfo = model.Tipo.GetConstructors();

            if(ctorInfo.Length != 1)
            {
                throw new ArgumentException("La classe selezionata deve avere un costruttore unico");
            }

            ModelDialog.TablePanel.Controls.Clear();
            foreach (ParameterInfo pInfo in ctorInfo[0].GetParameters())
            {
                Label l = new Label();
                l.Text = pInfo.Name;
                l.Dock = DockStyle.Right;
                NumericUpDown nup = new NumericUpDown();
                nup.Width = 50;
                nup.Dock = DockStyle.Left;
                nup.Tag = pInfo;
                nup.Minimum = 1;
                nup.Maximum = Int32.MaxValue;
                ModelDialog.TablePanel.Controls.Add(l);
                ModelDialog.TablePanel.Controls.Add(nup);
            }
        }

        /// <summary>
        /// Costruisce un oggetto di tipo modello a partire dal Type e dagli argomenti da passare al costruttore.
        /// </summary>
        private Modello CostruisciModello(Type selectedModelType, object[] args)
        {
            return (Modello)Activator.CreateInstance(selectedModelType, BindingFlags.CreateInstance, null, args, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Itera sui controlli nel TablePanel e usa il loro contenuto per costruire gli argomenti da passare al costruttore del modello.
        /// </summary>
        private object[] CalcolaArgomenti()
        {
            IEnumerable<NumericUpDown> nUpDowns = ModelDialog.TablePanel.Controls.OfType<NumericUpDown>();
            object[] args = new object[nUpDowns.Count()];
            for (int i = 0; i < args.Length; i++)
            {
                args[i] = (int)nUpDowns.ElementAt(i).Value;
            }
            return args;
        }

        #region EventHandlers
        private void OnComboChanging(object sender, EventArgs args)
        {
            PopulateTable(_control.SelectedModel);
        }

        private void Preview(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (null == Result) return;

            Panel previewPanel = (Panel)sender;
            int dim = Math.Min((previewPanel.Width - 4) / Result.Size.Width, (previewPanel.Height - 4) / Result.Size.Height);
            int sX = previewPanel.Width / 2 - Result.Size.Width * dim / 2;
            int sY = previewPanel.Height / 2 - Result.Size.Height * dim / 2;
            for (int i = 0; i < Result.Size.Width; i++)
            {
                for (int k = 0; k < Result.Size.Height; k++)
                {
                    if(Result[i, k])
                    {
                        g.FillRectangle(Brushes.LawnGreen, sX + dim*i, sY + dim*k, dim, dim);
                        g.DrawRectangle(Pens.Black, new Rectangle(sX + dim*i, sY + dim*k, dim, dim));
                    }
                }
            }
        }

        private void OnPreviewClicked(object sender, EventArgs args)
        {
            object[] argomenti = CalcolaArgomenti();
            Result = CostruisciModello(_control.SelectedModel.Tipo, argomenti);
            ModelDialog.SuspendLayout();
            if(ModelDialog.PreviewButton == sender) ModelDialog.PreviewPanel.Refresh();
            ModelDialog.ResumeLayout();
        }
        #endregion
    }
}
