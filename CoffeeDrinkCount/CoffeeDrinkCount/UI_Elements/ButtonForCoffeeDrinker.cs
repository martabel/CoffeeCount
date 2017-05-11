using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoffeeDrinkCount.Data;

using Xamarin.Forms;

namespace CoffeeDrinkCount.UI_Elements
{
    class ButtonForCoffeeDrinker : ContentView
    {
        int numberOfCoffeePerMonth = 0;
        CoffeeDrinker coffeeDrinker = new CoffeeDrinker();


        //Deklaration
        LabelForInput labelForCoffeeDrinkerName;// wird im Konstrukor Initialisiert
        LabelForInput labelNumberOfCoffeeForDrinker;
        LabelForInput labelNameCount;


        private string fieldFoChanges; // Eingabetext des Nutzers
        public string FieldForChanges
        {
            get { return fieldFoChanges; }
            set
            {
                fieldFoChanges = value;
                OnPropertyChanged("FieldForChanges");
            }
        }


        #region public GridForUserInputForString(string labelDescription, string placeholderText, Color backgroundColor, Color textColor)
        /// <summary>
        /// Standard Konstrukor
        /// Bei Erstellung eines Objektes dieser Klasse müssen alle geroderten Parameter übergeben werden
        /// </summary>
        /// <param name="labelDescription">Beschreibung des Eingabefeldes. Beispiel "Vorname:"</param>
        /// <param name="numberOfCoffee">Dieser Text wird, vor der ersten Eingabe in dem Entry Objekt angegeben.</param>
        /// <param name="backgroundColor">Die Hintergrundfarbe des Objektes</param>
        /// <param name="textColor">Die Text Farbe des Objektes</param>
        public ButtonForCoffeeDrinker(CoffeeDrinker coffeeDrinkerForThisButton, int numberOfCoffee, Color backgroundColor, Color textColor)
        {
            Margin = new Thickness(6, 3, 6, 3);

            numberOfCoffeePerMonth = numberOfCoffee;

            coffeeDrinker = coffeeDrinkerForThisButton;

            Button buttonAddCoffeeForUser = new Button();
            buttonAddCoffeeForUser.BackgroundColor = backgroundColor;
            buttonAddCoffeeForUser.Text = "";
            buttonAddCoffeeForUser.Clicked += ButtonAddCoffeeForUser_Clicked;

            labelForCoffeeDrinkerName = new LabelForInput(coffeeDrinker.Firstname + " " + coffeeDrinker.Name, Color.Transparent, textColor);
            labelNumberOfCoffeeForDrinker = new LabelForInput(numberOfCoffeePerMonth.ToString(), Color.Transparent, textColor);
            labelNameCount = new LabelForInput("Anzahl Monat:", Color.Transparent, textColor);
            labelForCoffeeDrinkerName.SetTextsize(26);

            labelNameCount.VerticalTextAlignment = TextAlignment.End;
            labelNumberOfCoffeeForDrinker.VerticalTextAlignment = TextAlignment.Start;

            Grid grid = new Grid
            {
                BackgroundColor = Color.Transparent,//backgroundColor,
                VerticalOptions = LayoutOptions.FillAndExpand,
                ColumnSpacing = 0,
                HeightRequest = 80,
                #region RowDefinitions -
                RowDefinitions =
                {
                   // new RowDefinition { Height = GridLength.Auto },
                   // new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                #endregion

                #region ColumnDefinition
                ColumnDefinitions =
                {
                   // new ColumnDefinition { },
                   // new ColumnDefinition { },
                   new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                }
                #endregion

            };

            grid.Children.Add(buttonAddCoffeeForUser, 0, 2, 0, 2);
            grid.Children.Add(labelForCoffeeDrinkerName, 0, 1, 0, 2);
            grid.Children.Add(labelNameCount, 1, 0);
            grid.Children.Add(labelNumberOfCoffeeForDrinker, 1, 1);
            //grid.Children.Add(buttonAddCoffeeForUser,0,2,0,2);

            this.Content = grid; // Das Grid wird diesem ContentView als Inhalt übergeben
        }

        public void ButtonAddCoffeeForUser_Clicked(object sender, EventArgs e)
        {
            FieldForChanges = (FieldForChanges + 1).ToString();
        }
        #endregion



        #region GetValue()
        /// <summary>
        /// Gibt den aktuellen Text des Eingabefeldes zurück
        /// </summary>
        /// <returns></returns>
        public CoffeeDrinker GetCoffeeDrinker()
        {
            return coffeeDrinker;
        }
        #endregion


        public void AddOneCoffee()
        {
            numberOfCoffeePerMonth = numberOfCoffeePerMonth + 1;

            labelNumberOfCoffeeForDrinker.Text = numberOfCoffeePerMonth.ToString();
        }
    }
}
