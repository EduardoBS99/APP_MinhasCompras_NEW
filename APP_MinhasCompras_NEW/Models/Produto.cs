using SQLite;


namespace APP_MinhasCompras_NEW.Models
{
    public class Produto
    {
        //validação para não inputar infos vazias
        string _descricao;
        double _quantidade;
        double _preco;


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { 
            get => _descricao;
            set
            {
                if (value == null)
                {
                    throw new Exception("Por favor, preencha a descição");

                }
                _descricao = value;
            }
        }
        public double Quantidade { 
            get => _quantidade;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Por favor, preencha a quantidade");

                }
                _quantidade = value;
            }

        }
        public double Preco { 
            get => _preco;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Por favor, preencha o preço");

                }
                _preco = value;
            }
        }

        // Inserindo a coluna total que realzia a operação
        public double Total { get => Quantidade * Preco; }

    }
}
