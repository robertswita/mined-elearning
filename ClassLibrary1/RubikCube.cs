using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGL
{

    public class RubikCube : TObject3D
    {
        public static int N = 3;
        TCubik[,,] Cubiks = new TCubik[N, N, N];
        public static double M = (N - 1)/2.0;
        public double Size = 0.45;

        public RubikCube() {
            Scale(1/M,1/M,1/M);
            for (int z = 0; z < N; z++)
                for (int y = 0; y < N; y++)
                    for (int x = 0; x < N; x++)
                    {
                        var cubik = new TCubik();
                        cubik.Translate(x - M, y - M,z - M);
                        cubik.Scale(Size, Size, Size);
                        Cubiks[z, y, x] = cubik;
                    }
        }
    }
}
