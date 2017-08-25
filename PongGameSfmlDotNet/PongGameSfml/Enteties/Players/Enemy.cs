using PongGameSfml.Enums;
using PongGameSfml.Factories;
using PongGameSfml.Utils.Randomizers;
using SFML.Graphics;
using System;

namespace PongGameSfml.Enteties.Players
{
    class Enemy : Drawable
    {
        private Paddle _paddle;
        public Enemy(RenderWindow rw)
        {
            this._paddle = PaddleFactory.CreatePaddle(rw, PaddleTypes.Enemy);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_paddle);
        }

        public void update(Ball ball)
        {
            CircleShape ballObject = ball.BallObject;
            bool ballIsAbove = ballObject.Position.Y < _paddle.PaddleObject.Position.Y - _paddle.PaddleObject.Size.Y / 2 ? true : false;
            bool ballIsBelow = ballObject.Position.Y > _paddle.PaddleObject.Position.Y + _paddle.PaddleObject.Size.Y / 2 ? true : false;
            if (ballIsAbove)
            {
                _paddle.move(0, -1);
            }
            if (ballIsBelow)
            {
                _paddle.move(0, 1);
            }
            else
            {
                int yAexis = new RandomGenerator().Next(-1, 2);
                switch (yAexis)
                {
                    case 1:
                        _paddle.move(0, 0.8f);
                        break;
                    case 0:
                        _paddle.move(0, -0.8f);
                        break;
                }
                
            }
            //todo angle algorithm and move it to logic folder
            bool ballInteractedWhichPaddleTop =
               (ballObject.Position.X >= _paddle.PaddleObject.Position.X - _paddle.PaddleObject.Size.X) &&
               (ballObject.Position.Y < _paddle.PaddleObject.Position.Y) &&
               (ballObject.Position.Y >= _paddle.PaddleObject.Position.Y - _paddle.PaddleObject.Size.Y) ?
               true : false;
            bool ballInteractedWhichPaddleDown =
                (ballObject.Position.X >= _paddle.PaddleObject.Position.X - _paddle.PaddleObject.Size.X) &&
                (ballObject.Position.Y > _paddle.PaddleObject.Position.Y) &&
                (ballObject.Position.Y <= _paddle.PaddleObject.Position.Y + _paddle.PaddleObject.Size.Y) ?
                true : false;
            bool ballInteractedWhichPaddleMiddle =
                (ballObject.Position.X >= _paddle.PaddleObject.Position.X - _paddle.PaddleObject.Size.X) &&
                (ballObject.Position.Y == _paddle.PaddleObject.Position.Y) ?
                true : false;
            if (ballInteractedWhichPaddleTop)
            {
                ball.move(-1, -0.1f);
            }
            else if (ballInteractedWhichPaddleDown)
            {
                ball.move(-1, 0.1f);
            }
            else if (ballInteractedWhichPaddleMiddle)
            {
                ball.move(-1, 0);
            }

        }
    }
}
