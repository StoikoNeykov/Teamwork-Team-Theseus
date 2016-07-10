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
using OpenTK.Input;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

namespace TeseusMainGame.UserControls
{
    public partial class Play : Form
    {
        bool loaded = false;
        private Texture2D texture,tileset;
        private ViewGame view;
        private Level level;
        public static int GRIDSIZE = 32, TILESIZE = 128;
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

            tileset = ContentPipe.LoadTexture("Tiles.png");
            view = new ViewGame(Vector2.Zero, 2f, 0);
            level=new Level("../../../GameLogic/Content/LevelOneNew.json");
            //var mouse = Mouse.GetState();
           // Input.Initialize(this);


            glControl1.MouseDown += GlControl1_MouseDown;
        }

        private void GlControl1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        float rotation = 0;
        private void Application_Idle(object sender, EventArgs e)
        {
            

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
         
            //GL.BindTexture(TextureTarget.Texture2D, texture.ID);

            Spritebach.Begin(this.Width, this.Height);
             view.ApplyTransform();
            for (int x = 0; x < level.Width; x++)
            {
                for (int y = 0; y < level.Height; y++)
                {
                    RectangleF source = new RectangleF(0, 0, 0, 0);
                    switch (level[x, y].Type)
                    {
                        case BlockType.Brick_Block:
                            source = new RectangleF(1*TILESIZE, 0*TILESIZE, TILESIZE, TILESIZE);

                            break;
                        case BlockType.Ice_Block:
                            source = new RectangleF(2 * TILESIZE, 0 * TILESIZE, TILESIZE, TILESIZE);

                            break;
                        case BlockType.StoneBlocks:
                            source = new RectangleF(1 * TILESIZE,2 * TILESIZE, TILESIZE, TILESIZE);

                            break;
                        case BlockType.Paper:
                            source = new RectangleF(1 * TILESIZE, 1 * TILESIZE, TILESIZE, TILESIZE);

                            break;
                        case BlockType.diamand:
                            source = new RectangleF(0 * TILESIZE, 0 * TILESIZE, TILESIZE, TILESIZE);

                            break;
                    }
                    Spritebach.Drow(tileset,new Vector2(x* GRIDSIZE, y* GRIDSIZE),new Vector2((float)GRIDSIZE/TILESIZE),Color.Aquamarine,Vector2.Zero,source );
                }
            }
            //Spritebach.Drow(texture, Vector2.Zero, new Vector2(0.2f, 0.2f), Color.DarkGreen, new Vector2(10, 50));
            //view.position.Y += 0.001f;
          
            glControl1.Invalidate();
            view.Update();
           
            glControl1.SwapBuffers();
         

        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            if (!loaded)
            {
                 return;
            }
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //GL.BindTexture(TextureTarget.Texture2D, texture.ID);

            Spritebach.Begin(this.Width, this.Height);
            view.ApplyTransform();
            for (int x = 0; x < level.Width; x++)
            {
                for (int y = 0; y < level.Height; y++)
                {
                    RectangleF source = new RectangleF(0, 0, 0, 0);
                    switch (level[x, y].Type)
                    {
                        case BlockType.Brick_Block:
                            source = new RectangleF(1 * TILESIZE, 0 * TILESIZE, TILESIZE, TILESIZE);

                            break;
                        case BlockType.Ice_Block:
                            source = new RectangleF(2 * TILESIZE, 0 * TILESIZE, TILESIZE, TILESIZE);

                            break;
                        case BlockType.StoneBlocks:
                            source = new RectangleF(1 * TILESIZE, 2 * TILESIZE, TILESIZE, TILESIZE);

                            break;
                        case BlockType.Paper:
                            source = new RectangleF(1 * TILESIZE, 1 * TILESIZE, TILESIZE, TILESIZE);

                            break;
                        case BlockType.diamand:
                            source = new RectangleF(0 * TILESIZE, 0 * TILESIZE, TILESIZE, TILESIZE);

                            break;
                    }
                    Spritebach.Drow(tileset, new Vector2(x * GRIDSIZE, y * GRIDSIZE), new Vector2((float)GRIDSIZE / TILESIZE), Color.White, Vector2.Zero, source);
                }
            }
            //Spritebach.Drow(texture, Vector2.Zero, new Vector2(0.2f, 0.2f), Color.DarkGreen, new Vector2(10, 50));
            //view.position.Y += 0.001f;

            glControl1.Invalidate();
            view.Update();

            glControl1.SwapBuffers();


            glControl1.Invalidate();
        }

        private void glControl1_MouseDown(object sender, MouseEventArgs e)
        {
            //Vector2 pos = new Vector2(e.X, e.Y);
            //pos -= new Vector2(texture.Width, texture.Height) / 2f;
            //pos = view.ToWorld(pos);
            //view.SetPosition(pos, TweenType.QuadraticInOut, 1000);
            // view.position = pos;
            var mouse = Mouse.GetState();

            if (mouse[MouseButton.Left])
            {
                Vector2 pos = new Vector2(e.X, e.Y) - new Vector2(this.Width, this.Height) / 2f;
                pos = view.ToWorld(pos);

                view.SetPosition(pos, TweenType.QuarticInOut, 60);

            }
            glControl1.Invalidate();
            
        }
    }
}
