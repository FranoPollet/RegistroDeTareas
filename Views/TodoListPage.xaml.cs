namespace RegistroDeTareas.Views;

public partial class TodoListPage : ContentPage
{
	public TodoListPage()
	{
		InitializeComponent();

		//Enlazamos esta vista con el ViewModel de Tareas
		BindingContext = new ViewModels.TodoListViewModel();
	}
}