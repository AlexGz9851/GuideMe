using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GuideMe
{
    public class Explore : ContentPage
    {
        public Explore()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            StackLayout stacklayoutPrimaryContent = new StackLayout
            {
                Padding = 5,
                BackgroundColor = Color.White,
                Children =
                {
                    new Title("EXPLORE"),
                    new Menu ("Exp")
                }
            };
            Content = stacklayoutPrimaryContent;
        }
    }
}
