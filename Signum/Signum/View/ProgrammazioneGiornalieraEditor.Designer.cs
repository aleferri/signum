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
            this._startPicker = new System.Windows.Forms.DateTimePicker();
            this._toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this._endPicker = new System.Windows.Forms.DateTimePicker();
            this._sequenzaFlowTop.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this._sequenzaFlowBottom.SuspendLayout();
            this._editorContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
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
            this._startPicker.CustomFormat = "HH:mm";
            this._startPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._startPicker.Location = new System.Drawing.Point(371, 3);
            this._startPicker.Name = "_startPicker";
            this._startPicker.ShowUpDown = true;
            this._startPicker.Size = new System.Drawing.Size(86, 20);
            this._startPicker.TabIndex = 2;
            this._startPicker.Value = new System.DateTime(2017, 7, 21, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(463, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Orario Fine";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _endPicker
            // 
            this._endPicker.CustomFormat = "HH:mm";
            this._endPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._endPicker.Location = new System.Drawing.Point(569, 3);
            this._endPicker.Name = "_endPicker";
            this._endPicker.ShowUpDown = true;
            this._endPicker.Size = new System.Drawing.Size(86, 20);
            this._endPicker.TabIndex = 4;
            this._endPicker.Value = new System.DateTime(2017, 7, 21, 0, 0, 0, 0);
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
        private System.Windows.Forms.DateTimePicker _startPicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker _endPicker;
    }
}
