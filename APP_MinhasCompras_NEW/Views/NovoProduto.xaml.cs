using APP_MinhasCompras_NEW.Models;
using System.Threading.Tasks;

namespace APP_MinhasCompras_NEW.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent();
    }

    // Evento chamado ao clicar no ToolbarItem
    // Importante: deve ser async void (e não async Task), pois é um EventHandler
    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Cria um novo produto com os dados digitados pelo usuário
            Produto p = new Produto
            {
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            // Insere no banco de dados
            await App.Db.Insert(p);

            // Exibe mensagem de sucesso
            await DisplayAlert("Sucesso!", "Produto inserido", "Ok");
        }
        catch (Exception ex)
        {
            // Exibe mensagem caso ocorra algum erro
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}
