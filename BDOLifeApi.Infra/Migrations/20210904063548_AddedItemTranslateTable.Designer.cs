﻿// <auto-generated />
using System;
using BDOLife.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BDOLife.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210904063548_AddedItemTranslateTable")]
    partial class AddedItemTranslateTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BDOLife.Core.Entities.ItemBase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BDOReference")
                        .HasColumnType("varchar(30)");

                    b.Property<int?>("Cooldown")
                        .HasColumnType("int");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Effect")
                        .HasColumnType("varchar(250)");

                    b.Property<int?>("EffectDuration")
                        .HasColumnType("int");

                    b.Property<Guid?>("MaterialGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(250)");

                    b.Property<int>("Tier")
                        .HasColumnType("int");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("MaterialGroupId");

                    b.ToTable("Itens");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ItemBase");
                });

            modelBuilder.Entity("BDOLife.Core.Entities.ItemTranslate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NameTranslated")
                        .HasColumnType("varchar(250)");

                    b.Property<Guid>("ServerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("ServerId");

                    b.ToTable("ItemTranslate");
                });

            modelBuilder.Entity("BDOLife.Core.Entities.MasteryAlchemy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ChanceRare")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("ChanceRegular")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("ChanceSpecial")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("ImperialBonus")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("Mastery")
                        .HasColumnType("int");

                    b.Property<decimal>("MaxProcChance")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("RareProc")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("RegularProc")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.ToTable("MasteryAlchemy");
                });

            modelBuilder.Entity("BDOLife.Core.Entities.MasteryCooking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CraftForDurability")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("ImperialBonus")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("Mastery")
                        .HasColumnType("int");

                    b.Property<decimal>("RareMaxProcChance")
                        .HasColumnType("decimal(5,4)");

                    b.Property<decimal>("RareProc")
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("RegularMaxProcChance")
                        .HasColumnType("decimal(5,4)");

                    b.Property<decimal>("RegularProc")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.ToTable("MasteryCooking");
                });

            modelBuilder.Entity("BDOLife.Core.Entities.MasteryProcess", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Batch")
                        .HasColumnType("int");

                    b.Property<int>("Mastery")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MasteryProcess");
                });

            modelBuilder.Entity("BDOLife.Core.Entities.MaterialGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("MaterialGroups");
                });

            modelBuilder.Entity("BDOLife.Core.Entities.Price", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<long>("InStock")
                        .HasColumnType("bigint");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ServerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Value")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("ServerId");

                    b.ToTable("Prices");
                });

            modelBuilder.Entity("BDOLife.Core.Entities.SellNPC", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Localization")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("NightTime")
                        .HasColumnType("bit");

                    b.Property<string>("NightTimeHour")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("SellNPCs");
                });

            modelBuilder.Entity("BDOLife.Core.Entities.SellNPCItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("AmityRequired")
                        .HasColumnType("bit");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<Guid>("SellNPCId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("SellNPCId");

                    b.ToTable("SellNPCsItens");
                });

            modelBuilder.Entity("BDOLife.Core.Entities.Server", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Language")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("MarketUrl")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(250)");

                    b.Property<string>("RequestVerificationToken")
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("BDOLife.Core.Entities.Item", b =>
                {
                    b.HasBaseType("BDOLife.Core.Entities.ItemBase");

                    b.HasDiscriminator().HasValue("Item");
                });

            modelBuilder.Entity("BDOLife.Core.Entities.Recipe", b =>
                {
                    b.HasBaseType("BDOLife.Core.Entities.ItemBase");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)");

                    b.Property<int>("EXP")
                        .HasColumnType("int");

                    b.Property<Guid?>("Material1Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Material2Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Material3Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Material4Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Material5Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MaterialGroup1Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MaterialGroup2Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MaterialGroup3Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MaterialGroup4Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("MaterialGroup5Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Product1Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Product2Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("QtdMaterial1")
                        .HasColumnType("int");

                    b.Property<int?>("QtdMaterial2")
                        .HasColumnType("int");

                    b.Property<int?>("QtdMaterial3")
                        .HasColumnType("int");

                    b.Property<int?>("QtdMaterial4")
                        .HasColumnType("int");

                    b.Property<int?>("QtdMaterial5")
                        .HasColumnType("int");

                    b.Property<decimal?>("QtdProduct1")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("QtdProduct2")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SkillLevel")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasIndex("Material1Id");

                    b.HasIndex("Material2Id");

                    b.HasIndex("Material3Id");

                    b.HasIndex("Material4Id");

                    b.HasIndex("Material5Id");

                    b.HasIndex("MaterialGroup1Id");

                    b.HasIndex("MaterialGroup2Id");

                    b.HasIndex("MaterialGroup3Id");

                    b.HasIndex("MaterialGroup4Id");

                    b.HasIndex("MaterialGroup5Id");

                    b.HasIndex("Product1Id");

                    b.HasIndex("Product2Id");

                    b.HasDiscriminator().HasValue("Recipe");
                });

            modelBuilder.Entity("BDOLife.Core.Entities.ItemBase", b =>
                {
                    b.HasOne("BDOLife.Core.Entities.MaterialGroup", null)
                        .WithMany("Materials")
                        .HasForeignKey("MaterialGroupId");
                });

            modelBuilder.Entity("BDOLife.Core.Entities.ItemTranslate", b =>
                {
                    b.HasOne("BDOLife.Core.Entities.ItemBase", "Item")
                        .WithMany("Translates")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BDOLife.Core.Entities.Server", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Server");
                });

            modelBuilder.Entity("BDOLife.Core.Entities.Price", b =>
                {
                    b.HasOne("BDOLife.Core.Entities.ItemBase", "Item")
                        .WithMany("Prices")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BDOLife.Core.Entities.Server", "Server")
                        .WithMany()
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Server");
                });

            modelBuilder.Entity("BDOLife.Core.Entities.SellNPCItem", b =>
                {
                    b.HasOne("BDOLife.Core.Entities.ItemBase", "Item")
                        .WithMany("SellNPCs")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BDOLife.Core.Entities.SellNPC", "SellNPC")
                        .WithMany()
                        .HasForeignKey("SellNPCId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("SellNPC");
                });

            modelBuilder.Entity("BDOLife.Core.Entities.Recipe", b =>
                {
                    b.HasOne("BDOLife.Core.Entities.ItemBase", "Material1")
                        .WithMany()
                        .HasForeignKey("Material1Id");

                    b.HasOne("BDOLife.Core.Entities.ItemBase", "Material2")
                        .WithMany()
                        .HasForeignKey("Material2Id");

                    b.HasOne("BDOLife.Core.Entities.ItemBase", "Material3")
                        .WithMany()
                        .HasForeignKey("Material3Id");

                    b.HasOne("BDOLife.Core.Entities.ItemBase", "Material4")
                        .WithMany()
                        .HasForeignKey("Material4Id");

                    b.HasOne("BDOLife.Core.Entities.ItemBase", "Material5")
                        .WithMany()
                        .HasForeignKey("Material5Id");

                    b.HasOne("BDOLife.Core.Entities.MaterialGroup", "MaterialGroup1")
                        .WithMany()
                        .HasForeignKey("MaterialGroup1Id");

                    b.HasOne("BDOLife.Core.Entities.MaterialGroup", "MaterialGroup2")
                        .WithMany()
                        .HasForeignKey("MaterialGroup2Id");

                    b.HasOne("BDOLife.Core.Entities.MaterialGroup", "MaterialGroup3")
                        .WithMany()
                        .HasForeignKey("MaterialGroup3Id");

                    b.HasOne("BDOLife.Core.Entities.MaterialGroup", "MaterialGroup4")
                        .WithMany()
                        .HasForeignKey("MaterialGroup4Id");

                    b.HasOne("BDOLife.Core.Entities.MaterialGroup", "MaterialGroup5")
                        .WithMany()
                        .HasForeignKey("MaterialGroup5Id");

                    b.HasOne("BDOLife.Core.Entities.ItemBase", "Product1")
                        .WithMany()
                        .HasForeignKey("Product1Id");

                    b.HasOne("BDOLife.Core.Entities.ItemBase", "Product2")
                        .WithMany()
                        .HasForeignKey("Product2Id");

                    b.Navigation("Material1");

                    b.Navigation("Material2");

                    b.Navigation("Material3");

                    b.Navigation("Material4");

                    b.Navigation("Material5");

                    b.Navigation("MaterialGroup1");

                    b.Navigation("MaterialGroup2");

                    b.Navigation("MaterialGroup3");

                    b.Navigation("MaterialGroup4");

                    b.Navigation("MaterialGroup5");

                    b.Navigation("Product1");

                    b.Navigation("Product2");
                });

            modelBuilder.Entity("BDOLife.Core.Entities.ItemBase", b =>
                {
                    b.Navigation("Prices");

                    b.Navigation("SellNPCs");

                    b.Navigation("Translates");
                });

            modelBuilder.Entity("BDOLife.Core.Entities.MaterialGroup", b =>
                {
                    b.Navigation("Materials");
                });
#pragma warning restore 612, 618
        }
    }
}
