using ModelManaging;
using Signum.Model;
using Signum.Presentation.EditorsHandling;
using Signum.View;
using System;
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
            _editorFactory = Documento.getInstance().EditorFactory;
            _mainContainer.CambiaModelloButton.Click += OnModelChangeClick;
            FillNuovoMenu();

        }

        private void FillNuovoMenu()
        {
            foreach(string name in _editorFactory.Names)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(name);
                item.Tag = _editorFactory.GetTagFromName(name);
                item.Click += OnNewClick;
                _mainContainer.NuovoMenu.DropDownItems.Add(item);
            }
        }

        #region EventHandlers
        private void OnModelChangeClick(object sender, EventArgs args)
        {
            Documento.getInstance().ModelloRiferimento = ModelPane.showModelDialog(Documento.getInstance().ModelloRiferimento) ?? Documento.getInstance().ModelloRiferimento;
            _mainContainer.RightPanel.Controls.Clear();
            foreach (ToolStripItem item in _mainContainer.SaveItems)
            {
                item.Enabled = true;
            }
        }
        private void OnNewClick(object sender, EventArgs args)
        {
            ToolStripItem source = (ToolStripItem)sender;
            IEditorPresenter old = _currentEditorHandler;
            _currentEditorHandler = _editorFactory.GetEditorHandler((Type)source.Tag, Documento.getInstance().ModelloRiferimento);
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
