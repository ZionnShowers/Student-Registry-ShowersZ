//Zionn Showers
//9-15-2026
//Student Registry
/*First, I declared multiple integers in public classes. I then created a short list of students. I created a function that reads all of the
students and their info with GetAllMembers. A single student can be read with getmember/{id}. You can create a student using the Create
function and putting in the info required. You can also update an existing student with the Update function. Lastly, I added the ability to
delete a student using the Delete function.*/
//Peer Review:
/**/
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
