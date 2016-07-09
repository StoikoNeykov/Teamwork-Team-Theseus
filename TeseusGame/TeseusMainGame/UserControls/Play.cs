using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameLogic.GameGenerator;
using OpenTK.Graphics.OpenGL;

namespace TeseusMainGame.UserControls
{
    public partial class Play : Form
    {
        public Play()
        {
            InitializeComponent();
        }
        bool loaded = false;
        private void glControl1_Load(object sender, EventArgs e)
        {
           
            loaded = true;
            GL.ClearColor(Color.SkyBlue);


        }

        private void Play_Load(object sender, EventArgs e)
        {

        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded) // Play nice
            {
                return;
            }

            
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.Color3(Color.Blue);

            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(0,0);
            GL.Vertex2(1, 0);
            GL.Vertex2(1, -0.9f);
            GL.Vertex2(0, -1);

            GL.End();
            glControl1.SwapBuffers();
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            if (!loaded)
            {
                 return;
            }
         
        }
    }
}
