using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Threading;

namespace spotifynotify
{
    public class SpotifyScraper : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Timer timer;

        public SpotifyScraper()
        {
            timer = new Timer(UpdateSongPlaying, null, 0, 500);
        }

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

        private bool _paused;
        public bool Paused
        {
            get
            {
                return _paused;
            }

            set
            {
                _paused = value;
            }
        }
       
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        private void UpdateSongPlaying(object state)
        {
            var proc = Process.GetProcessesByName("Spotify").FirstOrDefault(p => !string.IsNullOrWhiteSpace(p.MainWindowTitle));
            if(proc == null)
            {
                return;
            }

            var title = proc.MainWindowTitle;
            if (proc.MainWindowTitle.Equals("Spotify", StringComparison.OrdinalIgnoreCase))
            {
                Paused = true;
                return;
            }

            if(Paused || title != SongPlaying)
            {
                Paused = false;
                SongPlaying = title;
                ShowNotification();
            }         
        }

        private void ShowNotification()
        {
            string artist;
            string song;
            SplitString(SongPlaying, out artist, out song);

            App.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {
                new SpotifyNotification(artist, song).Show();
            }));
        }

        private void SplitString(string stringTosplit, out string artist, out string song)
        {
            var splitted = stringTosplit.Split('-');
            if (splitted.Length == 0)
            {
                artist = "";
                song = "";
            }
            else
            {
                artist = splitted[0].Trim();
                song = splitted[1].Trim();
            }

            return;
        }

    }
}
