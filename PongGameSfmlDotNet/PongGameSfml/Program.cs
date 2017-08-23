using PongGameSfml.Enteties;
using SFML.Graphics;
using SFML.Window;
namespace PongGameSfml
{
    class Program
    {
        static void Main(string[] args)
        {
            
            RenderWindow rw = new RenderWindow(new VideoMode(800, 600), "SFML works!", Styles.Default);
            rw.SetFramerateLimit(60);
            rw.Closed += (sender, arg) => rw.Close();
            Paddle paddle = new Paddle().CreatePaddle(rw);

            while (rw.IsOpen)
            {
                rw.DispatchEvents();

                rw.Clear(Color.Black);
                paddle.update();
                rw.Draw(paddle);
                
                rw.Display();
                
            }
        }
    }
}
