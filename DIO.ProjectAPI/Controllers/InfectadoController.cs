using Microsoft.AspNetCore.Mvc;
using DIO.ProjectAPI.Data.Collections;
using DIO.ProjectAPI.Models;
using MongoDB.Driver;


namespace DIO.ProjectAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB ?? throw new System.ArgumentNullException(nameof(mongoDB));
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude, dto.Id);

            _infectadosCollection.InsertOne(infectado);
            
            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
            
            return Ok(infectados);
        }

        [HttpPost]
        public ActionResult AtualizarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado(dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude, dto.Id);

            _infectadosCollection.UpdateOne(Builders<Infectado>.Filter.Where(_ => _.Id == dto.Id), Builders<Infectado>.Update.Set("Sexo", dto.Sexo));
            
            return StatusCode(201, "Infectado atualizado com sucesso");
        }

        [HttpGet]
        public IActionResult DeleteInfectado ([FromBody] InfectadoDto dto)
        {
            _infectadosCollection.DeleteOne(Builders<Infectado>.Filter.Where(_ => _.Id == dto.Id));
            return Ok("Excluido com sucesso");
        }

    }
}