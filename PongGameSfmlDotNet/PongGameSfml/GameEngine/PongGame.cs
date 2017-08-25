using SFML.Graphics;
using PongGameSfml.Enteties;
using PongGameSfml.Factories;
using PongGameSfml.Enums;
using PongGameSfml.Enteties.Players;

namespace PongGameSfml.GameEngine
{
    class PongGame : Drawable
    {
        private Player _player;
        private Enemy _enemy;
        private Ball _ball;
        
        public PongGame(RenderWindow rw)
        {
            this._player = new Player(rw);
            this._enemy = new Enemy(rw);
            this._ball = BallFactory.CreateBall(rw, BallTypes.Normal);
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_player);
            target.Draw(_enemy);
            target.Draw(_ball);
        }
        public void update()
        {
            _player.update(_ball);
            _enemy.update(_ball);
            _ball.update(_player,_enemy);
        }
    }
}
