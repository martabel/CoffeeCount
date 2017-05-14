using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CoffeeDrinkCount.UI_Elements
{
    class ButtonNormalMenu : Button
    {
        //Konstruktor
        public ButtonNormalMenu(string buttonText)
        {
            //Text des Button
            Text = buttonText;

            //Farben
            TextColor = Color.White;
            BackgroundColor = Color.FromHex("A36827");

            //Ausrichtung
            Margin = new Thickness(10, 4, 10, 4);
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.Start;
            HeightRequest = 100;
            
            // WidthRequest = 300
            // BorderWidth = 1,
            //Image = new FileImageSource() { File = "timer.png" },
            // Font = Font.SystemFontOfSize(NamedSize.Large),
        }
    }
}
