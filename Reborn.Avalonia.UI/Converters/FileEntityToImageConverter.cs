using Shared.ViewModels;
using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia;
using Avalonia.Platform;
using Avalonia.Media.Imaging;
using Avalonia.Controls;
using Avalonia.Media;

namespace Reborn.Avalonia.UI
{
    internal class FileEntityToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var drawingGroup = new DrawingGroup();

            if(value is FileEntityViewModel entityViewModel)
            {
                switch (entityViewModel)
                {
                    case DirectoryViewModel directoryViewModel:
                        return Application.Current.FindResource("FolderIcon");
                    case FileViewModel fileViewModel:
                        return Application.Current.FindResource("FileIcon");
                }
            }

            return drawingGroup;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
