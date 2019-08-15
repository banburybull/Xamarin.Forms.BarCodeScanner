using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace Barcode_Scanner
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel viewModel;
        ZXingScannerPage scanPage;
        public MainPage()
        {
            BindingContext = viewModel = new MainPageViewModel();
            viewModel.SetToolbarConnectivity(ToolbarItems);
            InitializeComponent();
        }

        private async void Barcode_Clicked(object sender, EventArgs e)
        {
            // Create our custom overlay
            var customOverlay = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            var cancel = new Button
            {
                Text = "Cancel",
                VerticalOptions = LayoutOptions.End

            };
            cancel.Clicked += delegate {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Navigation.PopAsync();
                });
            };
            customOverlay.Children.Add(cancel);


            scanPage = new ZXingScannerPage(new ZXing.Mobile.MobileBarcodeScanningOptions { AutoRotate = true, TryHarder = true }, customOverlay: customOverlay);
            scanPage.OnScanResult += (result) => {
                scanPage.IsScanning = false;

                if (result != null && result.Text.Length > 0)
                {
                    viewModel.SearchInput = result.Text;


                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Navigation.PopAsync();
                    });

                    viewModel.SearchCommand();
                }
                else
                {
                    viewModel.NoSearchResult_Message();
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Navigation.PopAsync();
                    });
                }
            };

            await Navigation.PushAsync(scanPage);
        }

        private void Search_Completed(object sender, EventArgs e)
        {
            viewModel.SearchCommand();
        }
    }
}
