using SFML.Graphics;
using SFML.System;

namespace PongGameSfml.Enteties
{
    class PaddleEntity
    {
        private RectangleShape _paddle;
        private float velocity;

        public RectangleShape Paddle { get => _paddle; set => _paddle = value; }
        public float Velocity { get => velocity; set => velocity = value; }

        public static PaddleEntity CreatePaddle(RenderWindow rw)
        {
            PaddleEntity p = new PaddleEntity();
            float width = 10.0f;
            float height = 60.0f;
            p.Velocity = 5.0f;

            p.Paddle = new RectangleShape(new Vector2f(width,height));
            p.Paddle.Position = new Vector2f(2*p.Paddle.Size.X,rw.Size.Y / 2);

            return p;
        }
    }
}
