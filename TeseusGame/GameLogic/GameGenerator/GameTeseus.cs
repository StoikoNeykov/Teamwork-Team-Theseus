
using System.Drawing;
using System.Threading;

namespace GameLogic.GameGenerator
{
    using System;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using OpenTK.Input;
   public class GameTeseus:GameWindow
    {
        public GameTeseus(int width, int heigh)
            :base(width,heigh)
        {
            GL.Enable(EnableCap.Texture2D);

            view = new ViewGame(Vector2.Zero,5f, 1f);
        }
          


       private Texture2D texture;
       private ViewGame view;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            texture = ContentPipe.LoadTexture("diamand.png");
           
            MouseDown += GameTeseus_MouseDown;
        }

        private void GameTeseus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var pos = new Vector2(e.Position.X, e.Position.Y);
            pos -= new Vector2(this.Width, this.Height) / 2f;
            pos = view.ToWorld(pos);
            //view.position = pos;
            view.SetPosition(pos, TweenType.QuadraticInOut, 60);


        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            //GL.Clear(ClearBufferMask.ColorBufferBit);
           
            //view.position.Y += 0.01f;
            view.Update();

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.AliceBlue);

           Spritebach.Begin(this.Width, this.Height);
     

            view.ApplyTransform();

            //GetValue();


            Spritebach.Drow(texture, Vector2.Zero, new Vector2(0.2f, 0.2f), Color.Azure, new Vector2(10, 50));
            Spritebach.Drow(texture, new Vector2(100,10), new Vector2(0.2f, 0.2f), Color.Aqua, new Vector2(10, 50));

            this.SwapBuffers();
        }

       private void GetValue()
       {
           GL.BindTexture(TextureTarget.Texture2D, texture.ID);
           GL.Begin(PrimitiveType.Quads);
           GL.Color3(Color.BurlyWood);
           GL.TexCoord2(0, 0);
           GL.Vertex2(0, 0);
           GL.Color3(Color.Blue);
           GL.TexCoord2(1, 0);
           GL.Vertex2(0.9f, 0);
           GL.Color3(Color.Azure);
           GL.TexCoord2(1, 1);
           GL.Vertex2(1, -0.9f);
           GL.Color3(Color.Brown);
           GL.TexCoord2(0, -1);
           GL.Vertex2(0, -1);
           GL.End();
       }
    }
}
