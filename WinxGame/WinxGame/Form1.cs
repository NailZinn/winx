using System;
using WinxGame.objects;
using Timer = System.Threading.Timer;

namespace WinxGame
{
    public partial class Form1 : Form
    {
        private readonly Fairy _fairy;
        private Spider[] _spiders;
        private FireBall _fireBall;
        private TimerCallback _callback;

        public Form1()
        {
            InitializeComponent();
            _fairy = new Fairy(new Point(Width / 2, (Height * 2) / 3));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Hide();
            Focus();
            Controls.Add(_fairy);

            var rnd = new Random();

            _spiders = Enumerable
                .Range(0, 10)
                .Select(s => new Spider(new Point(rnd.Next(0, Width), rnd.Next(0, Height / 2)), this))
                .ToArray();

            Controls.AddRange(_spiders);

            _callback = new TimerCallback(Render);
            var timer = new Timer(_callback, null, 0, 1000);
        }

        int i = 0;

        private void Render(object obj)
        {
            foreach (var spider in _spiders)
            {
                spider.Redraw(spider.CreateFireBallTime);
                
            }
            if (i == 10_000)
                i = 0;
            else
                i++;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // MessageBox.Show(e.Key);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            _fairy.Move(e.KeyCode);
        }
    }
}