namespace ToDoList_MVVM_MAUI.ViewModels
{
    public class TodoViewModel : BaseViewModel
    {
        private readonly IToDoRepository _repository;
        private readonly INavigationService _navigationService;

        public ObservableCollection<TodoItemViewModel> TodoItems { get; set; }
        public ICommand AddTodoCommand { get; }
        public ICommand NavigateToMainPageCommand { get; }

        private string _title;
        
        
        // Standardkonstruktor (utan beroenden för XAML)
        public TodoViewModel()
        {
            TodoItems = new ObservableCollection<TodoItemViewModel>();
            AddTodoCommand = new Command(async () => await AddTodoItem());
            NavigateToMainPageCommand = new Command(async () => await NavigateToMainPage());
        }

        // Konstruktor med dependency injection
        public TodoViewModel(IToDoRepository repository, INavigationService navigationService) : this()
        {
            _repository = repository;
            _navigationService = navigationService;
            _ = LoadTodos();
        }
        
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        // Lägg till en ny Todo
        private async Task AddTodoItem()
        {
            if (string.IsNullOrWhiteSpace(Title)) return;

            var newItem = new TodoItem { Title = Title, IsCompleted = false };
            await _repository.AddTodoItem(newItem);
            TodoItems.Add(new TodoItemViewModel(newItem, _repository));

            Title = string.Empty;
        }

        // Hämta alla Todos
        private async Task LoadTodos()
        {
            TodoItems.Clear();
            var items = await _repository.GetAllTodoItems();

            foreach (var item in items)
            {
                TodoItems.Add(new TodoItemViewModel(item, _repository));
            }
        }

        // Navigera till MainPage
        private async Task NavigateToMainPage()
        {
            await _navigationService.NavigateToAsync("//MainPage");
        }
    }
}
