using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GuideMe
{
    public class GridTravel : StackLayout
    {
        public Label lblNameLoc;
        public Label lblTime;
        public TapGestureRecognizer tapLoc;
        public Image imagePlace;

        public GridTravel(string urlCity, string NameLoc, string TimeLoc)
        {
            lblNameLoc = new Label();
            lblTime = new Label();
            tapLoc = new TapGestureRecognizer();
            imagePlace = new Image();

            BackgroundColor = Color.FromRgb(53, 116, 170);
            Margin = 10;
            Padding = 2;

            imagePlace.Source = ImageSource.FromUri(new Uri(urlCity));
            imagePlace.HeightRequest = 150;
            imagePlace.HorizontalOptions = LayoutOptions.CenterAndExpand;
            imagePlace.VerticalOptions = LayoutOptions.CenterAndExpand;

            lblNameLoc.Text = NameLoc;
            lblNameLoc.TextColor = Color.White;
            lblNameLoc.FontSize = 32;
            lblNameLoc.VerticalOptions = LayoutOptions.CenterAndExpand;
            lblNameLoc.HorizontalOptions = LayoutOptions.StartAndExpand;
            lblNameLoc.HorizontalTextAlignment = TextAlignment.Start;

            lblTime.Text = TimeLoc;
            lblTime.TextColor = Color.White;
            lblTime.FontSize = 16;
            lblTime.VerticalOptions = LayoutOptions.CenterAndExpand;
            lblTime.HorizontalOptions = LayoutOptions.StartAndExpand;
            lblTime.HorizontalTextAlignment = TextAlignment.Center;

            Orientation = StackOrientation.Vertical;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            Children.Add(imagePlace);
            Children.Add(lblNameLoc);
            Children.Add(lblTime);
            GestureRecognizers.Add(tapLoc);

            tapLoc.Tapped += (s,e) => TapLoc_Tapped(s,e,NameLoc,TimeLoc);

        }

        private async  void TapLoc_Tapped(object sender, EventArgs e, string Location, string Time)
        {
            await Navigation.PushAsync(new TravelLocations(Location, Time));
        }
    }
}
