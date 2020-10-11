using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Questions.Data
{
  public class QuestionsService : IQuestionsService
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

    public async Task<IEnumerable<Question>> GetQuestions(QuestionParameters questionParameters)
    {
      var queryStringParam = new Dictionary<string, string>
      {
        ["limit"] = questionParameters.Limit.ToString(),
        ["offset"] = questionParameters.Offset.ToString(),
        ["filter"] = questionParameters.Filter
      };

      HttpResponseMessage response = await httpClient.GetAsync(QueryHelpers.AddQueryString("questions", queryStringParam));
      string content = await response.Content.ReadAsStringAsync();
      response.EnsureSuccessStatusCode();
      var q = JsonSerializer.Deserialize<IEnumerable<Question>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
      return q;
    }

    public async Task<Question> GetQuestion(int id)
    {
      HttpResponseMessage response = await httpClient.GetAsync($"questions/{id}");
      string content = await response.Content.ReadAsStringAsync();
      response.EnsureSuccessStatusCode();
      try
      {
        return JsonSerializer.Deserialize<Question>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
      }
      catch
      {
        return null;
      }
    }


  }
}
