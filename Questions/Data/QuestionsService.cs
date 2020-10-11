using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Questions.Data
{
  public class QuestionsService: IQuestionsService
  {
    private readonly HttpClient httpClient;

    public QuestionsService(IConfiguration configuration)
    {
      httpClient = new HttpClient
      {
        BaseAddress = new Uri(configuration.GetConnectionString("api"))
      };
    }
  


    public async Task<HttpResponseMessage> CheckHealth()
    {
      
      return await httpClient.GetAsync("health");
    }

    public Task<IEnumerable<Question>> GetQuestions()
    {
      throw new NotImplementedException();
    }
  }
}
