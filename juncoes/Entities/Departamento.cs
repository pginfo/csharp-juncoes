using System.Collections.Generic;

namespace juncoes.Entities
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Departamento(int id, string nome) {
            Id = id;
            Nome = nome;
        }

        public static IEnumerable<Departamento> GetDepartamentos()
        {
            return new List<Departamento>
            {
                new Departamento(1, "Financeiro"),
                new Departamento(2, "Recursos Humanos"),
                new Departamento(3, "Almoxarifado"),
                new Departamento(4, "Marketing"),
                new Departamento(5, "Diretoria"),
                new Departamento(6, "Presidência"),
            };            
        }
    }
}
