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
    //1. Vinculo este viewModel con el Parametro de "TareaCompletada" que vendrá en la URL de navegación
    [QueryProperty(nameof(TareaRecibida), "TareaCompletada")]
    public partial class TareasCompletadasViewModel : ObservableObject
    {
        //2. Colección estática para que las tareas completadas se mantengan guardadas en memoria entre pantallas
        public static ObservableCollection<Tareas> ListaTareasCompletadas { get; set; } = new ObservableCollection<Tareas>();

        //Exponemos la lista para que la pantalla (View) pueda leerla y dibujarla
        public ObservableCollection<Tareas> TareasCompletadas => ListaTareasCompletadas;

        private Tareas _tareaRecibida;

        //3. Propiedades q se ejecuta automaticamente cuando MAUI recibe el parametro de navegación
        public Tareas TareaRecibida
        {
            get => _tareaRecibida;
            set
            {
                _tareaRecibida = value;

                //4. Implemento la validación requerida
                if (ValidarParametroRecibido(_tareaRecibida))
                {
                    //Marco el estado como completado (true)
                    _tareaRecibida.Estado = true;

                    //La agrego a la lista si no existe ya
                    if (!TareasCompletadas.Contains(_tareaRecibida))
                    {
                        TareasCompletadas.Add(_tareaRecibida);
                    }
                }
            }
        }

        //Método para validar parametro
        private bool ValidarParametroRecibido(Tareas tarea)
        {
            if (tarea == null) return false;

            //valido
            if (string.IsNullOrWhiteSpace(tarea.Titulo)) return false;

            return true;
        }


        //Comando para volver atrás y regresar a la pantalla de tareas pendientes
        [RelayCommand]
        private async Task VolverAtras()
        {
            //Navego de regreso usando la ruta relativa de Shell ".."
            await Shell.Current.GoToAsync("..");
        }

    }
}
