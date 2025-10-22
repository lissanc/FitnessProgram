using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FitnessProgram.Models;

public partial class FPContext : DbContext
{
    public FPContext()
    {
    }

    public FPContext(DbContextOptions<FPContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActiveGoal> ActiveGoals { get; set; }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<FitnessPlan> FitnessPlans { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<MuscleGroup> MuscleGroups { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:FPConnectionString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActiveGoal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ActiveGoals");

            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.GoalId)
                .ValueGeneratedOnAdd()
                .HasColumnName("goal_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("userID");
        });

        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("User_pk");

            entity.ToTable("AppUser");

            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.FitnessLevel).HasColumnName("fitnessLevel");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasMany(d => d.TrainerTrainers).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserTrainer",
                    r => r.HasOne<Trainer>().WithMany()
                        .HasForeignKey("TrainerTrainerId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("User_Trainer_Trainer"),
                    l => l.HasOne<AppUser>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("User_Trainer_User"),
                    j =>
                    {
                        j.HasKey("UserId", "TrainerTrainerId").HasName("User_Trainer_pk");
                        j.ToTable("User_Trainer");
                        j.IndexerProperty<int>("UserId").HasColumnName("userID");
                        j.IndexerProperty<int>("TrainerTrainerId").HasColumnName("Trainer_trainer_id");
                    });
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("Category_pk");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.EquipId).HasName("Equipment_pk");

            entity.Property(e => e.EquipId).HasColumnName("equip_id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.ExerciseId).HasName("Exercise_pk");

            entity.ToTable("Exercise");

            entity.Property(e => e.ExerciseId).HasColumnName("exercise_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.DifficultyLevel).HasColumnName("difficulty_level");
            entity.Property(e => e.Instructions)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("instructions");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Category).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Exercise_Category");

            entity.HasMany(d => d.Equips).WithMany(p => p.Exercises)
                .UsingEntity<Dictionary<string, object>>(
                    "ExerciseEquipment",
                    r => r.HasOne<Equipment>().WithMany()
                        .HasForeignKey("EquipId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Exercise_Equipment_Equipment"),
                    l => l.HasOne<Exercise>().WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Exercise_Equipment_Exercise"),
                    j =>
                    {
                        j.HasKey("ExerciseId", "EquipId").HasName("Exercise_Equipment_pk");
                        j.ToTable("Exercise_Equipment");
                        j.IndexerProperty<int>("ExerciseId").HasColumnName("exercise_id");
                        j.IndexerProperty<int>("EquipId").HasColumnName("equip_id");
                    });

            entity.HasMany(d => d.MuscleGroups).WithMany(p => p.Exercises)
                .UsingEntity<Dictionary<string, object>>(
                    "ExerciseMuscleGroup",
                    r => r.HasOne<MuscleGroup>().WithMany()
                        .HasForeignKey("MuscleGroupId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Exercise_MuscleGroup_MuscleGroup"),
                    l => l.HasOne<Exercise>().WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Exercise_MuscleGroup_Exercise"),
                    j =>
                    {
                        j.HasKey("ExerciseId", "MuscleGroupId").HasName("Exercise_MuscleGroup_pk");
                        j.ToTable("Exercise_MuscleGroup");
                        j.IndexerProperty<int>("ExerciseId").HasColumnName("exercise_id");
                        j.IndexerProperty<int>("MuscleGroupId").HasColumnName("muscle_group_id");
                    });
        });

        modelBuilder.Entity<FitnessPlan>(entity =>
        {
            entity.HasKey(e => e.PlanId).HasName("FitnessPlan_pk");

            entity.ToTable("FitnessPlan");

            entity.Property(e => e.PlanId).HasColumnName("plan_ID");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.DurationWeeks).HasColumnName("duration_weeks");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.TrainerId).HasColumnName("trainer_id");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.Category).WithMany(p => p.FitnessPlans)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FitnessPlan_Category");

            entity.HasOne(d => d.Trainer).WithMany(p => p.FitnessPlans)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FitnessPlan_Trainer");

            entity.HasOne(d => d.User).WithMany(p => p.FitnessPlans)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FitnessPlan_AppUser");

            entity.HasMany(d => d.Exercises).WithMany(p => p.Plans)
                .UsingEntity<Dictionary<string, object>>(
                    "PlanExercise",
                    r => r.HasOne<Exercise>().WithMany()
                        .HasForeignKey("ExerciseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Plan_Exercise_Exercise"),
                    l => l.HasOne<FitnessPlan>().WithMany()
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Plan_Exercise_FitnessPlan"),
                    j =>
                    {
                        j.HasKey("PlanId", "ExerciseId").HasName("Plan_Exercise_pk");
                        j.ToTable("Plan_Exercise");
                        j.IndexerProperty<int>("PlanId").HasColumnName("plan_ID");
                        j.IndexerProperty<int>("ExerciseId").HasColumnName("exercise_id");
                    });
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.HasKey(e => e.GoalId).HasName("Goal_pk");

            entity.ToTable("Goal");

            entity.Property(e => e.GoalId).HasColumnName("goal_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("userID");

            entity.HasOne(d => d.Category).WithMany(p => p.Goals)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Goal_Category");

            entity.HasOne(d => d.User).WithMany(p => p.Goals)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Goal_User");
        });

        modelBuilder.Entity<MuscleGroup>(entity =>
        {
            entity.HasKey(e => e.MuscleGroupId).HasName("MuscleGroup_pk");

            entity.ToTable("MuscleGroup");

            entity.Property(e => e.MuscleGroupId).HasColumnName("muscle_group_id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("Trainer_pk");

            entity.ToTable("Trainer");

            entity.Property(e => e.TrainerId).HasColumnName("trainer_id");
            entity.Property(e => e.UserId).HasColumnName("userID");
            entity.Property(e => e.Certification).HasColumnName("Certification");
            entity.Property(e => e.Specialization).HasColumnName("Specialization");
            entity.Property(e => e.YearsExperience).HasColumnName("YearsExperience");
            entity.Property(e => e.Name).HasColumnName("Name");


            entity.HasOne(d => d.User).WithMany(p => p.Trainers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Trainer_AppUser");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
