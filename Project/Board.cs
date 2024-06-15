using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
namespace Project
{
    public class Board
    {


        public bool up, left, right, down = false;        // הגדרת הלחצנים במשתנים בוליאנים

        public bool isGameover = false;        // הגדרת משתנה בוליאני כאשר המשחק נגמר
        public Canvas boardCanvas;               //יצירת קאנבס וניתנת שם לפרמטר
        public Player player;                   // קריאה לקלאס "שחקן" באמצעור פרמטר פלייר
        public List<Enemy> enemies;             // יצירת ליסט enemies.

        public DispatcherTimer timer = new DispatcherTimer();         //יצירת שני טיימרים לאוייבים ולשחקן
        public DispatcherTimer movetimer = new DispatcherTimer();


        public Board(Canvas cnvs)
        {

            boardCanvas = cnvs;
            player = new Player();
            enemies = new List<Enemy>();

            boardCanvas.Children.Add(player.Element);           // יצירת השחקן ומיקומו בקאנבס
            player.X = boardCanvas.ActualWidth / 2;
            player.Y = boardCanvas.ActualHeight / 2;


            for (int i = 0; i < 4; i++)
            {

                Enemy e = new Enemy();                              //לולאה שיוצרת אוייבים וממקמת אותם במסך
                e.X = 100;
                e.Y = 200 + 200 * i;
                boardCanvas.Children.Add(e.Element);
                enemies.Add(e);
            }
            timer.Interval = new TimeSpan(0, 0, 0, 0, 30);                  //הגדרת זמנים  לשני טיימרים אחד לשחקן ואחד לאוייבים
            timer.Tick += Timer_Tick;
            timer.Start();

            movetimer.Interval = new TimeSpan(0, 0, 0, 0, 30);
            movetimer.Tick += MovingTick;
            movetimer.Start();
        }
        public bool Collision(GamePiece player, GamePiece enemy)    //בדיקה האם האובייקט של השחקן נוגע באובייקט של האויב
        {
            double wid = player.Width;
            double hi = player.Height;
            double XlocA = player.X;
            double YlocA = player.Y;
            double XlocB = enemy.X;
            double YlocB = enemy.Y;

            return ((XlocA + wid >= XlocB && XlocA + wid <= XlocB + wid && YlocA >= YlocB && YlocA <= YlocB + hi || XlocA + wid >= XlocB && XlocA + wid <= XlocB + wid && YlocA + hi >= YlocB && YlocA + hi <= YlocB) ||
                (XlocA >= XlocB && XlocA <= XlocB + wid && YlocA >= YlocB && YlocA <= YlocB + hi || XlocA >= XlocB && XlocA <= XlocB + wid && YlocA + hi >= YlocB && YlocA + hi <= YlocB + hi) ||
                (YlocA + hi >= YlocB && YlocA + hi <= YlocB + hi && XlocA >= XlocB && XlocA <= XlocB + wid || YlocA + hi >= YlocB && YlocA + hi <= YlocB + hi && XlocA + wid >= XlocB && XlocA + wid <= XlocB + wid) ||
                (YlocA <= YlocB && YlocA >= YlocB + hi && XlocA >= XlocB && XlocA <= XlocB + wid || YlocA <= YlocB && YlocA >= YlocB + hi && XlocA + wid >= XlocB && XlocA + wid <= XlocB + wid));

        }

        public bool enemyMeettingEnemy(Enemy firstEnemy, Enemy secondEnemy) // בדיקה כאשר האויב נוגע באויב אחר
        {
            double enemy1x = firstEnemy.X;
            double enemy2x = secondEnemy.X;
            double enemy1y = firstEnemy.Y;
            double enemy2y = secondEnemy.Y;

            // Calculate the centers of both enemies
            double enemy1CenterX = enemy1x + firstEnemy.Width / 2;
            double enemy1CenterY = enemy1y + firstEnemy.Height / 2;
            double enemy2CenterX = enemy2x + secondEnemy.Width / 2;
            double enemy2CenterY = enemy2y + secondEnemy.Height / 2;

            // Calculate the distance between the centers of the enemies
            double distanceX = Math.Abs(enemy1CenterX - enemy2CenterX);
            double distanceY = Math.Abs(enemy1CenterY - enemy2CenterY);

            // Calculate the minimum distance for overlap (half of the width or height of an enemy)
            double minOverlapX = Math.Min(firstEnemy.Width, secondEnemy.Width) / 2;
            double minOverlapY = Math.Min(firstEnemy.Height, secondEnemy.Height) / 2;

            // Check if enemies overlap at least half in both dimensions
            if (distanceX < minOverlapX && distanceY < minOverlapY)
            {
                return true;
            }

            return false;
        }



        private void MovingTick(object sender, object e)
        {
            if (up)
                MoveUp();
            if (down)
                MoveDown();
            if (right)
                MoveRight();
            if (left)
                MoveLeft();
        }

        public void Start()            // הגדרת פונקציה ללחצן התחלה
        {
            timer.Start();
            movetimer.Start();
        }
        public void Pause()     // הגדרת פונקציה ללחצן עצירה
        {
            timer.Stop();
            movetimer.Stop();

        }
        public void Timer_Tick(object sender, object e)         //טיימר שבודק את תזוזת  האוייבים  ובודקת את ההתנגשות שלהם עם השחקן אם פגעו בשחקן אז פועלות פונקציות
        {                                                         //שהטיימרים יפסיקו ופונקציה שהשחקן מת, אם זה לא קורה מופעל לולאה שבודקת האם האויבים מתנגשים בעצמם
            foreach (var enemy in enemies)  // ואם זה קורה אז האויבים נעלמים אחד אחד בעזרת הפונקציה שכתובה בתוך האיף ובסוף פונקציה אחרונה מופעלת  כאשר המשתמש מנצח
            {
                enemy.Move(player);

            }
            for (int j = 0; j < enemies.Count; j++)
            {
                if (Collision(enemies[j], player))
                {
                    isGameover = true;
                    timer.Stop();
                    movetimer.Stop();
                    player.KillPlayer();
                }

            }
            for (int i = 0; i < enemies.Count; i++)
            {

                for (int f = 0; f < enemies.Count; f++)
                {
                    if (i != f)
                    {
                        if (enemyMeettingEnemy(enemies[i], enemies[f]))
                        {
                            boardCanvas.Children.Remove(enemies[i].Element);
                            enemies.RemoveAt(i);
                            if (enemies.Count == 1)
                            {
                                boardCanvas.Children.Remove(enemies[i].Element);
                                WinGame();

                            }

                        }

                    }
                }
            }
        }
        public async void WinGame()                           //פונקציה שפועל כאשר המשתמש מנצח
        {
            timer.Stop();
            movetimer.Stop();
            MessageDialog msg1 = new MessageDialog("Nice!! , your the Winner");
            await msg1.ShowAsync();
        }
        private void MoveLeft()                                                    // מה קורה כאשר המשתמש לוחץ על החץ שמאלה
        {
            if (player.X > 0)
                player.X -= player.Speed;
            else
                player.X = boardCanvas.ActualWidth - player.Width;
        }
        private void MoveUp()                                                  // מה קורה כאשר המשתמש לוחץ על החץ למעלה
        {
            if (player.Y > 0)
                player.Y -= player.Speed;
            else
                player.Y = boardCanvas.ActualHeight - player.Height;
        }
        private void MoveRight()                                    // מה קורה כאשר המשתמש לוחץ על החץ ימינה
        {
            if (player.X + player.Width < boardCanvas.ActualWidth)
                player.X += player.Speed;
            else
                player.X = 0;
        }
        private void MoveDown()                           // מה קורה כאשר המשתמש לוחץ על החץ למטה
        {
            if (player.Y + player.Height < boardCanvas.ActualHeight)
                player.Y += player.Speed;
            else
                player.Y = 0;
        }
    }
}