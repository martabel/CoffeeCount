using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using CoffeeDrinkCount.Data;
using CoffeeDrinkCount.Model;

namespace CoffeeDrinkCount.UI_Elements
{
    class ContentPageAddNewUser : ContentPage
    {
        private ModelCoffeeDatabase modelCoffeeDatabase;
       // IEnumerable<CoffeeDrinker> coffeeDrinkerList;

        Color backgroundColor = Color.FromHex("DDC9B2");

        Color userControlBackgroundColor = Color.Gray;
        Color userControlForegroundcolor = new Color();

        GridForUserInputForString gridUserInputVorname = new GridForUserInputForString("Vorname:", "Bitte angeben");
        GridForUserInputForString gridUserInputName = new GridForUserInputForString("Name:", "Bitte angeben");
        GridForUserInputForString gridUserInputChipId = new GridForUserInputForString("ChipId:", "Id z.B. 298746");
        GridForUserInputList gridUserListForDelete;
        Button buttonAddNewUser = new Button(); // Button zum Erzeugen eines neuen Users


        public ContentPageAddNewUser(ModelCoffeeDatabase pModelCoffeeDatabase)
        {
            modelCoffeeDatabase = pModelCoffeeDatabase; // Daten übergeben

            gridUserListForDelete = new GridForUserInputList("Benutzer wählen",modelCoffeeDatabase.coffeeDrinkerList.Select(x => x.Firstname + " " + x.Name).ToList());

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
        /// <summary>
        /// Wenn der Button betätigt wird, wird ein Neuer Nutzer, wenn er nicht zur Verfügung steht hinzugefügt!
        /// </summary>
        /// <param name="sender">Auslöser des Event</param>
        /// <param name="e">Abrufbare Parameter des Events</param>
        private async void ButtonAddNewUser_Clicked(object sender, EventArgs e)
        {
            await addNewCoffeeDrinker();
        }
        #endregion


        #region addNewCoffeeDrinker
        private async Task addNewCoffeeDrinker()
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

                foreach (var item in modelCoffeeDatabase.coffeeDrinkerList)
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
                    saveNewCoffeeDrinker(newCoffeeDrinker, modelCoffeeDatabase);
                }
                else
                {// Wenn der Name schon vorhanden ist, wird eine Fehlermeldung ausgegeben

                    var answer = await DisplayAlert("Name schon vorhanden!", "Möchtest du den Benutzer " + newCoffeeDrinker.Firstname + " " + newCoffeeDrinker.Name + " ein zweites mal anlegen?", "Ja", "Nein");

                    if (answer == true)
                    {// Wen der name trotzdem ein 2. mal angelegt werden soll...
                     //dann wir der Benutzer gespeichert
                        saveNewCoffeeDrinker(newCoffeeDrinker, modelCoffeeDatabase);
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
        private async void saveNewCoffeeDrinker(CoffeeDrinker newCoffeeDrinker, ModelCoffeeDatabase modelCoffeeDatabase)
        {
            //, dann wir der Benutzer in der Datenbank gespeichert.
            modelCoffeeDatabase.addCoffeeDrinker(newCoffeeDrinker.Firstname, newCoffeeDrinker.Name, newCoffeeDrinker.ChipId);
            await DisplayAlert("Speichern erfolgreich!", "Benutzer erfolgreich hinzugefügt", "OK");
        } 
        #endregion

    }
}
