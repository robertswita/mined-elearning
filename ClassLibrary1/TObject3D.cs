using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGL
{
    public struct TPoint3D
    {
        public double X, Y, Z;

        public TPoint3D(double x,double y,double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public class TObject3D
    {
        public List<TPoint3D> Vertices = new List<TPoint3D>();

        public List<TObject3D> Children = new List<TObject3D>();

        TObject3D _Parent;
        private TObject3D Parent { 
            get { return _Parent; } 
            set {
                _Parent?.Children.Remove(this);
                _Parent = value;
                _Parent?.Children.Add(this);
            } 
        }

        //public TPoint3D Scale = new TPoint3D(1,1,1);
        public TPoint3D Shear;
        public TPoint3D Rotation;
        public TPoint3D Origin;


        public double[] Transform = new double[16];

        public List<int> Faces = new List<int>();

        public TObject3D()
        {
            LoadIdentity();
        }

        public void LoadIdentity()
        {
            Transform = new double[16];
            for (int i = 0; i < 4; i++)
            {
                Transform[5*i] = 1;
            }
        }

        public void Scale(double sx,double sy,double sz)
        {
            OpenGL.glLoadMatrixd(Transform);
            OpenGL.glScaled(sx,sy,sz);
            OpenGL.glGetDoublev(OpenGL.GL_MODELVIEW_MATRIX,Transform);
        }

        public void Translate(double tx,double ty, double tz)
        {
            OpenGL.glLoadMatrixd(Transform);
            OpenGL.glTranslated(tx, ty, tz);
            OpenGL.glGetDoublev(OpenGL.GL_MODELVIEW_MATRIX, Transform);
        }

        public void RotateX(double alpha)
        {
            OpenGL.glLoadMatrixd(Transform);
            OpenGL.glRotated(alpha,1, 0, 0);
            OpenGL.glGetDoublev(OpenGL.GL_MODELVIEW_MATRIX, Transform);
        }

        public void RotateY(double alpha)
        {
            OpenGL.glLoadMatrixd(Transform);
            OpenGL.glRotated(alpha, 0, 1, 0);
            OpenGL.glGetDoublev(OpenGL.GL_MODELVIEW_MATRIX, Transform);
        }

        public void RotateZ(double alpha)
        {
            OpenGL.glLoadMatrixd(Transform);
            OpenGL.glRotated(alpha, 0, 0, 1);
            OpenGL.glGetDoublev(OpenGL.GL_MODELVIEW_MATRIX, Transform);
        }
    }
}
