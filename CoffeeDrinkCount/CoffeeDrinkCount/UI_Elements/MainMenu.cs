using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using CoffeeDrinkCount.Data;

namespace CoffeeDrinkCount.UI_Elements
{
    class MainMenu : ContentPage
    {
        CoffeeDatabase coffeedatabase;

        public MainMenu(CoffeeDatabase _coffeeDatabase, string path)
        {
            coffeedatabase = _coffeeDatabase;

            Title = "Kaffeeverwaltung";
            BackgroundColor = Color.FromHex("DDC9B2");
            Icon = "coffeemachine_2_comlete_white.png";
            

            buttonAddContentPageUserSetting.Clicked += OnAddContentPageAddUserClicked;
            buttonShowEntrys.Clicked += OnButtonAddContentPageUserSetting_Clicked;

            ScrollView scrollViewMainMenu = new ScrollView();

            StackLayout listWithUser = new StackLayout();
            listWithUser.Margin = 10;
            listWithUser.VerticalOptions = LayoutOptions.StartAndExpand;
            listWithUser.BackgroundColor = Color.FromHex("DDC9B2");

            listWithUser.Children.Add(buttonShowEntrys);
            listWithUser.Children.Add(buttonAddContentPageUserSetting);

           scrollViewMainMenu.Content = listWithUser;

            this.Content = scrollViewMainMenu;

        }



        private void OnButtonAddContentPageUserSetting_Clicked(object sender, EventArgs e)
        {
            ActivityIndicator watingForOpenPage = new ActivityIndicator();

            watingForOpenPage.Color = Color.White;
            watingForOpenPage.IsRunning = true;
         //   buttonAddContentPageUserSetting.Navigation.PushAsync(new ContentPageAddCoffeeForUser(coffeedatabase));
           // watingForOpenPage.IsRunning = false;
        }

        private void OnAddContentPageAddUserClicked(object sender, EventArgs e)
        {
            buttonAddContentPageUserSetting.Navigation.PushAsync(new ContentPageUserSetting(coffeedatabase));
        }



        Button buttonAddContentPageUserSetting = new Button()
        {
            Margin = new Thickness(10, 4, 10, 4),
            Text = "Benutzerverwaltung",
            //Image = new FileImageSource() { File = "timer.png" },
            // Font = Font.SystemFontOfSize(NamedSize.Large),
            TextColor = Color.White,
            // BorderWidth = 1,
            BackgroundColor = Color.FromHex("A36827"),
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.Start,
            HeightRequest = 100,
           // WidthRequest = 300
        };


        Button buttonShowEntrys = new Button()
        {
            Margin = new Thickness(10, 4, 10, 4),
            Text = "Kaffee trinken",
            //Image = new FileImageSource() { File = "timer.png" },
            // Font = Font.SystemFontOfSize(NamedSize.Large),
            TextColor = Color.White,
            // BorderWidth = 1,
            BackgroundColor = Color.FromHex("A36827"),
            //HorizontalOptions = LayoutOptions.Center,
            //  VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.Start,
            HeightRequest = 100,
            //WidthRequest = 300
        };

    }
}
