using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoAnhVu_DuAn1.Model;
using VoAnhVu_DuAn1.Repository;
using VoAnhVu_DuAn1.Service;

namespace VoAnhVu_DuAn1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VoAnhVu_DuAn1 (Learning Management System)", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                    });
            });
           
            services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
            
            services.AddDbContext<MyDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<IClassService, ClassService>();

            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();

            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<ISubjectService, SubjectService>();

            services.AddScoped<IHelpRepository, HelpRepository>();
            services.AddScoped<IHelpService, HelpService>();

            services.AddScoped<ILectureRepository, LectureRepository>();
            services.AddScoped<ILectureService, LectureService>();

            services.AddScoped<ITopicRepository, TopicRepository>();
            services.AddScoped<ITopicService, TopicService>();

            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionService, QuestionService>();

            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IAnswerService, AnswerService>();

            services.AddScoped<IQuestionBankRepository, QuestionBankRepository>();
            services.AddScoped<IQuestionBankService, QuestionBankService>();

            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IExamService, ExamService>();

            services.AddScoped<IQuestionsRepository, QuestionsRepository>();
            services.AddScoped<IQuestionsService, QuestionsService>();

            services.AddScoped<IQuestionExamRepository, QuestionExamRepository>();
            services.AddScoped<IQuestionExamService, QuestionExamService>();

            services.AddScoped<IExamResultRepository, ExamResultRepository>();
            services.AddScoped<IExamResultService, ExamResultService>();

            services.AddScoped<AuthenticationService>();

            services.Configure<AppSetting>(Configuration.GetSection("AppSettings"));

            var secretKey = Configuration["AppSettings:SecretKey"];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    //Tự cấp token
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    //Ký vào token
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),

                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("StudentPolicy", policy => policy.RequireRole("Sinh viên"));
                options.AddPolicy("TeacherPolicy", policy => policy.RequireRole("Giáo viên"));
                options.AddPolicy("LeaderShipPolicy", policy => policy.RequireRole("Lãnh đạo"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VoAnhVu_DuAn1 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
