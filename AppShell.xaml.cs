namespace RegistroDeTareas
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Registro de rutas: le digo a shell como encontrar TareasCompletadasPage para poder navegar hacia ella
            Routing.RegisterRoute(nameof(Views.TareasCompletadasPage), typeof(Views.TareasCompletadasPage));
        }
    }
}
