using PongGameSfml.Enums;
using PongGameSfml.Logic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace PongGameSfml.Enteties
{
    class Player : Drawable
    {
        private PaddleEntity _paddle;
        private Vector2f position;
        public Player(RenderWindow rw)
        {
            _paddle = PaddleEntity.CreatePaddle(rw);
            position = _paddle.Paddle.Position;
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_paddle.Paddle);
        }
        public void update(RenderWindow rw)
        {
            switch (Collision.WhichBoundryDoesPaddleCollideTo(_paddle.Paddle, rw))
            {
                case Boundries.Top:
                    GoDown();
                    break;
                case Boundries.Down:
                    GoUp();
                    break;
                case Boundries.None:
                    GoUp();
                    GoDown();
                    break;
            }
            _paddle.Paddle.Position = position;
        }

        private void GoUp()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                position.Y -= 1 * _paddle.Velocity;
            }
        }

        private void GoDown()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                position.Y += 1 * _paddle.Velocity;
            }
        }
    }
}
