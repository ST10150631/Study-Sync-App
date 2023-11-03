using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Media;

namespace Prog6212_POE_ST10150631.Pages
{
    public partial class MusicPg : Page
    {
        private List<string> mp3Files = new List<string>();
        private int currentTrackIndex = 0;
        private MediaPlayer mediaPlay = new MediaPlayer();

        public MusicPg()
        {
            InitializeComponent();
        }

        private void PlayCurrentTrack()
        {
            if (currentTrackIndex >= 0 && currentTrackIndex < mp3Files.Count)
            {
                mediaPlayer.Source = new Uri(mp3Files[currentTrackIndex].ToString());
                mediaPlayer.Play();
            }
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            // Play the video
            PlayCurrentTrack();
        }

        private void BtnSkipBack_Click(object sender, RoutedEventArgs e)
        {
            if (currentTrackIndex > 0)
            {
                currentTrackIndex--;
                PlayCurrentTrack();
            }
        }

        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void BtnSkipForward_Click(object sender, RoutedEventArgs e)
        {
            if (currentTrackIndex < mp3Files.Count - 1)
            {
                currentTrackIndex++;
                PlayCurrentTrack();
            }
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "MP3 Files|*.mp3",
                Multiselect = true, // Allow multiple file selection
            };

            if (openFileDialog.ShowDialog() == true)
            {
                mp3Files.Clear(); // Clear the existing list
                foreach (string mp3Path in openFileDialog.FileNames)
                {
                    mp3Files.Add(mp3Path);
                }

                if (mp3Files.Count > 0)
                {
                    currentTrackIndex = 0;
                    PlayCurrentTrack();
                }
            }
        }
    }

}