using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

using Xamarin.Forms;

using CoffeeDrinkCount.Data;
using CoffeeDrinkCount.UI_Elements;

namespace CoffeeDrinkCount
{
    public class App : Application
    {
        string path = "Fehler!";

        public CoffeeDatabase coffeeDatabase;

        public App()
        {
                path = DependencyService.Get<ILocalFileHelper>().GetLocalFilePath("CoffeeDatabase.db3");

                coffeeDatabase = new CoffeeDatabase(new SQLiteConnection(path));

            // The root page of your application
            MainPage = new NavigationPage(new MainMenu(coffeeDatabase))
            {
                BarBackgroundColor = Color.FromHex("573715"),
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
