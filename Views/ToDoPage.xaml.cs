namespace ToDoList_MVVM_MAUI.Views;
public partial class ToDoPage
{
    public ToDoPage(TodoViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
    }
}