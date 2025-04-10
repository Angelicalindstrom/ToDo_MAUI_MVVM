namespace ToDoList_MVVM_MAUI.ViewModels;
public class TodoItemViewModel : BaseViewModel
{
    private readonly IToDoRepository _repository;
    private readonly TodoItem _todoItem;

    public ICommand ToggleCommand { get; }
    public string Title => _todoItem.Title;

    private bool _isCompleted;
    public bool IsCompleted
    {
        get => _isCompleted;
        set
        {
            if (_isCompleted != value)
            {
                _isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
                _ = SaveChanges();
            }
        }
    }
    
    public TodoItemViewModel(TodoItem todoItem, IToDoRepository repository)
    {
        _todoItem = todoItem;
        _repository = repository;
        _isCompleted = todoItem.IsCompleted;

        ToggleCommand = new Command(async () => await ToggleIsCompleted());
    }

    // TOGGLE change, Save
    private async Task ToggleIsCompleted()
    {
        IsCompleted = !IsCompleted;
        await SaveChanges();
    }

    // Save Update
    private async Task SaveChanges()
    {
        _todoItem.IsCompleted = IsCompleted;
        await _repository.UpdateTodoItem(_todoItem);
    }
}
