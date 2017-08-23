using SFML.Graphics;
using SFML.Window;

namespace PongGameSfmlDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(new VideoMode(800,600),"Pong",Styles.Default);
        }
    }
}