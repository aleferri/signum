using ModelManaging;
using Signum.Model;
using Signum.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signum.Presentation
{
    class MainContainerPresenter
    {
        private readonly MainContainer _mainContainer;

        public MainContainerPresenter(MainContainer mainContainer)
        {
            _mainContainer = mainContainer;
            _mainContainer.CambiaModelloButton.Click += onModelChangeClick;
        }

        public void onModelChangeClick(object sender, EventArgs args)
        {
            Documento.getInstance().ModelloRiferimento = ModelPane.showModelDialog(Documento.getInstance().ModelloRiferimento) ?? Documento.getInstance().ModelloRiferimento;
        }
    }
}
