using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Barcode_Scanner
{
    public class MainPageViewModel
    {
        #region Properties
        private string _searchInput;
        public string SearchInput
        {
            get { return _searchInput; }
            set
            {
                SetProperty(ref _searchInput, value);
            }
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ICommand ClearCommand { get; private set; }

        public ICommand SubmitSearchCommand { get; private set; }
        #endregion
        public MainPageViewModel()
        {
            Title = "Barcode Scanner";
            ClearCommand = new Command(Clear);
            SubmitSearchCommand = new Command(SearchCommand);
        }
        public  void Clear()
        {
            SearchInput = "";
            OnPropertyChanged("SearchInput");
        }

        public  void SearchCommand()
        {
            if (SearchInput.Length == 0)
            {
                UserDialogs.Instance.Toast("Please Enter a Barcode");
            }
            else
            {
                UserDialogs.Instance.Toast("Barcode Entered: " + SearchInput);
            }
        }

        private bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void NoSearchResult_Message()
        {
            UserDialogs.Instance.Toast("Barcode could not be read, please try again.");
            return;
        }

        private IList<ToolbarItem> ToolbarItems { get; set; }

        public void SetToolbarConnectivity(IList<ToolbarItem> toolbarItems)
        {
            if (toolbarItems != null)
                ToolbarItems = toolbarItems;

        }
    }
}
