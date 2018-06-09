using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GuideMe
{
    public class GridLocation : StackLayout
    {
        public Image imageBall;
        public Button GoogleM;
        public Label NameLoc;
        public Label lblRaiting;
        public Image imageStar;
        public StackLayout stkRaiting;
        public Grid gridLoc;
        public GridLocation(string Name, string urlImage, string urlLoc, string raiting)
        {
            imageBall = new Image();
            GoogleM = new Button();
            NameLoc = new Label();
            lblRaiting = new Label();
            imageStar = new Image();
            stkRaiting = new StackLayout();
            gridLoc = new Grid();

            BackgroundColor= Color.FromHex("#BADFEC");
            Padding = 2;

            gridLoc.RowSpacing = 10;
            gridLoc.ColumnSpacing = 0;
            gridLoc.BackgroundColor = Color.White;
            gridLoc.HorizontalOptions = LayoutOptions.FillAndExpand;
            gridLoc.Padding = 0;
            gridLoc.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridLoc.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            gridLoc.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(8, GridUnitType.Star) });
            gridLoc.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });

            GoogleM.Text = "OPEN IN MAPS";
            GoogleM.TextColor = Color.FromRgb(53, 116, 170);
            GoogleM.BackgroundColor = Color.White;
            GoogleM.Clicked += (s, e) => GoogleM_Clicked(s, e, urlLoc);

            NameLoc.Text = Name;
            NameLoc.TextColor = Color.FromRgb(53, 116, 170);
            NameLoc.FontSize = 20;
            NameLoc.VerticalOptions = LayoutOptions.CenterAndExpand;
            NameLoc.HorizontalOptions = LayoutOptions.Center;
            NameLoc.HorizontalTextAlignment = TextAlignment.Center;

            lblRaiting.Text = raiting;
            lblRaiting.TextColor = Color.FromRgb(53, 116, 170);
            lblRaiting.FontSize = 16;
            lblRaiting.VerticalOptions = LayoutOptions.CenterAndExpand;
            lblRaiting.HorizontalOptions = LayoutOptions.Center;
            lblRaiting.HorizontalTextAlignment = TextAlignment.Center;

            imageStar.Source = "estrella.png";
            imageStar.VerticalOptions = LayoutOptions.CenterAndExpand;

            stkRaiting.Orientation = StackOrientation.Horizontal;
            stkRaiting.HorizontalOptions = LayoutOptions.Center;
            stkRaiting.Children.Add(lblRaiting);
            stkRaiting.Children.Add(imageStar);

            imageBall.Source = ImageSource.FromUri(new Uri(urlImage));
            imageBall.HeightRequest = 25;
            imageBall.HorizontalOptions = LayoutOptions.CenterAndExpand;
            imageBall.VerticalOptions = LayoutOptions.CenterAndExpand;

            gridLoc.Children.Add(NameLoc, 0, 1, 0, 1);
            gridLoc.Children.Add(imageBall, 1, 2, 0, 1);
            gridLoc.Children.Add(GoogleM, 0, 1, 1, 2);
            gridLoc.Children.Add(stkRaiting, 1, 2, 1, 2);

            Children.Add(gridLoc);

            //imageBall.Source = ImageSource.FromUri(new Uri("http://maps.gstatic.com/mapfiles/place_api/icons/generic_business-71.png"));
        }

        private void GoogleM_Clicked(object sender, EventArgs e, string url)
        {
            Device.OpenUri(new Uri(url));
        }
    }
}
