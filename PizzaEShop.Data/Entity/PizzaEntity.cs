using PizzaEShop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PizzaEShop.Data.Entity
{
    public class PizzaEntity
    {
        public int Id { get; set; }
        public OrderEntity Order { get; set; } = null!;
        public PizzaType PizzaType { get; set; }
        public int PizzaCost { get; set; }

        public int Mozzarela { get; set; }
        public int Gorgonzola { get; set; }
        public int Hermelin { get; set; }
        public int Vejce { get; set; }
        public int Kukurice { get; set; }
        public int Rukola { get; set; }
        public int Salam { get; set; }
        public int Losos { get; set; }
        public int Zizaly { get; set; }

    }
}
