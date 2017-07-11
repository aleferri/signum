namespace Signum.View
{
    partial class SequenzaEditor
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
            this._splitContainer = new System.Windows.Forms.SplitContainer();
            this._elementList = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._aggiungiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.daLibreriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._nomeSequenza = new System.Windows.Forms.TextBox();
            this._groupBox1 = new System.Windows.Forms.GroupBox();
            this._nomeField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._durataUpDown = new System.Windows.Forms.NumericUpDown();
            this._elementoContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._eliminaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._spostaSuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._spostaGiuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).BeginInit();
            this._splitContainer.Panel1.SuspendLayout();
            this._splitContainer.Panel2.SuspendLayout();
            this._splitContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this._groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._durataUpDown)).BeginInit();
            this._elementoContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _splitContainer
            // 
            this._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._splitContainer.Location = new System.Drawing.Point(0, 0);
            this._splitContainer.Name = "_splitContainer";
            // 
            // _splitContainer.Panel1
            // 
            this._splitContainer.Panel1.Controls.Add(this._elementList);
            this._splitContainer.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // _splitContainer.Panel2
            // 
            this._splitContainer.Panel2.Controls.Add(this._groupBox1);
            this._splitContainer.Size = new System.Drawing.Size(752, 511);
            this._splitContainer.SplitterDistance = 250;
            this._splitContainer.TabIndex = 0;
            // 
            // _elementList
            // 
            this._elementList.ContextMenuStrip = this._elementoContextMenu;
            this._elementList.Dock = System.Windows.Forms.DockStyle.Fill;
            this._elementList.FormattingEnabled = true;
            this._elementList.Location = new System.Drawing.Point(0, 0);
            this._elementList.Name = "_elementList";
            this._elementList.Size = new System.Drawing.Size(250, 411);
            this._elementList.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 411);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 100);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.menuStrip1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(244, 44);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aggiungiToolStripMenuItem,
            this.daLibreriaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(202, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _aggiungiToolStripMenuItem
            // 
            this._aggiungiToolStripMenuItem.Name = "_aggiungiToolStripMenuItem";
            this._aggiungiToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this._aggiungiToolStripMenuItem.Text = "Aggiungi";
            // 
            // daLibreriaToolStripMenuItem
            // 
            this.daLibreriaToolStripMenuItem.Name = "daLibreriaToolStripMenuItem";
            this.daLibreriaToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.daLibreriaToolStripMenuItem.Text = "Aggiungi da Libreria";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._nomeSequenza);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 44);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nome Sequenza";
            // 
            // _nomeSequenza
            // 
            this._nomeSequenza.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._nomeSequenza.Location = new System.Drawing.Point(7, 20);
            this._nomeSequenza.Name = "_nomeSequenza";
            this._nomeSequenza.Size = new System.Drawing.Size(231, 20);
            this._nomeSequenza.TabIndex = 0;
            // 
            // _groupBox1
            // 
            this._groupBox1.Controls.Add(this._nomeField);
            this._groupBox1.Controls.Add(this.label2);
            this._groupBox1.Controls.Add(this.label1);
            this._groupBox1.Controls.Add(this._durataUpDown);
            this._groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this._groupBox1.Location = new System.Drawing.Point(0, 0);
            this._groupBox1.Name = "_groupBox1";
            this._groupBox1.Size = new System.Drawing.Size(498, 48);
            this._groupBox1.TabIndex = 0;
            this._groupBox1.TabStop = false;
            this._groupBox1.Text = "Informazioni Elemento";
            // 
            // _nomeField
            // 
            this._nomeField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._nomeField.Location = new System.Drawing.Point(212, 18);
            this._nomeField.Name = "_nomeField";
            this._nomeField.Size = new System.Drawing.Size(280, 20);
            this._nomeField.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Durata (s)";
            // 
            // _durataUpDown
            // 
            this._durataUpDown.Location = new System.Drawing.Point(65, 19);
            this._durataUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._durataUpDown.Name = "_durataUpDown";
            this._durataUpDown.Size = new System.Drawing.Size(92, 20);
            this._durataUpDown.TabIndex = 0;
            this._durataUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _elementoContextMenu
            // 
            this._elementoContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._eliminaToolStripMenuItem,
            this._spostaSuToolStripMenuItem,
            this._spostaGiuToolStripMenuItem});
            this._elementoContextMenu.Name = "_elementoContextMenu";
            this._elementoContextMenu.Size = new System.Drawing.Size(153, 92);
            // 
            // _eliminaToolStripMenuItem
            // 
            this._eliminaToolStripMenuItem.Name = "_eliminaToolStripMenuItem";
            this._eliminaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this._eliminaToolStripMenuItem.Text = "Elimina";
            // 
            // _spostaSuToolStripMenuItem
            // 
            this._spostaSuToolStripMenuItem.Name = "_spostaSuToolStripMenuItem";
            this._spostaSuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this._spostaSuToolStripMenuItem.Text = "Sposta Su";
            // 
            // _spostaGiuToolStripMenuItem
            // 
            this._spostaGiuToolStripMenuItem.Name = "_spostaGiuToolStripMenuItem";
            this._spostaGiuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this._spostaGiuToolStripMenuItem.Text = "Sposta Giù";
            // 
            // SequenzaEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._splitContainer);
            this.Name = "SequenzaEditor";
            this.Size = new System.Drawing.Size(752, 511);
            this._splitContainer.Panel1.ResumeLayout(false);
            this._splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).EndInit();
            this._splitContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this._groupBox1.ResumeLayout(false);
            this._groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._durataUpDown)).EndInit();
            this._elementoContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer _splitContainer;
        private System.Windows.Forms.ListBox _elementList;
        private System.Windows.Forms.GroupBox _groupBox1;
        private System.Windows.Forms.NumericUpDown _durataUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _nomeField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox _nomeSequenza;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _aggiungiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem daLibreriaToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip _elementoContextMenu;
        private System.Windows.Forms.ToolStripMenuItem _eliminaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _spostaSuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _spostaGiuToolStripMenuItem;
    }
}
