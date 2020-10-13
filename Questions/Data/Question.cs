using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Questions.Data
{
  public class Question
  {
    [Key]
    public int Id { get; set; }
    [JsonPropertyName("question")]
    public string QuestionText { get; set; }
    public string Image_Url { get; set; }
    public string Thumb_Url { get; set; }
    public DateTime Published_At { get; set; }
    public List<Choices> Choices { get; set; }
  }
  public class Choices
  {
    public string Choice { get; set; }
    public int Votes { get; set; }
  }
}
