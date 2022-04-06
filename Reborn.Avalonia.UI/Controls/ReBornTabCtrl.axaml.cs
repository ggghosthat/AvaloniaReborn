using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Reborn.Avalonia.UI
{
    public partial class ReBornTabCtrl : UserControl
    {
        public ReBornTabCtrl()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
