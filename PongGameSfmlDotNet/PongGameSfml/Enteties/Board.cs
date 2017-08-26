using SFML.Graphics;

namespace PongGameSfml.Enteties
{
    class Board : Drawable
    {
        private RectangleShape _topBoundry;
        private RectangleShape _bottomBoundry;

        public RectangleShape TopBoundry { get => _topBoundry; set => _topBoundry = value; }
        public RectangleShape BottomBoundry { get => _bottomBoundry; set => _bottomBoundry = value; }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(TopBoundry);
            target.Draw(BottomBoundry);
        }
    }
}
