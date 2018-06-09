using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GuideMe
{
    public class Settings : ContentPage
    {
        public Settings()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            StackLayout stacklayoutPrimaryContent = new StackLayout
            {
                Padding = 5,
                BackgroundColor = Color.White,
                Children =
                {
                    new Title("SETTINGS"),
                    new Menu ("Set")
                }
            };
            Content = stacklayoutPrimaryContent;
        }
    }
}