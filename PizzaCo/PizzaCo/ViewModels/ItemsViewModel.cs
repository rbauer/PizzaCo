using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using PizzaCo.Models;
using PizzaCo.Views;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace PizzaCo.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        ObservableCollection<Pizza> pizzas = new ObservableCollection<Pizza>();
        public ObservableCollection<Pizza> Pizzas
        {
            get { return pizzas; }
            set { SetProperty(ref pizzas, value); }
        }

        ObservableCollection<PizzaFavorite> pizzaFavorites = new ObservableCollection<PizzaFavorite>();
        public ObservableCollection<PizzaFavorite> PizzaFavorites
        {
            get { return pizzaFavorites; }
            set { SetProperty(ref pizzaFavorites, value); }
        }

        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Pizza Co's Favorite Pizza's - Top 20";
            Pizzas = new ObservableCollection<Pizza>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Pizzas.Clear();

                var client = new HttpClient();
                HttpResponseMessage httpResponseMessage = await client.GetAsync("https://www.olo.com/pizzas.json");
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var content = await httpResponseMessage.Content.ReadAsStringAsync();

                    Pizzas = JsonConvert.DeserializeObject<ObservableCollection<Pizza>>(content);

                    var tmp =
                        from p in Pizzas.Select(pt => string.Join(", ", pt.Toppings.OrderBy(t => t).ToList<string>()))
                        group p by p
                        into g
                        orderby g.Count() descending
                        select new PizzaFavorite { Toppings = g.Key, Count = g.Count() };

                    PizzaFavorites = new ObservableCollection<PizzaFavorite>(tmp.Take(20));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}