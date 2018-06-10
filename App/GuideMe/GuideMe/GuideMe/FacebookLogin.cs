using GuideMe;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace GuideMe
{
    public class FacebookLogin : ContentPage
    {
        ActivityIndicator actIndicator = new ActivityIndicator()
        {
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            Color = Color.FromRgb(53, 116, 170)
        };
        public FacebookLogin()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            string baseURI = "https://www.facebook.com/v2.8/dialog/oauth?";
            string id_cliente = "client_id=" + "155371731806629";
            string scope = "&scope=email";
            string responseType = "&response_type=token";
            string redirect_uri = "&redirect_uri=https://www.facebook.com/connect/login_success.html";
            var url = baseURI + id_cliente + scope + responseType + redirect_uri;
            var webView = new WebView
            {
                Source = url,
                HeightRequest = 1
            };
            webView.Navigated += WebView_Navigated;
            Content = webView;
        }

        private async void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            //Checamos que el usuario se haya logueado bien con facebook
            if (e.Result == WebNavigationResult.Failure || e.Result == WebNavigationResult.Timeout)
            {
                await DisplayAlert("Error", "Facebook no tiene conexión a  internet", "Ok");
                await Navigation.PopAsync();
            }
            if (e.Url.Contains("error_reason=user_denied"))
                await Navigation.PopAsync();
            var accesToken = ExtractAccesTokenFromUrl(e.Url);//A partir de aqui es el puro token
            if (accesToken == "")
                return;
            //Obtenemos los datos del usuario en base al token retornado            
            //en este punto cambiamos la vista a un "Waiting", creamos la cuenta e iniciamos sesion
            this.Content = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                Children = { actIndicator }
            };
            actIndicator.IsRunning = true;
            var result = await GetFacebookProfileAsync(accesToken);
        }

        //Obtenemos el token de acceso de facebook
        private string ExtractAccesTokenFromUrl(string url)
        {

            if (url.Contains("access_token") && url.Contains("&expires_in="))
            {
                var at = url.Substring(url.IndexOf("access_token=")).Replace("access_token=", "");
                var accesToken = at.Remove(at.IndexOf("&expires_in="));
                return accesToken;
            }
            return "";
        }

        //Obtenemos los datos del usuario
        public async Task<FacebookStructure> GetFacebookProfileAsync(string accesToken)
        {
            var requestUrl = "https://graph.facebook.com/v2.7/me?" +
                "scope=public_profile,email&fields=name,email,gender,is_verified" +//Extras posibles picture,cover,age,range,devices,
                "&access_token=" + accesToken;

            var httpClient = new HttpClient();
            var userJson = await httpClient.GetStringAsync(requestUrl);
            return JsonConvert.DeserializeObject<FacebookStructure>(userJson);
        }

        //Creamos la cuenta del usuario en base a los datos retornados por facebook, el usuario es el correo y la contraseña pasara a ser el ID del usuario
        /*public async void CreateFAcebookAccount(FacebookStructure structure)
        {
            var user = new UserModel();
            string avatar = "https://graph.facebook.com/v2.8/" + structure.id + "/picture?width=1920";
            user.name = structure.name;
            user.img_src = avatar;
            user.email = structure.email;
            user.facebook_token = structure.id;

            //Hacer peticion a la API
            var cliente = new RestClient();
            var response = await cliente.Post<LoginResponseModel>("login/facebook", user);
            if (response != null && response.success == true)
            {
                using (var access = new DataAccess())
                {
                    var tokenDB = access.GetSessions();
                    if (tokenDB == null)
                    {
                        access.Insert(new TSessions()
                        {
                            token = response.token,
                            email = Security.Encriptar(structure.email),
                            password = Security.Encriptar(structure.id),
                            loginType = "facebook"
                        });
                    }
                    else
                    {
                        tokenDB.token = response.token;
                        access.Update(tokenDB);
                    }
                }
                if (response.permissionTip)
                {
                    var dailyTip = await cliente.Get<HomeTipModel>("home?token=" + response.token);
                    await Navigation.PushAsync(new Activities() );
                }
                else
                    await Navigation.PushAsync(new Activities());
            }
            else
            {
                await DisplayAlert("Error", "Error de servidor", "Ok");
                await Navigation.PushModalAsync(new Home());
            }
        }
    }
    */
        public class FacebookStructure
        {
            public string name { get; set; }
            public string gender { get; set; }
            public bool is_verified { get; set; }
            public string id { get; set; }
            public string email { get; set; }
        }
    }
}