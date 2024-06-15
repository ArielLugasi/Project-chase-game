using System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;

namespace Project
{
    public class Player : GamePiece
    {
        public string playerDead = @"ms-appx:///Assets/dead.png";              //הגדרת תמונה בתוך הסטרינג
        public double Speed { get; internal set; }                   //הגדרת מהירות

        protected override void Image()                    //הגדרת פונקציה והעברתה באמצעות Override 
        {
            Speed = 15;
            imageUri = @"ms-appx:///Assets/NarotuK (1).gif";
            base.Image();
        }
        public async void KillPlayer()                    // פונקציה שפועלת כאשר השחקן מת
        {
            Element.Source = new BitmapImage(new Uri(playerDead));
            MessageDialog msg = new MessageDialog("Not bad, maybe next time :D ");
            await msg.ShowAsync();
        }
    }
}
