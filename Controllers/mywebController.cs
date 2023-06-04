using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/")]
    [Route("[controller]/[action]")]
    public class mywebController : ControllerBase
    {
        private List<emp> e = new List<emp>();

        public mywebController() {
            var e = new List<emp>()
            {
                new emp () {Id=1,Name="Himanshu"}
            };


        }


        [Route("~/api")]
        public string getData()
        {
            return "hello world";
        }

        [Route("{id}")]
        [Route("[controller]/[action]")] public string getDat(int id, string name)
        {
            return id + name;
        }


        public List<emp> getAll()
        {
            return new List<emp>()
        {
            new emp() {Id=1, Name="Himanshu"},
            new emp() {Id=2,Name="Sachin"}
        };


        }

        [Route("{id}")]
        public IActionResult getemp(int id) {

            List<emp> list = new List<emp>() { new emp() { Id=1,Name="Sachin"},
        new emp() {Id=2,Name="Himanshu"}};

            if (id > 3) {

                return BadRequest();

            }
            foreach (emp emp in list) {

                if (emp.Id == id) return Ok(emp.Name);



            }

            return NotFound();


        }
        [Route("{id}")]
        public IActionResult getEmp(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            return Ok(e.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult newemp(emp emp)
        {

            e.Add(emp);

            return Created("myweb/getEmp/", new { id = emp.Id });

        }



        //bind property

        [BindProperty]
        public anime an { get; set; }

        [HttpPost]
        public IActionResult getc()
        {
            return Ok(this.an.Name);
        }


        [HttpPost]
        public IActionResult getg(anime a)
        {
            return Ok(a.Name);
        }


        [HttpPost]
        public IActionResult Fromdata([FromQuery] emp mk)
        {
            return Ok(mk.Name);
        }

        [HttpPost("{Id}/{Name}")]
        public IActionResult fromg([FromRoute] emp po, [FromQuery] string name)
        {
            return Ok(po.Name + name);
        }

        [HttpPost]
        public IActionResult simple(anime name)
        {
            return Ok(name);
        }

        [HttpPost("{Name}")]
        public IActionResult juki([FromBody] int id, [FromRoute] string Name)
        {
            return Ok(Name + id.ToString() );
        } 
        
        [HttpPost()]
        public IActionResult him( [FromForm] string Name)
        {
            return Ok(Name);
        }
        
        [HttpPost()]
        public IActionResult gim( [FromHeader] string Name)
        {
            return Ok(Name);
        }

        [HttpPost()]
        public IActionResult jim(string e)
        {
            return Ok(e);
        }
        //custom model binder


        public IActionResult custom([ModelBinder(typeof(custombinder))]string[] Name)
        {
            return Ok(Name);
        }

    }
    




}
