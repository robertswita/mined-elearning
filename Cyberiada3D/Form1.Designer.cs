namespace Cyberiada3D
{
    partial class Form1
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
            this.tglView1 = new TGL.TGLView();
            this.SuspendLayout();
            // 
            // tglView1
            // 
            this.tglView1.BackColor = System.Drawing.Color.White;
            this.tglView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tglView1.Location = new System.Drawing.Point(0, 0);
            this.tglView1.Name = "tglView1";
            this.tglView1.Size = new System.Drawing.Size(1120, 716);
            this.tglView1.TabIndex = 0;
            this.tglView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tglView1_MouseDown);
            this.tglView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tglView1_MouseMove);
            this.tglView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tglView1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 716);
            this.Controls.Add(this.tglView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private TGL.TGLView tglView1;
    }
}

