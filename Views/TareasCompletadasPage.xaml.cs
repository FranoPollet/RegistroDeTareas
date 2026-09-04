namespace RegistroDeTareas.Views;

public partial class TareasCompletadasPage : ContentPage
{
	public TareasCompletadasPage()
	{
		InitializeComponent();
        //Conecto la pantalla con el viewModel de TareasCompletadas
		BindingContext = new ViewModels.TareasCompletadasViewModel();
    }
}