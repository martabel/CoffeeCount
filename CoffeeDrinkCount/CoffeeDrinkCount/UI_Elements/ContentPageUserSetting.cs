using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using CoffeeDrinkCount.Data;

namespace CoffeeDrinkCount.UI_Elements
{
    class ContentPageUserSetting : ContentPage
    {

        CoffeeDatabase coffeedatabase;

        public ContentPageUserSetting(CoffeeDatabase _coffeeDatabase )
        {
            coffeedatabase = _coffeeDatabase;

            Title = "Benutzerverwaltung";
            BackgroundColor = Color.FromHex("DDC9B2");

            ScrollView scrollViewUserSetting = new ScrollView();

            buttonAddContentPageAddUser.Clicked += OnAddContentPageAddUserClicked;
            buttonShowEntrys.Clicked += ButtonShowEntrys_Clicked;
            

            Grid grid = new Grid
            {
                //BackgroundColor = Color.Aqua,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                //ColumnSpacing = 0,
                RowDefinitions =
                {
                   // new RowDefinition { Height = GridLength.Auto },
                   // new RowDefinition { Height = GridLength.Auto },
                   // new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                   // new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) }
                },
                ColumnDefinitions =
                {
                  //  new ColumnDefinition { Width = 300 },// GridLength.Auto },
                   // new ColumnDefinition { Width = GridLength.Auto },
                   // new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                   // new ColumnDefinition { Width = new GridLength(100, GridUnitType.Absolute) }
                }
            };

            grid.Children.Add(buttonShowEntrys, 0, 0);
            grid.Children.Add(buttonAddContentPageAddUser, 1, 0);
            grid.Children.Add(new Button { Text = "Dummy", VerticalOptions = LayoutOptions.FillAndExpand }, 0, 1);
            grid.Children.Add(new Button { Text = "Dummy", VerticalOptions = LayoutOptions.FillAndExpand }, 1, 1);
            //grid.Children.Add(new Label { Text = path, HorizontalOptions = LayoutOptions.FillAndExpand } , 0, 1);
            //grid.Children.Add(labelShowItems, 0, 2);
            //grid.Children.Add(new Button { Text = "Dummy", VerticalOptions = LayoutOptions.FillAndExpand }, 1, 1);
            //grid.Children.Add(new Button { Text = "Dummy", VerticalOptions = LayoutOptions.FillAndExpand }, 1, 2);
            //grid.Children.Add(new BoxView { BackgroundColor = Color.Yellow},0,2);


            scrollViewUserSetting.Content = grid;

            this.Content = scrollViewUserSetting;
        }

        private void ButtonShowEntrys_Clicked(object sender, EventArgs e)
        {
           // buttonAddContentPageAddUser.Navigation.PushAsync(new ContentPageAddCoffeeForUser(coffeedatabase));


           // labelShowItems.Text = showContent();
        }

        private void OnAddContentPageAddUserClicked(object sender, EventArgs e)
        {
            buttonAddContentPageAddUser.Navigation.PushAsync(new ContentPageAddNewUser(coffeedatabase));
        }

        Button buttonAddContentPageAddUser = new Button()
        {
            Margin = new Thickness(4, 4, 4, 4),
            Text = "Benutzer hinzufügen!",
            //Image = new FileImageSource() { File = "timer.png" },
            // Font = Font.SystemFontOfSize(NamedSize.Large),
            TextColor = Color.White,
            // BorderWidth = 1,
            BackgroundColor = Color.FromHex("A36827"),
            //HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.FillAndExpand,

        };

        Button buttonShowEntrys = new Button()
        {
            Margin = new Thickness(4, 4, 4, 4),
            Text = "Benutzer löschen!",
            //Image = new FileImageSource() { File = "timer.png" },
            // Font = Font.SystemFontOfSize(NamedSize.Large),
            TextColor = Color.White,
            // BorderWidth = 1,
            BackgroundColor = Color.FromHex("A36827"),
            //HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.FillAndExpand,

        };

    }
}
