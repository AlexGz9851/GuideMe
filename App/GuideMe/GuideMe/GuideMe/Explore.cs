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

            StackLayout stackContent = new StackLayout
            {
                BackgroundColor = Color.White,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Spacing = 10,
            };

            Label lblAsk = new Label
            {
                Text = "Where are you going?",
                FontSize = 24
            };
            Entry PlaceEntry = new Entry
            {
                Keyboard = Keyboard.Default,
                Placeholder = "Write the location"
            };

            Button btnSearch = new Button
            {
                Text = "Search",
                TextColor = Color.White,
                BackgroundColor = Color.FromRgb(53, 116, 170),
            };
            stackContent.Children.Add(lblAsk);
            stackContent.Children.Add(PlaceEntry);
            stackContent.Children.Add(btnSearch);

            StackLayout stacklayoutPrimaryContent = new StackLayout
            {
                Padding = 5,
                BackgroundColor = Color.White,
                Children =
                {
                    new Title("EXPLORE"),
                    stackContent,
                    new Menu ("Exp")
                }
            };
            Content = stacklayoutPrimaryContent;
        }
    }
}
