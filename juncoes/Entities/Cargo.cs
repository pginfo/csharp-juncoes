using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juncoes.Entities
{
    public class Cargo
    {
        public Cargo(int id, string nome) {        
            Id = id;
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public static IEnumerable<Cargo> GetCargos()
        {
            return new List<Cargo>
            {
                new Cargo(1,"Ajudante"),
                new Cargo(2,"Carpinteiro"),
                new Cargo(3,"Vidraceiro"),
                new Cargo(4,"Eletricista"),
                new Cargo(5,"Encanador"),
                new Cargo(6,"Pedreiro"),
                new Cargo(7,"Engenheiro")
            };
        }
        
    }
}
