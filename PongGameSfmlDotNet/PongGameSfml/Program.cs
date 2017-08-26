using PongGameSfml.GameEngine;
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
            PongGame pong = new PongGame(rw);

            while (rw.IsOpen)
            {
                rw.DispatchEvents();
                

                rw.Clear(Color.Black);
                rw.Draw(pong);
                pong.update();


                rw.Display();
                
            }
        }
    }
}
