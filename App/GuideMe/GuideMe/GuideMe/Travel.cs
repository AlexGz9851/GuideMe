using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GuideMe
{
    public class Travel : ContentPage
    {
        public Travel()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            StackLayout stackContent = new StackLayout
            {
                BackgroundColor = Color.White,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            stackContent.Children.Add(new GridTravel("Guadalajara", "2018/05/12"));
            stackContent.Children.Add(new GridTravel("Monterrey", "2018/05/24"));
            stackContent.Children.Add(new GridTravel("Guanajuato", "2018/06/8"));
            stackContent.Children.Add(new GridTravel("Culiacan", "2018/06/15"));

            StackLayout stacklayoutPrimaryContent = new StackLayout
            {
                Padding = 5,
                BackgroundColor = Color.White,
                Children =
                {
                    new Title("TRAVEL"),
                    stackContent,
                    new Menu("Trav")
                }
            };
            Content = stacklayoutPrimaryContent;
        }
    }
}