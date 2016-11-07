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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ksiazkakucharska
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            if (App.LoginToken != null) ContentFrame.Navigate(typeof(Find));
            else ContentFrame.Navigate(typeof(Assets.Login));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HamburgerMenu.IsPaneOpen = !HamburgerMenu.IsPaneOpen;
        }

        private void FindStackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (App.LoginToken != null) ContentFrame.Navigate(typeof(Find));
            else ContentFrame.Navigate(typeof(Assets.Login));
            HamburgerMenu.IsPaneOpen = false;
        }

        private void AddStackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (App.LoginToken != null) ContentFrame.Navigate(typeof(Add));
            else ContentFrame.Navigate(typeof(Assets.Login));
            HamburgerMenu.IsPaneOpen = false;
        }

        private void LoginStackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Assets.Login));
            HamburgerMenu.IsPaneOpen = false;
        }

        private void RecipeDetailsStackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (App.LoginToken != null) ContentFrame.Navigate(typeof(Assets.RecipeDetails));
            else ContentFrame.Navigate(typeof(Assets.Login));
            HamburgerMenu.IsPaneOpen = false;
        }
        private void SettingsStackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (App.LoginToken != null) ContentFrame.Navigate(typeof(Assets.Settings));
            else ContentFrame.Navigate(typeof(Assets.Login));
            HamburgerMenu.IsPaneOpen = false;
        }
        private void ResultsStackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (App.LoginToken != null) ContentFrame.Navigate(typeof(Assets.Results));
            else ContentFrame.Navigate(typeof(Assets.Login));
            HamburgerMenu.IsPaneOpen = false;
        }
    }
}
