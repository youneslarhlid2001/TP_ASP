using System.ComponentModel.DataAnnotations;

namespace TPASPnet5.data
{
    public class Commande
    {
        [Key]
        public string num_commande { get; set; }
        public string entree { get; set; }
        public string plat { get; set; }
        public string dessert { get; set; }
        public string boisson { get; set; }
        public string situation { get; set; }
    }
    }
