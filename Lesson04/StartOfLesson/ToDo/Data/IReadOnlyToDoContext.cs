using Microsoft.EntityFrameworkCore;
using System.Linq;
using ToDoApp.Models;

namespace ToDoApp.Data
{
    public interface IReadOnlyToDoContext
    {
        IQueryable<ToDo> ToDos { get; }

        IQueryable<Status> Statuses { get; }
    }
}