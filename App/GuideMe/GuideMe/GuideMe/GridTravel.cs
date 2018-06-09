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

        public GridTravel(string NameLoc, string TimeLoc)
        {
            lblNameLoc = new Label();
            lblTime = new Label();
            tapLoc = new TapGestureRecognizer();

            BackgroundColor = Color.FromRgb(53, 116, 170);
            Margin = 10;
            Padding = 2;

            Orientation = StackOrientation.Horizontal;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            Children.Add(lblNameLoc);
            Children.Add(lblTime);
            GestureRecognizers.Add(tapLoc);

            tapLoc.Tapped += (s,e) => TapLoc_Tapped(s,e,NameLoc,TimeLoc);

            lblNameLoc.Text = NameLoc;
            lblNameLoc.TextColor = Color.White;
            lblNameLoc.FontSize = 24;
            lblNameLoc.VerticalOptions = LayoutOptions.CenterAndExpand;
            lblNameLoc.HorizontalOptions = LayoutOptions.StartAndExpand;
            lblNameLoc.HorizontalTextAlignment = TextAlignment.Start;

            lblTime.Text = TimeLoc;
            lblTime.TextColor = Color.White;
            lblTime.FontSize = 16;
            lblTime.VerticalOptions = LayoutOptions.CenterAndExpand;
            lblTime.HorizontalOptions = LayoutOptions.EndAndExpand;
            lblTime.HorizontalTextAlignment = TextAlignment.Center;

        }

        private async  void TapLoc_Tapped(object sender, EventArgs e, string Location, string Time)
        {
            await Navigation.PushAsync(new TravelLocations(Location, Time));
        }
    }
}
