using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDeTareas.Models
{
    public partial class Tareas : ObservableObject
    {
        //Titulo de la tarea
        [ObservableProperty]
        private string titulo;

        //Descripcion de la tarea
        [ObservableProperty]
        private string descripcion;

        //Fecha limite de la tarea
        [ObservableProperty]
        private string fechaLimite;

        //Estado de la tarea (completado = true; pendiente = false)
        [ObservableProperty]
        private bool estado;
    }
}
