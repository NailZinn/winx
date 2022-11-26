using Timer = System.Threading.Timer;

namespace WinxGame.objects
{
    internal class FireBall : PictureBox, IRenderable
    {
        private readonly Form _form;

        public FireBall(Point location, Form form)
        {
            Location = location;
            Image = Image.FromFile(Path.Join(Directory.GetCurrentDirectory(), @"images/Fireball_68x9.png"));
            Height = 100;
            Width = 100;
            SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void Redraw()
        {
            Location = new Point(Location.X, Location.Y + 10);
        }
    }
}
