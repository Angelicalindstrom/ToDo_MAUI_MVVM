namespace ToDoList_MVVM_MAUI.Data;

public interface IToDoRepository
{
    // Interface to easy change databaseImplement whithout changing code in the rest of th app and easier tp test
    Task<List<TodoItem>> GetAllTodoItems();
    Task<int> AddTodoItem(TodoItem item); 
    Task<int> UpdateTodoItem(TodoItem item); 
    Task<int> DeleteTodoItem(TodoItem item);
}