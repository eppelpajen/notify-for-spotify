using System;
using System.Windows;

namespace spotifynotify
{
    /// <summary>
    /// Interaction logic for SpotifyNotification.xaml
    /// </summary>
    public partial class SpotifyNotification : Window
    {
        private string _songPlaying;
        public string SongPlaying
        {
            get
            {
                return _songPlaying;
            }

            set
            {
                _songPlaying = value;
            }
        }

        public SpotifyNotification(string song)
        {
            InitializeComponent();
            SongPlaying = song;
            DataContext = this;
        }

        public new void Show()
        {
            base.Show();

            var workArea = System.Windows.SystemParameters.WorkArea;
            var transform = PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice;
            var corner = transform.Transform(new Point(workArea.Right, workArea.Bottom));

            this.Left = corner.X - this.ActualWidth - 20;
            this.Top = corner.Y - this.ActualHeight - 15;
        }

        private void MenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NotificationCompleted(object sender, EventArgs e)
        {
            Close();
        }
    }
}
