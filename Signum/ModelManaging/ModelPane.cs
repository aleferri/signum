using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModelManaging
{
    public class ModelPane
    {
        public static Modello showModelDialog()
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

        public static Modello showModelDialog(Modello precedente)
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
