using Shared.ViewModels;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace ReBorn.WPF.UI
{
    internal class FileEntityToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var drawingImage = new DrawingImage();

            if(value is DirectoryViewModel) 
            {
                var directoryImageSource = Application.Current.TryFindResource("FolderIcon");
                if (directoryImageSource is ImageSource directoryImageInstance)
                    return directoryImageInstance;
            }
            else if (value is FileEntityViewModel)
            {
                var fileImageSource = Application.Current.TryFindResource("FileIcon");
                if (fileImageSource is ImageSource fileImageInstance)
                    return fileImageInstance;
            }

            return drawingImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
