namespace ToDoList_MVVM_MAUI.Data;

public class ToDoRepository : IToDoRepository
{
    private readonly SQLiteAsyncConnection _database;

    public ToDoRepository(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<TodoItem>().Wait();
    }

    public async Task<List<TodoItem>> GetAllTodoItems()
    {
        try
        {
            return await _database.Table<TodoItem>().ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error fetching ToDo items: {e.Message}");
            return new List<TodoItem>();
        }
        
    }

    public async Task<int> AddTodoItem(TodoItem item)
    {
        try
        {
            return await _database.InsertAsync(item);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error adding Todo item: {e.Message}");
            return 0;  // Returnerar 0 om något går fel
        }
    }

    public async Task<int> UpdateTodoItem(TodoItem item)
    {
        try
        {
            return await _database.UpdateAsync(item);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error updating Todo item: {e.Message}");
            return 0;
        }
    }

    public async Task<int> DeleteTodoItem(TodoItem item)
    {
        try
        {
            return await _database.DeleteAsync(item);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error deleting Todo item: {e.Message}");
            return 0;
        }
    }
}