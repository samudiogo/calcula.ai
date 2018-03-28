using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace calculaAi
{
    public partial class SugestaoListaPage : ContentPage
    {
        ObservableCollection<string> lista = new ObservableCollection<string>();

        public SugestaoListaPage()
        {
            InitializeComponent();
        }
    }
}
