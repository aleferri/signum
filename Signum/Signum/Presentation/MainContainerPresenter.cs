﻿using ModelManaging;
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
            FillNuovoMenu();
            OnLibreriaChange(this, EventArgs.Empty);
            _mainContainer.CambiaModelloButton.Click += OnModelChangeClick;
            _mainContainer.LibreriaView.MouseDoubleClick += OnLibreriaClick;
            Documento.getInstance().LibreriaChanged += OnLibreriaChange;

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
        private void FillImmaginiFisseNode(TreeNode node)
        {
            foreach(ModelToPersistenceWrapper<ImmagineFissa> imm in Documento.getInstance().Libreria.ImmaginiFisse)
            {
                TreeNode immNode = new TreeNode(imm.ModelElement.Nome + " (Immagine Fissa)");
                immNode.Tag = imm;
                node.Nodes.Add(immNode);
            }
        }
        private void FillAnimazioniNode(TreeNode node)
        {
            foreach (ModelToPersistenceWrapper<Animazione> a in Documento.getInstance().Libreria.Animazioni)
            {
                TreeNode aNode = new TreeNode(a.ModelElement.Nome + " (Animazione)");
                aNode.Tag = a;
                node.Nodes.Add(aNode);
            }
        }
        private void FillSequenzeNode(TreeNode node)
        {
            foreach (ModelToPersistenceWrapper<Sequenza> s in Documento.getInstance().Libreria.Sequenze)
            {
                TreeNode sNode = new TreeNode(s.ModelElement.Nome);
                sNode.Tag = s;
                node.Nodes.Add(sNode);
            }
        }
        private void FillProgrammazioniGiornaliereNode(TreeNode node)
        {
            foreach (ModelToPersistenceWrapper<ProgrammazioneGiornaliera> p in Documento.getInstance().Libreria.ProgrGiornaliere)
            {
                TreeNode pNode = new TreeNode(p.ModelElement.Nome);
                pNode.Tag = p;
                node.Nodes.Add(pNode);
            }
        }
        private IEditorPresenter ChangePresenter(Type modelType)
        {
            IEditorPresenter old = _currentEditorHandler;
            _currentEditorHandler = _editorFactory.GetEditorHandler(modelType, Documento.getInstance().ModelloRiferimento);
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
            return _currentEditorHandler;
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
        private void OnLibreriaClick(object sender, MouseEventArgs args)
        {
            TreeNode clicked = _mainContainer.LibreriaView.GetNodeAt(new System.Drawing.Point(args.X, args.Y));
            if (null == clicked.Tag) return;
            ModelToPersistenceWrapper obj = (ModelToPersistenceWrapper)clicked.Tag;
            IEditorPresenter presenter = ChangePresenter(obj.ObjectModelElement.GetType());
            presenter.CaricaModello(obj);
        }
        private void OnLibreriaChange(object sender, EventArgs args)
        {
            TreeNodeCollection nodes = _mainContainer.LibreriaView.Nodes;
            nodes.Clear();
            TreeNode elementi = new TreeNode("Elementi");
            FillImmaginiFisseNode(elementi);
            FillAnimazioniNode(elementi);
            TreeNode sequenze = new TreeNode("Sequenze");
            FillSequenzeNode(sequenze);
            TreeNode progr = new TreeNode("Programmazioni Giornaliere");
            FillProgrammazioniGiornaliereNode(progr);
            if (elementi.Nodes.Count != 0) nodes.Add(elementi);
            if (sequenze.Nodes.Count != 0) nodes.Add(sequenze);
            if (progr.Nodes.Count != 0) nodes.Add(progr);
        }
        private void OnNewClick(object sender, EventArgs args)
        {
            ToolStripItem source = (ToolStripItem)sender;
            ChangePresenter((Type)source.Tag);
        }
        #endregion
    }
}
