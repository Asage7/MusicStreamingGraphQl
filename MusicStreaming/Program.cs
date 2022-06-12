using Microsoft.EntityFrameworkCore;
using MusicStreaming.Data;
using MusicStreaming.Mutation;
using MusicStreaming.Query;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDBContext>(context => context.UseInMemoryDatabase("UsersDB"));
//builder.Services.AddDbContext<AppDBContext>(opt => opt.UseMySql(builder.Configuration.GetConnectionString("DBContext"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("TesnemContext"))));
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddTypeExtension<UserQuery>()
    .AddTypeExtension<PlaylistQuery>()
    .AddTypeExtension<MusicQuery>()
    .AddMutationType<Mutation>()
    .AddTypeExtension<MutationUser>()
    .AddTypeExtension<MutationPlaylist>()
    .AddTypeExtension<MutationMusic>()
    .AddProjections().AddFiltering().AddSorting();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapGraphQL("/graphql");

app.MapControllers();

app.Run();
