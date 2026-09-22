using Microsoft.AspNetCore.Mvc;
using Student_Registry.Model;

namespace Student_Registry.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // -> /api/student
    public class StudentController : ControllerBase
    {
        private static List<StudentMember> Student = [
            new StudentMember {Id = 1, Name = "Zionn Showers", AtSchool = true},
            new StudentMember {Id = 2, Name = "Isaiah Ferguson", AtSchool = true},
            new StudentMember {Id = 3, Name = "Jacob Dekok", AtSchool = true}
        ];
        private static int _nextId = 4;

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
            member.Name = incoming.Name;
            member.AtSchool = incoming.AtSchool;

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
    }
}