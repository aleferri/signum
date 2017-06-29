namespace Signum.View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._mainContainer = new Signum.View.MainContainer();
            this._statusStrip = new System.Windows.Forms.StatusStrip();
            this._modelLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this._statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _mainContainer
            // 
            this._mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainContainer.Location = new System.Drawing.Point(0, 0);
            this._mainContainer.Name = "_mainContainer";
            this._mainContainer.Size = new System.Drawing.Size(1088, 712);
            this._mainContainer.TabIndex = 0;
            // 
            // _statusStrip
            // 
            this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._modelLabel});
            this._statusStrip.Location = new System.Drawing.Point(0, 712);
            this._statusStrip.Name = "_statusStrip";
            this._statusStrip.Size = new System.Drawing.Size(1088, 22);
            this._statusStrip.TabIndex = 1;
            this._statusStrip.Text = "statusStrip1";
            // 
            // _modelLabel
            // 
            this._modelLabel.Name = "_modelLabel";
            this._modelLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 734);
            this.Controls.Add(this._mainContainer);
            this.Controls.Add(this._statusStrip);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Signum";
            this._statusStrip.ResumeLayout(false);
            this._statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MainContainer _mainContainer;
        private System.Windows.Forms.StatusStrip _statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel _modelLabel;
    }
}