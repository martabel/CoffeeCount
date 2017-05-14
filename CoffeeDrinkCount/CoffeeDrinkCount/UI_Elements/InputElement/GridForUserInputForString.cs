using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;


namespace CoffeeDrinkCount.UI_Elements
{

    class GridForUserInputForString : ContentView
    {
        //Deklaration
        EntryInputfield inputField; // wird im Konstrukor Initialisiert
        LabelForInput labelForInput;// wird im Konstrukor Initialisiert


        private string inputFieldValueText; // Eingabetext des Nutzers
        public string InputFieldValue
        {
            get { return inputFieldValueText; }
            set
            {
                inputFieldValueText = value;
                OnPropertyChanged("InputFieldValue");
            }
        }


        #region public GridForUserInputForString(string labelDescription, string placeholderText, Color backgroundColor, Color textColor)
        /// <summary>
        /// Standard Konstrukor
        /// Bei Erstellung eines Objektes dieser Klasse müssen alle geroderten Parameter übergeben werden
        /// </summary>
        /// <param name="labelDescription">Beschreibung des Eingabefeldes. Beispiel "Vorname:"</param>
        /// <param name="placeholderText">Dieser Text wird, vor der ersten Eingabe in dem Entry Objekt angegeben.</param>
        /// <param name="backgroundColor">Die Hintergrundfarbe des Objektes</param>
        /// <param name="textColor">Die Text Farbe des Objektes</param>
        public GridForUserInputForString(string labelDescription, string placeholderText, Color backgroundColor, Color textColor)
        {
            Margin = Margin = new Thickness(6, 2, 6, 0);

            inputField = new EntryInputfield(placeholderText, Color.FromHex("D68933"), Color.Black);// backgroundColor, textColor);
            inputField.TextChanged += inputField_TextChanged;
            
            labelForInput = new LabelForInput(labelDescription, Color.FromHex("D68933"), Color.Black);

            Grid grid = new Grid
            {
                BackgroundColor = Color.Yellow,
                VerticalOptions = LayoutOptions.FillAndExpand,
                ColumnSpacing = 0,
                #region RowDefinitions -
                //RowDefinitions =
                //{
                //   // new RowDefinition { Height = GridLength.Auto },
                //   // new RowDefinition { Height = GridLength.Auto },
                //   // new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                //   // new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) }
                //}, 
                #endregion
                ColumnDefinitions =
                {
                   // new ColumnDefinition { },
                   // new ColumnDefinition { },
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                   new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) }
                }
            };

            grid.Children.Add(labelForInput, 0, 0);
            grid.Children.Add(inputField, 1, 0);
            // grid.Children.Add(new LabelForInput(labelUnit, backgroundColor, textColor), 2, 0);

            this.Content = grid; // Das Grid wird dieser Seite als Inhalt übergeben
        }
        #endregion


        #region inputField_TextChanged
        /// <summary>
        /// Wenn der Text des Eingabefeldes geändert wird, wird dieses Event ausgelöst
        /// </summary>
        /// <param name="sender">Auslöser des Ereignisses</param>
        /// <param name="e">Eventhandler</param>
        private void inputField_TextChanged(object sender, TextChangedEventArgs e)
        {
            InputFieldValue = inputField.Text;
        } 
        #endregion


        #region GetValue()
        /// <summary>
        /// Gibt den aktuellen Text des Eingabefeldes zurück
        /// </summary>
        /// <returns></returns>
        public string GetValue()
        {
            return inputFieldValueText;
        } 
        #endregion


    }

}
