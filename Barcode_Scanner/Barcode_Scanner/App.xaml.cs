using Acr.UserDialogs;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Barcode_Scanner
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            ToastConfig.DefaultActionTextColor = Color.White;
            ToastConfig.DefaultBackgroundColor = Color.FromRgb(0, 39, 59);
            ToastConfig.DefaultDuration = TimeSpan.FromSeconds(4.0);
            ToastConfig.DefaultPosition = ToastPosition.Bottom;

            MainPage = new NavigationPage(new MainPage()) { BarBackgroundColor = Color.Turquoise };  
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
