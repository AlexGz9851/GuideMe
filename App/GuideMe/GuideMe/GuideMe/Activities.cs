﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GuideMe
{
    public class Activities: ContentPage 
    {
        public Activities()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            StackLayout stackContent = new StackLayout
            {
                BackgroundColor = Color.White,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            StackLayout stacklayoutPrimaryContent = new StackLayout
            {
                Padding = 5,
                BackgroundColor = Color.White,
                Children =
                {
                    new Title("ACTIVITIES"),
                    stackContent,
                    new Menu("Act")
                }
            };
            Content = stacklayoutPrimaryContent;
        }
    }
}
