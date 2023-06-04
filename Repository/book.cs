using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;
namespace WebApplication1.Repository
{
    public class book :ibook
    {
        private readonly bookContext context;

        public book(bookContext bookContext)
        {
            context = bookContext;
        }


        //get all the book

        public List<emp> GetEmps()
        {
            return context.emple.ToList();
        }


        public emp GetEmpById(int id)
        {
            return context.emple.Where(x =>x.Id == id).FirstOrDefault();
            
        }

        //adding employee

        public int addEmp(emp emp)
        {
            emp e = new emp()
            {
                Name = emp.Name,
            };
            context.emple.Add(emp);
            context.SaveChanges();

            return e.Id;
        }

        //update the emp

        public emp updateempl(int id , emp emp)
        {
            var data = context.emple.Where(x => x.Id == id).FirstOrDefault();

            if (data != null)
            {
                data.Name = emp.Name;
                context.SaveChanges();
            }

            return emp;
        }  
        
        //update the emp patch

        public emp updateemplpatch(int id ,[FromBody] JsonPatchDocument emp)
        {
            var data = context.emple.Where(x => x.Id == id).FirstOrDefault();

            if (data != null)
            {
                emp.ApplyTo(data);
                context.SaveChanges();
            }

            return data;
        } 
        
        //delete the emp 

        public bool Deleteemplpatch(int id)
        {
            var data = context.emple.Where(x => x.Id == id).FirstOrDefault();

            if (data != null)
            {
               context.emple.Remove(data);
                context.SaveChanges();
            }

            return true;
        }

    }
}
