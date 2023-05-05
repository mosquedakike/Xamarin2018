using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin2018.Clases
{
    public class Tarea
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(1000)]
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public bool Completada { get; set; }
    }
}
