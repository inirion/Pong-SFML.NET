using PongGameSfml.Enums;
using SFML.Graphics;

namespace PongGameSfml.Logic
{
    class Collision
    {

        public static bool CheckIfBallCollidedWithPaddle(FloatRect object1, FloatRect object2)
        {
            if (object1.Intersects(object2))
            {
                return true;
            }
            return false;
        }

        public static Boundries WhichBoundryDoesPaddleCollideTo(RectangleShape paddle, RenderWindow rw)
        {
            Boundries collision = Boundries.None;

            bool TopCollision = paddle.Position.Y <= 0 ? true : false;
            bool DownCollision = paddle.Position.Y + paddle.Size.Y >= rw.GetView().Size.Y ? true : false;

            if (TopCollision) collision = Boundries.Top;
            if (DownCollision) collision = Boundries.Down;

            return collision;
        }
    }
}
