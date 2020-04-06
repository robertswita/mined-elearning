using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGL
{
    public class TCubik : TObject3D
    {
        public int X
        {
            get
            {
                return (int) Math.Round(Origin.X + RubikCube.M);
            }
        }

        public int Y
        {
            get
            {
                return (int) Math.Round(Origin.Y + RubikCube.M);
            }
        }

        public int Z
        {
            get
            {
                return (int) Math.Round(Origin.Z + RubikCube.M);
            }
        }

        public TCubik(){
            var lbn = new TPoint3D(-1, -1, -1);
            var rtf = new TPoint3D(1, 1, 1);

            for (int i = 0; i < 8; i++)
            {
                var point = lbn;
                if ((i & 1) == 1)
                {
                    point.X = rtf.X;
                }
                if ((i & 2) == 2)
                {
                    point.Y = rtf.Y;
                }
                if((i & 4) == 4)
                {
                    point.Z = rtf.Z;
                }

                Vertices.Add(point);
            }

            for (int dim = 0; dim < 3; dim++)
            {
                var axis1 = 1<<dim;
                var axis2 = 1<<(dim + 1)%3;

                Faces.Add(axis1);
                Faces.Add(axis2);
                Faces.Add(0);

                Faces.Add(axis1 + axis2);
                Faces.Add(axis2);
                Faces.Add(axis1);
            }

            for (int i = Faces.Count - 1; i >= 0 ; i--)
            {
                Faces.Add(7-Faces[i]);
            }
        }
    }
}
