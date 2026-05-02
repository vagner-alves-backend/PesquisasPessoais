using Terminal.Gui.App;
using Terminal.Gui.Views;

using var app = Application.Create();

app.Init();
var win = new Window() {Title = "Titulo"};
app.Run(win);

