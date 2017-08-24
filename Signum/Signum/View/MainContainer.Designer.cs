namespace Signum.View
{
    partial class MainContainer
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._nuovoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._nuovoProgettoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._apriProgettoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._salvaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._cambiaModelloDiRiferimentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._modificaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._leftArrowButton = new System.Windows.Forms.ToolStripButton();
            this._rightArrowButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._salvaTooltipButton = new System.Windows.Forms.ToolStripButton();
            this._outerSplitContainer = new System.Windows.Forms.SplitContainer();
            this._libreriaTreeView = new System.Windows.Forms.TreeView();
            this._contextMenuTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._eliminaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esportaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._outerSplitContainer)).BeginInit();
            this._outerSplitContainer.Panel1.SuspendLayout();
            this._outerSplitContainer.SuspendLayout();
            this._contextMenuTreeView.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._fileToolStripMenuItem,
            this._modificaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(898, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _fileToolStripMenuItem
            // 
            this._fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._nuovoToolStripMenuItem,
            this._nuovoProgettoToolStripMenuItem,
            this._apriProgettoToolStripMenuItem,
            this._salvaToolStripMenuItem,
            this.toolStripSeparator2,
            this._cambiaModelloDiRiferimentoToolStripMenuItem});
            this._fileToolStripMenuItem.Name = "_fileToolStripMenuItem";
            this._fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this._fileToolStripMenuItem.Text = "File";
            // 
            // _nuovoToolStripMenuItem
            // 
            this._nuovoToolStripMenuItem.Image = global::Signum.Properties.Resources.new1;
            this._nuovoToolStripMenuItem.Name = "_nuovoToolStripMenuItem";
            this._nuovoToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this._nuovoToolStripMenuItem.Text = "Nuovo...";
            this._nuovoToolStripMenuItem.ToolTipText = "Crea un nuovo progetto";
            // 
            // _nuovoProgettoToolStripMenuItem
            // 
            this._nuovoProgettoToolStripMenuItem.Name = "_nuovoProgettoToolStripMenuItem";
            this._nuovoProgettoToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this._nuovoProgettoToolStripMenuItem.Text = "Nuovo Progetto";
            // 
            // _apriProgettoToolStripMenuItem
            // 
            this._apriProgettoToolStripMenuItem.Name = "_apriProgettoToolStripMenuItem";
            this._apriProgettoToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this._apriProgettoToolStripMenuItem.Text = "Apri Progetto";
            // 
            // _salvaToolStripMenuItem
            // 
            this._salvaToolStripMenuItem.Enabled = false;
            this._salvaToolStripMenuItem.Image = global::Signum.Properties.Resources.salva1;
            this._salvaToolStripMenuItem.Name = "_salvaToolStripMenuItem";
            this._salvaToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this._salvaToolStripMenuItem.Text = "Salva...";
            this._salvaToolStripMenuItem.ToolTipText = "Salva le modifiche correnti";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(234, 6);
            // 
            // _cambiaModelloDiRiferimentoToolStripMenuItem
            // 
            this._cambiaModelloDiRiferimentoToolStripMenuItem.Name = "_cambiaModelloDiRiferimentoToolStripMenuItem";
            this._cambiaModelloDiRiferimentoToolStripMenuItem.Size = new System.Drawing.Size(237, 22);
            this._cambiaModelloDiRiferimentoToolStripMenuItem.Text = "Cambia modello di riferimento";
            // 
            // _modificaToolStripMenuItem
            // 
            this._modificaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.esportaToolStripMenuItem});
            this._modificaToolStripMenuItem.Enabled = false;
            this._modificaToolStripMenuItem.Name = "_modificaToolStripMenuItem";
            this._modificaToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this._modificaToolStripMenuItem.Text = "Modifica";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._leftArrowButton,
            this._rightArrowButton,
            this.toolStripSeparator1,
            this._salvaTooltipButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(898, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _leftArrowButton
            // 
            this._leftArrowButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._leftArrowButton.Enabled = false;
            this._leftArrowButton.Image = global::Signum.Properties.Resources.leftArrow;
            this._leftArrowButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._leftArrowButton.Name = "_leftArrowButton";
            this._leftArrowButton.Size = new System.Drawing.Size(23, 22);
            this._leftArrowButton.Text = "Torna indietro di un passo";
            // 
            // _rightArrowButton
            // 
            this._rightArrowButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._rightArrowButton.Enabled = false;
            this._rightArrowButton.Image = global::Signum.Properties.Resources.rightArrow;
            this._rightArrowButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rightArrowButton.Name = "_rightArrowButton";
            this._rightArrowButton.Size = new System.Drawing.Size(23, 22);
            this._rightArrowButton.Text = "Avanza di un passo";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _salvaTooltipButton
            // 
            this._salvaTooltipButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._salvaTooltipButton.Enabled = false;
            this._salvaTooltipButton.Image = global::Signum.Properties.Resources.salva1;
            this._salvaTooltipButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._salvaTooltipButton.Name = "_salvaTooltipButton";
            this._salvaTooltipButton.Size = new System.Drawing.Size(23, 22);
            this._salvaTooltipButton.Text = "Salva";
            // 
            // _outerSplitContainer
            // 
            this._outerSplitContainer.BackColor = System.Drawing.SystemColors.Control;
            this._outerSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._outerSplitContainer.Location = new System.Drawing.Point(0, 49);
            this._outerSplitContainer.Name = "_outerSplitContainer";
            // 
            // _outerSplitContainer.Panel1
            // 
            this._outerSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this._outerSplitContainer.Panel1.Controls.Add(this._libreriaTreeView);
            // 
            // _outerSplitContainer.Panel2
            // 
            this._outerSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this._outerSplitContainer.Size = new System.Drawing.Size(898, 553);
            this._outerSplitContainer.SplitterDistance = 131;
            this._outerSplitContainer.SplitterWidth = 2;
            this._outerSplitContainer.TabIndex = 2;
            // 
            // _libreriaTreeView
            // 
            this._libreriaTreeView.ContextMenuStrip = this._contextMenuTreeView;
            this._libreriaTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._libreriaTreeView.Location = new System.Drawing.Point(0, 0);
            this._libreriaTreeView.Name = "_libreriaTreeView";
            this._libreriaTreeView.Size = new System.Drawing.Size(131, 553);
            this._libreriaTreeView.TabIndex = 0;
            // 
            // _contextMenuTreeView
            // 
            this._contextMenuTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._eliminaToolStripMenuItem});
            this._contextMenuTreeView.Name = "_contextMenuTreeView";
            this._contextMenuTreeView.Size = new System.Drawing.Size(114, 26);
            // 
            // _eliminaToolStripMenuItem
            // 
            this._eliminaToolStripMenuItem.Name = "_eliminaToolStripMenuItem";
            this._eliminaToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this._eliminaToolStripMenuItem.Text = "Elimina";
            // 
            // esportaToolStripMenuItem
            // 
            this.esportaToolStripMenuItem.Name = "esportaToolStripMenuItem";
            this.esportaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.esportaToolStripMenuItem.Text = "Esporta";
            // 
            // MainContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._outerSplitContainer);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainContainer";
            this.Size = new System.Drawing.Size(898, 602);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this._outerSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._outerSplitContainer)).EndInit();
            this._outerSplitContainer.ResumeLayout(false);
            this._contextMenuTreeView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem _fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton _rightArrowButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer _outerSplitContainer;
        private System.Windows.Forms.ToolStripButton _leftArrowButton;
        private System.Windows.Forms.ToolStripMenuItem _nuovoToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton _salvaTooltipButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem _salvaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _cambiaModelloDiRiferimentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _modificaToolStripMenuItem;
        private System.Windows.Forms.TreeView _libreriaTreeView;
        private System.Windows.Forms.ContextMenuStrip _contextMenuTreeView;
        private System.Windows.Forms.ToolStripMenuItem _eliminaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _nuovoProgettoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _apriProgettoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esportaToolStripMenuItem;
    }
}
