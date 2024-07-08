
using System;

namespace projeto.Models
{
    public class Imc
    {
        public int Id { get; set; }
        public Aluno Aluno { get; set; }
        public float Altura { get; set; }
        public float Peso {get; set; }
        public string classe{ get; set; }
        public float imc { get; set; }
        public DateTime DataCriacao { get; set; }
        

       

        
    }
}
