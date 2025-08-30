using SQLite;


namespace APP_MinhasCompras_NEW.Models
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public double Preco { get; set; }

        // Inserindo a coluna total que realzia a operação
        public double Total { get => Quantidade * Preco; }

    }
}
