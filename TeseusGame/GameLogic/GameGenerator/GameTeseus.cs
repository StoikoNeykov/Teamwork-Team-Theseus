
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
            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(Color.Aqua);

            this.SwapBuffers();

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            this.SwapBuffers();
        }
    }
}
