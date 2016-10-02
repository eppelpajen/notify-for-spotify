using System;
using System.Windows;

namespace spotifynotify
{
    /// <summary>
    /// Interaction logic for SpotifyNotification.xaml
    /// </summary>
    public partial class SpotifyNotification : Window
    {
        public SpotifyNotification(string artist, string song)
        {
            InitializeComponent();
            Song.Text = song;
            Artist.Text = artist;
        }

        public new void Show()
        {
            base.Show();

            var workArea = System.Windows.SystemParameters.WorkArea;
            var transform = PresentationSource.FromVisual(this).CompositionTarget.TransformFromDevice;
            var corner = transform.Transform(new Point(workArea.Right, workArea.Bottom));

            this.Left = corner.X - this.ActualWidth - 20;
            this.Top = corner.Y - this.ActualHeight - 10;
        }

        private void NotificationCompleted(object sender, EventArgs e)
        {
            Close();
        }
    }
}
