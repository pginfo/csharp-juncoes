using juncoes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace juncoes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Departamento> deptos = Departamento.GetDepartamentos();
            IEnumerable<Colaborador> colaborador = Colaborador.GetColaboradores();
            IEnumerable<Cargo> cargos = Cargo.GetCargos();

            var depto_colab = deptos.GroupJoin(colaborador, d => d.Id, c => c.DeptoId,
                (a, b) => new { Depto1 = a, Colab1 = b })
                .SelectMany(d => d.Colab1.DefaultIfEmpty(),
                (a, b) => new { Depto2 = a, Colab2 = b })
                .Select(x => new
                {
                    IdDepartamento = x.Depto2.Depto1.Id,
                    IdColaborador = x.Colab2?.Id,
                    CargoIdColaborador = x.Colab2?.CargoId,
                    NomeDepartamento = x.Depto2.Depto1.Nome,
                    NomeColaborador = x.Colab2?.Nome ?? string.Empty,
                });

            var depto_colab_cargo = depto_colab.GroupJoin(cargos, d => d.CargoIdColaborador, c => c.Id,
                (x,y) => new { Depto = x, _cargo = y })
                .SelectMany(w => w._cargo.DefaultIfEmpty(),
                (a, b) => new { DeptoCargo = a, _Cargo = b })
                .Select(s => new {
                    IdDepartamento = s.DeptoCargo.Depto?.IdDepartamento,
                    NomeDepartamento = s.DeptoCargo.Depto?.NomeDepartamento,
                    IdColaborador = s.DeptoCargo.Depto?.IdColaborador,
                    NomeColaborador = s.DeptoCargo.Depto?.NomeColaborador,
                    IdCargo = s._Cargo?.Id,
                    NomeCargo = s._Cargo?.Nome
                });

            foreach (var item in depto_colab_cargo)
            {
                Console.WriteLine($"IdDepartamento: {item.IdDepartamento}");
                Console.WriteLine($"NomeDepartamento: {item.NomeDepartamento}");
                Console.WriteLine($"IdColaborador: {item.IdColaborador}");
                Console.WriteLine($"NomeColaborador: {item.NomeColaborador}");
                Console.WriteLine($"IdCargo: {item.IdCargo}");
                Console.WriteLine($"NomeCargo: {item.NomeCargo}");

                //Console.WriteLine($"CargoIdColaborador: {item.CargoIdColaborador}");

                Console.WriteLine("---");
            }

            Console.ReadLine();
        }
    }
}
