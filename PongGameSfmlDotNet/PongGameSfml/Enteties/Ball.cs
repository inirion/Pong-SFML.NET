using SFML.Graphics;
using SFML.System;

namespace PongGameSfml.Enteties
{
    class Ball : Drawable
    {
        private CircleShape _ball;
        private float _velocity;
        private Vector2f _moveVector;
        private Vector2f _statingPosition;

        public CircleShape BallObject { get => _ball; set => _ball = value; }
        public float Velocity { get => _velocity; set => _velocity = value; }
        public Vector2f MoveVector { get => _moveVector; set => _moveVector = value; }
        public Vector2f StatingPosition { get => _statingPosition; set => _statingPosition = value; }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(BallObject);
            CircleShape ball = new CircleShape(2);
            ball.FillColor = Color.Red;
            ball.Position = BallObject.Position;
            target.Draw(ball);
        }

        public void update(Board board)
        {
            bool paddleInteractedWhichBoardTop =
               _ball.Position.Y - _ball.Radius / 2 <= board.TopBoundry.Position.Y + board.TopBoundry.Size.Y / 2 ?
               true : false;
            bool paddleInteractedWhichBoardBottom =
                _ball.Position.Y + _ball.Radius / 2 >= board.BottomBoundry.Position.Y - board.BottomBoundry.Size.Y / 2 ?
                true : false;
            if (paddleInteractedWhichBoardTop || paddleInteractedWhichBoardBottom)
                MoveVector = move(MoveVector,1,-1);

            BallObject.Position += MoveVector*Velocity;


        }

        public void move(float xAexis, float yAexis)
        {
            MoveVector = new Vector2f(MoveVector.X*xAexis,yAexis);
        }

        public Vector2f move(Vector2f vector, float xMultiplayer, float yMultiplayer)
        {

            return new Vector2f(vector.X*xMultiplayer,vector.Y*yMultiplayer);
        }

        public void resetPosition()
        {
            this._ball.Position = this.StatingPosition;
        }
    }
}
