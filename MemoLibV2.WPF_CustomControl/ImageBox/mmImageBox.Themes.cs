using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Xceed.Wpf.Toolkit.Primitives;

namespace MemoLibV2.WPF_CustomControl.ImageBox
{
    public enum ImageBoxThemes
    {
        GridTileBrush,
        GridTileBrushExtraSmall,
        GridTileBrushBlue,
        GridTileBrushGreen,
        GridTileBrushBlack,
        GridTileBrushBlackSmall,
        GridTileBrushDarkGray,
        GridTileBrushBlackBlue,
        DiamondTileBrush,
        HexagonTileBrush,
        DotTileBrushSmall,
        CrossHatchTileBrush,
        BrickTileBrush
    }
    public partial class mmImageBox
    {
        public static readonly DependencyProperty ThemeProperty =
        DependencyProperty.Register("Theme", typeof(ImageBoxThemes), typeof(mmImageBox),
        new PropertyMetadata(ImageBoxThemes.GridTileBrushDarkGray, OnThemeChanged));

        public ImageBoxThemes Theme
        {
            get { return (ImageBoxThemes)GetValue(ThemeProperty); }
            set { SetValue(ThemeProperty, value); }
        }

        private static void OnThemeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as mmImageBox;
            string resourceKey = e.NewValue.ToString();

            if (control.Resources.Contains(resourceKey)) {
                control.ZoomAndPanControl.Background = (Brush)control.Resources[resourceKey];
            }

            foreach (MenuItem item in control.themeMenu.Items)
            {
                if (item.Header.ToString() == resourceKey) {
                    item.IsChecked = true;
                }
                else item.IsChecked = false;
            }
        }

        public void InitThemes()
        {
            string[] themeNames = Enum.GetNames(typeof(ImageBoxThemes));
            foreach (string theme in themeNames) { 
                MenuItem item = new MenuItem();
                item.Header = theme;
                item.IsCheckable = true;
                item.IsChecked = false;
                item.Click += ChangeThemes_Click;
                themeMenu.Items.Add(item);

            }

            this.Theme = ImageBoxThemes.GridTileBrushGreen;
        }

        private void ChangeThemes_Click(object sender, RoutedEventArgs e)
        {
            MenuItem selectedItem = e.Source as MenuItem;
            string themeString = selectedItem.Header as string;

            this.Theme = (ImageBoxThemes)Enum.Parse(typeof(ImageBoxThemes), themeString);

          
        }
    }
}
