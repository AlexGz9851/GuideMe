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

            StackLayout stackContent = new StackLayout
            {
                BackgroundColor = Color.White,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Spacing = 10
            };
            Label tagsTitle = new Label
            {
                Text = "TAGS",
                FontSize = 25,
                TextColor = Color.FromRgb(53, 116, 170)
        };
            stackContent.Children.Add(tagsTitle);
            stackContent.Children.Add(new Tags("Bar"));
            stackContent.Children.Add(new Tags("Casino"));
            stackContent.Children.Add(new Tags("Park"));
            stackContent.Children.Add(new Tags("Stadium"));


            StackLayout stacklayoutPrimaryContent = new StackLayout
            {
                Padding = 5,
                BackgroundColor = Color.White,
                Children =
                {
                    new Title("SETTINGS"),
                    stackContent,
                    new Menu ("Set")
                }
            };
            Content = stacklayoutPrimaryContent;
        }
    }
}