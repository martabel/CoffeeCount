using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CoffeeDrinkCount.UI_Elements
{
    class LabelForInput : Label
    {

        #region Konstruktor
        /// <summary>
        /// Konstruktor
        /// Das Design des Labels kann hier angegeben werden. Hierzu kann
        /// die Hintergrundfarbe und die Textfarbe angegeben werden.
        /// Es muss außerdem der Text des Labels festgelegt werden
        /// </summary>
        /// <param name="labelText">Der Text der angezeigt werden soll"</param>
        /// <param name="backgroundColor">Die Hintergrundfarbe des Objektes</param>
        /// <param name="textColor">Die Text Farbe des Objektes</param>
        public LabelForInput(string labelText, Color backgroundColor, Color textColor)
        {
            Text = labelText;
            TextColor = textColor;
            BackgroundColor = backgroundColor;
            VerticalTextAlignment = TextAlignment.Center;
            HorizontalTextAlignment = TextAlignment.Center;
            LineBreakMode = LineBreakMode.CharacterWrap;
            HorizontalOptions = LayoutOptions.FillAndExpand;
        }
        #endregion

        public void SetTextsize(int fontSize)
        {
            this.FontSize = fontSize;
        }
    }
}
