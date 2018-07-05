using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace quiz_backend.Controllers
{   [Produces("application/json")]
    [Route("api/Questions")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        readonly QuizContext context;
        public QuestionsController(QuizContext context)
        {
            this.context = context;
        }
        //GET api/questions
        [HttpGet]
        public IEnumerable<Models.Question> Get(){
            return context.Questions;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Models.Question question)
        {
            if (id != question.ID)
                return BadRequest();
            context.Entry(question).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(question);
        }

        // POST api/questions
        [HttpPost]
        public void Post([FromBody] Models.Question question)
        {
            context.Questions.Add(question);
            context.SaveChanges();
        }
    }
}