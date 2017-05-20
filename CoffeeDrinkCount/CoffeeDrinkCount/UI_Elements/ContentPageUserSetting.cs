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
    class ContentPageUserSetting : ContentPage
    {
        private ModelCoffeeDatabase modelCoffeeDatabase;

        public ContentPageUserSetting(ModelCoffeeDatabase pModelCoffeeDatabase)
        {
            modelCoffeeDatabase = pModelCoffeeDatabase;

            Title = "Einstellungen";
            this.Icon = "settings_white.png";
            BackgroundColor = Color.FromHex("DDC9B2");

            ScrollView scrollViewUserSetting = new ScrollView();

            ButtonNormalMenu buttonOpenContentPageAddNewUser = new ButtonNormalMenu("Benutzer hinzufügen");
            buttonOpenContentPageAddNewUser.Clicked += ButtonOpenContentPageAddNewUser_Clicked;

            ButtonNormalMenu buttonOpenContentPageDeleteUser = new ButtonNormalMenu("Benutzer löschen");
            buttonOpenContentPageDeleteUser.Clicked += ButtonOpenContentPageDeleteUser_Clicked;

            StackLayout listWithUser = new StackLayout();
            listWithUser.Margin = 10;
            listWithUser.VerticalOptions = LayoutOptions.StartAndExpand;
            listWithUser.BackgroundColor = Color.FromHex("DDC9B2");

            listWithUser.Children.Add(buttonOpenContentPageAddNewUser);
            listWithUser.Children.Add(buttonOpenContentPageDeleteUser);

            scrollViewUserSetting.Content = listWithUser;

            this.Content = scrollViewUserSetting;
        }


        private void ButtonOpenContentPageAddNewUser_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ContentPageAddNewUser(modelCoffeeDatabase));
        }


        private void ButtonOpenContentPageDeleteUser_Clicked(object sender, EventArgs e)
        {
            // buttonAddContentPageAddUser.Navigation.PushAsync(new ContentPageAddCoffeeForUser(coffeedatabase));
            // labelShowItems.Text = showContent();
        }


    }
}
