using System;

namespace Project
{
    public class Enemy : GamePiece
    {
        public int step;

        protected override void Image()
        {
            imageUri = @"ms-appx:///Assets/sasuke.gif";           // הגדרת התמונה של האויב במשתנה
            step = new Random().Next(3, 10);         // Step = כמות צעדים רנגדומלית שאני נותן לו
            base.Image();
        }

        public void Move(GamePiece player)
        {
            if (this.X > player.X)
                this.X -= step;
            else
                this.X += step;

            if (this.Y < player.Y)
                this.Y += step;
            else
                this.Y -= step;
        }        // הגדרת תזוזה של האויב אחרי השחקן
    }
}

