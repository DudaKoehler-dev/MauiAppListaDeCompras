using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace MauiAppListaDeCompras.Models
{
    public class Produto
    {
        [AutoIncrement, PrimaryKey] 
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public double Preco {  get; set; }

        public double Total { get => Quantidade * Preco; }

    }
}
