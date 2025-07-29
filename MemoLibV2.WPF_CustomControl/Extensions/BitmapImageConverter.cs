using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MemoLibV2.WPF_CustomControl.Extensions
{
    public static class BitmapImageConverter
    {

        public static BitmapSource ConvertToBitmapSource(Bitmap bitmap)
        {
            var hBitmap = bitmap.GetHbitmap();
            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                DeleteObject(hBitmap); // Clean up unmanaged resource
            }
        }
        public static BitmapSource ToBitmapSource(this Mat mat)
        {
            System.Windows.Media.PixelFormat pixelFormat;
            switch (mat.Channels())
            {
                case 1:
                    pixelFormat = PixelFormats.Gray8;
                    break;
    
                case 3:
                    pixelFormat = PixelFormats.Bgr24;
                    break;
                case 4:
                    pixelFormat = PixelFormats.Bgra32;
                    break;
                default:
                    throw new ArgumentException($"Unsupported channels: {mat.Channels()}");
            }

           

            return BitmapSource.Create(
                mat.Width,
                mat.Height,
                96, 96,
                pixelFormat,
                null,
                mat.Data,
                (int)(mat.Step() * mat.Height),
                (int)mat.Step());
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

    }


}
