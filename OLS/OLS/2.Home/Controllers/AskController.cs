using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OLS.DTO.Asks.Home;
using OLS.Services.Interface.Home;

namespace OLS._2.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AskController : ControllerBase
    {
        private readonly IAskRepository askRepo;
        public AskController(IAskRepository askRepo)
        {
            this.askRepo = askRepo;
        }

        // Get all asks by discuss id 
        [HttpGet("/getAllAskByDiscussId/{discussId}")]
        public async Task<ActionResult<IEnumerable<AskReadHomeDTO>>> GetAllAskByDiscussId(int discussId)
        {
            try
            {
                var asks = await askRepo.GetAllAsksByDiscussId(discussId);
                return Ok(asks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Cerate new ask 
        [HttpPost("/createAsk")]
        public async Task<ActionResult<IEnumerable<AskCreateHomeDTO>>> CreateAsk(AskCreateHomeDTO ask)
        {
            try
            {
                var newAsk = await askRepo.CreateAsk(ask);
                return Ok(newAsk);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get ask by askId
        [HttpGet("/getAskByAskId/{askId}")]
        public async Task<ActionResult<IEnumerable<AskReadHomeDTO>>> GetAskByAskId(int askId)
        {
            try
            {
                var ask = await askRepo.GetAskByAskId(askId); 
                return Ok(ask);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update ask by askId
        [HttpPut("/updateAskByAskID/{askId}")] //UpdateAskByAskID(int askId, AskUpdateHomeDTO updatedAsk);
        public async Task<ActionResult<IEnumerable<AskUpdateHomeDTO>>> UpdateAskByAskID(int askId, AskUpdateHomeDTO updatedAsk)
        {
            try
            {
                var existingAsk = await askRepo.UpdateAskByAskID(askId, updatedAsk);
                return Ok(existingAsk);
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete ask by askId
        [HttpDelete("/deleteAskByAskId/{askId}")]
        public async Task<ActionResult> DeleteAskByAskId(int askId)
        {
            try
            {
                var existingAsk = await askRepo.DeleteAskByAskId(askId);
                return NoContent();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
