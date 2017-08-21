using System.Windows.Forms;

namespace ModelManaging
{
    public class ModelPane
    {
        /// <summary>
        /// Visualizza il dialogo (modale) per la scelta del modello per poi ritornarne il risultato.
        /// </summary>
        public static Modello ShowModelDialog()
        {
            ModelDialog md = new ModelDialog();
            ModelControlPresenter presenter = new ModelControlPresenter(md);
            using (md)
            {
                if (md.ShowDialog() == DialogResult.OK)
                {
                    return presenter.Result;
                }
                return null;

            }
        }

        /// <summary>
        /// Visualizza il dialogo (modale) per la scelta del modello caricando i dati del modello precedente, per poi ritornarne il risultato.
        /// </summary>
        public static Modello ShowModelDialog(Modello precedente)
        {
            ModelDialog md = new ModelDialog();
            ModelControlPresenter presenter = new ModelControlPresenter(md, precedente);
            using (md)
            {
                if (md.ShowDialog() == DialogResult.OK)
                {
                    return presenter.Result;
                }
                return null;
            }
        }
    }
}
