using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GuideMe
{
    public class Locations: ContentPage 
    {
        public Locations()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            StackLayout stackContent = new StackLayout
            {
                BackgroundColor = Color.White,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            stackContent.Children.Add(new GridLocation("Sandra's Coffee", "http://maps.gstatic.com/mapfiles/place_api/icons/generic_business-71.png", "https://www.google.com/maps/search/?api=1&query=51.8448409802915,0.7337046802915023&query_place_id=ChIJT4UQE87i2EcRFJ_YpbfTQQA", "4.5"));
            stackContent.Children.Add(new GridLocation("Starbucks Coffee", "http://maps.gstatic.com/mapfiles/place_api/icons/generic_business-71.png", "https://www.google.com/maps/search/?api=1&query=51.8448409802915,0.7337046802915023&query_place_id=ChIJT4UQE87i2EcRFJ_YpbfTQQA", "4.2"));
            stackContent.Children.Add(new GridLocation("Library", "http://maps.gstatic.com/mapfiles/place_api/icons/generic_business-71.png", "https://www.google.com/maps/search/?api=1&query=51.8448409802915,0.7337046802915023&query_place_id=ChIJT4UQE87i2EcRFJ_YpbfTQQA", "3.9"));

            StackLayout stacklayoutPrimaryContent = new StackLayout
            {
                Padding = 5,
                BackgroundColor = Color.White,
                Children =
                {
                    new Title("LOCATIONS"),
                    stackContent,
                    new Menu("Loc")
                }
            };
            Content = stacklayoutPrimaryContent;
        }
    }
}
