using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CalculaAI
{
    public partial class CarteiraPage : ContentPage
    {
        public CarteiraPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new SugestaoListaPage();
        }
    }
}
