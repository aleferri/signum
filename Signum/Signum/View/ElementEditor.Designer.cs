namespace Signum.View
{
    partial class ElementEditor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._dateHourCheck = new System.Windows.Forms.CheckBox();
            this._infoTextBox = new System.Windows.Forms.TextBox();
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this._tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._infoTextBox);
            this.groupBox1.Controls.Add(this._dateHourCheck);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(583, 49);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gestione Informazione";
            // 
            // _dateHourCheck
            // 
            this._dateHourCheck.AutoSize = true;
            this._dateHourCheck.Location = new System.Drawing.Point(6, 19);
            this._dateHourCheck.Name = "_dateHourCheck";
            this._dateHourCheck.Size = new System.Drawing.Size(123, 17);
            this._dateHourCheck.TabIndex = 0;
            this._dateHourCheck.Text = "Visualizza data e ora";
            this._dateHourCheck.UseVisualStyleBackColor = true;
            // 
            // _infoTextBox
            // 
            this._infoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._infoTextBox.Location = new System.Drawing.Point(135, 17);
            this._infoTextBox.Name = "_infoTextBox";
            this._infoTextBox.Size = new System.Drawing.Size(441, 20);
            this._infoTextBox.TabIndex = 1;
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.ColumnCount = 1;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this._tableLayoutPanel.Controls.Add(this.groupBox1, 0, 0);
            this._tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 2;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel.Size = new System.Drawing.Size(589, 544);
            this._tableLayoutPanel.TabIndex = 1;
            // 
            // ElementEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._tableLayoutPanel);
            this.Name = "ElementEditor";
            this.Size = new System.Drawing.Size(589, 544);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this._tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox _infoTextBox;
        private System.Windows.Forms.CheckBox _dateHourCheck;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
    }
}
