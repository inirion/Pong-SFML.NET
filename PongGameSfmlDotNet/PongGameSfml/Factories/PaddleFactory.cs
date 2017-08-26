using PongGameSfml.Enteties;
using PongGameSfml.Enums;
using SFML.Graphics;
using SFML.System;

namespace PongGameSfml.Factories
{
    class PaddleFactory
    {
        public static Paddle CreatePaddle(RenderWindow rw, PaddleTypes type)
        {
            Paddle p = new Paddle();
            float width = 10.0f;
            float height = 100.0f;

            switch (type)
            {
                case PaddleTypes.Player:
                    p.Velocity = 10.0f;
                    p.PaddleObject = new RectangleShape(new Vector2f(width, height));
                    p.PaddleObject.Origin = new Vector2f(p.PaddleObject.Size.X / 2, p.PaddleObject.Size.Y / 2);
                    p.PaddleObject.Position = new Vector2f(2 * p.PaddleObject.Size.X, rw.GetView().Size.Y / 2);
                    p.StartingPosition = p.PaddleObject.Position;
                    break;
                case PaddleTypes.Enemy:
                    p.Velocity = 2.5f;
                    p.PaddleObject = new RectangleShape(new Vector2f(width, height));
                    p.PaddleObject.Origin = new Vector2f(p.PaddleObject.Size.X / 2, p.PaddleObject.Size.Y / 2);
                    p.PaddleObject.Position = new Vector2f(rw.GetView().Size.X - (2 * p.PaddleObject.Size.X), rw.GetView().Size.Y / 2);
                    p.StartingPosition = p.PaddleObject.Position;
                    break;
            }

            return p;
        }
    }
}
