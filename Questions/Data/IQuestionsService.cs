using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Questions.Data
{
  interface IQuestionsService
  {
    Task<HttpResponseMessage> CheckHealth();
    Task<IEnumerable<Question>> GetQuestions(QuestionParameters questionParameters);
  }
}
