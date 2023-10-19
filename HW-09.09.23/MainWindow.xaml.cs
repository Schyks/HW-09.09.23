using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HW_09._09._23
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Video Files|*.mp4;*.mkv;*.avi|All Files|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                mediaElement.Source = new Uri(openFileDialog.FileName);
                mediaElement.LoadedBehavior = MediaState.Manual;
                filenameText.Text = System.IO.Path.GetFileName(openFileDialog.FileName);
                mediaElement.Play();
            }
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            if (mediaElement.Source == null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Video Files|*.mp4;*.mkv;*.avi|All Files|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    mediaElement.Source = new Uri(openFileDialog.FileName);
                    mediaElement.LoadedBehavior = MediaState.Manual;
                    filenameText.Text = System.IO.Path.GetFileName(openFileDialog.FileName);
                    mediaElement.Play();
                }
            }
            else
            {
                mediaElement.Play();
            }
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (mediaElement.Source != null)
            {
                mediaElement.Pause();
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            if (mediaElement.Source != null)
            {
                mediaElement.Stop();
                slider.Value = 0;
                mediaElement.Close();
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           mediaElement.Position = TimeSpan.FromSeconds((slider.Value / 100) * mediaElement.NaturalDuration.TimeSpan.TotalSeconds);
           SliderText.Text = $"{(int)slider.Value}%";
        }

    }
}

