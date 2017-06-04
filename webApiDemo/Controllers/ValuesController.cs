using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeesDAL;
using System.Collections;

namespace webApiDemo.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<Employee> Get()
        {
            using (testEntities employeeEntity = new testEntities())
                return employeeEntity.Employees.ToList<Employee>();
        }

        // GET api/values/5
        
        [Route("api/values/{id:int}",Name ="getEmployeeById")]
        public Employee Get(int id)
        {
            using (testEntities empentity = new testEntities())
                return empentity.Employees.FirstOrDefault(e => e.Id == id);
        }

        // POST api/values
        public List<Employee> Post([FromBody]Employee employee)
        {
            /*if (!ModelState.IsValid)
            {
                return employee.l
            }*/
            using (testEntities empentity = new testEntities())
            {
                empentity.Employees.Add(employee);
                empentity.SaveChanges();
                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, new Uri(Url.Link("getEmployeeById", new { id = employee.Id })));
                // response.Headers.Location = new Uri(Url.Link("getEmployeeById",new { id = employee.Id }));
                //return response;
                //using (testEntities employeeEntity = new testEntities())
                List<Employee> l = new List<Employee>();
                l.Add(empentity.Employees.FirstOrDefault(e => e.Id == employee.Id));
                    return l;
            }
        }

        // PUT api/values/5
        [Route("api/values/{id:int}", Name = "hello")]
        [HttpPut]
        public List<Employee> Put(int id, [FromBody]Employee em)
        {
            Employee stud;
            List<Employee> l = new List<Employee>();
            using (testEntities empentity = new testEntities())
            {
                


                stud = empentity.Employees.Where(s => s.Id ==id).FirstOrDefault<Employee>();
                empentity.Employees.Remove(stud);
                //stud.Name = "Updated Student1";
                empentity.Employees.Add(em);
                empentity.SaveChanges();
                return empentity.Employees.ToList<Employee>();
                l.Add(stud);
                //return l;
                //Employee em = 

                //l.Add(em);
                //return l;
            }
            /*using (testEntities abc = new testEntities())
            {
                abc.Employees.Add(em);
                abc.SaveChanges();
                return abc.Employees.ToList<Employee>();
            }*/




        }

        // DELETE api/values/5
        [Route("api/values/{id:int}", Name = "hi")]
        [HttpDelete]
        public List<Employee> Delete(int id)
        {
            Employee stud;
            List<Employee> l = new List<Employee>();
            using (testEntities empentity = new testEntities())
            {
                stud = empentity.Employees.Where(s => s.Id == id).FirstOrDefault<Employee>();
                empentity.Employees.Remove(stud);
                empentity.SaveChanges();
                return empentity.Employees.ToList<Employee>();
            }
        }
    }


}
