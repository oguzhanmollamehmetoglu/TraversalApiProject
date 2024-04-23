using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TraversalApiProject.Dal.Context;
using TraversalApiProject.Dal.Entities;

namespace TraversalApiProject.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult VisitorList()
        {
            using (var context = new VisitorContext())
            {
                var values = context.visitors.ToList();
                return Ok(values);
            }
        }
        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                context.Add(visitor);
                context.SaveChanges();
                return Ok();
            }
        }
        [HttpGet("{id}")]
        public IActionResult VisitorGet(int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(values);
                }
            }
        }
        [HttpDelete("{id}")]
        public IActionResult VisitorDelete(int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    context.Remove(values);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }
        [HttpPut("{id}")]
        public IActionResult VisitorUpdate(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Find<Visitor>(visitor.VisitorID);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    values.City = visitor.City;
                    values.Surname = visitor.Surname;
                    values.Country = visitor.Country;
                    values.Name = visitor.Name;
                    values.Mail = visitor.Mail;
                    context.Update(values);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}