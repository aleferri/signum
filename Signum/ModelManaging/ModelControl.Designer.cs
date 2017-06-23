namespace ModelManaging
{
    partial class ModelControl
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._groupBox = new System.Windows.Forms.GroupBox();
            this._tablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this._comboBox = new System.Windows.Forms.ComboBox();
            this._previewPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this._groupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._groupBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._previewPanel);
            this.splitContainer1.Size = new System.Drawing.Size(733, 623);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.TabIndex = 0;
            // 
            // _groupBox
            // 
            this._groupBox.Controls.Add(this._tablePanel);
            this._groupBox.Controls.Add(this.panel1);
            this._groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._groupBox.Location = new System.Drawing.Point(0, 0);
            this._groupBox.Name = "_groupBox";
            this._groupBox.Size = new System.Drawing.Size(244, 623);
            this._groupBox.TabIndex = 0;
            this._groupBox.TabStop = false;
            this._groupBox.Text = "Impostazione Modello";
            // 
            // _tablePanel
            // 
            this._tablePanel.ColumnCount = 2;
            this._tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this._tablePanel.Location = new System.Drawing.Point(3, 76);
            this._tablePanel.Name = "_tablePanel";
            this._tablePanel.RowCount = 1;
            this._tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tablePanel.Size = new System.Drawing.Size(238, 531);
            this._tablePanel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._comboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 54);
            this.panel1.TabIndex = 1;
            // 
            // _comboBox
            // 
            this._comboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBox.FormattingEnabled = true;
            this._comboBox.Location = new System.Drawing.Point(3, 17);
            this._comboBox.Name = "_comboBox";
            this._comboBox.Size = new System.Drawing.Size(232, 21);
            this._comboBox.TabIndex = 0;
            // 
            // _previewPanel
            // 
            this._previewPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._previewPanel.Location = new System.Drawing.Point(0, 0);
            this._previewPanel.Name = "_previewPanel";
            this._previewPanel.Size = new System.Drawing.Size(485, 623);
            this._previewPanel.TabIndex = 0;
            // 
            // ModelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ModelControl";
            this.Size = new System.Drawing.Size(733, 623);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this._groupBox.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox _groupBox;
        private System.Windows.Forms.TableLayoutPanel _tablePanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox _comboBox;
        private System.Windows.Forms.Panel _previewPanel;
    }
}
