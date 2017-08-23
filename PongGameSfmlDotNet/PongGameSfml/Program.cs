using SFML.Graphics;
using SFML.Window;

namespace PongGameSfml
{
    class Program
    {
        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(new VideoMode(1000, 800), "SFML works!", Styles.Default);

            window.Closed += (sender, arg) => window.Close();
            CircleShape shape = new CircleShape(100.0f);
            shape.FillColor = Color.Green;

            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear(Color.Black);
                window.Draw(shape);
                window.Display();
            }
        }
    }
}
