using Microsoft.EntityFrameworkCore;
using OnlineExamSystem.Business_Logic;
using OnlineExamSystem.Business_Logic.Interfaces;
using OnlineExamSystem.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ExamDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<IExamRepository, ExamRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IOptionService, OptionService>();
//builder.Services.AddScoped<IExamSessionRepository, ExamSessionRepository>();
//builder.Services.AddScoped<IExamSessionService, ExamSessionService>();
builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<AnswerService>();
builder.Services.AddScoped<IResultRepository, ResultRepository>();
builder.Services.AddScoped<IResultService, ResultService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();




app.Run();
