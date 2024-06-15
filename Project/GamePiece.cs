using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Project
{
    public class GamePiece
    {
        protected string imageUri = "";

        public Image Element { get; set; }         // הגדרת  תמונה

        public double X                          // הגדרת רוחב של הקנבאס
        {
            get
            {
                return Canvas.GetLeft(Element);
            }
            set
            {
                Canvas.SetLeft(Element, value);
            }
        }
        public double Y                         // הגדרת גובה של הקנבאס
        {
            get
            {
                return Canvas.GetTop(Element);
            }
            set
            {
                Canvas.SetTop(Element, value);
            }
        }
        public double Height               //  הגדרת גובה של התמונה
        {
            get
            {
                return Element.ActualHeight;
            }
            set
            {
                Element.Height = value;
            }
        }
        public double Width              // הגדרת רוחב של התמונה
        {
            get
            {
                return Element.ActualWidth;
            }
            set
            {
                Element.Width = value;
            }
        }
        public GamePiece()
        {
            Element = new Image();                            // הגדרת אלמנט כתמונה
            Element.Stretch = Stretch.Fill;
            Height = 100;
            Width = 100;
            Image();
        }

        protected virtual void Image()                  // הגדרת פונקציה ובעזרת הוירטואל נוכל לעשות אוברייד לפונקיצה
        {
            Element.Source = new BitmapImage(new Uri(imageUri));
        }

    }
}
