using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using PongGameSfml.Logic;

namespace PongGameSfml.Enteties
{
    class Paddle : Drawable
    {
        private Vector2f position;
        private RectangleShape _paddle;
        private float velocity;
        public Paddle() { }
        public Paddle CreatePaddle(RenderWindow rw)
        {
            Paddle p = new Paddle();
            float width = 10.0f;
            float height = 60.0f;
            p.velocity = 5.0f;

            p._paddle = new RectangleShape(new Vector2f(width,height));
            p.position = new Vector2f(2*p._paddle.Size.X,rw.Size.Y / 2);
            p._paddle.Position = p.position;

            return p;
        }


        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_paddle);
        }
        public void update()
        {
            Collision c = new Collision();
            if (c.CheckIfBallOrPaddleCollidedWithBoundry(new FloatRect(this.position, this._paddle.Size), new FloatRect(0, 0, 800, 600))) 
            {
                if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                {
                    position.Y -= 1 * velocity;
                }
                else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                {
                    position.Y += 1 * velocity;
                }
            }
            
            _paddle.Position = position;
        }
    }
}
