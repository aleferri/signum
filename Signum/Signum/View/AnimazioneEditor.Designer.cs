namespace Signum.View
{
    partial class AnimazioneEditor
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
            this._tabControl = new System.Windows.Forms.TabControl();
            this._tabNewPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._framerateNumeric = new System.Windows.Forms.NumericUpDown();
            this._tabContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.spostaASinistraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spostaADestraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._tabControl.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._framerateNumeric)).BeginInit();
            this._tabContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tabControl
            // 
            this._tabControl.Controls.Add(this._tabNewPage);
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.Location = new System.Drawing.Point(0, 39);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(642, 496);
            this._tabControl.TabIndex = 0;
            // 
            // _tabNewPage
            // 
            this._tabNewPage.Location = new System.Drawing.Point(4, 22);
            this._tabNewPage.Name = "_tabNewPage";
            this._tabNewPage.Padding = new System.Windows.Forms.Padding(3);
            this._tabNewPage.Size = new System.Drawing.Size(634, 470);
            this._tabNewPage.TabIndex = 1;
            this._tabNewPage.Text = "+";
            this._tabNewPage.ToolTipText = "Aggiungi un frame";
            this._tabNewPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._framerateNumeric);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(642, 39);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Framerate";
            // 
            // _framerateNumeric
            // 
            this._framerateNumeric.Location = new System.Drawing.Point(7, 13);
            this._framerateNumeric.Name = "_framerateNumeric";
            this._framerateNumeric.Size = new System.Drawing.Size(120, 20);
            this._framerateNumeric.TabIndex = 0;
            // 
            // _tabContextMenu
            // 
            this._tabContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spostaASinistraToolStripMenuItem,
            this.spostaADestraToolStripMenuItem,
            this.eliminaToolStripMenuItem});
            this._tabContextMenu.Name = "_tabContextMenu";
            this._tabContextMenu.Size = new System.Drawing.Size(159, 70);
            // 
            // spostaASinistraToolStripMenuItem
            // 
            this.spostaASinistraToolStripMenuItem.Name = "spostaASinistraToolStripMenuItem";
            this.spostaASinistraToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.spostaASinistraToolStripMenuItem.Text = "Sposta a sinistra";
            // 
            // spostaADestraToolStripMenuItem
            // 
            this.spostaADestraToolStripMenuItem.Name = "spostaADestraToolStripMenuItem";
            this.spostaADestraToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.spostaADestraToolStripMenuItem.Text = "Sposta a destra";
            // 
            // eliminaToolStripMenuItem
            // 
            this.eliminaToolStripMenuItem.Name = "eliminaToolStripMenuItem";
            this.eliminaToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.eliminaToolStripMenuItem.Text = "Elimina";
            // 
            // AnimazioneEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tabControl);
            this.Controls.Add(this.groupBox1);
            this.Name = "AnimazioneEditor";
            this.Size = new System.Drawing.Size(642, 535);
            this._tabControl.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._framerateNumeric)).EndInit();
            this._tabContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TabPage _tabNewPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown _framerateNumeric;
        private System.Windows.Forms.ContextMenuStrip _tabContextMenu;
        private System.Windows.Forms.ToolStripMenuItem spostaASinistraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spostaADestraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminaToolStripMenuItem;
    }
}
