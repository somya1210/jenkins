using Microsoft.EntityFrameworkCore;

namespace ToDoListWebApi.Data
{
    public class ToDoListContext:DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        { 
        }
        public DbSet<ToDo> TaskTable { get; set; }
    }
}
