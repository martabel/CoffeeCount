using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

using Xamarin.Forms;


using CoffeeDrinkCount.Data;
using CoffeeDrinkCount.UI_Elements;
using CoffeeDrinkCount.Model;

namespace CoffeeDrinkCount
{
    public class App : Application
    {
        ModelCoffeeDatabase modelCoffeeDatabase = new ModelCoffeeDatabase();

        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new ContentPageAddCoffeeForUser(modelCoffeeDatabase)) // MainMenu(modelCoffeeDatabase))
            {
                BarBackgroundColor = Color.FromHex("573715"), // Farbe der Leiste Oben - Mittel Braun - Bar Farbe
            };
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
