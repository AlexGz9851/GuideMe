using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace GuideMe
{
    public class MenuStack : StackLayout
    {
        public Label lblOpcMenu;
        public Image imgOpcMenu;
        public TapGestureRecognizer tapGestureRecognizer;
        //public NavigationPage navigationPage { get; set; } = new NavigationPage();
        public MenuStack(string lbltxt, string imgSource, string estado, string opcion)
        {
            lblOpcMenu = new Label();
            imgOpcMenu = new Image();
            tapGestureRecognizer = new TapGestureRecognizer();
            imgOpcMenu.Source = imgSource;
            imgOpcMenu.HeightRequest = 30;

            lblOpcMenu.Text = lbltxt;
            lblOpcMenu.BackgroundColor = Color.White;
            if (estado == "Si")
                lblOpcMenu.TextColor = Color.FromRgb(53, 116, 170);
            else
                lblOpcMenu.TextColor = Color.FromRgb(110, 214, 222);
            lblOpcMenu.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label));
            lblOpcMenu.HorizontalOptions = LayoutOptions.CenterAndExpand;

            BackgroundColor = Color.White;
            Margin = 10;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;
            tapGestureRecognizer.Tapped += (s, e) => TapGestureRecognizer_Tapped(s, e, opcion, estado);

            Children.Add(imgOpcMenu);
            Children.Add(lblOpcMenu);
            GestureRecognizers.Add(tapGestureRecognizer);
        }
        
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e, string opc, string estado)
        {
            if (opc == "locations" && estado == "No")
                await Navigation.PushAsync(new Locations(), true);
            else if (opc == "explore" && estado == "No")
                await Navigation.PushAsync(new Explore(), true);
            else if (opc == "travels" && estado == "No")
                await Navigation.PushAsync(new Travel(), true);
            else if (opc == "settings" && estado == "No")
                await Navigation.PushAsync(new Settings(), true);
        }
        
    }
}
