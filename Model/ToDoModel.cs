using System.ComponentModel.DataAnnotations;

namespace ToDoListWebApi.Model
{
   /* public enum Priority
    {
        High,
        Medium,
        Low 
    }
    public class Category
    {
        public string Title;
    }
   */
    public class ToDoModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
      //  public Priority priority { get; set; }
        //public Category category { get; set; }
    }
}
