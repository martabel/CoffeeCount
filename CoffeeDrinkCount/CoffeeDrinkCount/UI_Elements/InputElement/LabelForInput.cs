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
        /// Das Design des Labels kann hier angegeben werden.
       /// Der Hintergrund des Labels ist immer Transparent
       /// Angegeben werden kann die Textfarbe
        /// Es muss außerdem der Text des Labels festgelegt werden
        /// </summary>
        /// <param name="labelText">Der Text der angezeigt werden soll"</param>
        /// <param name="textColor">Die Text Farbe des Labels</param>
        public LabelForInput(string labelText, Color textColor)
        {
            Color backgroundColor = Color.Transparent;

            Text = labelText;
            TextColor = textColor;

            BackgroundColor = Color.Transparent;
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
