using System;
using System.Collections.Generic;
using System.Data;

namespace BOMEapi.Models
{
    public class Pedido
    {
        public string id { get; set; }
        public User usr_cliente { get; set; }
        public User usr_comercio { get; set; }
        public Transportador transportador { get; set; }
        public List<Produto> listProdutos { get; set; }

        public List<Pedido> GetPedidos()
        {
            string sql = "SELECT * FROM bomedb.pedido";
            BomeDbContext db = new BomeDbContext();
            DataTable table = db.getData(sql);
            List<Pedido> list = new List<Pedido>();

            foreach (DataRow item in table.Rows)
            {
                Pedido pedido = new Pedido()
                {
                    id = item["id"].ToString(),
                };
                pedido.usr_cliente = new User().getUserId(item["id_usr_cliente"].ToString());
                pedido.usr_comercio = new User().getUserId(item["id_usr_comercio"].ToString());
                if (item["id_transportador"] != null)
                    pedido.transportador = new Transportador().getTransportadorId(item["id_transportador"].ToString());

                pedido.listProdutos = new Produto().getProdutosPedido(pedido.id);

                list.Add(pedido);
            }
            return list;
        }
        public void InsertPedido(Pedido pedido)
        {
            string sql = $"INSERT INTO `bomedb`.`pedido` (`id`, `id_usr_cliente`, `id_usr_comercio`) VALUES ('{Guid.NewGuid().ToString()}', '{usr_cliente.id}', '{usr_comercio.id}');";
            BomeDbContext db = new BomeDbContext();
            db.InsertData(sql);

        }
        public bool isValid()
        {
            if (string.IsNullOrEmpty(this.usr_cliente.id) || string.IsNullOrWhiteSpace(this.usr_cliente.id))
                return false;
            if (string.IsNullOrEmpty(this.usr_comercio.id) || string.IsNullOrWhiteSpace(this.usr_comercio.id))
                return false;
            if (string.IsNullOrEmpty(this.transportador.id) || string.IsNullOrWhiteSpace(this.transportador.id))
                return false;
            if (listProdutos.Count < 1)
                return false;

            return true;
        }
        public void UpdatePedidoTrans(string id_pedido, string id_transportador)
        {
            string sql = $"UPDATE `bomedb`.`pedido` SET `id_transportador` = '{id_transportador}' WHERE(`id` = '{id_pedido}');";
            BomeDbContext db = new BomeDbContext();
            db.InsertData(sql);
        }
    }
}
