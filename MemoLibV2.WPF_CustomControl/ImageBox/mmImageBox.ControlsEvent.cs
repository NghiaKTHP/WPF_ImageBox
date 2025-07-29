using Microsoft.Win32;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MemoLibV2.WPF_CustomControl.ImageBox
{
    public partial class mmImageBox
    {
        private void FitImageToWindow_CLick(object sender, RoutedEventArgs e)
        {
            this.ZoomAndPanControl.ZoomAndPanInitialPosition = ZoomAndPan.ZoomAndPanInitialPositionEnum.FitScreen;
            this.ZoomAndPanControl.ScaleToFit();
        }

        private void FillImageToWindow_CLick(object sender, RoutedEventArgs e)
        {
            this.ZoomAndPanControl.ZoomAndPanInitialPosition = ZoomAndPan.ZoomAndPanInitialPositionEnum.FillScreen;
            this.ZoomAndPanControl.ScaleToFit();
        }

        private void SaveImage_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bitmap Image (*.bmp)|*.bmp|" +
                                    "PNG Image (*.png)|*.png|" +
                                   "JPEG Image (*.jpg)|*.jpg|" +
                                   "JPEG Image (*.jpeg)|*.jpeg|" +

                                   "All Image Files|*.png;*.jpg;*.jpeg;*.bmp|" +
                                   "All Files (*.*)|*.*";

            saveFileDialog.DefaultExt = "bmp";
            saveFileDialog.Title = "Save Image";
            saveFileDialog.FileName = $"{dt.Year}_{dt.Month}_{dt.Day}_{dt.Hour}_{dt.Minute}_{dt.Second}";

            if (saveFileDialog.ShowDialog() == true)
            {
                string fileName = saveFileDialog.FileName;
                //string extension = System.IO.Path.GetExtension(fileName).ToLower();

                Cv2.ImWrite(fileName, this.ImageSource);
            }
        }

        private void SaveGraphicsImage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ClearView_Click(object sender, RoutedEventArgs e)
        {
            this.ImageSource = null;
        }
        private void ClearGraphics_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
