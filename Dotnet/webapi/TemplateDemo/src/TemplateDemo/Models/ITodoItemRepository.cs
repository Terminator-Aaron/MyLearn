using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemplateDemo.Models
{
    public interface ITodoItemRepository
    {
        void Add(TodoItem item);
        IEnumerable<TodoItem> GetAll();
        TodoItem Find(string key);
        IEnumerable<TodoItem> FilterByComplete(bool isComplete);
        TodoItem Remove(string key);
        void Update(TodoItem item);
    }
}
