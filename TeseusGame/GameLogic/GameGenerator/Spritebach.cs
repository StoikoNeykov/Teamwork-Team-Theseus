namespace GameLogic.GameGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using OpenTK;
    using OpenTK.Graphics.OpenGL;
    using System.Drawing;

   public class Spritebach
    {
        public static  void Drow(Texture2D texture, Vector2 position, Vector2 scale,Color color, Vector2 origin,
            RectangleF? sourceRec=null)
        {

            Vector2[] verticis = new Vector2[4]
            {
                new Vector2(0, 0),
                new Vector2(1,0),
                 new Vector2(1,1),
        new Vector2(0,
                1),
            };
            GL.BindTexture(TextureTarget.Texture2D, texture.ID);
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(color);

            for (int i = 0; i < 4; i++)
            {
                if (sourceRec == null)
                {
                    GL.TexCoord2(verticis[i]);

                }
                else
                {
                    GL.TexCoord2((sourceRec.Value.Left + verticis[i].X * sourceRec.Value.Width) / texture.Width,
                        (sourceRec.Value.Top + verticis[i].Y * sourceRec.Value.Height) / texture.Height);
                }
                GL.TexCoord2(verticis[i]);
                verticis[i].X *= sourceRec?.Width ?? texture.Width;
                verticis[i].Y *= sourceRec?.Height ?? texture.Height;
                ////verticis[i].X *= texture.Width;
                ////verticis[i].Y *= texture.Height;
                verticis[i] -= origin;
                verticis[i] *= scale;
                verticis[i] += position;

                GL.Vertex2(verticis[i]);
            }

            GL.End();
        }

        public static void Begin(int screenWidth, int screenHeight)
        {
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            GL.Ortho(-screenWidth/2f, screenWidth/2f, screenHeight/2f, -screenHeight/2f, 0f, 1f);

        }
    }
}
