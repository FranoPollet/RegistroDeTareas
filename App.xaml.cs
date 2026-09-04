namespace RegistroDeTareas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new RegistroDeTareas.Views.TodoListPage();
        }
    }
}
