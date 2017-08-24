namespace Signum.View
{
    partial class ProgrammazioneEditor
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this._venCombo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this._lunCombo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this._marCombo = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this._merCombo = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this._gioCombo = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this._sabCombo = new System.Windows.Forms.ComboBox();
            this._domCombo = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nuovaProgrammazioneGiornaliera = new System.Windows.Forms.ToolStripMenuItem();
            this._sottoEditorPanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._sottoEditorPanel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(670, 606);
            this.tableLayoutPanel1.TabIndex = 44;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 600);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.menuStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 552);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(329, 48);
            this.panel2.TabIndex = 61;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this._venCombo);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this._lunCombo);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this._marCombo);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this._merCombo);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this._gioCombo);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this._sabCombo);
            this.panel3.Controls.Add(this._domCombo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(329, 552);
            this.panel3.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(64, 325);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 76;
            this.label8.Text = "Domenica";
            // 
            // _venCombo
            // 
            this._venCombo.FormattingEnabled = true;
            this._venCombo.Location = new System.Drawing.Point(144, 263);
            this._venCombo.Name = "_venCombo";
            this._venCombo.Size = new System.Drawing.Size(121, 21);
            this._venCombo.TabIndex = 66;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(64, 298);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 75;
            this.label9.Text = "Sabato";
            // 
            // _lunCombo
            // 
            this._lunCombo.FormattingEnabled = true;
            this._lunCombo.Location = new System.Drawing.Point(144, 155);
            this._lunCombo.Name = "_lunCombo";
            this._lunCombo.Size = new System.Drawing.Size(121, 21);
            this._lunCombo.TabIndex = 61;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(64, 271);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 74;
            this.label10.Text = "Venerdì";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(64, 244);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 73;
            this.label11.Text = "Giovedì";
            // 
            // _marCombo
            // 
            this._marCombo.FormattingEnabled = true;
            this._marCombo.Location = new System.Drawing.Point(144, 182);
            this._marCombo.Name = "_marCombo";
            this._marCombo.Size = new System.Drawing.Size(121, 21);
            this._marCombo.TabIndex = 63;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(64, 217);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 72;
            this.label12.Text = "Mercoledì";
            // 
            // _merCombo
            // 
            this._merCombo.FormattingEnabled = true;
            this._merCombo.Location = new System.Drawing.Point(144, 209);
            this._merCombo.Name = "_merCombo";
            this._merCombo.Size = new System.Drawing.Size(121, 21);
            this._merCombo.TabIndex = 64;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(64, 190);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 71;
            this.label13.Text = "Martedì";
            // 
            // _gioCombo
            // 
            this._gioCombo.FormattingEnabled = true;
            this._gioCombo.Location = new System.Drawing.Point(144, 236);
            this._gioCombo.Name = "_gioCombo";
            this._gioCombo.Size = new System.Drawing.Size(121, 21);
            this._gioCombo.TabIndex = 65;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(64, 163);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 13);
            this.label14.TabIndex = 70;
            this.label14.Text = "Lunedì";
            // 
            // _sabCombo
            // 
            this._sabCombo.FormattingEnabled = true;
            this._sabCombo.Location = new System.Drawing.Point(144, 290);
            this._sabCombo.Name = "_sabCombo";
            this._sabCombo.Size = new System.Drawing.Size(121, 21);
            this._sabCombo.TabIndex = 67;
            // 
            // _domCombo
            // 
            this._domCombo.FormattingEnabled = true;
            this._domCombo.Location = new System.Drawing.Point(144, 317);
            this._domCombo.Name = "_domCombo";
            this._domCombo.Size = new System.Drawing.Size(121, 21);
            this._domCombo.TabIndex = 68;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuovaProgrammazioneGiornaliera});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(329, 48);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // nuovaProgrammazioneGiornaliera
            // 
            this.nuovaProgrammazioneGiornaliera.Name = "nuovaProgrammazioneGiornaliera";
            this.nuovaProgrammazioneGiornaliera.Size = new System.Drawing.Size(54, 44);
            this.nuovaProgrammazioneGiornaliera.Text = "Nuova";
            // 
            // _sottoEditorPanel
            // 
            this._sottoEditorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._sottoEditorPanel.Location = new System.Drawing.Point(338, 3);
            this._sottoEditorPanel.Name = "_sottoEditorPanel";
            this._sottoEditorPanel.Size = new System.Drawing.Size(329, 600);
            this._sottoEditorPanel.TabIndex = 1;
            // 
            // ProgrammazioneEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProgrammazioneEditor";
            this.Size = new System.Drawing.Size(670, 606);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox _venCombo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox _lunCombo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox _marCombo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox _merCombo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox _gioCombo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox _sabCombo;
        private System.Windows.Forms.ComboBox _domCombo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem nuovaProgrammazioneGiornaliera;
        private System.Windows.Forms.Panel _sottoEditorPanel;
    }
}
