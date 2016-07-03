namespace GameLogic.GameGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using OpenTK;
    using System.Drawing;
    using OpenTK.Graphics.OpenGL;

    public enum TweenType
    {
        Instant,
        Linear,
        QuadraticInOut,
        CubicInOut,
        QuarticInOut
    }
    class View
    {
        private Vector2 positionGoTo, positionFrom;
        private TweenType tweentype;
        private int curentStep, tweenSteps;

        public Vector2 PositionGoTo
        {
            get
            {
                return positionGoTo;
            }
        }

        private Vector2 position;

        /// <summary>
        /// In Radiants += clocwise rotation of the camera
        /// </summary>
        public double rotation;

        /// <summary>
        /// 1=no zoom
        /// 2=2x zoom
        /// </summary>
        public double zoom;
        /// <summary>
        /// Moving the texture with the mouse
        ///
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Vector2 ToWorld(Vector2 input)
        {
            input /= (float) zoom;
            Vector2 dx = new Vector2((float) Math.Cos(rotation), (float) Math.Sin(rotation));
            Vector2 dy = new Vector2((float) Math.Cos(rotation +MathHelper.PiOver2), (float) Math.Sin(rotation+ MathHelper.PiOver2));

            return (this.position + dx*input.X + dy*input.Y);
        }

        public Vector2 Position
        {
            get { return this.position; }
        }


        public View(Vector2 startPosition, double startZoom = 1.0, double startRotation = 0.0)
        {
            this.position = startPosition;
            this.rotation = startRotation;
            this.zoom = startZoom;

        }
        public void Update()
        {
            if (curentStep < tweenSteps)
            {
                curentStep++;
                switch (tweentype)
                {
                    case TweenType.Linear:
                        position = positionFrom + (positionGoTo - positionFrom)*GetLinear((float) curentStep/tweenSteps);

                        break;
                    case TweenType.CubicInOut:
                        position = positionFrom + (positionGoTo - positionFrom) * GetCubicInOut((float)curentStep / tweenSteps);
                        break;
                    case TweenType.QuadraticInOut:
                        position = positionFrom + (positionGoTo - positionFrom) * GetQuadraticInOut((float)curentStep / tweenSteps);
                        break;
                    case TweenType.QuarticInOut:
                        position = positionFrom + (positionGoTo - positionFrom) * GetQuarticInOut((float)curentStep / tweenSteps);
                        break;
                }
             
            }
            else
            {
                position = positionGoTo;

            }
        }

        public float GetLinear(float t)
        {
            return t;
        }
        public float GetQuadraticInOut(float t)
        {
            return (t*t)/((2*t*t)-(2*t)+1);
        }
        public float GetCubicInOut(float t)
        {
            return (t * t*t) / ((3* t * t) - (3 * t) + 1);
        }

        public float GetQuarticInOut(float t)
        {
            return -((t - 1)*(t - 1)*(t - 1)*(t - 1))+1;
        }

        public void SetPosition(Vector2 newposition)
        {
            this.positionFrom = position;
            this.position = newposition;   
            this.positionGoTo = newposition;
            tweentype = TweenType.Instant;
            curentStep = 0;
            tweenSteps = 0;
        }
        public void SetPosition(Vector2 newposition,TweenType type,int numSteps)
        {
            this.position = newposition;
            this.positionFrom = newposition;
            this.positionGoTo = newposition;
            tweentype = type;
            curentStep = 0;
            tweenSteps = numSteps;
        }
        public void ApplyTransform()
        {
            Matrix4 transform = Matrix4.Identity;

            transform = Matrix4.Mult(transform, Matrix4.CreateTranslation(-position.X, -position.Y, 0));
            transform = Matrix4.Mult(transform, Matrix4.CreateRotationZ(-(float) rotation));
            transform = Matrix4.Mult(transform, Matrix4.CreateScale((float)zoom,(float) zoom, 1.0f));

            GL.MultMatrix(ref transform);
        }
    }
}
