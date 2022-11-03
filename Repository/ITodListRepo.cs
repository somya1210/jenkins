using ToDoListWebApi.Model;

namespace ToDoListWebApi.Repository
{
    public interface ITodListRepo
    {
        Task<List<ToDoModel>> GetAllBookAsync();
      Task<ToDoModel> GetBookByIdAsync(int id);
        Task<int> AddBookAsync(ToDoModel todomodel);
        Task<int> UpdateBookAsync(int TaskId, ToDoModel todomodel);
        Task DeleteBookAsync(int TaskId);
        Task<List<ToDoModel>> GetAllBookSortedByDateAsync();
    }
}
