using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Prog6212_POE_ST10150631;

namespace Prog6212_POE_ST10150631.Pages
{
    public partial class MusicPg : Page
    {
        /// <summary>
        /// Media Player
        /// </summary>
        private MediaPlayer MusicPlayer;
        private List<string> SongList = new List<string>();
        private List<string> SongNames = new List<string>();    
        private int CurrentSong;
        /// <summary>
        /// Default constructor
        /// </summary>
        public MusicPg()
        {
            InitializeComponent();
            MusicPlayer = new MediaPlayer();
            LoadSongs();    
        }


        private void LoadSongs()
        {
            string songsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MusicFiles");

            if (Directory.Exists(songsFolder))
            {
                SongList = (Directory.GetFiles(songsFolder, "*.mp3").Select(Path.GetFullPath).ToList());
                SongNames = Directory.GetFiles(songsFolder, "*.mp3")
                    .Select(Path.GetFileNameWithoutExtension)
                    .ToList();

                foreach (var songName in SongNames)
                {
                    SongItemsControl.Items.Add($"{songName}");
                }
                txtSongTitle.Text = SongNames[CurrentSong];
            }
        }
        //string currentSong = songs[currentSongIndex];

        //// Extract artist and song title from the file name
        //string[] songParts = currentSong.Split('_');
        //string artist = songParts[0];
        //string songTitle = songParts[1];

        //// Get the path to the song file 
        //string songPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Songs", $"{currentSong}.mp3");

        //if (File.Exists(songPath))
        //{
        //    // Update the song title and artist text
        //    txtSongTitle1.Text = songTitle;
        //    txtArtits1.Text = artist;

        //    // Load and play the song
        //    mediaPlayer.Open(new Uri(songPath));
        //    mediaPlayer.Play();
        //}
        //else
        //{
        //    MessageBox.Show("The selected song file is missing.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //}




        private void BtnSkipBack_Click(object sender, RoutedEventArgs e)
        {
            if (SongList.Count >= 0)
            {
                CurrentSong--;
                if (CurrentSong < SongList.Count)
                {
                    CurrentSong = SongList.Count - 1;
                }
                txtSongTitle.Text = SongNames[CurrentSong];
                PlayCurrentSong();

            }
        }

        private void BtnPlay_Click(object sender, RoutedEventArgs e)
        {
            if(SongList.Count > 0)
            {
                PlayCurrentSong();
            }
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            MusicPlayer.Stop();
            CurrentSong = 0;
            txtSongTitle.Text = SongNames[CurrentSong];
        }

        private void BtnPause_Click(object sender, RoutedEventArgs e)
        {
            MusicPlayer.Pause();
        }
        /// <summary>
        /// Executes when the  skip button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSkipForwrd_Click(object sender, RoutedEventArgs e)
        {
            if (SongList.Count >= 0)
            {
                CurrentSong++;
                if (CurrentSong >= SongList.Count)
                {
                    CurrentSong = 0;
                }
                txtSongTitle.Text = SongNames[CurrentSong];
                PlayCurrentSong();
            }
        }



        private void BtnUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "MP3 Files|*.mp3",
                Multiselect = true,
            };

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string mp3Path in openFileDialog.FileNames)
                {
                    string songName = Path.GetFileNameWithoutExtension(mp3Path);
                    SongNames.Add(songName);
                    SongList.Add(mp3Path);
                    SongItemsControl.Items.Add(songName);
                }

                if (SongList.Count > 0)
                {
                    CurrentSong = 0;
                }
            }
        }
        private void PlayCurrentSong()
        {
            if (SongList.Count > 0)
            {
                string currentSongPath = SongList[CurrentSong];
                MusicPlayer.Open(new Uri(currentSongPath));
                MusicPlayer.Play();
            }
        }
    }


}