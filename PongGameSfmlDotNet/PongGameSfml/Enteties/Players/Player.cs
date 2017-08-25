using SFML.Graphics;
using SFML.Window;
using PongGameSfml.Factories;
using PongGameSfml.Enums;

namespace PongGameSfml.Enteties.Players
{
    class Player : Drawable
    {
        private Paddle _paddle;
        public Player(RenderWindow rw)
        {
            this._paddle = PaddleFactory.CreatePaddle(rw, PaddleTypes.Player);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_paddle);
        }

        public void update(Ball ball)
        {
            CircleShape ballObject = ball.BallObject;
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                _paddle.move(0,-1);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                _paddle.move(0, 1);
            }
            //todo angle algorithm and move it to logic folder
            bool ballInteractedWhichPaddleTop =
                (ballObject.Position.X<=_paddle.PaddleObject.Position.X+_paddle.PaddleObject.Size.X) &&
                (ballObject.Position.Y<_paddle.PaddleObject.Position.Y) &&
                (ballObject.Position.Y >= _paddle.PaddleObject.Position.Y - _paddle.PaddleObject.Size.Y) ?
                true : false;
            bool ballInteractedWhichPaddleDown =
                (ballObject.Position.X <= _paddle.PaddleObject.Position.X + _paddle.PaddleObject.Size.X) &&
                (ballObject.Position.Y > _paddle.PaddleObject.Position.Y) &&
                (ballObject.Position.Y <= _paddle.PaddleObject.Position.Y + _paddle.PaddleObject.Size.Y) ?
                true : false;
            bool ballInteractedWhichPaddleMiddle =
                (ballObject.Position.X <= _paddle.PaddleObject.Position.X + _paddle.PaddleObject.Size.X) &&
                (ballObject.Position.Y == _paddle.PaddleObject.Position.Y) ?
                true : false;
            if (ballInteractedWhichPaddleTop)
            {
                ball.move(-1,-0.1f);
            }
            else if (ballInteractedWhichPaddleDown)
            {
                ball.move(-1, 0.1f);
            }
            else if(ballInteractedWhichPaddleMiddle)
            {
                ball.move(-1, 0);
            }
        }
    }
}
