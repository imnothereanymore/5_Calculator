﻿// <auto-generated />
using _5_Calculator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace _5_Calculator.Migrations
{
    [DbContext(typeof(CalculatorContext))]
    [Migration("20241126085844_m_init")]
    partial class m_init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("_5_Calculator.Data.DataInputVariant", b =>
                {
                    b.Property<int>("ID_DataInputVariant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Operand_1")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Operand_2")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Result")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Type_operation")
                        .HasColumnType("varchar(128)");

                    b.HasKey("ID_DataInputVariant");

                    b.ToTable("DataInputVariants");
                });
#pragma warning restore 612, 618
        }
    }
}
