﻿using System;
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
using Microsoft.Win32;
using System.IO;

namespace MemoLibV2.WPF_CustomControl.ImageBox
{
    /// <summary>
    /// Interaction logic for mmImageBox.xaml
    /// </summary>
    public partial class mmImageBox : UserControl
    {
        public mmImageBox()
        {
            InitializeComponent();
            InitThemes();
        }

       
    }
}
