using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RegistroDeTareas.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDeTareas.ViewModels
{
    public partial class TodoListViewModel : ObservableObject
    {

        //1. Coleccion observable q la vista va a observar para dibujar la lista
        public ObservableCollection<Tareas> Tareas { get; set; } = new ObservableCollection<Tareas>();

        //2. Propiedades para capturar lo q el usuario ingresa en los inputs
        [ObservableProperty]
        private string _nuevoTitulo;

        [ObservableProperty]
        private string _nuevaDescripcion;

        [ObservableProperty]
        private string _nuevaFechaLimite;

        //3. Commnand para agregar una nueva tarea a la lista --> Command es como decir aca viene la funcion q se va a ejecutar cuando el usuario haga click en el boton
        [RelayCommand]
        private void AgregarTarea()
        {
            //Valido que por lo menos el titulo no este vacio
            if (string.IsNullOrEmpty(NuevoTitulo))
            {
                return;
            }

            //Creo la nueva tarea usndo el Model (molde)
            var tareaNueva = new Tareas
            {
                Titulo = NuevoTitulo,
                Descripcion = NuevaDescripcion,
                FechaLimite = NuevaFechaLimite,
                Estado = false
            };

            //Agrego la tarea a la coleccion observable (la pantalla se actualiza automaticamente)
            Tareas.Add(tareaNueva);

            //Limpio los inputs
            NuevoTitulo = string.Empty;
            NuevaDescripcion = string.Empty;
            NuevaFechaLimite = string.Empty;

        }

        //4. Comando / Funcion para eliminar una tarea de la lista
        [RelayCommand]
        private void EliminarTarea(Tareas tareaAEliminar)
        {
            if (tareaAEliminar != null && Tareas.Contains(tareaAEliminar))
            {
                Tareas.Remove(tareaAEliminar);
            }
        }


        // COMANDOS AGREGADOS PARA LA NAVEGACIÓN
        //Comando ejecutado al precionar el check de completar
        [RelayCommand]
        private async Task CompletarTarea(Tareas tareaACompletar)
        {
            if (tareaACompletar == null) return;
            
            //1. La remuevo de la lista de pendientes actual
            Tareas.Remove(tareaACompletar);

            //2. Preparo el parametro de navegación en un diccionario
            var parametros = new Dictionary<string, object>
            {
                {"TareaCompletada", tareaACompletar }
            };

            //3. Navego a la pantalla de completados pasando los parametros de forma asincrona
            await Shell.Current.GoToAsync("TareasCompletadasPage", parametros);
        }

        //Comando para ir a ver la pantalla de completadas de forma directa
        [RelayCommand]
        private async Task IrACompletadas()
        {
            await Shell.Current.GoToAsync("TareasCompletadasPage");
        }

    }
}
