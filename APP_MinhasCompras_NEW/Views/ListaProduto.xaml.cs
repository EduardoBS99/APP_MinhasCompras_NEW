using APP_MinhasCompras_NEW.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace APP_MinhasCompras_NEW.Views;

public partial class ListaProduto : ContentPage
{

    // Cria uma cole��o observ�vel de produtos (ObservableCollection) que notifica automaticamente a interface gr�fica
    // sempre que itens s�o adicionados, removidos ou alterados.
    ObservableCollection<Produto> lista = new ObservableCollection<Produto>();
	public ListaProduto()
	{
		InitializeComponent();

        // Define a fonte de dados (ItemsSource) do ListView "lst_produtos" como a cole��o "lista"
        lst_produtos.ItemsSource = lista;
	}

    // M�todo executado automaticamente quando a p�gina aparece na tela
    protected async override void OnAppearing()
    {
        // Manobra para o aplicativo n�o "cratear"

        try
        {
            //bug da listagem dupla
            lista.Clear();
            // Busca todos os produtos armazenados no banco de dados de forma ass�ncrona
            List<Produto> tmp = await App.Db.GetAll();

            // Percorre a lista de produtos retornada e adiciona cada item na ObservableCollection
            tmp.ForEach(i => lista.Add(i));
            
        }
        catch (Exception ex)
        {
            // Caso ocorra algum erro, exibe uma mensagem de alerta na tela
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    // Evento disparado quando o usu�rio clica no bot�o da Toolbar (menu superior)
    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
            // Evento disparado quando o usu�rio clica no bot�o da Toolbar (menu superior)
            Navigation.PushAsync(new Views.NovoProduto());

		}
		catch (Exception ex)
		{
            // Caso ocorra algum erro, exibe uma mensagem de alerta na tela
            DisplayAlert("Ops", ex.Message, "OK");

		}
    }

    // evento que realiza a busca
    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            string q = e.NewTextValue;

            lista.Clear();

            List<Produto> tmp = await App.Db.Search(q);

            tmp.ForEach(i => lista.Add(i));

        }
        catch (Exception ex)
        {
            // Caso ocorra algum erro, exibe uma mensagem de alerta na tela
            await DisplayAlert("Ops", ex.Message, "OK");
        }



    }
    // evento que realizada a soma
    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            double soma = lista.Sum(i => i.Total);

            string msg = $"O total �  {soma:C}";

            DisplayAlert("Total dos Produtos", msg, "OK");

        }
        catch (Exception ex)
        {
            // Caso ocorra algum erro, exibe uma mensagem de alerta na tela
            DisplayAlert("Ops", ex.Message, "OK");
        }


    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
        try
        {

            // localiza o bot�o selecionado e pergunta se de fato a exclus�o ser� feita
            MenuItem selecionado = sender as MenuItem;

            Produto p = selecionado.BindingContext as Produto;


            bool confirm = await DisplayAlert(
                "Tem Certeza?", $"Remover {p.Descricao}?","Sim","N�o");
            if (confirm)
            { 
                await App.Db.Delete(p.Id);
                lista.Remove(p);

            }



        }
        catch (Exception ex)
        {
            // Caso ocorra algum erro, exibe uma mensagem de alerta na tela
            await DisplayAlert("Ops", ex.Message, "OK");
        }


    }

    private void lst_produtos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        try
        {
            Produto p = e.SelectedItem as Produto;

            Navigation.PushAsync(new Views.EditarProduto
            {
                BindingContext = p,

            });
        
        
        }
        catch (Exception ex)
        {
            // Caso ocorra algum erro, exibe uma mensagem de alerta na tela
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}