using SFML.Graphics;
using SFML.System;

namespace PongGameSfml.Enteties
{
    class Paddle : Drawable
    {
        private RectangleShape _paddle;
        private float _velocity;
        //private PaddleStrategy update;

        public RectangleShape PaddleObject { get => _paddle; set => _paddle = value; }
        public float Velocity { get => _velocity; set => _velocity = value; }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(PaddleObject);
        }

        public void move(float xAexis, float yAexis)
        {
            PaddleObject.Position = new Vector2f(xAexis* Velocity, yAexis*Velocity) + PaddleObject.Position;
        }
    }
}
