﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin2018
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(usuarioEntry.Text) || string.IsNullOrEmpty(passwordEntry.Text))
            {
                resultadoLabel.Text = "Debes escribir usuario y contraseña";
            }
            else
            {
                resultadoLabel.Text = "Inicio de sesion exitoso";
                await Navigation.PushAsync(new ListaTareas());
            }
        }
    }
}
