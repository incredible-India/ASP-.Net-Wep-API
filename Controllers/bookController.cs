using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class bookController : Controller
    {
        private readonly ibook _ibook;

        public bookController(ibook ibook)
        {
            _ibook = ibook;
        }


        [HttpGet("")]
        public IActionResult Index()
        {
            var em = _ibook.GetEmps();
            return Ok(em);
        }

        [HttpGet("{id}")]
        public IActionResult Getempbyid(int id) {

            var data = _ibook.GetEmpById(id);
            return Ok(data);
        }

        [HttpPost("add")]
        public IActionResult addEmp([FromBody] emp e)
        {
            int id =_ibook.addEmp(e);
            return CreatedAtAction(nameof(Getempbyid), new { id = id, Controller="book" }, e.Id);
        }


        [HttpPut("update/{id}")]
        public IActionResult updateinfo(int id, [FromBody]emp e) {

            var c  = _ibook.updateempl(id,e);
            return Ok(c);
        
        } 
        
        [HttpPatch("updatepatch/{id}")]
        public IActionResult updateinfopatch(int id, [FromBody] JsonPatchDocument e) {

            var c  = _ibook.updateemplpatch(id,e);
            return Ok(c);
        
        }
        
        [HttpPatch("delete/{id}")]
        public IActionResult udelteinfopatch(int id) {

            var c  = _ibook.Deleteemplpatch(id);
            return Ok(c);
        
        }

    }
}
