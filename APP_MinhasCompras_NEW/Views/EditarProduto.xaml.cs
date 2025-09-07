using APP_MinhasCompras_NEW.Models;

namespace APP_MinhasCompras_NEW.Views;

public partial class EditarProduto : ContentPage
{
	public EditarProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            //vincular o Id ao bindincontext
            Produto produto_anexado = BindingContext as Produto;


            // Cria um novo produto com os dados digitados pelo usuário
            Produto p = new Produto
            {
                Id = produto_anexado.Id,
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            // Atualiza (update) o banco de dados
            await App.Db.Update(p);

            // Exibe mensagem de sucesso
            await DisplayAlert("Sucesso!", "Produto Atualizado", "Ok");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            // Exibe mensagem caso ocorra algum erro
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}