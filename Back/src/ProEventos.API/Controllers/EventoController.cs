using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento[]
            {
                new()
                {
                    EventoId = 1,
                    Local = "Belo Horizonte",
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
                    Tema = "Angular e .NET 5",
                    Quantidade = 250,
                    Lote = "1º Lote",
                    ImagemURL = "foto.jpg"
                },
                new()
                {
                    EventoId = 2,
                    Local = "São Paulo",
                    DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
                    Tema = "Angular e Suas Novidades",
                    Quantidade = 350,
                    Lote = "2º Lote",
                    ImagemURL = "foto1.jpg"
                }
            };
        public EventoController()
        {

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where(evento => evento.EventoId == id);
        }

        // [HttpPost]
        // public String Post()
        // {
        //     return "Exemplo";
        // }

        // [HttpPut("{id}")]
        // public String Put(int id)
        // {
        //     return $"Exemplo de Put id = {id}";
        // }

        // [HttpDelete("{id}")]
        // public String Delete(int id)
        // {
        //     return $"Exemplo de Delete id = {id}";
        // }
    }
}

