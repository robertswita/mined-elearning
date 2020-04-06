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
        public List<TMove> Moves = new List<TMove>();
        public static Random Rnd = new Random();

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
                rot.X = 180.0 * (e.Y - StartPos.Y) / Height;
                rot.Y = 180.0 * (e.X - StartPos.X) / Width;
                tglView1.Context.Root.RotateY(-rot.Y);
                tglView1.Context.Root.RotateX(-rot.X);
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

        int MoveNo;
        int FrameNo;
        int FrameCount = 25;

        private void timer1_Tick(object sender, EventArgs e)
        {
           if(MoveNo < Moves.Count)
            {
                var move = Moves[MoveNo];
                if(FrameNo < FrameCount)
                {
                    if(FrameNo == 0)
                    {
                        RubikCube.Select(move);
                        RubikCube.Group();                 
                    }
                    var ratio = (double) FrameNo / (FrameCount - 1);
                    var angle = ratio * (move.Angle + 1) * 90;
                    if (move.Axis == 0)
                    {
                        RubikCube.Wall.RotateX(angle);
                    }
                    else if (move.Axis == 1)
                    {
                        RubikCube.Wall.RotateY(angle);
                    }
                    else
                    {
                        RubikCube.Wall.RotateZ(angle);
                    }
                    FrameNo++;
                    tglView1.Invalidate();
                }
                else
                {
                    FrameNo = 0;
                    MoveNo++;
                    RubikCube.Ungroup();
                    RubikCube.MakeMove(move);
                } 
            } else
            {
                MoveTimer.Stop();
                Moves.Clear();
                MoveNo = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 25; i++)
            {
                var code = Rnd.Next(9 * RubikCube.N);
                var move = new TMove();
                move.Decode(code);
                Moves.Add(move);
            }
            MoveTimer.Start();
        }
    }
}
