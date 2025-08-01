﻿using Microsoft.Win32;
using OpenCvSharp;
using System;
using System.Collections.Generic;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now;

            var openFileDialog = new OpenFileDialog
            {
                Title = "Select Image File",
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.tiff|All Files|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Load image với OpenCV
                    Mat mat = Cv2.ImRead(openFileDialog.FileName);
                    this.imageBox.ImageSource = mat;


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error");
                }
            }
        }
    }
}
