namespace Signum.View.Utils
{
    partial class TimePicker
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
            this._dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // _dateTimePicker
            // 
            this._dateTimePicker.CustomFormat = "HH:mm";
            this._dateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._dateTimePicker.Location = new System.Drawing.Point(0, 0);
            this._dateTimePicker.MaxDate = new System.DateTime(1971, 1, 2, 0, 0, 0, 0);
            this._dateTimePicker.MinDate = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this._dateTimePicker.Name = "_dateTimePicker";
            this._dateTimePicker.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._dateTimePicker.RightToLeftLayout = true;
            this._dateTimePicker.ShowUpDown = true;
            this._dateTimePicker.Size = new System.Drawing.Size(157, 20);
            this._dateTimePicker.TabIndex = 0;
            this._dateTimePicker.Value = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            this._dateTimePicker.ValueChanged += new System.EventHandler(this.OnValueChange);
            // 
            // TimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._dateTimePicker);
            this.Name = "TimePicker";
            this.Size = new System.Drawing.Size(157, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker _dateTimePicker;
    }
}
