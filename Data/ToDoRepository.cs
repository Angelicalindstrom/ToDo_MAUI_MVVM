namespace ToDoList_MVVM_MAUI.Data;

public class ToDoRepository : IToDoRepository
{
    private readonly SQLiteAsyncConnection _database;

    public ToDoRepository(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<TodoItem>().Wait();
    }

    public ToDoRepository() : this(Path.Combine(FileSystem.AppDataDirectory, "todos.db"))
    {
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
            int rowsAffected = await _database.UpdateAsync(item);
            Console.WriteLine($"SQLite: Uppdaterade {rowsAffected} rader i databasen.");
            return rowsAffected; // Om 0, så sparades inget
        }
        catch (Exception e)
        {
            Console.WriteLine($"❌ Fel vid uppdatering: {e.Message}");
            return 0;
        }
    }

    public Task<int> DeleteTodoItem(TodoItem item)
    {
        throw new NotImplementedException();
    }
}