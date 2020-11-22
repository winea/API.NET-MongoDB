using Api.Data.Collections;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;


namespace Api.Controllers
{
    [ApiController] //Informa que é uma API
    [Route("[controller]")]//http://localhost:5000/infectado
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB; //Classe que criamos pasta Data
        IMongoCollection<Infectado> _infectadosCollection;
        
        
        //Injecao de dependencia -> Data.MongoDB mongoDB
        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto) //recebe obj com estrutura da InfectadoDto
        {
            var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            //Collection tem uma serie de funcionalidades interessantes
            _infectadosCollection.InsertOne(infectado);
            
            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
            
            return Ok(infectados);
        }
    }
}
