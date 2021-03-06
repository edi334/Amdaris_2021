// <auto-generated />
using Assignment.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Assignment.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Capital")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capital = "Bucharest",
                            Name = "Romania",
                            Population = 20000
                        },
                        new
                        {
                            Id = 2,
                            Capital = "Budapest",
                            Name = "Hungary",
                            Population = 10000
                        },
                        new
                        {
                            Id = 3,
                            Capital = "Paris",
                            Name = "France",
                            Population = 50000
                        });
                });

            modelBuilder.Entity("Assignment.Models.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId")
                        .IsUnique();

                    b.ToTable("Participants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Email = "andrei.popescu@gmail.com",
                            FirstName = "Andrei",
                            LastName = "Popescu"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 3,
                            Email = "jean.monet@gmail.com",
                            FirstName = "Jean",
                            LastName = "Monet"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 2,
                            Email = "istvan.seres@gmail.com",
                            FirstName = "Istvan",
                            LastName = "Seres"
                        });
                });

            modelBuilder.Entity("Assignment.Models.Workshop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Theme")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Workshops");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Breakdance Workshop",
                            ShortDescription = "We will learn to breakdance!",
                            Theme = "Dancing"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Painting Workshop",
                            ShortDescription = "We will learn to paint!",
                            Theme = "Painting"
                        });
                });

            modelBuilder.Entity("Assignment.Models.WorkshopParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("WorkshopId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("WorkshopId");

                    b.ToTable("WorkshopParticipants");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ParticipantId = 1,
                            WorkshopId = 1
                        },
                        new
                        {
                            Id = 2,
                            ParticipantId = 1,
                            WorkshopId = 2
                        },
                        new
                        {
                            Id = 3,
                            ParticipantId = 2,
                            WorkshopId = 1
                        },
                        new
                        {
                            Id = 4,
                            ParticipantId = 3,
                            WorkshopId = 1
                        });
                });

            modelBuilder.Entity("Assignment.Models.Participant", b =>
                {
                    b.HasOne("Assignment.Models.Country", "Country")
                        .WithOne("Participant")
                        .HasForeignKey("Assignment.Models.Participant", "CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Assignment.Models.WorkshopParticipant", b =>
                {
                    b.HasOne("Assignment.Models.Participant", "Participant")
                        .WithMany("WorkshopParticipants")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment.Models.Workshop", "Workshop")
                        .WithMany("WorkshopParticipants")
                        .HasForeignKey("WorkshopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Participant");

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("Assignment.Models.Country", b =>
                {
                    b.Navigation("Participant");
                });

            modelBuilder.Entity("Assignment.Models.Participant", b =>
                {
                    b.Navigation("WorkshopParticipants");
                });

            modelBuilder.Entity("Assignment.Models.Workshop", b =>
                {
                    b.Navigation("WorkshopParticipants");
                });
#pragma warning restore 612, 618
        }
    }
}
