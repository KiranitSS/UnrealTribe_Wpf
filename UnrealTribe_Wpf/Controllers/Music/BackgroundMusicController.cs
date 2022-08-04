using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using UnrealTribe_Wpf.Utils;

namespace UnrealTribe_Wpf.Controllers.Music
{
    public class BackgroundMusicPlayer : IMusicPlayer
    {
        public MediaPlayer Player { get; }
        public BackgroundMusicPlayer()
        {
            this.Player = new MediaPlayer();
        }

        public BackgroundMusicPlayer(string track) : this()
        {
            this.Player.MediaEnded += OnMediaEnded;
            this.Player.Open(new Uri(PathUtils.MusicPath + track));
        }

        public void Play()
        {
            this.Player.Play();
        }

        public void Stop()
        {
            this.Player.Stop();
        }

        public void Pause()
        {
            this.Player.Pause();
        }

        public void SetTrack(string track)
        {
            this.Player.Open(new Uri(track));
        }

        private void OnMediaEnded(object? sender, EventArgs e)
        {
            this.Player.Play();
        }
    }
}
