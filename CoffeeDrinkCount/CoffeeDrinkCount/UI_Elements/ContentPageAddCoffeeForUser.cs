using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using CoffeeDrinkCount.Data;
using CoffeeDrinkCount.Utility;
using CoffeeDrinkCount.Model;

namespace CoffeeDrinkCount.UI_Elements
{
    class ContentPageAddCoffeeForUser : ContentPage
    {
        private ModelCoffeeDatabase modelCoffeeDatabase;

        //IEnumerable<OneCoffee> coffeeList;

        //IEnumerable<CoffeeDrinker> coffeeDrinkerList;

        public ContentPageAddCoffeeForUser(ModelCoffeeDatabase pModelCoffeeDatabase)
        {
            this.Title = "Kaffee trinken";
            this.BackgroundColor = Color.FromHex("DDC9B2");
            this.Icon = "coffeemachine_2_comlete_white.png";
            

            ToolbarItem toolbarSettings = new ToolbarItem();
            toolbarSettings.Icon = "settings_white.png";
            toolbarSettings.Clicked += ToolbarSettings_Clicked;


            ToolbarItems.Add(toolbarSettings);

            modelCoffeeDatabase = pModelCoffeeDatabase;

            ScrollView scrollView = new ScrollView();
            //scrollView

            StackLayout listWithUser = new StackLayout();
            listWithUser.Margin = 10;
            listWithUser.VerticalOptions = LayoutOptions.StartAndExpand;
            listWithUser.BackgroundColor = Color.FromHex("DDC9B2");

            #region Jeder Benutzer bekommt einen Button und wird zum Stacklayout hinzugefügt
            foreach (var item in modelCoffeeDatabase.coffeeDrinkerList)
            {
                int numberOfCoffee = CoffeeDrinkerUtility.countCoffeeForCoffeeDrinkerPerActualMonth(item.ID, modelCoffeeDatabase.coffeeList);

                ButtonForCoffeeDrinker buttonUserAddCoffeeDrinker = new ButtonForCoffeeDrinker(item, numberOfCoffee);
                buttonUserAddCoffeeDrinker.HorizontalOptions = LayoutOptions.FillAndExpand;
                buttonUserAddCoffeeDrinker.PropertyChanged += UserAddCoffee_Clicked;

                listWithUser.Children.Add(buttonUserAddCoffeeDrinker);
            } 
            #endregion

            scrollView.Content = listWithUser;

            this.Content = scrollView;
        }

        private void ToolbarSettings_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContentPageUserSetting(modelCoffeeDatabase));
        }

        public async void UserAddCoffee_Clicked(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "FieldForChanges")
            {// Wenn sich das Feld im ContentView ändert, dann

                //Ermittelt den Nutzer, der gerade seinen Button betätigt hat.
                ButtonForCoffeeDrinker buttonUserDrinkCoffee = (ButtonForCoffeeDrinker)sender;

                CoffeeDrinker coffeeDrinkerNow = buttonUserDrinkCoffee.GetCoffeeDrinker();
                //
                var answer = await DisplayAlert("Hallo " + coffeeDrinkerNow.Firstname + " " + coffeeDrinkerNow.Name + ",", "hast du dir einen Kaffee genommen?", "Ja", "Nein");

                if (answer == true)
                {// Wenn der Nutzer bestätigt, dass er gerade einen Kaffee getrunken hat.
                    // dann wird ein neuer Kaffee mit der Id des Nutzers der Datenbank hinzugefügt

                    modelCoffeeDatabase.AddOneCoffeeForUserById(coffeeDrinkerNow.ID);

                    buttonUserDrinkCoffee.AddOneCoffee(); // Label wird um 1 erhöht
                }
            }
        }


    }
}
