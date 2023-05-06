using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin2018.Clases;

namespace Xamarin2018
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaTareas : ContentPage
    {
        public ListaTareas()
        {
            InitializeComponent();

            var botonAgregar = new ToolbarItem() 
            { 
                Text = "Agregar" 
            };

            botonAgregar.Clicked += botonAgregar_Clicked;
            ToolbarItems.Add(botonAgregar);
        }

        private async void botonAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NuevoItem());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLite.SQLiteConnection conexion = new SQLite.SQLiteConnection(App.RutaBD))
            {
                List<Tarea> listaTareas = conexion.Table<Tarea>()
                                                    .Where(t => t.Completada == false).ToList();

                ListaTareasListView.ItemsSource = listaTareas;
            }
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            using (SQLite.SQLiteConnection conexion = new SQLite.SQLiteConnection(App.RutaBD))
            {
                var tareaCompletar = (sender as MenuItem).CommandParameter as Tarea;
                tareaCompletar.Completada = true;

                conexion.Update(tareaCompletar);

                List<Tarea> listaTareasFiltradas = conexion.Table<Tarea>()
                                                    .Where(t => t.Completada == false).ToList();
                ListaTareasListView.ItemsSource = listaTareasFiltradas;
            }
        }
    }
}