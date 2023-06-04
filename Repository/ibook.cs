using Microsoft.AspNetCore.JsonPatch;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public interface ibook
    {
        //getting all the information of the book
        public List<emp> GetEmps();

        //gettingthe emp bu id
        public emp GetEmpById(int id);

        //adding the new employee
        public int addEmp(emp emp);

        //updateing the employee
        public emp updateempl(int id, emp emp);
        //update the emp patch

        public emp updateemplpatch(int id, JsonPatchDocument emp);
        //delete the emp 

        public bool Deleteemplpatch(int id);
    }
}
