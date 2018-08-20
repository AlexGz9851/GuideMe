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

            stackContent.Children.Add(new GridTravel("http://2btravel.com/wp-content/uploads/2015/04/Guadalajara.png", "Guadalajara", "2018/05/12"));
            stackContent.Children.Add(new GridTravel("http://www.construccion-pa.com/wp-content/uploads/4/2017/06/CONSTRUCCION_Consorcio-pide-compensaci%C3%B3n-por-cancelaci%C3%B3n-de-acueducto-Monterrey.jpg", "Monterrey", "2018/05/24"));
            stackContent.Children.Add(new GridTravel("http://2btravel.com/wp-content/uploads/2015/04/Guanajuato.png", "Guanajuato", "2018/06/08"));
            stackContent.Children.Add(new GridTravel("http://www.planoinformativo.com/stock12/image/2015/Abril/14/10s.jpg", "Culiacan", "2018/06/15"));

            ScrollView scroll = new ScrollView
            {
                Content = stackContent
            };
            StackLayout stackscroll = new StackLayout
            {
                Children =
                {
                    scroll
                }
            };
            StackLayout stacklayoutPrimaryContent = new StackLayout
            {
                Padding = 5,
                BackgroundColor = Color.White,
                Children =
                {
                    new Title("TRAVEL"),
                    stackscroll,
                    new Menu("Trav")
                }
            };
            Content = stacklayoutPrimaryContent;
        }
    }
}