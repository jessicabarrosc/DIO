using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace DIO.ProjectAPI.Data.Collections
{ public class Infectado
    {
        public Infectado(DateTime dataNascimento, string sexo, double latitude, double longitude, int id)
        {
            this.Id = id;
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }

        public int Id { get; set;}
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
    }
}