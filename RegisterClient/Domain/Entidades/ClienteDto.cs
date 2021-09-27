using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cep { get; set; }
        //public List<string> Telefones { get; private set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(NomeCompleto))
            {
                throw new ArgumentNullException("Nome não pode ser vazio");
            }

            if (string.IsNullOrEmpty(Cpf))
            {
                throw new ArgumentNullException("Não pode ser vazio");
            }
        }

        public bool Adulto()
        {
            return true;
        }

        public ClienteDto(string nomeCompleto, string cpf, string rg, DateTime dataNascimento, string cep)
        {
            NomeCompleto = nomeCompleto;
            Cpf = cpf;
            Rg = rg;
            DataNascimento = dataNascimento;
            Cep = cep;
            Validar();
        }

        public ClienteDto()
        {

        }
    }
}
