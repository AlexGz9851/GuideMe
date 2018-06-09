using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GuideMe
{

    public class Title : StackLayout
    {
        public Label lblTitle;
        public BoxView line1;

        /// <summary>
        /// Clase para agregar un navbar con boton de atrás, recordar quitarle 
        /// el navbar por defecto a la pagina en la que se desea agregar. 
        /// </summary>
        /// <param name="title">Se recibe el titulo a poner.</param>
        public Title(string title)
        {
            lblTitle = new Label();
            line1 = new BoxView();

            lblTitle.Text = title;
            lblTitle.HorizontalOptions = LayoutOptions.EndAndExpand;
            lblTitle.VerticalOptions = LayoutOptions.Center;
            lblTitle.TextColor = Color.FromRgb(53, 116, 170);
            lblTitle.FontSize = 20;
            lblTitle.Margin = 10;

            line1.HeightRequest = 1;
            line1.HorizontalOptions = LayoutOptions.FillAndExpand;
            line1.Color = Color.FromRgb(53, 116, 170);

            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.Start;
            BackgroundColor = Color.White;
            double top;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    top = 40;
                    break;
                case Device.Android:
                default:
                    top = 20;
                    break;
            }
            Orientation = StackOrientation.Vertical;
            Padding = new Thickness(5, top, 10, 10);
            Children.Add(lblTitle);
            Children.Add(line1);
        }
    }
}
