using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CoffeeDrinkCount.UI_Elements
{

    /// <summary>
    /// Diese Klasse stellt ein typisches Eingabefeld dieser Applikation dar
    /// </summary>
    class EntryInputfield : Entry
    {

        #region EntryInputfield() - Standard Konstruktor
        /// <summary>
        /// Standard Konstruktor
        /// </summary>
        public EntryInputfield()
        {
            HorizontalTextAlignment = TextAlignment.End;
            HorizontalOptions = LayoutOptions.FillAndExpand;
        }
        #endregion


        #region public EntryInputfield(string placeholderText, Color backgroundColor, Color textColor)
        /// <summary>
        /// Konstruktor 1
        /// Es kann das Design des Eingabefeldes festgelegt werden durch Angabe der Hintergrund und der Textfarbe
        /// Außerdem kann ein Platzhalter Text angegeben werden
        /// </summary>
        /// <param name="placeholderText">Dieser Text wird, vor der ersten Eingabe in dem Entry Objekt angegeben.</param>
        /// <param name="backgroundColor">Die Hintergrundfarbe des Objektes</param>
        /// <param name="textColor">Die Text Farbe des Objektes</param>
        public EntryInputfield(string placeholderText, Color textColor)
        {
            Color backgroundColor = Color.Transparent;

            Text = "";
            TextColor = textColor;
            Placeholder = placeholderText;
           // HorizontalTextAlignment = TextAlignment.End;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            BackgroundColor = backgroundColor;
        }
        #endregion

        #region public string GetValue()
        /// <summary>
        /// Öffentliche Methode, um den Inhalt des Textfeldes nach außen zu geben
        /// </summary>
        /// <returns>Der Inhalt des Textattributes wird nach außen gegeben</returns>
        public string GetValue()
        {
            return this.Text;
        }
        #endregion

    }
}
