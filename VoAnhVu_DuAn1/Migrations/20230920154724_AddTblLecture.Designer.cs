﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VoAnhVu_DuAn1.Model;

namespace VoAnhVu_DuAn1.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230920154724_AddTblLecture")]
    partial class AddTblLecture
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VoAnhVu_DuAn1.Entity.EnrollmentEntity", b =>
                {
                    b.Property<string>("EnrollmentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SubjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("VoAnhVu_DuAn1.Entity.HelpEntity", b =>
                {
                    b.Property<string>("HelpId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HelpId");

                    b.ToTable("Help");
                });

            modelBuilder.Entity("VoAnhVu_DuAn1.Entity.LectureEntity", b =>
                {
                    b.Property<string>("LectureId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FileUpload")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LectureId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Lecture");
                });

            modelBuilder.Entity("VoAnhVu_DuAn1.Entity.RoleEntity", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Decription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("VoAnhVu_DuAn1.Entity.SubjectEntity", b =>
                {
                    b.Property<string>("SubjectId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SubjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("VoAnhVu_DuAn1.Entity.UserEntity", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("VoAnhVu_DuAn1.Entity.EnrollmentEntity", b =>
                {
                    b.HasOne("VoAnhVu_DuAn1.Entity.SubjectEntity", "Subject")
                        .WithMany("Enrollments")
                        .HasForeignKey("SubjectId");

                    b.HasOne("VoAnhVu_DuAn1.Entity.UserEntity", "User")
                        .WithMany("Enrollments")
                        .HasForeignKey("UserId");

                    b.Navigation("Subject");

                    b.Navigation("User");
                });

            modelBuilder.Entity("VoAnhVu_DuAn1.Entity.LectureEntity", b =>
                {
                    b.HasOne("VoAnhVu_DuAn1.Entity.SubjectEntity", "Subject")
                        .WithMany("Lectures")
                        .HasForeignKey("SubjectId");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("VoAnhVu_DuAn1.Entity.UserEntity", b =>
                {
                    b.HasOne("VoAnhVu_DuAn1.Entity.RoleEntity", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("VoAnhVu_DuAn1.Entity.RoleEntity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("VoAnhVu_DuAn1.Entity.SubjectEntity", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("Lectures");
                });

            modelBuilder.Entity("VoAnhVu_DuAn1.Entity.UserEntity", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
