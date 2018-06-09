using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GuideMe
{
    public class BackBtnTitle : StackLayout
    {
        public Label lblTitle;
        public StackLayout stackBack;
        public Image imgArrow;
        public Label lblBack;
        public TapGestureRecognizer tapBack = new TapGestureRecognizer();

        /// <summary>
        /// Clase para agregar un navbar con boton de atrás, recordar quitarle 
        /// el navbar por defecto a la pagina en la que se desea agregar. 
        /// </summary>
        /// <param name="title">Se recibe el titulo a poner.</param>
        public BackBtnTitle(string title)
        {
            lblTitle = new Label();
            stackBack = new StackLayout();
            imgArrow = new Image();
            lblBack = new Label();
            tapBack = new TapGestureRecognizer();

            lblBack.Text = "< BACK";
            lblBack.HorizontalOptions = LayoutOptions.Start;
            lblBack.VerticalOptions = LayoutOptions.Center;
            lblBack.TextColor = Color.FromRgb(53, 116, 170);
            lblBack.BackgroundColor = Color.White;
            lblBack.FontSize = 16;

            stackBack.VerticalOptions = LayoutOptions.Center;
            stackBack.BackgroundColor = Color.White;
            stackBack.Margin = 0;
            stackBack.Spacing = 10;
            stackBack.Orientation = StackOrientation.Horizontal;
            stackBack.Children.Add(lblBack);
            stackBack.GestureRecognizers.Add(tapBack);

            tapBack.Tapped += tapBack_Tapped;

            lblTitle.Text = title;
            lblTitle.HorizontalOptions = LayoutOptions.EndAndExpand;
            lblTitle.VerticalOptions = LayoutOptions.Center;
            lblTitle.TextColor = Color.FromRgb(53, 116, 170);
            lblTitle.FontSize = 20;
            lblTitle.Margin = 10;

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
                case Device.WinPhone:
                case Device.UWP:
                default:
                    top = 20;
                    break;
            }
            Orientation = StackOrientation.Horizontal;
            Padding = new Thickness(5, top, 10, 10);
            Children.Add(stackBack);
            Children.Add(lblTitle);
        }
        private async void tapBack_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}

