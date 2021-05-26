using System;

namespace DIO.ProjectAPI.Models
{
    public class InfectadoDto
    {
        public int Id {get; set;}
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}