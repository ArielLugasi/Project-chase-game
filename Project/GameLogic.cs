using Windows.UI.Xaml.Controls;
using Windows.System;
namespace Project
{
    public class GameLogic
    {
        public Board board;

        public GameLogic(Canvas canvas)
        {
            board = new Board(canvas);
        }
        public void CleanUp()         // הגדרת פונקציה שמנקה את הלוח
        {
            board.player = null;
            board.enemies.Clear();
            board.boardCanvas.Children.Clear();
            board.timer.Stop();
            board.movetimer.Stop();

        }

        public void Start()           // הגדרת פונקציה ללחצן התחל
        {
            board.Start();
        }

        public void Pause()       // הגדרת פונקציה ללחצן עצירה
        {
            board.Pause();
        }

        public void KeyDown(VirtualKey key)               //הגדרת אילו כפתורים אני רוצה ומה קורה כאשר הכפתור נלחץ
        {
            switch (key)
            {
                case VirtualKey.Left:
                    board.left = true;
                    break;
                case VirtualKey.Up:
                    board.up = true;
                    break;
                case VirtualKey.Right:
                    board.right = true;
                    break;
                case VirtualKey.Down:
                    board.down = true;
                    break;
            }
        }

        public void KeyUp(VirtualKey key)          //הגדרת אילו כפתורים אני רוצה ומה קורה כאשר הכפתור נעזב
        {
            switch (key)
            {
                case VirtualKey.Left:
                    board.left = false;
                    break;
                case VirtualKey.Up:
                    board.up = false;
                    break;
                case VirtualKey.Right:
                    board.right = false;
                    break;
                case VirtualKey.Down:
                    board.down = false;
                    break;
            }
        }

    }
}
