﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OneLinkTest.Infrastructure.DataAccess;

namespace OneLinkTest.Infrastructure.DataAccess.Migrations
{
    [DbContext(typeof(OneLinkTestContext))]
    partial class OneLinkTestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OneLinkTest.Domain.Areas.Area", b =>
                {
                    b.Property<int>("AreaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AreaId");

                    b.ToTable("Areas");

                    b.HasData(
                        new
                        {
                            AreaId = 1,
                            Name = "Comercialización"
                        },
                        new
                        {
                            AreaId = 2,
                            Name = "Administración"
                        },
                        new
                        {
                            AreaId = 3,
                            Name = "Administración del Personal"
                        });
                });

            modelBuilder.Entity("OneLinkTest.Domain.Areas.Subareas.Subarea", b =>
                {
                    b.Property<int>("SubareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubareaId");

                    b.HasIndex("AreaId");

                    b.ToTable("Subareas");

                    b.HasData(
                        new
                        {
                            SubareaId = 1,
                            AreaId = 1,
                            Name = "Investigación de mercado"
                        },
                        new
                        {
                            SubareaId = 2,
                            AreaId = 1,
                            Name = "Publicidad"
                        },
                        new
                        {
                            SubareaId = 3,
                            AreaId = 1,
                            Name = "Promoción"
                        },
                        new
                        {
                            SubareaId = 4,
                            AreaId = 1,
                            Name = "Ventas"
                        },
                        new
                        {
                            SubareaId = 5,
                            AreaId = 1,
                            Name = "Distribución"
                        },
                        new
                        {
                            SubareaId = 6,
                            AreaId = 2,
                            Name = "Finanzas"
                        },
                        new
                        {
                            SubareaId = 7,
                            AreaId = 2,
                            Name = "Control"
                        },
                        new
                        {
                            SubareaId = 8,
                            AreaId = 3,
                            Name = "Selección y distribución"
                        },
                        new
                        {
                            SubareaId = 9,
                            AreaId = 3,
                            Name = "Relaciones Industriales"
                        },
                        new
                        {
                            SubareaId = 10,
                            AreaId = 3,
                            Name = "Servicios Sociales"
                        });
                });

            modelBuilder.Entity("OneLinkTest.Domain.Employees.Employee", b =>
                {
                    b.Property<long>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Document")
                        .HasColumnType("bigint");

                    b.Property<int>("DocumentType")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubareaId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("SubareaId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1L,
                            Document = 1040049214L,
                            DocumentType = 1,
                            FirstName = "Cristian",
                            LastName = "García",
                            SubareaId = 7
                        });
                });

            modelBuilder.Entity("OneLinkTest.Domain.Areas.Subareas.Subarea", b =>
                {
                    b.HasOne("OneLinkTest.Domain.Areas.Area", "Area")
                        .WithMany("Subareas")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OneLinkTest.Domain.Employees.Employee", b =>
                {
                    b.HasOne("OneLinkTest.Domain.Areas.Subareas.Subarea", "Subarea")
                        .WithMany("Employees")
                        .HasForeignKey("SubareaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
