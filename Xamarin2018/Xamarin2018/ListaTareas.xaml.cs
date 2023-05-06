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
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLite.SQLiteConnection conexion = new SQLite.SQLiteConnection(App.RutaBD))
            {
                List<Tarea> listaTareas = conexion.Table<Tarea>().ToList();

                ListaTareasView.ItemsSource = listaTareas;
            }
        }
    }
}