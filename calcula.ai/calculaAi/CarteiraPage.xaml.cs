using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace calculaAi
{
    public partial class CarteiraPage : ContentPage
    {
        public CarteiraPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            App.Current.MainPage = new SugestaoListaPage();
        }
    }
}
