namespace MAUI_Coopera;

public partial class InicioPage : ContentPage
{
	public InicioPage()
	{
		InitializeComponent();
		CarregarPicker();

    }

	private void CarregarPicker()
	{
		for (int i = 1; i<=5;i++)
		{
			pckEstrela.Items.Add(i.ToString());
		}
	}
}