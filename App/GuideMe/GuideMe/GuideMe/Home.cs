using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GuideMe
{

    public class Home : ContentPage
    {

        public Home()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            Image imgLogo = new Image
            {
                Source = "logo.png",
            };
          
            StackLayout stacklayoutImage = new StackLayout
            {
                Padding = new Thickness(0, 5, 0, 5),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    imgLogo,
                }
            };
            Button btnFacebookLogin = new Button
            {
                Text = "Connect with Facebook",
                BackgroundColor = Color.FromRgb(110, 214, 222),
                TextColor = Color.White,
                HeightRequest = 60,
            };
            btnFacebookLogin.Clicked += BtnFacebookLogin_Clicked;

            StackLayout stacklayoutPrimaryContent = new StackLayout
            {
                Padding = 5,
                BackgroundColor = Color.White,
                Children =
                {
                    stacklayoutImage,
                    btnFacebookLogin,
                }
            };
            Content = stacklayoutPrimaryContent;
        }

        private async void BtnFacebookLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Activities(), true);
        }
    }
}

