namespace ToDoList_MVVM_MAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        // Register Services for Dependency Injection
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "todos.db");
        builder.Services.AddSingleton<IToDoRepository>(s => new ToDoRepository(dbPath));

        // Register ViewModels
        builder.Services.AddTransient<TodoViewModel>();

        // Register Views
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<ToDoPage>();

        return builder.Build();
    }
}
