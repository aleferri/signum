using ModelManaging;
using Signum.Model;
using Signum.Presentation.EditorsHandling;
using Signum.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signum.Presentation
{
    class MainContainerPresenter
    {
        private readonly MainContainer _mainContainer;
        private readonly EditorFactory _editorFactory;
        private IEditorPresenter _currentEditorHandler;
        public MainContainerPresenter(MainContainer mainContainer)
        {
            _mainContainer = mainContainer;
            _editorFactory = new EditorFactory();
            _mainContainer.CambiaModelloButton.Click += OnModelChangeClick;
            _mainContainer.NuovoImmagine.Click += OnNewClick;
        }

        #region EventHandlers
        public void OnModelChangeClick(object sender, EventArgs args)
        {
            Documento.getInstance().ModelloRiferimento = ModelPane.showModelDialog(Documento.getInstance().ModelloRiferimento) ?? Documento.getInstance().ModelloRiferimento;
            _mainContainer.RightPanel.Controls.Clear();
            foreach (ToolStripItem item in _mainContainer.SaveItems)
            {
                item.Enabled = true;
            }
        }
        public void OnNewClick(object sender, EventArgs args)
        {
            ToolStripItem source = (ToolStripItem)sender;
            IEditorPresenter old = _currentEditorHandler;
            _currentEditorHandler = _editorFactory.getEditorHandler((string)source.Tag, Documento.getInstance().ModelloRiferimento);
            _mainContainer.RightPanel.Controls.Clear();
            _mainContainer.RightPanel.Controls.Add(_currentEditorHandler.Editor);

            foreach (ToolStripItem item in _mainContainer.SaveItems)
            {
                item.Enabled = true;
                if (null != old)
                {
                    item.Click -= old.OnSave;
                }

                item.Click += _currentEditorHandler.OnSave;
            }
        }
        #endregion
    }
}
