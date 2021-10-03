using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using wapi.Models;

namespace wapi.Controllers
{
    //agregue route y api
    [ApiController]
    [Route("[controller]/[action]")]

    public class RoleController : ControllerBase
    {
        // POST: role/apost
        [HttpPost]
        public async Task<ActionResult<RoleModel>> aPost(RoleModel payload)
        {
            using (var context = new RoleContext())
            {
                context.RoleM.Add(payload);
                await context.SaveChangesAsync();
            }
            return Ok(payload);
        }

        // GET: role/aget/4
        [HttpGet("{id?}")]
        public async Task<ActionResult<RoleModel>> aGet(int? id)
        {
            using (var context = new RoleContext()) 
            {  
                if (id == null)  
                {                            
                    var rolvar = context.RoleM.ToList();
                    return Ok(rolvar); 
                }
                var aw = await context.RoleM.FindAsync(id); 

                return NotFound(aw);  
            }     
        } 

        // PUT: role/aput/4
        [HttpPut("{id}")]
        public async Task<ActionResult<RoleModel>> aPut(int id, [FromBody]RoleModel payload) //el frombody es opcional
        {
            using (var context = new RoleContext())
            {   
                var aw = await context.RoleM.FindAsync(id);  

                if (aw == null)
                {
                    return BadRequest("id not found");
                }  

                aw.rolename = payload.rolename;

                context.Update(aw); 
                await context.SaveChangesAsync();   
                return Ok(aw); 
            }     
        } 

        // DELETE: role/adel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoleModel>> aDel(int id)
        {   
            using(var context = new RoleContext()){

                var aw = await context.RoleM.FindAsync(id);

                if (aw == null)
                {
                    return NotFound();
                }
                
                context.RoleM.Remove(aw);
                await context.SaveChangesAsync();

                return Ok(aw);
            }            
        }  



    }

    
}