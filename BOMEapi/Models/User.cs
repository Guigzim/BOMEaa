using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace BOMEapi.Models
{
    public class User
    {
        
        public string id { get; set; }
        public string nome { get; set; }
        public string cpf_cnpj { get; set; }
        public string rua { get; set; }
        public string numero { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string uf { get; set; }
        public string tipo { get; set; }

        public User getUserId(string id)
        {
            List<User> list = GetUserAll();
            return list.Find(x => x.id == id);
        }
        public List<User> getUserTipo(string tipo)
        {
            List<User> list = GetUserAll();
            return list.Where(x => x.tipo == tipo).ToList();
        }
        public List<User> GetUserAll()
        {
            string sql = "SELECT * FROM bomedb.user";
            BomeDbContext db = new BomeDbContext();
            DataTable table = db.getData(sql);
            List<User> list = new List<User>();
            foreach (DataRow item in table.Rows)
            {
                User usr = new User()
                {
                    id = item["id"].ToString(),
                    nome = item["nome"].ToString(),
                    cpf_cnpj = item["cpf_cnpj"].ToString(),
                    rua = item["rua"].ToString(),
                    numero = item["numero"].ToString(),
                    bairro = item["bairro"].ToString(),
                    cidade = item["cidade"].ToString(),
                    uf = item["uf"].ToString(),
                    tipo = item["tipo"].ToString()
                };
                list.Add(usr);
            }
            return list;
        }
    }

}

