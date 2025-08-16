using Microsoft.EntityFrameworkCore;
using OnlineExamSystem.Models.Subjects;
using OnlineExamSystem.Models.Exams;
using OnlineExamSystem.Models.Login;
using OnlineExamSystem.Models.Questions;

namespace OnlineExamSystem.Data
{
    public class ExamDbContext : DbContext
    {
        public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<ExamSession> ExamSessions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Result { get; set; }
      

        public DbSet<LoginHistory> LoginHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExamSession>()
                .HasKey(e => e.SessionID);
            modelBuilder.Entity<Answer>()
                .HasKey(a => a.AnswerID);
            modelBuilder.Entity<Result>()
                .HasKey(r => r.ResultID);
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserID);
            modelBuilder.Entity<Roles>()
                .HasKey(r => r.RoleId);
            modelBuilder.Entity<Subject>()
                .HasKey(s => s.SubjectID);
            modelBuilder.Entity<Exam>()
                .HasKey(e => e.ExamID);
            modelBuilder.Entity<Question>()
                .HasKey(q => q.QuestionID);
            modelBuilder.Entity<Option>()
                .HasKey(o => o.OptionID);
            modelBuilder.Entity<LoginHistory>()
                .HasKey(lh => lh.LoginID);



            // User and Roles relationship
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleID)
                .OnDelete(DeleteBehavior.Restrict);

            // Subject ↔ User (CreatedBy)
            modelBuilder.Entity<Subject>()
                .HasOne(s => s.createdByUser)
                .WithMany()
                .HasForeignKey(s => s.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);


            // Exam and Subject relationship

            //modelBuilder.Entity<Exam>()
            //     .HasOne(e => e.Subject)
            //     .WithMany()
            //     .HasForeignKey(e => e.SubjectID)
            //     .OnDelete(DeleteBehavior.Restrict);


            // Exam and User (CreatedBy) relationship
            modelBuilder.Entity<Exam>()
                .HasOne(e => e.CreatedByUser)
                .WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // Option and Question relationship
            modelBuilder.Entity<Option>()
                .HasOne(o => o.Question)
                .WithMany()
                .HasForeignKey(o => o.QuestionID)
                .OnDelete(DeleteBehavior.Restrict);



           
            modelBuilder.Entity<LoginHistory>()
                .HasOne(lh => lh.User)
                .WithMany()
                .HasForeignKey(lh => lh.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Exam>()
        .HasOne(e => e.Subject)
        .WithMany(s => s.Exams)
        .HasForeignKey(e => e.SubjectID)
        .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Question>()
            .HasKey(q => q.QuestionID);

            modelBuilder.Entity<Question>()
                .HasOne(q => q.Exams)
                .WithMany()
                .HasForeignKey(q => q.ExamID)
                .OnDelete(DeleteBehavior.Restrict);

            ///

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.HasKey(a => a.AnswerID);

                entity.HasOne(a => a.Question)
                      .WithMany()
                      .HasForeignKey(a => a.QuestionID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Option)
                      .WithMany()
                      .HasForeignKey(a => a.OptionID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

         


        }

    }
}
