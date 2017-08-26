using SFML.Graphics;
using PongGameSfml.Enteties;
using PongGameSfml.Factories;
using PongGameSfml.Enums;
using PongGameSfml.Enteties.Players;
using SFML.System;

namespace PongGameSfml.GameEngine
{
    class PongGame : Drawable
    {
        private Player _player;
        private Enemy _enemy;
        private Ball _ball;
        private Board _board;
        private Text _score;
        
        public PongGame(RenderWindow rw)
        { 
            this._score = new Text("Score: 0 - 0", new Font(@"..\..\..\resources\Fonts\CaviarDreams.ttf"),20);
            this._score.Position = new Vector2f(rw.GetView().Size.X / 2, rw.GetView().Size.Y / 10);
            this._player = new Player(rw);
            this._enemy = new Enemy(rw);
            this._ball = BallFactory.CreateBall(rw, BallTypes.Normal);
            this._board = BoardFactory.CreateBoard(rw, BoardTypes.Normal);
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_player);
            target.Draw(_enemy);
            target.Draw(_ball);
            target.Draw(_board);
            target.Draw(_score);
        }
        public void update()
        {
            if (checkIfScored())
            {
                ResetGameSavingScore();
            }
            _player.update(_ball,_board);
            _enemy.update(_ball, _board);
            _ball.update(_board);
        }

        public bool checkIfScored()
        {
            bool EnemyScored = _ball.BallObject.Position.X + _ball.BallObject.Radius / 2 <= 0 ? true : false;
            bool PlayerScored = _ball.BallObject.Position.X - _ball.BallObject.Radius / 2 >= _board.TopBoundry.Size.X ? true : false;

            if (PlayerScored)
            {
                _score.DisplayedString = "Score: " + ++_player.Points + " - " + _enemy.Points;
                return true;
            }
            if (EnemyScored)
            {
                _score.DisplayedString = "Score: " + _player.Points + " - " + ++_enemy.Points;
                return true;
            }
            return false;
        }

        public void ResetGameSavingScore()
        {
            _player.resetPaddlePosition();
            _enemy.resetPaddlePosition();
            _ball.resetPosition();
        }
    }
}
