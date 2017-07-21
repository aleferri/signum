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
            Modello modello = ModelPane.showModelDialog();
            if (null == modello) Environment.Exit(1);

            Documento.getInstance().ModelloRiferimento = modello;

            MainForm form = new MainForm();
            MainContainerPresenter presenter = new MainContainerPresenter(form.MainContainer);
            Application.Run(form);
        }
    }
}
