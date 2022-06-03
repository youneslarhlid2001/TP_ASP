using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TPASPnet5.data;
using TPASPnet5.Models;

namespace TPASPnet5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class commandController : ControllerBase
    {
        private TP_APIDbContext _DbContext;
        public commandController(TP_APIDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        
        [HttpGet("GetCmds")]
        public IActionResult Get()
        {
            
            var Commande = _DbContext.achat.ToList();

            if (Commande.Count == 0)
            {
                return StatusCode(404, "y'a aucune commande");
            }

            return Ok(Commande);

        }


        [HttpPost("AddCmd")]
        
        public IActionResult Add([FromBody] commandRequest request)
        {

            Commande cmd = new Commande();
            cmd.num_commande = request.num_commande;
            cmd.entree = request.entree;
            cmd.plat = request.plat;
            cmd.dessert = request.dessert;
            cmd.boisson = request.boisson;
            cmd.situation = request.situation;
            _DbContext.achat.Add(cmd);
            _DbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("UpdateCmd")]
        public IActionResult Update([FromBody] commandRequest request)
        {
            var cmd = _DbContext.achat.FirstOrDefault(i => i.num_commande == request.num_commande);
            if (cmd == null)
            {
                return StatusCode(404, "y'a aucune commande");
            }
            cmd.entree = request.entree;
            cmd.plat = request.plat;
            cmd.dessert = request.dessert;
            cmd.boisson = request.boisson;
            cmd.situation = request.situation;

            _DbContext.Entry(cmd).State = EntityState.Modified;
            _DbContext.SaveChanges();

            var cmds = Get();
            return Ok(cmds);
        }

       
        [HttpDelete("DeleteCmd/{Id}")]
        public IActionResult Delete([FromRoute] string Id)
        {

            var cmd = _DbContext.achat.FirstOrDefault(i => i.num_commande ==Id);
            if (cmd == null)
            {
                return StatusCode(404, "y'a aucune commande");
            }

            _DbContext.Entry(cmd).State = EntityState.Deleted;
            _DbContext.SaveChanges();
            return Ok();
        }

       
    }
}
