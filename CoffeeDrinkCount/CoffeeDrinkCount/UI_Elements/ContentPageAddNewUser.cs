using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using CoffeeDrinkCount.Data;

namespace CoffeeDrinkCount.UI_Elements
{
    class ContentPageAddNewUser : ContentPage
    {
        CoffeeDatabase coffeeDatabase;
        IEnumerable<CoffeeDrinker> coffeeDrinkerList;

        Color backgroundColor = Color.FromHex("DDC9B2");

        Color userControlBackgroundColor = Color.Gray;
        Color userControlForegroundcolor = new Color();

        GridForUserInputForString gridUserInputVorname = new GridForUserInputForString("Vorname:", "Bitte angeben", Color.Gray, Color.White);
        GridForUserInputForString gridUserInputName = new GridForUserInputForString("Name:", "Bitte angeben", Color.Gray, Color.White);
        GridForUserInputForString gridUserInputChipId = new GridForUserInputForString("ChipId:", "Id z.B. 298746", Color.Gray, Color.White);
        GridForUserInputList gridUserListForDelete;
        Button buttonAddNewUser = new Button(); // Button zum Erzeugen eines neuen Users


        public ContentPageAddNewUser(CoffeeDatabase _coffeedatabase)
        {
            coffeeDatabase = _coffeedatabase; // Daten übergeben

            coffeeDrinkerList = coffeeDatabase.GetCoffeeDrinkers(); // Liste der Kaffeetrinker

            gridUserListForDelete = new GridForUserInputList("Benutzer wählen",coffeeDrinkerList.Select(x => x.Firstname + " " + x.Name).ToList());

            this.Title = "Benutzer hinzufügen"; // Menü überschrift

            BackgroundColor = backgroundColor;

            buttonAddNewUser.Clicked += ButtonAddNewUser_Clicked;

            buttonAddNewUser.BackgroundColor = Color.FromHex("A36827");
            buttonAddNewUser.HorizontalOptions = LayoutOptions.FillAndExpand;
            buttonAddNewUser.TextColor = Color.White;
            buttonAddNewUser.Text = "Neuen Benutzer anlegen";

            //buttonAddNewUser.FontSize = 20; //  NamedSize.Large;
            ScrollView scrollView = new ScrollView();

            scrollView.Content = new StackLayout
            {
                Margin = 10,
                VerticalOptions = LayoutOptions.StartAndExpand,
                BackgroundColor = Color.FromHex("DDC9B2"),
                // HorizontalOptions = LayoutOptions.Start,

                Children = {
                        gridUserInputVorname,
                        gridUserInputName,
                        gridUserInputChipId,
                        new BoxView() //Platzhalter
                        {
                            BackgroundColor = Color.FromHex("DDC9B2"),
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            WidthRequest = 20,
                        },
                        buttonAddNewUser,
                        new BoxView() // Platzhalter
                        {
                            BackgroundColor = Color.FromHex("DDC9B2"),
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                        },
                        gridUserListForDelete,

        }
            };

            this.Content = scrollView;
        }



        #region ButtonAddNewUser_Clicked
        private async void ButtonAddNewUser_Clicked(object sender, EventArgs e)
        {
            CoffeeDrinker newCoffeeDrinker = new CoffeeDrinker();

            // To DO - Wenn Felder leer! Benutzer nicht speichern!
            if (gridUserInputVorname.GetValue() != null || gridUserInputVorname.GetValue() != "" && gridUserInputName.GetValue() != null || gridUserInputName.GetValue() != "")
            {
                newCoffeeDrinker.Firstname = gridUserInputVorname.GetValue();
                newCoffeeDrinker.Name = gridUserInputName.GetValue();
                newCoffeeDrinker.ChipId = gridUserInputChipId.GetValue();
                newCoffeeDrinker.Email = "-";
                newCoffeeDrinker.Active = true;

                bool nameIsUsed = false;

                foreach (var item in coffeeDrinkerList)
                {//Liste aller Kaffetrinker wird durchlaufen
                 // Es wird überprüft, ob der name schon vorhanden ist.
                    if (item.Name == newCoffeeDrinker.Name && item.Firstname == newCoffeeDrinker.Firstname)
                    {
                        nameIsUsed = true;
                        break;// Wenn ein Name gefunden wurde, wird die Schleife verlassen
                    }
                }


                if (nameIsUsed == false)
                {// Ist der Benutzer noch kein 2. Mal vorhanden wird dieser gespeichert
                    saveNewCoffeeDrinker(coffeeDatabase, newCoffeeDrinker, coffeeDrinkerList);
                }
                else
                {// Wenn der Name schon vorhanden ist, wird eine Fehlermeldung ausgegeben

                    var answer = await DisplayAlert("Name schon vorhanden!", "Möchtest du den Benutzer " + newCoffeeDrinker.Firstname + " " + newCoffeeDrinker.Name + " ein zweites mal anlegen?", "Ja", "Nein");

                    if (answer == true)
                    {// Wen der name trotzdem ein 2. mal angelegt werden soll...
                     //dann wir der Benutzer gespeichert
                        saveNewCoffeeDrinker(coffeeDatabase, newCoffeeDrinker, coffeeDrinkerList);
                    }
                }
            }
            else
            {// Wenn eins der beiden Felder leer ist,
                //dann wird dem Nutzer ein Hinweis eingeblendet
                await DisplayAlert("Speichern nicht möglich!", "Die Felder \"Vorname\" und \"Name\" dürfen nicht leer sein!", "OK");
            }

        } 

        #endregion



        #region saveNewCoffeeDrinker
        /// <summary>
        /// Ein neuer Benutzer wird hinzugefügt
        /// Es wird ein Hinweis eingeblendet, das der Nutzer erfolgreich hinzugefügt wurde
        /// </summary>
        /// <param name="coffeeDatabase">Datenbank</param>
        /// <param name="newCoffeeDrinker">Neuer Kaffeetrinker</param>
        /// <param name="coffeeDrinkerList">Liste aller Kaffetrinker aus der Datenbank</param>
        private async void saveNewCoffeeDrinker(CoffeeDatabase coffeeDatabase, CoffeeDrinker newCoffeeDrinker, IEnumerable<CoffeeDrinker> coffeeDrinkerList)
        {
            //, dann wir der Benutzer in der Datenbank gespeichert.
            coffeeDatabase.SaveCoffeeDrinker(newCoffeeDrinker);
            // Außerdem wird die Liste - zum überprüfen der Namen - aktualisiert
            coffeeDrinkerList = coffeeDatabase.GetCoffeeDrinkers();

            await DisplayAlert("Speichern erfolgreich!", "Benutzer erfolgreich hinzugefügt", "OK");

        } 
        #endregion

    }
}
