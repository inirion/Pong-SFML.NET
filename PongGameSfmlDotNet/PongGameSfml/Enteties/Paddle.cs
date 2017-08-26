using SFML.Graphics;
using SFML.System;

namespace PongGameSfml.Enteties
{
    class Paddle : Drawable
    {
        private RectangleShape _paddle;
        private float _velocity;
        private Vector2f _startingPosition;

        public RectangleShape PaddleObject { get => _paddle; set => _paddle = value; }
        public float Velocity { get => _velocity; set => _velocity = value; }
        public Vector2f StartingPosition { get => _startingPosition; set => _startingPosition = value; }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(PaddleObject);
        }

        public void move(float xAexis, float yAexis)
        {
            PaddleObject.Position = new Vector2f(xAexis* Velocity, yAexis*Velocity) + PaddleObject.Position;
        }

        public void resetPosition()
        {
            this._paddle.Position = this.StartingPosition;
        }
    }
}
