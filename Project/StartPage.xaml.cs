using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;



namespace Project
{

    public sealed partial class StartPage : Page
    {
        public StartPage()
        {
            this.InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(BoardGame), Frame);       // call to BoardGame with StartPage
        }

    }
}
