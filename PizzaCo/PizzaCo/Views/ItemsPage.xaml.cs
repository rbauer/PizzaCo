using System;
using System.ComponentModel;
using Xamarin.Forms;
using PizzaCo.Models;
using PizzaCo.ViewModels;

namespace PizzaCo.Views
{
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Pizzas.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}