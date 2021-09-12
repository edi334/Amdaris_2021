﻿// <auto-generated />
using System;
using F1Management.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace F1Management.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210912121804_ConfigUpdates")]
    partial class ConfigUpdates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("F1Management.Core.GrandPrix", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CircuitName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GrandPrix");
                });

            modelBuilder.Entity("F1Management.Core.Models.Car.Chassis", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BodyWork")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FrontWing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RaceCarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RearWing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Wear")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("RaceCarId")
                        .IsUnique();

                    b.ToTable("Chassis");
                });

            modelBuilder.Entity("F1Management.Core.Models.Car.Engine", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<Guid>("RaceCarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Wear")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("RaceCarId")
                        .IsUnique();

                    b.ToTable("Engines");
                });

            modelBuilder.Entity("F1Management.Core.Models.Car.Gearbox", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("GearCount")
                        .HasColumnType("int");

                    b.Property<Guid>("RaceCarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Wear")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("RaceCarId")
                        .IsUnique();

                    b.ToTable("Gearboxes");
                });

            modelBuilder.Entity("F1Management.Core.Models.Car.RaceCar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Strategy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RaceCars");
                });

            modelBuilder.Entity("F1Management.Core.Models.Car.TireSet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FrontLeftWear")
                        .HasColumnType("int");

                    b.Property<int>("FrontRightWear")
                        .HasColumnType("int");

                    b.Property<Guid>("RaceCarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RearLeftWear")
                        .HasColumnType("int");

                    b.Property<int>("RearRightWear")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RaceCarId")
                        .IsUnique();

                    b.ToTable("TireSets");
                });

            modelBuilder.Entity("F1Management.Core.Models.CarSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("FastestLap")
                        .HasColumnType("time");

                    b.Property<Guid>("GrandPrixId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<Guid>("RaceCarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SessionType")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GrandPrixId");

                    b.HasIndex("RaceCarId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("F1Management.Core.Models.Identity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("F1Management.Core.Models.Identity.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEmailVerified")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("F1Management.Core.Models.Identity.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("F1Management.Core.Models.PitStop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarSessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("NewTiresId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OldTiresId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("StationaryTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("CarSessionId");

                    b.HasIndex("NewTiresId")
                        .IsUnique();

                    b.HasIndex("OldTiresId")
                        .IsUnique();

                    b.ToTable("PitStops");
                });

            modelBuilder.Entity("F1Management.Core.Models.TeamMembers.CarMechanic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("CarMechanics");
                });

            modelBuilder.Entity("F1Management.Core.Models.TeamMembers.Driver", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<Guid>("RaceCarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RaceCarId")
                        .IsUnique();

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("F1Management.Core.Models.TeamMembers.PitStopCrew", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TeamId")
                        .IsUnique();

                    b.ToTable("PitStopCrews");
                });

            modelBuilder.Entity("F1Management.Core.Models.TeamMembers.PitStopMechanic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PitStopCrewId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PitStopCrewId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("PitStopMechanics");
                });

            modelBuilder.Entity("F1Management.Core.Models.TeamMembers.RaceEngineer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DriverId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TeamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("DriverId")
                        .IsUnique();

                    b.HasIndex("TeamId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("RaceEngineers");
                });

            modelBuilder.Entity("F1Management.Core.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("F1Management.Core.Models.Car.Chassis", b =>
                {
                    b.HasOne("F1Management.Core.Models.Car.RaceCar", "RaceCar")
                        .WithOne("Chassis")
                        .HasForeignKey("F1Management.Core.Models.Car.Chassis", "RaceCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RaceCar");
                });

            modelBuilder.Entity("F1Management.Core.Models.Car.Engine", b =>
                {
                    b.HasOne("F1Management.Core.Models.Car.RaceCar", "RaceCar")
                        .WithOne("Engine")
                        .HasForeignKey("F1Management.Core.Models.Car.Engine", "RaceCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RaceCar");
                });

            modelBuilder.Entity("F1Management.Core.Models.Car.Gearbox", b =>
                {
                    b.HasOne("F1Management.Core.Models.Car.RaceCar", "RaceCar")
                        .WithOne("Gearbox")
                        .HasForeignKey("F1Management.Core.Models.Car.Gearbox", "RaceCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RaceCar");
                });

            modelBuilder.Entity("F1Management.Core.Models.Car.TireSet", b =>
                {
                    b.HasOne("F1Management.Core.Models.Car.RaceCar", "RaceCar")
                        .WithOne("TireSet")
                        .HasForeignKey("F1Management.Core.Models.Car.TireSet", "RaceCarId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("RaceCar");
                });

            modelBuilder.Entity("F1Management.Core.Models.CarSession", b =>
                {
                    b.HasOne("F1Management.Core.GrandPrix", "GrandPrix")
                        .WithMany("CarSessions")
                        .HasForeignKey("GrandPrixId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("F1Management.Core.Models.Car.RaceCar", "RaceCar")
                        .WithMany("CarSessions")
                        .HasForeignKey("RaceCarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrandPrix");

                    b.Navigation("RaceCar");
                });

            modelBuilder.Entity("F1Management.Core.Models.Identity.UserRole", b =>
                {
                    b.HasOne("F1Management.Core.Models.Identity.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("F1Management.Core.Models.Identity.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("F1Management.Core.Models.PitStop", b =>
                {
                    b.HasOne("F1Management.Core.Models.CarSession", "Session")
                        .WithMany("PitStops")
                        .HasForeignKey("CarSessionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("F1Management.Core.Models.Car.TireSet", "NewTires")
                        .WithOne()
                        .HasForeignKey("F1Management.Core.Models.PitStop", "NewTiresId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("F1Management.Core.Models.Car.TireSet", "OldTires")
                        .WithOne()
                        .HasForeignKey("F1Management.Core.Models.PitStop", "OldTiresId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("NewTires");

                    b.Navigation("OldTires");

                    b.Navigation("Session");
                });

            modelBuilder.Entity("F1Management.Core.Models.TeamMembers.CarMechanic", b =>
                {
                    b.HasOne("F1Management.Core.Team", "Team")
                        .WithMany("CarMechanics")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("F1Management.Core.Models.Identity.User", "User")
                        .WithOne()
                        .HasForeignKey("F1Management.Core.Models.TeamMembers.CarMechanic", "UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Team");

                    b.Navigation("User");
                });

            modelBuilder.Entity("F1Management.Core.Models.TeamMembers.Driver", b =>
                {
                    b.HasOne("F1Management.Core.Models.Car.RaceCar", "RaceCar")
                        .WithOne("Driver")
                        .HasForeignKey("F1Management.Core.Models.TeamMembers.Driver", "RaceCarId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("F1Management.Core.Team", "Team")
                        .WithMany("Drivers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("F1Management.Core.Models.Identity.User", "User")
                        .WithOne()
                        .HasForeignKey("F1Management.Core.Models.TeamMembers.Driver", "UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("RaceCar");

                    b.Navigation("Team");

                    b.Navigation("User");
                });

            modelBuilder.Entity("F1Management.Core.Models.TeamMembers.PitStopCrew", b =>
                {
                    b.HasOne("F1Management.Core.Team", "Team")
                        .WithOne("PitStopCrew")
                        .HasForeignKey("F1Management.Core.Models.TeamMembers.PitStopCrew", "TeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("F1Management.Core.Models.TeamMembers.PitStopMechanic", b =>
                {
                    b.HasOne("F1Management.Core.Models.TeamMembers.PitStopCrew", "PitStopCrew")
                        .WithMany("PitStopMechanics")
                        .HasForeignKey("PitStopCrewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("F1Management.Core.Models.Identity.User", "User")
                        .WithOne()
                        .HasForeignKey("F1Management.Core.Models.TeamMembers.PitStopMechanic", "UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("PitStopCrew");

                    b.Navigation("User");
                });

            modelBuilder.Entity("F1Management.Core.Models.TeamMembers.RaceEngineer", b =>
                {
                    b.HasOne("F1Management.Core.Models.TeamMembers.Driver", "Driver")
                        .WithOne("RaceEngineer")
                        .HasForeignKey("F1Management.Core.Models.TeamMembers.RaceEngineer", "DriverId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("F1Management.Core.Team", "Team")
                        .WithMany("RaceEngineers")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("F1Management.Core.Models.Identity.User", "User")
                        .WithOne()
                        .HasForeignKey("F1Management.Core.Models.TeamMembers.RaceEngineer", "UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Team");

                    b.Navigation("User");
                });

            modelBuilder.Entity("F1Management.Core.GrandPrix", b =>
                {
                    b.Navigation("CarSessions");
                });

            modelBuilder.Entity("F1Management.Core.Models.Car.RaceCar", b =>
                {
                    b.Navigation("CarSessions");

                    b.Navigation("Chassis");

                    b.Navigation("Driver");

                    b.Navigation("Engine");

                    b.Navigation("Gearbox");

                    b.Navigation("TireSet");
                });

            modelBuilder.Entity("F1Management.Core.Models.CarSession", b =>
                {
                    b.Navigation("PitStops");
                });

            modelBuilder.Entity("F1Management.Core.Models.Identity.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("F1Management.Core.Models.Identity.User", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("F1Management.Core.Models.TeamMembers.Driver", b =>
                {
                    b.Navigation("RaceEngineer");
                });

            modelBuilder.Entity("F1Management.Core.Models.TeamMembers.PitStopCrew", b =>
                {
                    b.Navigation("PitStopMechanics");
                });

            modelBuilder.Entity("F1Management.Core.Team", b =>
                {
                    b.Navigation("CarMechanics");

                    b.Navigation("Drivers");

                    b.Navigation("PitStopCrew");

                    b.Navigation("RaceEngineers");
                });
#pragma warning restore 612, 618
        }
    }
}
