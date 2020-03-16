using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PizzaCo.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About Pizza Co";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.linkedin.com/in/ryan-bauer-2a018b52/"));
        }

        public ICommand OpenWebCommand { get; }
    }
}