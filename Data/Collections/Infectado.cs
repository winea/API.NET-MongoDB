using System;
using MongoDB.Driver.GeoJsonObjectModel;

//Classe que que representa a nossa collection no banco
namespace Api.Data.Collections
{
    public class Infectado
    {
        public Infectado(DateTime dataNascimento, string sexo, double latitude, double longitude)
        {
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            //Para utilizar geolocalizacao
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
        
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
    }
}