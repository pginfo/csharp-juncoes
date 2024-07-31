using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace juncoes.Entities
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int DeptoId { get; set; }
        public int CargoId { get; set; }

        public Colaborador(int id, string nome, int deptoId, int cargoId)
        {
            Id = id;
            Nome = nome;
            DeptoId = deptoId;
            CargoId = cargoId;
        }

        public static IEnumerable<Colaborador> GetColaboradores()
        {
            return new List<Colaborador> { 
            new Colaborador(1, "Moisés", 4, 3),
            new Colaborador(2, "João", 2, 2),
            new Colaborador(3, "Pedro", 6, 4),
            new Colaborador(4, "Teresa", 2, 4),
            new Colaborador(5, "Marciano", 2, 3),
            new Colaborador(6, "Felipe", 4, 3),
            new Colaborador(7, "Moacir", 6, 7)
            };
        }
    }
}
