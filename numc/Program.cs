using MySql.Data.MySqlClient;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();





app.UseStaticFiles();

app.MapGet("/", () =>
{
    Database db = new Database();

    var dados = db.LerDados("Alunos");

    return string.Join("\n", dados);
});

app.Run();
