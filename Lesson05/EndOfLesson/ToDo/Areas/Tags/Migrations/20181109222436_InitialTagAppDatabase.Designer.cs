﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoApp.Areas.Tags.Data;

namespace ToDoApp.Areas.Tags.Migrations
{
    [DbContext(typeof(TagContext))]
    [Migration("20181109222436_InitialTagAppDatabase")]
    partial class InitialTagAppDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Tags")
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ToDoApp.Areas.Tags.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TenantId");

                    b.Property<string>("Value")
                        .IsRequired();

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("TenantId", "Value")
                        .IsUnique()
                        .HasName("IX_Tag_TenantId_Value");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ToDoApp.Areas.Tags.Models.Tenant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("IX_Tenant_Name");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("ToDoApp.Areas.Tags.Models.Tag", b =>
                {
                    b.HasOne("ToDoApp.Areas.Tags.Models.Tenant", "Tenant")
                        .WithMany("Tags")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
