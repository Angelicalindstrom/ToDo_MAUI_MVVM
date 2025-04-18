namespace ToDoList_MVVM_MAUI.Models;
public class TodoItem
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public bool IsCompleted { get; set; }
}
