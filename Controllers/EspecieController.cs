using API_FAUNA.Data;
using API_FAUNA.Interfaces;
using API_FAUNA.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_FAUNA.Controllers
{
    [Route("api/especie")]
    [ApiController]
    public class EspecieController : ControllerBase
    {
        private readonly EspecieService especieService;
        public EspecieController(EspecieService especieService)
        {
            this.especieService = especieService;
        }
        
        [HttpGet]
        public ActionResult<Especie> GetEspecies() 
        {
            try
            {
                return Ok(especieService.GetEspecies());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult PostEspecies(Especie especie)
        {
            try
            {
                if (especie == null)
                    return NotFound();

                especieService.Adicionar(especie);
                return Ok("Espécie cadastrada com sucesso");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public ActionResult PutEspecies(int id)
        {
            try
            {
                Especie especie = especieService.GetId(id);

                if (especie != null)
                {
                    especieService.Atualizar(especie);
                    return Ok("Espécie atualizada com sucesso");
                }
                else
                    return Ok("Não foi possível atualizar essa espécie pois ela não existe no banco de dados!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public ActionResult DeleteEspecies(int id)
        {
            try
            {
                Especie especie = especieService.GetId(id);

                if (especie != null)
                {
                    especieService.Remover(especie);
                    return Ok("Espécie excluída com sucesso");
                }
                else
                    return Ok("Não foi possível deletar essa espécie pois ela não existe no banco de dados!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
