using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entidades
{
    public class ClientEntcs
    {
        public int Id { get; private set; }
        public string NomeCompleto { get; private set; }
        public string Cpf { get; private set; }
        public string Rg { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Cep { get; private set; }
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

        //public void AdicionarTelefone(string telefone)
        //{
        //    if(Telefones == null)
        //    {
        //        Telefones = new List<string>();
        //    }
        //    Telefones.Add(telefone);
        //}

        public ClientEntcs(string nomeCompleto, string cpf, string rg, DateTime dataNascimento, string cep)
        {
            NomeCompleto = nomeCompleto;
            Cpf = cpf;
            Rg = rg;
            DataNascimento = dataNascimento;
            Cep = cep;         
        }

        public ClientEntcs()
        {

        }
    }
}
