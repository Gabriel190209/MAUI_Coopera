namespace MAUI_Coopera;

public partial class PerfilPage : ContentPage
{
	public PerfilPage()
	{
		InitializeComponent();
		CarregarDados();
	}

	private void CarregarDados()
	{
		string fotoBase64 = Preferences.Get("userFoto", string.Empty);

		if (!string.IsNullOrEmpty(fotoBase64))
		{
            byte[] imagemBytes = Convert.FromBase64String(fotoBase64);
            imgPerfil.Source = ImageSource.FromStream(() => new MemoryStream(imagemBytes));
		} else
		{
            imgPerfil.Source = ImageSource.FromFile("mais.png");
        }

		lblOla.Text = $"Olá, {Preferences.Get("userNome", "Usuário")}";

		string funcao = Preferences.Get("userIdFuncao", "0");

		if (funcao == "1")
		{
			btnProfissional.Text = "Virar Profissional";
		} else
		{
            btnProfissional.Text = "Editar Perfil";
        }
    }

    private async void btnSair_Clicked(object sender, EventArgs e)
    {
		Preferences.Clear();
		Application.Current.MainPage = new NavigationPage(new MainPage());
    }

    private void btnProfissional_Clicked(object sender, EventArgs e)
    {
		if (btnProfissional.Text == "Virar Profissional")
		{
			Navigation.PushAsync(new VirarProfissionalPage());
		} else
		{
			DisplayAlert("a", "Fazer a pagina de editar perfil e também a parte da API", "Ok");
		}
    }
}