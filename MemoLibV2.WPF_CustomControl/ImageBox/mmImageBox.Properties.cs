using MemoLibV2.WPF_CustomControl.Extensions;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MemoLibV2.WPF_CustomControl.ImageBox
{
    public partial class mmImageBox
    {
        public static readonly DependencyProperty ImageSourceProperty =
        DependencyProperty.Register("ImageSource", typeof(Mat), typeof(mmImageBox),
        new PropertyMetadata(null, OnImageSourceChanged));

        public Mat ImageSource
        {
            get { return (Mat)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        private static void OnImageSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as mmImageBox;
            if (control != null)
            {
                if(e.NewValue != null)
                {
                    BitmapSource image = (e.NewValue as Mat).ToBitmapSource();
                    control.mainImage.Source = image;
                }
                else control.mainImage.Source = null;
       
            }
        }

        private static readonly DependencyProperty ViewNameProperty =
            DependencyProperty.Register("ViewName", typeof(string), typeof(mmImageBox));

        public string ViewName
        {
            get { return (string)GetValue(ViewNameProperty); }
            set { SetValue(ViewNameProperty, value); }
        }

        private static readonly DependencyProperty ControlPanelVisibilityProperty =
            DependencyProperty.Register("ControlPanelVisibility", typeof(Visibility), typeof(mmImageBox));
        public Visibility ControlPanelVisibility
        {
            get { return (Visibility)GetValue(ControlPanelVisibilityProperty); }
            set { SetValue(ControlPanelVisibilityProperty, value); }
        }

    }
}
