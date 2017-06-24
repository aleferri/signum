using ModelManaging;
using Signum.Model;
using Signum.Presentation;
using Signum.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signum
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Documento.getInstance().ModelloRiferimento = ModelPane.showModelDialog();
            if (null == Documento.getInstance().ModelloRiferimento) Environment.Exit(1);

            MainForm form = new MainForm();
            MainContainerPresenter presenter = new MainContainerPresenter(form.MainContainer);
            Application.Run(form);
        }
    }
}
