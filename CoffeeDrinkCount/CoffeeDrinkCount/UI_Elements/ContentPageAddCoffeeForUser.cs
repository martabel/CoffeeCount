using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using CoffeeDrinkCount.Data;
using CoffeeDrinkCount.Utility;

namespace CoffeeDrinkCount.UI_Elements
{
    class ContentPageAddCoffeeForUser : ContentPage
    {
        CoffeeDatabase coffeeDatabase;

        IEnumerable<OneCoffee> coffeeList;

        IEnumerable<CoffeeDrinker> coffeeDrinkerList;

        public ContentPageAddCoffeeForUser(CoffeeDatabase _coffeedatabase)
        {
            this.Title = "Kaffee trinken";
            this.BackgroundColor = Color.FromHex("DDC9B2");

            coffeeDatabase = _coffeedatabase;

            coffeeList = coffeeDatabase.GetCoffees();

            coffeeDrinkerList = coffeeDatabase.GetCoffeeDrinkers();

            ScrollView scrollView = new ScrollView();
            //scrollView

            StackLayout listWithUser = new StackLayout();
            listWithUser.Margin = 10;
            listWithUser.VerticalOptions = LayoutOptions.StartAndExpand;
            listWithUser.BackgroundColor = Color.FromHex("DDC9B2");

            #region Jeder Benutzer bekommt einen Button und wird zum Stacklayout hinzugefügt
            foreach (var item in coffeeDrinkerList)
            {
                int numberOfCoffee = CoffeeDrinkerUtility.countCoffeeForCoffeeDrinkerPerActualMonth(item.ID, coffeeList);

                ButtonForCoffeeDrinker userAddCoffeeDrinker = new ButtonForCoffeeDrinker(item, numberOfCoffee, Color.FromHex("A36827"), Color.White);

                userAddCoffeeDrinker.HorizontalOptions = LayoutOptions.FillAndExpand;

                userAddCoffeeDrinker.PropertyChanged += UserAddCoffee_Clicked;

                listWithUser.Children.Add(userAddCoffeeDrinker);
            } 
            #endregion

            scrollView.Content = listWithUser;

            this.Content = scrollView;
        }

        public async void UserAddCoffee_Clicked(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "FieldForChanges")
            {// Wenn sich das Feld im ContentView ändert, dann

                //Ermittel den Nutzer, der gerade seinen Button betätigt hat.
                ButtonForCoffeeDrinker userDrinkCoffee = (ButtonForCoffeeDrinker)sender;

                CoffeeDrinker coffeeDrinkerNow = userDrinkCoffee.GetCoffeeDrinker();
                //
                var answer = await DisplayAlert("Hallo " + coffeeDrinkerNow.Firstname + " " + coffeeDrinkerNow.Name + ",", "hast du dir einen Kaffee genommen?", "Ja", "Nein");

                if (answer == true)
                {// Wenn der Nutzer bestätigt, dass er gerade einen Kaffee getrunken hat.
                    // dann wird ein neuer Kaffee mit der Id des Nutzers der Datenbank hinzugefügt

                    OneCoffee coffee = new OneCoffee();

                    coffee.CoffeeCosumer_Id = coffeeDrinkerNow.ID.ToString();
                    coffee.Payed = false;
                    coffee.DateTime = DateTime.Now.ToString();

                    coffeeDatabase.SaveCoffee(coffee);

                    userDrinkCoffee.AddOneCoffee(); // Label wird um 1 erhöht
                }
            }
        }


    }
}
