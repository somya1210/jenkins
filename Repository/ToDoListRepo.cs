using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListWebApi.Data;
using ToDoListWebApi.Model;

namespace ToDoListWebApi.Repository
{
    public class ToDoListRepo : ITodListRepo
    {
        private readonly ToDoListContext _context;
        public ToDoListRepo(ToDoListContext context)
        {
            _context = context;
        }


        public async Task<List<ToDoModel>> GetAllBookAsync()
        {
            // write the logic to fetch from the database
            //return the type book to bookmodel
            var records = await _context.TaskTable.Select(x => new ToDoModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                IsCompleted = x.IsCompleted,
                DueDate = x.DueDate
            }).ToListAsync();

            return records;
        }
        public async Task<List<ToDoModel>> GetAllBookSortedByDateAsync()
        {
            var records = await _context.TaskTable.Select(x => new ToDoModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                IsCompleted = x.IsCompleted,
                DueDate = x.DueDate
            }).OrderBy(x => x.DueDate).ToListAsync();
            return records;
        }


        public async Task<ToDoModel> GetBookByIdAsync(int id)
        {// all logic can be added in wherer
            var searched_book = await _context.TaskTable.Where(x => x.Id == id).Select(x => new ToDoModel()
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                IsCompleted = x.IsCompleted,
                DueDate = x.DueDate
            }).FirstOrDefaultAsync();
            return searched_book;
        }

        public async Task<int> AddBookAsync(ToDoModel todomodel)
        { // since database does not knw about bookmodel ,it works on books database , so convert to type books
            var book = new ToDo()
            {
                Id = todomodel.Id,
                Title = todomodel.Title,
                Description = todomodel.Description,
                IsCompleted = todomodel.IsCompleted,
                DueDate = todomodel.DueDate


            };
            _context.TaskTable.Add(book);
            // tomake changes to the database we need to save changees
            await _context.SaveChangesAsync();
            return book.Id;
        }


        public async Task<int> UpdateBookAsync(int TaskId, ToDoModel todomodel)
        { // since database does not knw about bookmodel ,it works on books database , so convert to type books
            var task = await _context.TaskTable.FindAsync(TaskId);
            if (task != null)
            {

                task.Id = todomodel.Id;
                task.Title = todomodel.Title;
                task.Description = todomodel.Description;
                task.IsCompleted = todomodel.IsCompleted;
                task.DueDate = todomodel.DueDate;
                await _context.SaveChangesAsync();
            }

            // _context.BooksTable.Add(book);
            // tomake changes to the database we need to save changees
            //await _context.SaveChangesAsync();
            return task.Id;
        }


        public async Task DeleteBookAsync(int id)
        {
            var task = await _context.TaskTable.FindAsync(id);
            _context.TaskTable.Remove(task);
           await _context.SaveChangesAsync();
        }
    }
}
