using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GuideMe
{
    public class Tags:StackLayout
    {
        public Image TagImg;
        public Label lblTag;

        public Tags( string tag)
        {
            TagImg = new Image();
            lblTag = new Label();

            lblTag.Text = tag;
            lblTag.TextColor = Color.Black;
            lblTag.FontSize = 22;

            TagImg.Source = "tag.png";
            TagImg.HeightRequest = 25;

            Orientation = StackOrientation.Horizontal;
            Spacing = 5;
            Children.Add(TagImg);
            Children.Add(lblTag);
            BackgroundColor = Color.White;
        }
    }
}
