namespace ToDoList_MVVM_MAUI.Services;
 
public interface INavigationService
{
    Task NavigateToAsync(string route);
    Task GoBackAsync();
}