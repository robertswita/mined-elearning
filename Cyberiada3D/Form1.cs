using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGL;

namespace Cyberiada3D
{
    public partial class Form1 : Form
    {
        public RubikCube RubikCube;

        public Form1()
        {
            InitializeComponent();
        }

        Point StartPos;
        private void tglView1_MouseDown(object sender, MouseEventArgs e)
        {
            StartPos = e.Location;
            
        }

        private void tglView1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var rot = new TPoint3D();
                rot.X += 180.0 * (e.Y - StartPos.Y) / Height;
                rot.Y += 180.0 * (e.X - StartPos.X) / Width;
                tglView1.Context.Root.RotateY(rot.Y);
                tglView1.Context.Root.RotateX(rot.X);
                StartPos = e.Location;
                tglView1.Invalidate();
            }
        }

        private void tglView1_MouseUp(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    var r = Rectangle.FromLTRB(StartPos.X, StartPos.Y, e.X, e.Y);
            //    tglView1.Context.ZoomIn(r);
            //}
        }

        private void tglView1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            RubikCube = new RubikCube();
            RubikCube.Parent = tglView1.Context.Root;
        }
    }
}
