namespace Signum.View
{
    partial class ProgrammazioneGiornalieraEditor
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
            this._sequenzaFlowTop = new System.Windows.Forms.FlowLayoutPanel();
            this._midnightLabel = new System.Windows.Forms.Label();
            this._middayLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._sequenzaFlowBottom = new System.Windows.Forms.FlowLayoutPanel();
            this._midnightLabel2 = new System.Windows.Forms.Label();
            this._middayLabel2 = new System.Windows.Forms.Label();
            this._editorContainer = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this._nomeField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._startPicker = new Signum.View.Utils.TimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this._endPicker = new Signum.View.Utils.TimePicker();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this._labelMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._nuovaSequenzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aggiungiSequenzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._eliminaSequenzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._rinominaSequenzaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._sequenzaFlowTop.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this._sequenzaFlowBottom.SuspendLayout();
            this._editorContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this._labelMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _sequenzaFlowTop
            // 
            this._sequenzaFlowTop.Controls.Add(this._midnightLabel);
            this._sequenzaFlowTop.Controls.Add(this._middayLabel);
            this._sequenzaFlowTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this._sequenzaFlowTop.Location = new System.Drawing.Point(3, 3);
            this._sequenzaFlowTop.Name = "_sequenzaFlowTop";
            this._sequenzaFlowTop.Size = new System.Drawing.Size(808, 50);
            this._sequenzaFlowTop.TabIndex = 0;
            // 
            // _midnightLabel
            // 
            this._midnightLabel.Location = new System.Drawing.Point(3, 0);
            this._midnightLabel.Name = "_midnightLabel";
            this._midnightLabel.Size = new System.Drawing.Size(35, 50);
            this._midnightLabel.TabIndex = 0;
            this._midnightLabel.Text = "00:00";
            this._midnightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _middayLabel
            // 
            this._middayLabel.Location = new System.Drawing.Point(44, 0);
            this._middayLabel.Name = "_middayLabel";
            this._middayLabel.Size = new System.Drawing.Size(35, 50);
            this._middayLabel.TabIndex = 1;
            this._middayLabel.Text = "12:00";
            this._middayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this._sequenzaFlowTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this._sequenzaFlowBottom, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(814, 112);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // _sequenzaFlowBottom
            // 
            this._sequenzaFlowBottom.Controls.Add(this._midnightLabel2);
            this._sequenzaFlowBottom.Controls.Add(this._middayLabel2);
            this._sequenzaFlowBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this._sequenzaFlowBottom.Location = new System.Drawing.Point(3, 59);
            this._sequenzaFlowBottom.Name = "_sequenzaFlowBottom";
            this._sequenzaFlowBottom.Size = new System.Drawing.Size(808, 50);
            this._sequenzaFlowBottom.TabIndex = 1;
            // 
            // _midnightLabel2
            // 
            this._midnightLabel2.Location = new System.Drawing.Point(3, 0);
            this._midnightLabel2.Name = "_midnightLabel2";
            this._midnightLabel2.Size = new System.Drawing.Size(35, 50);
            this._midnightLabel2.TabIndex = 2;
            this._midnightLabel2.Text = "00:00";
            this._midnightLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _middayLabel2
            // 
            this._middayLabel2.Location = new System.Drawing.Point(44, 0);
            this._middayLabel2.Name = "_middayLabel2";
            this._middayLabel2.Size = new System.Drawing.Size(35, 50);
            this._middayLabel2.TabIndex = 3;
            this._middayLabel2.Text = "12:00";
            this._middayLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _editorContainer
            // 
            this._editorContainer.Controls.Add(this.groupBox1);
            this._editorContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._editorContainer.Location = new System.Drawing.Point(0, 112);
            this._editorContainer.Name = "_editorContainer";
            this._editorContainer.Size = new System.Drawing.Size(814, 543);
            this._editorContainer.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 44);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informazioni Sequenza";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this._nomeField);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this._startPicker);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this._endPicker);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(808, 25);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome Sequenza";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _nomeField
            // 
            this._nomeField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._nomeField.Enabled = false;
            this._nomeField.Location = new System.Drawing.Point(109, 3);
            this._nomeField.Name = "_nomeField";
            this._nomeField.Size = new System.Drawing.Size(150, 20);
            this._nomeField.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(265, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Orario Inizio";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _startPicker
            // 
            this._startPicker.CanGoDown = true;
            this._startPicker.CanGoUp = true;
            this._startPicker.InitValue = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this._startPicker.Location = new System.Drawing.Point(371, 3);
            this._startPicker.MinuteInterval = 1;
            this._startPicker.Name = "_startPicker";
            this._startPicker.Size = new System.Drawing.Size(120, 20);
            this._startPicker.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(497, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Orario Fine";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _endPicker
            // 
            this._endPicker.CanGoDown = true;
            this._endPicker.CanGoUp = true;
            this._endPicker.InitValue = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this._endPicker.Location = new System.Drawing.Point(603, 3);
            this._endPicker.MinuteInterval = 1;
            this._endPicker.Name = "_endPicker";
            this._endPicker.Size = new System.Drawing.Size(120, 20);
            this._endPicker.TabIndex = 7;
            // 
            // _labelMenuStrip
            // 
            this._labelMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._nuovaSequenzaToolStripMenuItem,
            this._aggiungiSequenzaToolStripMenuItem,
            this.toolStripSeparator1,
            this._eliminaSequenzaToolStripMenuItem,
            this._rinominaSequenzaToolStripMenuItem});
            this._labelMenuStrip.Name = "_labelMenuStrip";
            this._labelMenuStrip.Size = new System.Drawing.Size(179, 98);
            // 
            // _nuovaSequenzaToolStripMenuItem
            // 
            this._nuovaSequenzaToolStripMenuItem.Name = "_nuovaSequenzaToolStripMenuItem";
            this._nuovaSequenzaToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this._nuovaSequenzaToolStripMenuItem.Text = "Nuova Sequenza";
            // 
            // _aggiungiSequenzaToolStripMenuItem
            // 
            this._aggiungiSequenzaToolStripMenuItem.Name = "_aggiungiSequenzaToolStripMenuItem";
            this._aggiungiSequenzaToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this._aggiungiSequenzaToolStripMenuItem.Text = "Aggiungi Sequenza";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
            // 
            // _eliminaSequenzaToolStripMenuItem
            // 
            this._eliminaSequenzaToolStripMenuItem.Name = "_eliminaSequenzaToolStripMenuItem";
            this._eliminaSequenzaToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this._eliminaSequenzaToolStripMenuItem.Text = "Elimina Sequenza";
            // 
            // _rinominaSequenzaToolStripMenuItem
            // 
            this._rinominaSequenzaToolStripMenuItem.Name = "_rinominaSequenzaToolStripMenuItem";
            this._rinominaSequenzaToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this._rinominaSequenzaToolStripMenuItem.Text = "Rinomina Sequenza";
            // 
            // ProgrammazioneGiornalieraEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._editorContainer);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Name = "ProgrammazioneGiornalieraEditor";
            this.Size = new System.Drawing.Size(814, 655);
            this._sequenzaFlowTop.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this._sequenzaFlowBottom.ResumeLayout(false);
            this._editorContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this._labelMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel _sequenzaFlowTop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label _midnightLabel;
        private System.Windows.Forms.Label _middayLabel;
        private System.Windows.Forms.FlowLayoutPanel _sequenzaFlowBottom;
        private System.Windows.Forms.Label _midnightLabel2;
        private System.Windows.Forms.Label _middayLabel2;
        private System.Windows.Forms.Panel _editorContainer;
        private System.Windows.Forms.ToolTip _toolTip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _nomeField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Utils.TimePicker _startPicker;
        private Utils.TimePicker _endPicker;
        private System.Windows.Forms.ContextMenuStrip _labelMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem _nuovaSequenzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _aggiungiSequenzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem _eliminaSequenzaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _rinominaSequenzaToolStripMenuItem;
    }
}
