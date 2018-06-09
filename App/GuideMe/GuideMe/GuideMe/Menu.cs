using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
namespace GuideMe
{
    public class Menu : Grid
    {
        public string lugar;
        public Menu(string estado)
        {
            RowSpacing = 0;
            ColumnSpacing = 0;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.End;
            Padding = 0;
            BackgroundColor = Color.White;
            RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            string img1, est1, img2, est2, img3, est3, img4, est4;

            if (estado == "Act")
            {
                img1 = "acts_dark.png";
                est1 = "Si";
            }
            else
            {
                img1 = "acts_light.png";
                est1 = "No";
            }

            if (estado == "Exp")
            {
                img2 = "explore_dark.png";
                est2 = "Si";
            }
            else
            {
                img2 = "explore_light.png";
                est2 = "No";
            }
            if (estado == "Trav")
            {
                img3 = "travels_dark.png";
                est3 = "Si";
            }
            else
            {
                img3 = "travels_light.png";
                est3 = "No";
            }
            if (estado == "Set")
            {
                img4 = "settings_dark.png";
                est4 = "Si";
            }
            else
            {
                img4 = "settings_light.png";
                est4 = "No";
            }
            
            MenuStack Opc1 = new MenuStack("activities", img1, est1, "activities");
            MenuStack Opc2 = new MenuStack("explore", img2, est2, "explore");
            MenuStack Opc3 = new MenuStack("travels", img3, est3, "travels");
            MenuStack Opc4 = new MenuStack("settings", img4, est4, "settings");

            Children.Add(Opc1, 0, 0);
            Children.Add(Opc2, 1, 0);
            Children.Add(Opc3, 2, 0);
            Children.Add(Opc4, 3, 0);
        }
    }
}
