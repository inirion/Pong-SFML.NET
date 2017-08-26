using PongGameSfml.Enteties;
using PongGameSfml.Enums;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace PongGameSfml.Factories
{
    class BoardFactory
    {
        public static Board CreateBoard(RenderWindow rw, BoardTypes type)
        {
            Board b = new Board();
            switch (type)
            {
                case BoardTypes.Normal:
                    float width = 0;
                    float height = 0;
                    b.TopBoundry = new RectangleShape();
                    //top boundry
                    width = rw.GetView().Size.X;
                    height = rw.GetView().Size.Y / 20;
                    b.TopBoundry.Size = new Vector2f(width, height);
                    b.TopBoundry.Origin = new Vector2f(b.TopBoundry.Size.X / 2, b.TopBoundry.Size.Y / 2);
                    b.TopBoundry.Position = new Vector2f(rw.GetView().Size.X / 2, height/2);
                    //bottom boundry
                    b.BottomBoundry = new RectangleShape(b.TopBoundry);
                    b.BottomBoundry.Position = new Vector2f(rw.GetView().Size.X / 2, rw.GetView().Size.Y-height/2);
                    break;
            }

            return b;
        }
    }
}
