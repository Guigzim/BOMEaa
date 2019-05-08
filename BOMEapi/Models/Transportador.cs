using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BOMEapi.Models
{
    public class Transportador
    {
        public string id { get; set; }
        public string nome { get; set; }
        public string cpf_cnpj { get; set; }
        public veiculo tipo_veiculo { get; set; }


        public List<Transportador> getAllTrasportador()
        {
            string sql = "SELECT * FROM bomedb.transportador";
            BomeDbContext db = new BomeDbContext();
            DataTable table = db.getData(sql);
            List<Transportador> list = new List<Transportador>();
            foreach (DataRow item in table.Rows)
            {
                Transportador transp = new Transportador()
                {
                    id = item["id"].ToString(),
                    nome = item["nome"].ToString(),
                    cpf_cnpj = item["cpf_cnpj"].ToString(),
                    tipo_veiculo = (veiculo)item["tipo_veiculo"]
                };
                list.Add(transp);
            }
            return list;
        }
        public List<Transportador> getTransportadorVeiculo(veiculo veiculo)
        {
            List<Transportador> list = getAllTrasportador();
            return list.Where(x => x.tipo_veiculo == veiculo).ToList();
        }
        public Transportador getTransportadorId(string id)
        {
            List<Transportador> list = getAllTrasportador();
            return list.Find(x => x.id == id);
        }
    }

    public enum veiculo
    {
       Carro,
       Moto,
       Caminhão,
       Bicicleta
    }
}
