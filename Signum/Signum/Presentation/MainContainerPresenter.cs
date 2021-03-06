﻿using ModelManaging;
using Signum.Common;
using Signum.Model;
using Signum.Presentation.EditorsHandling;
using Signum.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Signum.Presentation
{
    class MainContainerPresenter
    {
        private delegate void Deleter(int index);

        private static readonly TreeNode ELEMENTI_NODE = new TreeNode("Elementi");
        private static readonly TreeNode SEQUENZE_NODE = new TreeNode("Sequenze");
        private static readonly TreeNode PROG_NODE = new TreeNode("Programmazioni Giornaliere");

        private readonly MainContainer _mainContainer;
        private readonly EditorFactory _editorFactory;
        private IEditorPresenter _currentEditorHandler = null;
        private ProgrammazioneEditorPresenter _progettoPresenter = null;
        private Dictionary<Type, Deleter> _deleters;

        public MainContainerPresenter(MainContainer mainContainer)
        {
            _mainContainer = mainContainer;
            _editorFactory = Documento.getInstance().EditorFactory;
            _deleters = new Dictionary<Type, Deleter>();
            FillDeleters();
            FillNuovoMenu();
            OnLibreriaChange(this, EventArgs.Empty);
            _mainContainer.CambiaModelloButton.Click += OnModelChangeClick;
            _mainContainer.LibreriaView.MouseDoubleClick += OnLibreriaDoubleClick;
            _mainContainer.LibreriaView.MouseClick += OnLibreriaClick;
            _mainContainer.NuovoProgetto.Click += OnNuovoProgettoClick;
            Documento.getInstance().LibreriaChanged += OnLibreriaChange;

        }

        private void FillDeleters()
        {
            ILibreria l = Documento.getInstance().Libreria;
            _deleters.Add(typeof(ImmagineFissa), l.EliminaImmagineFissa);
            _deleters.Add(typeof(Animazione), l.EliminaAnimazione);
            _deleters.Add(typeof(Sequenza), l.EliminaSequenza);
            _deleters.Add(typeof(ProgrammazioneGiornaliera), l.EliminaProgrGiornaliera);
        }
        private void FillNuovoMenu()
        {
            foreach (string name in _editorFactory.Names)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(name);
                item.Tag = _editorFactory.GetTagFromName(name);
                item.Click += OnNewClick;
                _mainContainer.NuovoMenu.DropDownItems.Add(item);
            }
        }
        private void FillImmaginiFisseNode(TreeNode node)
        {
            foreach (PersisterMapper<ImmagineFissa> imm in Documento.getInstance().Libreria.ImmaginiFisse)
            {
                TreeNode immNode = new TreeNode(imm.Element.Nome + " (Immagine Fissa)");
                immNode.Tag = imm;
                node.Nodes.Add(immNode);
            }
        }
        private void FillAnimazioniNode(TreeNode node)
        {
            foreach (PersisterMapper<Animazione> a in Documento.getInstance().Libreria.Animazioni)
            {
                TreeNode aNode = new TreeNode(a.Element.Nome + " (Animazione)");
                aNode.Tag = a;
                node.Nodes.Add(aNode);
            }
        }
        private void FillSequenzeNode(TreeNode node)
        {
            foreach (PersisterMapper<Sequenza> s in Documento.getInstance().Libreria.Sequenze)
            {
                TreeNode sNode = new TreeNode(s.Element.Nome);
                sNode.Tag = s;
                node.Nodes.Add(sNode);
            }
        }
        private bool Conferma()
        {
            if (null != _currentEditorHandler || null != _progettoPresenter) {
                return DialogResult.Yes == MessageBox.Show(null, "I dati non salvati verranno persi: sei sicuro?", "Attenzione", MessageBoxButtons.YesNo);
            }
            return true;
        }
        private void FillProgrammazioniGiornaliereNode(TreeNode node)
        {
            foreach (PersisterMapper<ProgrammazioneGiornaliera> p in Documento.getInstance().Libreria.ProgrGiornaliere)
            {
                TreeNode pNode = new TreeNode(p.Element.Nome);
                pNode.Tag = p;
                node.Nodes.Add(pNode);
            }
        }
        private IEditorPresenter ChangePresenter(Type modelType)
        {
            if (Conferma())
            {
                _mainContainer.MenuModifica.Enabled = false;
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
                    if (null != _progettoPresenter)
                    {
                        item.Click -= _progettoPresenter.OnSave;
                    }
                    item.Click += _currentEditorHandler.OnSave;
                }
                _progettoPresenter = null;
            }          
            return _currentEditorHandler;
        }

        #region EventHandlers
        private void OnNuovoProgettoClick(object sender, EventArgs args)
        {
            if (Conferma())
            {
                _progettoPresenter = new ProgrammazioneEditorPresenter(_editorFactory);
                _mainContainer.RightPanel.Controls.Clear();
                _mainContainer.RightPanel.Controls.Add(_progettoPresenter.Editor);
                foreach (ToolStripItem item in _mainContainer.SaveItems)
                {
                    item.Enabled = true;
                    if (null != _currentEditorHandler)
                    {
                        item.Click -= _currentEditorHandler.OnSave;
                    }
                    if (null != _progettoPresenter)
                    {
                        item.Click -= _progettoPresenter.OnSave;
                    }
                    item.Click += _progettoPresenter.OnSave;
                }
                _currentEditorHandler = null;
                _mainContainer.MenuModifica.Enabled = true;
            }
        }
        private void OnLibreriaChange(object sender, EventArgs args)
        {
            TreeNodeCollection nodes = _mainContainer.LibreriaView.Nodes;
            nodes.Clear();
            TreeNode elementi = ELEMENTI_NODE;
            elementi.Nodes.Clear();
            FillImmaginiFisseNode(elementi);
            FillAnimazioniNode(elementi);
            TreeNode sequenze = SEQUENZE_NODE;
            sequenze.Nodes.Clear();
            FillSequenzeNode(sequenze);
            TreeNode progr = PROG_NODE;
            progr.Nodes.Clear();
            FillProgrammazioniGiornaliereNode(progr);
            if (elementi.Nodes.Count != 0) nodes.Add(elementi);
            if (sequenze.Nodes.Count != 0) nodes.Add(sequenze);
            if (progr.Nodes.Count != 0) nodes.Add(progr);
            _mainContainer.LibreriaView.ExpandAll();
        }
        private void OnModelChangeClick(object sender, EventArgs args)
        {
            Documento.getInstance().ModelloRiferimento = ModelPane.ShowModelDialog(Documento.getInstance().ModelloRiferimento) ?? Documento.getInstance().ModelloRiferimento;
            _mainContainer.RightPanel.Controls.Clear();
            foreach (ToolStripItem item in _mainContainer.SaveItems)
            {
                item.Enabled = false;
            }
        }
        private void OnLibreriaDoubleClick(object sender, MouseEventArgs args)
        {
            TreeNode clicked = _mainContainer.LibreriaView.GetNodeAt(new System.Drawing.Point(args.X, args.Y));
            if (null == clicked.Tag) return;
            PersisterMapper obj = (clicked.Tag as PersisterMapper);
            if (null == obj) return;
            IEditorPresenter presenter = ChangePresenter(obj.Element.GetType());
            presenter.CaricaModello(obj.Copy());
        }
        private void OnLibreriaClick(object sender, MouseEventArgs args)
        {
            TreeView view = _mainContainer.LibreriaView;
            Point click = new Point(args.X, args.Y);
            TreeNode node = view.GetNodeAt(click);
            view.SelectedNode = node;
            if (null == node.Parent)
            {
                return;
            }
            if (args.Button == MouseButtons.Right)
            {
                view.ContextMenuStrip.Show(view, click);
                ILibreria l = Documento.getInstance().Libreria;
                PersisterMapper mapper = (PersisterMapper)node.Tag;
                _mainContainer.Elimina.Click += (object s, EventArgs a) => { _deleters[mapper.Element.GetType()](mapper.ID); };
            }
        }
        private void OnNewClick(object sender, EventArgs args)
        {
            ToolStripItem source = (ToolStripItem)sender;
            if (null == source) return;
            ChangePresenter((Type)source.Tag);
        }
        #endregion
    }
}
