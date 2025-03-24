using System.Collections.ObjectModel;
using System.Windows.Input;
using ToDoList_MVVM_MAUI.Services;

namespace ToDoList_MVVM_MAUI.ViewModels;

public class TodoViewModel : BaseViewModel
{
    private readonly IToDoRepository _repository;
    
    public ObservableCollection<TodoItem> TodoItems { get; set; }
    public ICommand AddTodoCommand { get; }

    
    public TodoViewModel(IToDoRepository repository)
    {
        _repository = repository;
        TodoItems = new ObservableCollection<TodoItem>();

        _ = LoadTodos();
        AddTodoCommand = new Command<string>(async void (title) => await AddTodoItem(title));
    }

    // Add NewTodoItem
    private async Task AddTodoItem(string title)
    {
        if (string.IsNullOrWhiteSpace(title)) return;

        try
        {
            var newItem = new TodoItem { Title = title, IsCompleted = false };
            await _repository.AddTodoItem(newItem);
            await LoadTodos();  // LoadAll
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding todo: {ex.Message}");
        }
    }

    // Load All from Db
    private async Task LoadTodos()
    {
        try
        {
            TodoItems.Clear();
            var items = await _repository.GetAllTodoItems();
            foreach (var item in items)
            {
                TodoItems.Add(item);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading todos: {ex.Message}");
        }
    }
    
    
}