using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace UWPNetNativeSample
{
    public sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            if (!(Window.Current.Content is MainPage))
            {
                MainPage mainPage = new MainPage();
                Window.Current.Content = mainPage;
            }

            if (e.PrelaunchActivated == false)
            {
                Window.Current.Activate();
            }
        }
    }
}
