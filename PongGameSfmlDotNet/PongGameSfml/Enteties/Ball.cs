using System;
using PongGameSfml.Enteties.Players;
using SFML.Graphics;
using SFML.System;

namespace PongGameSfml.Enteties
{
    class Ball : Drawable
    {
        private CircleShape _ball;
        private float _velocity;
        private Vector2f _moveVector;

        public CircleShape BallObject { get => _ball; set => _ball = value; }
        public float Velocity { get => _velocity; set => _velocity = value; }
        public Vector2f MoveVector { get => _moveVector; set => _moveVector = value; }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(BallObject);
        }

        public void update(Player player, Enemy enemy)
        {
            BallObject.Position += MoveVector*Velocity;
        }

        public void move(float xAexis, float yAexis)
        {
            MoveVector = new Vector2f(MoveVector.X*xAexis,yAexis);
        }
    }
}
