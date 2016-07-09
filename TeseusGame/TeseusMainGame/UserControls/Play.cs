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
using OpenTK;
using OpenTK.Graphics.OpenGL;
namespace TeseusMainGame.UserControls
{
    public partial class Play : Form
    {
        bool loaded = false;
        private Texture2D texture;
        private ViewGame view;
        private Level level;
        public Play()
        {
        
            InitializeComponent();
         
           

        }
      
        private void glControl1_Load(object sender, EventArgs e)
        {
            OpenTK.Graphics.OpenGL.GL.Enable(EnableCap.Texture2D);
            Application.Idle += Application_Idle;
            loaded = true;
            GL.ClearColor(Color.SkyBlue);

            //GL.Enable(EnableCap.Texture2D);

            texture = ContentPipe.LoadTexture("diamand.jpg");
            view = new ViewGame(Vector2.Zero, 1.0, 0.0);
            level=new Level("Content/LevelOneNew.json");
        }
        float rotation = 0;
        private void Application_Idle(object sender, EventArgs e)
        {
             //  GL.Enable(EnableCap.Texture2D);
            //while (glControl1.IsIdle)
            //{
            
            //    rotation += 1;
            //    view.Update();
            //}
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
          
       
            GL.LoadIdentity();
        
            view.ApplyTransform();

            GL.BindTexture(TextureTarget.Texture2D, texture.ID);


            GL.Begin(PrimitiveType.Quads);
            GL.Color3(Color.AliceBlue);


            GL.Vertex2(0, 0);
            GL.TexCoord2(0, 0);
            GL.Vertex2(1, 0);
            GL.TexCoord2(1, 1);
            GL.Vertex2(1, -0.9f);
            GL.TexCoord2(0, 1);
            GL.Vertex2(0, -1);


            GL.End();
            //Spritebach.Drow(texture, Vector2.Zero, new Vector2(0.2f, 0.2f), Color.DarkGreen, new Vector2(10, 50));


            glControl1.SwapBuffers();
          
          
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            if (!loaded)
            {
                 return;
            }
           
            glControl1.Invalidate();
        }
    }
}
