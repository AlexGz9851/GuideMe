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
            stackContent.Children.Add(new GridLocation("http://www.serviciosiasa.com/imagenes_sites/EstiloHoy/marzo2011/cafes_lujosos_mundo_1.jpg", "Sandra's Coffee", "http://maps.gstatic.com/mapfiles/place_api/icons/generic_business-71.png", "https://www.google.com/maps/search/?api=1&query=51.8448409802915,0.7337046802915023&query_place_id=ChIJT4UQE87i2EcRFJ_YpbfTQQA", "4.5"));
            stackContent.Children.Add(new GridLocation("http://codigo.pe/wp-content/uploads/2018/04/starbucks_4d6211ba-1-350x250.jpg", "Starbucks Coffee", "http://maps.gstatic.com/mapfiles/place_api/icons/generic_business-71.png", "https://www.google.com/maps/search/?api=1&query=51.8448409802915,0.7337046802915023&query_place_id=ChIJT4UQE87i2EcRFJ_YpbfTQQA", "4.2"));
            stackContent.Children.Add(new GridLocation("http://i.pinimg.com/originals/68/0d/55/680d5585ab9a911463326826c5ab2f40.jpg", "Library", "http://maps.gstatic.com/mapfiles/place_api/icons/generic_business-71.png", "https://www.google.com/maps/search/?api=1&query=51.8448409802915,0.7337046802915023&query_place_id=ChIJT4UQE87i2EcRFJ_YpbfTQQA", "3.9"));

            ScrollView scroll = new ScrollView
            {
                Content = stackContent,
            };
            StackLayout stackscroll = new StackLayout
            {
                Children =
                {
                    scroll,
                }
            };

            StackLayout stacklayoutPrimaryContent = new StackLayout
            {
                Padding = 5,
                BackgroundColor = Color.White,
                Children =
                {
                    new Title("LOCATIONS"),
                    stackscroll,
                    new Menu("Loc")
                }
            };
            Content = stacklayoutPrimaryContent;
        }
    }
}
