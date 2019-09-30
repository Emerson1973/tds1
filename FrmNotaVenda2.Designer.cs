namespace BDStored
{
    partial class FrmNotaVenda2
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
            this.txbUltima = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txbUltima
            // 
            this.txbUltima.Location = new System.Drawing.Point(12, 12);
            this.txbUltima.Name = "txbUltima";
            this.txbUltima.Size = new System.Drawing.Size(100, 20);
            this.txbUltima.TabIndex = 0;
            // 
            // FrmNotaVenda2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txbUltima);
            this.Name = "FrmNotaVenda2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nota";
            this.Load += new System.EventHandler(this.FrmNotaVenda2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbUltima;
    }
}