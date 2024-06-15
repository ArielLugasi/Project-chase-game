using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
namespace Project
{

    public sealed partial class BoardGame : Page
    {

        private GameLogic logic;          // call to gamelogic,  that we can use is functions.

        public BoardGame()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;       // פוקוסים ללחצנים האלה
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;

        }


        private void CoreWindow_KeyUp(CoreWindow sender, KeyEventArgs args)          //קריאה לפונקציה KeyUp
        {
            logic.KeyUp(args.VirtualKey);
        }
        private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)        //קריאה לפונקציה KeyDown
        {
            logic.KeyDown(args.VirtualKey);
        }
        private void MainPage_Loaded(object sender, RoutedEventArgs e)      // קריאה לעליית התוכנה
        {
            logic = new GameLogic(mainCanvas);
        }

        private void OnPlayClick(object sender, RoutedEventArgs e)     // קריאה למשחק להתחיל באמצעות כפתור ההתחל
        {
            logic.Start();
        }
        private void OnPauseClick(object sender, RoutedEventArgs e)        // קריאה למשחק לעצור באמצעות כפתור ההעצור
        {
            logic.Pause();
        }
        private void OnRestartClick(object sender, RoutedEventArgs e)       // קריאה למשחק לאתחל את עצמו ולנקות את המסך באמצעות כפתור אתחול 
        {
            logic.CleanUp();
            logic = new GameLogic(mainCanvas);
        }
    }
}
