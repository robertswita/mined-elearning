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
            this.tglView1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.tglView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tglView1.Location = new System.Drawing.Point(0, 0);
            this.tglView1.Margin = new System.Windows.Forms.Padding(2);
            this.tglView1.Name = "tglView1";
            this.tglView1.Size = new System.Drawing.Size(840, 582);
            this.tglView1.TabIndex = 0;
            this.tglView1.Load += new System.EventHandler(this.tglView1_Load);
            this.tglView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tglView1_MouseDown);
            this.tglView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.tglView1_MouseMove);
            this.tglView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tglView1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 582);
            this.Controls.Add(this.tglView1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private TGL.TGLView tglView1;
    }
}

