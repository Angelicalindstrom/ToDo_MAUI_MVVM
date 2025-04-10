namespace ToDoList_MVVM_MAUI.Views;
public partial class ToDoPage : ContentPage
{
    public ToDoPage(TodoViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}