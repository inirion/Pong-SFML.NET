using PongGameSfml.Enums;
using PongGameSfml.Factories;
using SFML.Graphics;

namespace PongGameSfml.Enteties.Players
{
    class Enemy : Drawable
    {
        private Paddle _paddle;
        private int _points;
        public Enemy(RenderWindow rw)
        {
            this._points = 0;
            this._paddle = PaddleFactory.CreatePaddle(rw, PaddleTypes.Enemy);
        }

        public int Points { get => _points; set => _points = value; }

        public void resetPaddlePosition()
        {
            _paddle.resetPosition();
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_paddle);
        }

        public void update(Ball ball, Board board)
        {
            CircleShape ballObject = ball.BallObject;
            bool ballIsAbove = ballObject.Position.Y < _paddle.PaddleObject.Position.Y - _paddle.PaddleObject.Size.Y / 2 ? true : false;
            bool ballIsBelow = ballObject.Position.Y > _paddle.PaddleObject.Position.Y + _paddle.PaddleObject.Size.Y / 2 ? true : false;
            bool paddleInteractedWhichBoardTop =
                _paddle.PaddleObject.Position.Y - _paddle.PaddleObject.Size.Y / 2 <= board.TopBoundry.Position.Y + board.TopBoundry.Size.Y / 2 ?
                true : false;
            bool paddleInteractedWhichBoardBottom =
                _paddle.PaddleObject.Position.Y + _paddle.PaddleObject.Size.Y / 2 >= board.BottomBoundry.Position.Y - board.BottomBoundry.Size.Y / 2 ?
                true : false;
            if (ballIsAbove)
            {
                if(!paddleInteractedWhichBoardTop)
                    _paddle.move(0, -1);
            }
            if (ballIsBelow)
            {
                if(!paddleInteractedWhichBoardBottom)
                    _paddle.move(0, 1);
            }

            //todo angle algorithm and move it to logic folder
            bool ballInteractedWhichPaddleTop =
                (ballObject.Position.X + ballObject.Radius / 2 >= _paddle.PaddleObject.Position.X - _paddle.PaddleObject.Size.X / 2) &&
                (ballObject.Position.Y + ballObject.Radius / 2 < _paddle.PaddleObject.Position.Y) &&
                (ballObject.Position.Y + ballObject.Radius / 2 > _paddle.PaddleObject.Position.Y - _paddle.PaddleObject.Size.Y / 2) ?
                true : false;
            bool ballInteractedWhichPaddleDown =
                (ballObject.Position.X + ballObject.Radius / 2 >= _paddle.PaddleObject.Position.X - _paddle.PaddleObject.Size.X / 2) &&
                (ballObject.Position.Y - ballObject.Radius / 2 > _paddle.PaddleObject.Position.Y) &&
                (ballObject.Position.Y - ballObject.Radius / 2 < _paddle.PaddleObject.Position.Y + _paddle.PaddleObject.Size.Y / 2) ?
                true : false;
            bool ballInteractedWhichPaddleMiddle =
                (ballObject.Position.X + ballObject.Radius / 2 >= _paddle.PaddleObject.Position.X - _paddle.PaddleObject.Size.X / 2) &&
                (ballObject.Position.Y >= _paddle.PaddleObject.Position.Y - ballObject.Radius / 2) &&
                (ballObject.Position.Y <= _paddle.PaddleObject.Position.Y + ballObject.Radius / 2) ?
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
