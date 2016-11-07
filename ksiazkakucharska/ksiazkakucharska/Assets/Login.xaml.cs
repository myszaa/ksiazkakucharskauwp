using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ksiazkakucharska.Assets
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        public Login()
        {
            this.InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string json = "{\"action\":\"login\", \"email\":\"" + Email.Text + "\", \"password\":\"" + Password.Password + "\"}";
            Task<HttpResponseMessage> responseTask = Task.Run(()=>SendToServer(json));
            responseTask.Wait();
            HttpResponseMessage response = responseTask.Result;
            string responseBodyAsText = await response.Content.ReadAsStringAsync();
            dynamic stuff = JsonConvert.DeserializeObject(responseBodyAsText.ToString());
            if (stuff.error == null)
            {
                App.LoginToken = stuff.token;
                App.LocalSettings.Values["LoginToken"] = App.LoginToken;
                var dialog = new MessageDialog("Witaj " + stuff.nick + "!");
                await dialog.ShowAsync();
                Frame.Navigate(typeof(Find));
            }
            else
            {
                var dialog = new MessageDialog("Nie udało się utworzyć konta! Szczegóły błędu: " + stuff.error);
                await dialog.ShowAsync();
            }
        }

        private async Task<HttpResponseMessage> SendToServer(string json)
        {
            HttpClient request = new HttpClient();
            var content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return await request.PostAsync("http://mobilne.kjozwiak.ovh/index.php", content);
        }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string json = "{\"action\":\"register\", \"email\":\"" + RegistryEmail.Text + "\", \"password\":\"" + RegistryPassword.Password + "\", \"nick\":\"" + RegistryNick.Text + "\"}";
            Task<HttpResponseMessage> responseTask = Task.Run(() => SendToServer(json));
            responseTask.Wait();
            HttpResponseMessage response = responseTask.Result;
            string responseBodyAsText = await response.Content.ReadAsStringAsync();
            dynamic stuff = JsonConvert.DeserializeObject(responseBodyAsText.ToString());
            if (stuff.error == null)
            {
                var dialog = new MessageDialog("Konto utworzone dla " + stuff.nick + "!");
                await dialog.ShowAsync();
            }
            else
            {
                var dialog = new MessageDialog("Nie udało się utworzyć konta! Szczegóły błędu: " + stuff.error);
                await dialog.ShowAsync();
            }
        }
    }
}
