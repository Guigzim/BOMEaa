using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BOMEapi.Models
{
    public class Produto
    {
        public string id { get; set; }
        public string descricao { get; set; }
        public string valor { get; set; }

        public List<Produto> getAll()
        {
            string sql = "SELECT * FROM bomedb.produto";
            BomeDbContext db = new BomeDbContext();
            DataTable table = db.getData(sql);

            List<Produto> list = new List<Produto>();
            foreach (DataRow item in table.Rows)
            {
                Produto produto = new Produto()
                {
                    id = item["id"].ToString(),
                    descricao = item["descricao"].ToString(),
                    valor = item["valor"].ToString()

                };
                list.Add(produto);
            }
            return list;

        }
        public List<Produto> getProdutosPedido(string id_pedido)
        {
            string sql = $"SELECT A.id, A.descricao, A.valor FROM produto AS A JOIN pedido_produto AS B ON A.id = B.id_produto JOIN pedido AS C ON B.id_pedido = C.id WHERE C.id = '{id_pedido}';";
            BomeDbContext db = new BomeDbContext();
            DataTable table = db.getData(sql);
            List<Produto> list = new List<Produto>();
            foreach (DataRow item in table.Rows)
            {
                Produto produto = new Produto()
                {
                    id = item["id"].ToString(),
                    descricao = item["descricao"].ToString(),
                    valor = item["valor"].ToString()

                };
                list.Add(produto);
            }
            return list;
        }
        public static void Insert(Produto produto)
        {
            string sql = $"INSERT INTO `bomedb`.`produto` (`id`, `descricao`, `valor`) VALUES ('{Guid.NewGuid().ToString()}', '{produto.descricao}', '{produto.valor}');";
            BomeDbContext db = new BomeDbContext();
            db.InsertData(sql);

        }
        public bool isValid()
        {
            double result;
            if (string.IsNullOrEmpty(this.descricao) || string.IsNullOrWhiteSpace(this.descricao))
                return false;
            if (!double.TryParse(this.valor, out result))
                return false;

            return true;

        }
    }

}
