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
            this._moveLeftOption = new System.Windows.Forms.ToolStripMenuItem();
            this._moveRightOption = new System.Windows.Forms.ToolStripMenuItem();
            this._eliminaOption = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
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
            this._tabNewPage.Text = "+ Frame";
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
            this._framerateNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._framerateNumeric.Name = "_framerateNumeric";
            this._framerateNumeric.Size = new System.Drawing.Size(120, 20);
            this._framerateNumeric.TabIndex = 0;
            this._framerateNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _tabContextMenu
            // 
            this._tabContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._moveLeftOption,
            this._moveRightOption,
            this._eliminaOption});
            this._tabContextMenu.Name = "_tabContextMenu";
            this._tabContextMenu.Size = new System.Drawing.Size(159, 70);
            // 
            // _moveLeftOption
            // 
            this._moveLeftOption.Name = "_moveLeftOption";
            this._moveLeftOption.Size = new System.Drawing.Size(158, 22);
            this._moveLeftOption.Text = "Sposta a sinistra";
            // 
            // _moveRightOption
            // 
            this._moveRightOption.Name = "_moveRightOption";
            this._moveRightOption.Size = new System.Drawing.Size(158, 22);
            this._moveRightOption.Text = "Sposta a destra";
            // 
            // _eliminaOption
            // 
            this._eliminaOption.Name = "_eliminaOption";
            this._eliminaOption.Size = new System.Drawing.Size(158, 22);
            this._eliminaOption.Text = "Elimina";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 26);
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
        private System.Windows.Forms.ToolStripMenuItem _moveLeftOption;
        private System.Windows.Forms.ToolStripMenuItem _moveRightOption;
        private System.Windows.Forms.ToolStripMenuItem _eliminaOption;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}
