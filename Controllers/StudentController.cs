using Microsoft.AspNetCore.Mvc;
using Student_Registry.Model;

namespace Student_Registry.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // -> /api/student
    public class StudentController : ControllerBase
    {
        private static List<StudentMember> Student = [
            new StudentMember {Id = 1, FirstName = "Zionn", LastName = "Showers", Hobby = "Gaming", Email = "zshowers@codestack.co", SlackName = "Zionn Showers"},
            new StudentMember {Id = 2, FirstName = "Callen", LastName = "Thomason", Hobby = "Lifting Weights", Email = "cthomason@codestack.co", SlackName = "Callen Thomason"},
            new StudentMember {Id = 3, FirstName = "Valery", LastName = "Lot", Hobby = "Trying new restaurants", Email = "vlot@codestack.co", SlackName = "Valery Lot"},
            new StudentMember {Id = 4, FirstName = "Brandon", LastName = "Langehennig", Hobby = "Art", Email = "blangehennig@codestack.co", SlackName = "Brandon Langehennig"},
            new StudentMember {Id = 5, FirstName = "Zackary", LastName = "Santos", Hobby = "Gaming", Email = "zsantos@codestack.co", SlackName = "Zackary Santos"},
            new StudentMember {Id = 6, FirstName = "Chris", LastName = "Estrada", Hobby = "Magic The Gathering", Email = "cestrada@codestack.co", SlackName = "Chris Estrada"},
            new StudentMember {Id = 7, FirstName = "Jacob", LastName = "Dekok", Hobby = "Coding", Email = "jdekok@sjcoe.net", SlackName = "Jaconator The Iced Winged Angel"},
            new StudentMember {Id = 8, FirstName = "Isaiah", LastName = "Ferguson", Hobby = "Martial Arts", Email = "ifergusonlll@sjcoe.net", SlackName = "Isaiah"},
            
            // new StudentMember {Id = 1, Name = "Zionn Showers", AtSchool = true},
            // new StudentMember {Id = 2, Name = "Isaiah Ferguson", AtSchool = true},
            // new StudentMember {Id = 3, Name = "Jacob Dekok", AtSchool = true}
        ];
        private static int _nextId = 9;

        [HttpGet("GetAllMembers")]
        public ActionResult<List<StudentMember>> GetAll()
        {
            return Ok(Student);
        }

        [HttpGet("getmember/{id}")]
        public ActionResult<StudentMember> GetById(int id)
        {
            StudentMember member = Student.FirstOrDefault(c => c.Id == id);

            if(member == null)
            {
                return NotFound($"No student with id {id}.");
            }
            return Ok(member);
        }

        [HttpPost("Create")]
        public ActionResult<StudentMember> Create([FromBody] StudentMember incoming)
        {
            incoming.Id = _nextId;
            _nextId ++;

            Student.Add(incoming);

            return CreatedAtAction(
                actionName: nameof(GetById),
                routeValues: new {id = incoming.Id},
                value: incoming
            );
        }

        [HttpPut("Update/{id}")]
        public ActionResult<bool> Update(int id, [FromBody] StudentMember incoming)
        {
            StudentMember? member = Student.FirstOrDefault(c => c.Id == id);

            if(member == null)
            {
                return NotFound($"No student with id {id}");
            }
            // member.Name = incoming.Name;
            // member.AtSchool = incoming.AtSchool;
            member.FirstName = incoming.FirstName;
            member.LastName = incoming.LastName;
            member.Hobby = incoming.Hobby;
            member.Email = incoming.Email;
            member.SlackName = incoming.SlackName;

            return Ok(true);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            StudentMember? member = Student.FirstOrDefault(c => c.Id == id);
            
            if(member == null)
            {
                return NotFound($"No student with {id}");
            }

            Student.Remove(member);

            return Ok(true);
        }

        [HttpGet("getemail/{email}")]
        public ActionResult<StudentMember> GetByEmail(string email)
        {
            StudentMember member = Student.FirstOrDefault(c => c.Email == email);

            if(member == null)
            {
                return NotFound($"No student with email {email}.");
            }
            return Ok(member);
        }
    }
}