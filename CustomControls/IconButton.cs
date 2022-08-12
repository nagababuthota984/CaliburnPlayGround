using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CaliburnPlayGround.CustomControls
{
    public class IconButton : Button
    {


        public string IconSource
        {
            get 
            { 
                return (string)GetValue(IconSourceProperty); 
            }
            set 
            {
                SetValue(IconSourceProperty, value); 
            }
        }


        public static readonly DependencyProperty IconSourceProperty =
            DependencyProperty.Register("IconSource", typeof(string), typeof(IconButton), new PropertyMetadata(string.Empty, OnIconSourcePropertyChanged));


        private static void OnIconSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is string imgPath && !string.IsNullOrWhiteSpace(imgPath))
            {
                try
                {
                    Uri imgUri = new(imgPath, UriKind.Relative);
                    Image icon = new() { Source = new BitmapImage(imgUri) };
                    if (d is Button btn && btn != null)
                    {
                        string textContent = btn.Content != null ? btn.Content.ToString() : string.Empty;
                        btn.Content = BuildAndGetPanel(icon, textContent);
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message.ToString());
                }
            }
        }

        private static StackPanel BuildAndGetPanel(Image icon, string? textContent)
        {
            StackPanel panel = new() { Orientation = Orientation.Horizontal };
            panel.Children.Add(new TextBlock() { Text = textContent });
            panel.Children.Add(icon);
            return panel;
        }
    }
}
