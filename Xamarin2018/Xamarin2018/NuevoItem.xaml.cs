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
    public partial class NuevoItem : ContentPage
    {
        public NuevoItem()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Tarea nuevaTarea = new Tarea()
            {
                Nombre = NombreEntry.Text,
                Fecha = FechaLimiteDatePicker.Date,
                Hora = HoraLimiteTimePicker.Time,
                Completada = false
            };

            using (SQLite.SQLiteConnection conexion = new SQLite.SQLiteConnection(App.RutaBD))
            {
                conexion.CreateTable<Tarea>();
                var resultado = conexion.Insert(nuevaTarea);

                if (resultado > 0)
                {
                    DisplayAlert("Exito", "La tarea fue guardada correctamente", "Ok");
                    Navigation.PushAsync(new ListaTareas());
                }
                else
                {
                    DisplayAlert("Eror", "Algo salio mal", "Ok");
                }
            }
                
        }
    }
}