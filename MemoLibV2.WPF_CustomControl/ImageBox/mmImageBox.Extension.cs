using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MemoLibV2.WPF_CustomControl.ImageBox
{
    public partial class mmImageBox
    {
        public void AddFuntionButton(Button btn)
        {
            DockPanel.SetDock(btn, Dock.Right);
            pnControlFunction.Children.Add(btn);
        }
    }
}
