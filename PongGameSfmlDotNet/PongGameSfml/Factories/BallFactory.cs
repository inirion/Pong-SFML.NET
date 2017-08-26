using PongGameSfml.Enteties;
using PongGameSfml.Enums;
using SFML.Graphics;
using SFML.System;

namespace PongGameSfml.Factories
{
    class BallFactory
    {
        public static Ball CreateBall(RenderWindow rw, BallTypes type)
        {
            Ball b = new Ball();
            float radius = 15;

            switch (type)
            {
                case BallTypes.Normal:
                    b.Velocity = 5.0f;
                    b.MoveVector = new Vector2f(-1, 0);
                    b.BallObject = new CircleShape(radius);
                    b.BallObject.Origin = new Vector2f(b.BallObject.Radius, b.BallObject.Radius);
                    b.BallObject.Position = new Vector2f(rw.GetView().Size.X / 2, rw.GetView().Size.Y/2);
                    b.StatingPosition = b.BallObject.Position;
                    break;
            }

            return b;
        }
    }
}
