using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questions.Data
{
 public class QuestionsRepository
  {
    public List<Question> Questions { get; set; }

    public event Action OnChange;

    public void SetProperty(IEnumerable<Question> value)
    {
      Questions = value.ToList();
      NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
  }
}
