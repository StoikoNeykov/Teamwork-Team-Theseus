
using System.Drawing;

namespace GameLogic.GameGenerator
{
    using System;
    using OpenTK;
    using OpenTK.Graphics.OpenGL;

   public class GameTeseus:GameWindow
    {
        public GameTeseus(int width, int heigh)
            :base(width,heigh)
        {
            GL.Enable(EnableCap.Texture2D);
            view = new ViewGame(Vector2.Zero, 2.0, MathHelper.PiOver4);

        }

       private Texture2D texture;
       private ViewGame view;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            texture = ContentPipe.LoadTexture("diamand.png");
            GL.ClearColor(Color.Aqua);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            //GL.Clear(ClearBufferMask.ColorBufferBit);
           
            view.position.Y += 0.01f;
            //view.Update();

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.LoadIdentity();
            view.ApplyTransform();
            GL.BindTexture(TextureTarget.Texture2D, texture.ID);
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

            this.SwapBuffers();
        }
    }
}
