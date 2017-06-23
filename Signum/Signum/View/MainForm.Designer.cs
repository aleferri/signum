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
            this.SuspendLayout();
            // 
            // _mainContainer
            // 
            this._mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainContainer.Location = new System.Drawing.Point(0, 0);
            this._mainContainer.Name = "_mainContainer";
            this._mainContainer.Size = new System.Drawing.Size(1088, 734);
            this._mainContainer.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 734);
            this.Controls.Add(this._mainContainer);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private MainContainer _mainContainer;
    }
}