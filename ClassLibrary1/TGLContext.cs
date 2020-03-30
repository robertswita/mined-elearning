using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace TGL
{
    public class TGLContext
    {
        public TGLView View;
        IntPtr HDC;
        IntPtr HRC;
        Win32.PIXELFORMATDESCRIPTOR pfd;
        List<object> NameStack;
        public Rectangle Viewport;
        public TCamera Camera;
        public TObject3D Root = new TObject3D();
        public IntPtr Handle
        {
            get
            {
                if (HRC == IntPtr.Zero)
                {
                    HDC = View.CreateGraphics().GetHdc();
                    pfd = new Win32.PIXELFORMATDESCRIPTOR();
                    var idx = Win32.ChoosePixelFormat(HDC, pfd);
                    Win32.SetPixelFormat(HDC, idx, pfd);
                    HRC = Win32.wglCreateContext(HDC);
                    Win32.wglMakeCurrent(HDC,HRC);
                }
                return HRC;
            }
        }

        public bool IsInited;
        void Init()
        {
            if (!IsInited)
            {
                OpenGL.glEnable(OpenGL.GL_DEPTH_TEST);
                //OpenGL.glEnable(OpenGL.GL_LIGHTING);
                OpenGL.glEnable(OpenGL.GL_COLOR_MATERIAL);
                OpenGL.glEnable(OpenGL.GL_NORMALIZE);
                IsInited = true;
            }
        }

        internal void DrawView()
        {
            if (Handle != IntPtr.Zero)
            {
                Viewport = View.ClientRectangle;
                var backColor = View.BackColor;
                Win32.wglMakeCurrent(HDC, HRC);
                OpenGL.glClearColor(backColor.R / 255f, backColor.G / 255f, backColor.B / 255f, 1);
                OpenGL.glClear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
                OpenGL.glViewport(Viewport.Left, Viewport.Top, Viewport.Width, Viewport.Height);
                Init();
                DrawScene();
                Win32.SwapBuffers(HDC);
            }
        }


        void DrawScene()
        {
            //OpenGL.glMatrixMode(OpenGL.GL_PROJECTION);
            //OpenGL.glLoadMatrixd(Camera.Projection.Items);
            //OpenGL.glMatrixMode(OpenGL.GL_MODELVIEW);
            //InitLights();
            OpenGL.glLoadIdentity();
            DrawObject(Root);
        }

        void DrawObject(TObject3D obj)
        {
            OpenGL.glPushMatrix();
            OpenGL.glMultMatrixd(obj.Transform);
            OpenGL.glBegin(OpenGL.GL_TRIANGLES);
            for (int i = 0; i < obj.Faces.Count; i++)
            {
                var vertex = obj.Vertices[obj.Faces[i]];
                if(i%6 == 0)
                    OpenGL.glColor3d(vertex.X,vertex.Y,vertex.Z);
                OpenGL.glVertex3d(vertex.X, vertex.Y, vertex.Z);
            }
            //foreach (var face in obj.Faces)
            //{
            //    if (!face.Smooth)
            //        OpenGL.glNormal3dv(face.Normal.Items);
            //    foreach (var vertex in face.Vertices)
            //    {
            //        if (face.Smooth)
            //            OpenGL.glNormal3dv(vertex.Normal.Items);
            //        OpenGL.glColor3dv(vertex.Coords.Items);
            //        OpenGL.glVertex3dv(vertex.Coords.Items);
            //    }
            //}
            OpenGL.glEnd();
            foreach (var child in obj.Children)
                DrawObject(child);
            OpenGL.glPopMatrix();
        }
    }
}