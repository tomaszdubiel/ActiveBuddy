using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SquashLeague.Models;

namespace SquashLeague.Migrations
{
    [DbContext(typeof(SquashContext))]
    [Migration("20161025192649_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SquashLeague.Models.Stop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Arrival");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<int?>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("Stops");
                });

            modelBuilder.Entity("SquashLeague.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCreated");

                    b.Property<string>("Name");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("SquashLeague.Models.Stop", b =>
                {
                    b.HasOne("SquashLeague.Models.Trip")
                        .WithMany("Stops")
                        .HasForeignKey("TripId");
                });
        }
    }
}
