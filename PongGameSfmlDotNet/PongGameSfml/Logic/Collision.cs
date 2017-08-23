using SFML.Graphics;

namespace PongGameSfml.Logic
{
    class Collision
    {
        public Collision() { }

        public bool CheckIfBallCollidedWithPaddle(FloatRect object1, FloatRect object2)
        {
            if (object1.Intersects(object2))
            {
                return true;
            }
            return false;
        }

        public bool CheckIfBallOrPaddleCollidedWithBoundry(FloatRect object1, FloatRect object2)
        {
            if (!object1.Intersects(object2))
            {
                return true;
            }
            return false;
        }
    }
}
