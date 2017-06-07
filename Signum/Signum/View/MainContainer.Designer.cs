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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._outerSplitContanier = new System.Windows.Forms.SplitContainer();
            this._innerSplitContainer = new System.Windows.Forms.SplitContainer();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._leftArrowButton = new System.Windows.Forms.ToolStripButton();
            this._rightArrowButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this._nuovoProgettoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apriProgettoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._outerSplitContanier)).BeginInit();
            this._outerSplitContanier.Panel2.SuspendLayout();
            this._outerSplitContanier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._innerSplitContainer)).BeginInit();
            this._innerSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(898, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._nuovoProgettoToolStripMenuItem,
            this.apriProgettoToolStripMenuItem,
            this.toolStripSeparator2,
            this.salvaToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._leftArrowButton,
            this._rightArrowButton,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(898, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _outerSplitContanier
            // 
            this._outerSplitContanier.BackColor = System.Drawing.Color.Black;
            this._outerSplitContanier.Dock = System.Windows.Forms.DockStyle.Fill;
            this._outerSplitContanier.Location = new System.Drawing.Point(0, 49);
            this._outerSplitContanier.Name = "_outerSplitContanier";
            // 
            // _outerSplitContanier.Panel1
            // 
            this._outerSplitContanier.Panel1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // _outerSplitContanier.Panel2
            // 
            this._outerSplitContanier.Panel2.Controls.Add(this._innerSplitContainer);
            this._outerSplitContanier.Size = new System.Drawing.Size(898, 553);
            this._outerSplitContanier.SplitterDistance = 200;
            this._outerSplitContanier.SplitterWidth = 2;
            this._outerSplitContanier.TabIndex = 2;
            // 
            // _innerSplitContainer
            // 
            this._innerSplitContainer.BackColor = System.Drawing.Color.Black;
            this._innerSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._innerSplitContainer.Location = new System.Drawing.Point(0, 0);
            this._innerSplitContainer.Name = "_innerSplitContainer";
            // 
            // _innerSplitContainer.Panel1
            // 
            this._innerSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // _innerSplitContainer.Panel2
            // 
            this._innerSplitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this._innerSplitContainer.Size = new System.Drawing.Size(696, 553);
            this._innerSplitContainer.SplitterDistance = 582;
            this._innerSplitContainer.SplitterWidth = 2;
            this._innerSplitContainer.TabIndex = 1;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(156, 6);
            // 
            // _leftArrowButton
            // 
            this._leftArrowButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._leftArrowButton.Image = global::Signum.Properties.Resources.leftArrow;
            this._leftArrowButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._leftArrowButton.Name = "_leftArrowButton";
            this._leftArrowButton.Size = new System.Drawing.Size(23, 22);
            this._leftArrowButton.Text = "Torna indietro di un passo";
            // 
            // _rightArrowButton
            // 
            this._rightArrowButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._rightArrowButton.Image = global::Signum.Properties.Resources.rightArrow;
            this._rightArrowButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._rightArrowButton.Name = "_rightArrowButton";
            this._rightArrowButton.Size = new System.Drawing.Size(23, 22);
            this._rightArrowButton.Text = "Avanza di un passo";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Signum.Properties.Resources.new1;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::Signum.Properties.Resources.salva1;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // _nuovoProgettoToolStripMenuItem
            // 
            this._nuovoProgettoToolStripMenuItem.Image = global::Signum.Properties.Resources.new1;
            this._nuovoProgettoToolStripMenuItem.Name = "_nuovoProgettoToolStripMenuItem";
            this._nuovoProgettoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this._nuovoProgettoToolStripMenuItem.Text = "Nuovo Progetto";
            this._nuovoProgettoToolStripMenuItem.ToolTipText = "Crea un nuovo progetto";
            // 
            // salvaToolStripMenuItem
            // 
            this.salvaToolStripMenuItem.Image = global::Signum.Properties.Resources.salva1;
            this.salvaToolStripMenuItem.Name = "salvaToolStripMenuItem";
            this.salvaToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.salvaToolStripMenuItem.Text = "Salva...";
            this.salvaToolStripMenuItem.ToolTipText = "Salva le modifiche correnti";
            // 
            // apriProgettoToolStripMenuItem
            // 
            this.apriProgettoToolStripMenuItem.Image = global::Signum.Properties.Resources.carica;
            this.apriProgettoToolStripMenuItem.Name = "apriProgettoToolStripMenuItem";
            this.apriProgettoToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.apriProgettoToolStripMenuItem.Text = "Apri progetto";
            // 
            // MainContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._outerSplitContanier);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainContainer";
            this.Size = new System.Drawing.Size(898, 602);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this._outerSplitContanier.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._outerSplitContanier)).EndInit();
            this._outerSplitContanier.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._innerSplitContainer)).EndInit();
            this._innerSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton _rightArrowButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer _outerSplitContanier;
        private System.Windows.Forms.SplitContainer _innerSplitContainer;
        private System.Windows.Forms.ToolStripButton _leftArrowButton;
        private System.Windows.Forms.ToolStripMenuItem _nuovoProgettoToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem salvaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apriProgettoToolStripMenuItem;
    }
}
