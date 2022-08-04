using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace UnrealTribe_Wpf.Controllers.Music
{
    public interface IMusicPlayer
    {
        public MediaPlayer Player { get; }

        public void Play();

        public void Stop();

        public void Pause();

        /// <summary>
        /// Set the music track to play.
        /// </summary>
        /// <param name="track">The music track name.</param>
        public void SetTrack(string track);
    }
}
