using Windows.UI.Xaml.Controls;


namespace Project
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            mainFrame.Navigate(typeof(StartPage), mainFrame);          /*  Call StartPage   with MainPaige */
        }
    }
}
