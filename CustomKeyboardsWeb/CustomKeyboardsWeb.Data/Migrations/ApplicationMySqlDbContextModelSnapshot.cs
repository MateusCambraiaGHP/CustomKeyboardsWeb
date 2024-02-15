﻿// <auto-generated />
using System;
using CustomKeyboardsWeb.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomKeyboardsWeb.Data.Migrations
{
    [DbContext(typeof(ApplicationMySqlDbContext))]
    partial class ApplicationMySqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CustomKeyboardsWeb.Domain.Primitives.Entities.Customers.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Active")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("InsertionBy")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.Property<DateTime>("InsertionDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModification")
                        .HasColumnType("datetime");

                    b.Property<string>("ModificationBy")
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.HasKey("Id");

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("CustomKeyboardsWeb.Domain.Primitives.Entities.Keyboards.Keyboard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Active")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid?>("IdKey")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("IdSwitch")
                        .HasColumnType("char(36)");

                    b.Property<string>("InsertionBy")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.Property<DateTime>("InsertionDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModification")
                        .HasColumnType("datetime");

                    b.Property<string>("ModificationBy")
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.HasKey("Id");

                    b.HasIndex("IdKey");

                    b.HasIndex("IdSwitch");

                    b.ToTable("Keyboard", (string)null);
                });

            modelBuilder.Entity("CustomKeyboardsWeb.Domain.Primitives.Entities.Keys.Key", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Active")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("InsertionBy")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.Property<DateTime>("InsertionDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModification")
                        .HasColumnType("datetime");

                    b.Property<string>("ModificationBy")
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.HasKey("Id");

                    b.ToTable("Key", (string)null);
                });

            modelBuilder.Entity("CustomKeyboardsWeb.Domain.Primitives.Entities.Members.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Active")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("InsertionBy")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.Property<DateTime>("InsertionDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModification")
                        .HasColumnType("datetime");

                    b.Property<string>("ModificationBy")
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Member", (string)null);
                });

            modelBuilder.Entity("CustomKeyboardsWeb.Domain.Primitives.Entities.PuchaseHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Active")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("IdCustomer")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("IdKeyboard")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("IdSupplier")
                        .HasColumnType("char(36)");

                    b.Property<string>("InsertionBy")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ModificationBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("PuchaseDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("IdKeyboard");

                    b.HasIndex("IdSupplier");

                    b.ToTable("PuchaseHistory", (string)null);
                });

            modelBuilder.Entity("CustomKeyboardsWeb.Domain.Primitives.Entities.Suppliers.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Active")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("InsertionBy")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.Property<DateTime>("InsertionDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModification")
                        .HasColumnType("datetime");

                    b.Property<string>("ModificationBy")
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.HasKey("Id");

                    b.ToTable("Supplier", (string)null);
                });

            modelBuilder.Entity("CustomKeyboardsWeb.Domain.Primitives.Entities.Switchies.Switch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Active")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)");

                    b.Property<DateTime?>("DeletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("InsertionBy")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.Property<DateTime>("InsertionDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("LastModification")
                        .HasColumnType("datetime");

                    b.Property<string>("ModificationBy")
                        .HasMaxLength(70)
                        .HasColumnType("varchar(70)");

                    b.HasKey("Id");

                    b.ToTable("Switch", (string)null);
                });

            modelBuilder.Entity("CustomKeyboardsWeb.Domain.Primitives.Entities.Customers.Customer", b =>
                {
                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("longtext")
                                .HasColumnName("AddressValue");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Cep", "Cep", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("varchar(15)")
                                .HasColumnName("Cep");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.FantasyName", "FantasyName", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(40)
                                .HasColumnType("varchar(40)")
                                .HasColumnName("FantasyName");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.FederativeUnit", "FederativeUnit", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(5)
                                .HasColumnType("varchar(5)")
                                .HasColumnName("FederativeUnit");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Name");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Phone", "Phone", b1 =>
                        {
                            b1.Property<Guid>("CustomerId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Phone");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customer");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Cep")
                        .IsRequired();

                    b.Navigation("FantasyName")
                        .IsRequired();

                    b.Navigation("FederativeUnit")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Phone");
                });

            modelBuilder.Entity("CustomKeyboardsWeb.Domain.Primitives.Entities.Keyboards.Keyboard", b =>
                {
                    b.HasOne("CustomKeyboardsWeb.Domain.Primitives.Entities.Keys.Key", "Key")
                        .WithMany()
                        .HasForeignKey("IdKey")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("CustomKeyboardsWeb.Domain.Primitives.Entities.Switchies.Switch", "Switch")
                        .WithMany()
                        .HasForeignKey("IdSwitch")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("KeyboardId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Name");

                            b1.HasKey("KeyboardId");

                            b1.ToTable("Keyboard");

                            b1.WithOwner()
                                .HasForeignKey("KeyboardId");
                        });

                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("KeyboardId")
                                .HasColumnType("char(36)");

                            b1.Property<double>("Value")
                                .HasPrecision(15, 4)
                                .HasColumnType("double")
                                .HasColumnName("Price");

                            b1.HasKey("KeyboardId");

                            b1.ToTable("Keyboard");

                            b1.WithOwner()
                                .HasForeignKey("KeyboardId");
                        });

                    b.Navigation("Key");

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();

                    b.Navigation("Switch");
                });

            modelBuilder.Entity("CustomKeyboardsWeb.Domain.Primitives.Entities.Keys.Key", b =>
                {
                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("KeyId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Name");

                            b1.HasKey("KeyId");

                            b1.ToTable("Key");

                            b1.WithOwner()
                                .HasForeignKey("KeyId");
                        });

                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("KeyId")
                                .HasColumnType("char(36)");

                            b1.Property<double>("Value")
                                .HasPrecision(15, 4)
                                .HasColumnType("double")
                                .HasColumnName("Price");

                            b1.HasKey("KeyId");

                            b1.ToTable("Key");

                            b1.WithOwner()
                                .HasForeignKey("KeyId");
                        });

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("CustomKeyboardsWeb.Domain.Primitives.Entities.Members.Member", b =>
                {
                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("MemberId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(40)
                                .HasColumnType("varchar(40)")
                                .HasColumnName("Email");

                            b1.HasKey("MemberId");

                            b1.ToTable("Member");

                            b1.WithOwner()
                                .HasForeignKey("MemberId");
                        });

                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("MemberId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(60)
                                .HasColumnType("varchar(60)")
                                .HasColumnName("Password");

                            b1.HasKey("MemberId");

                            b1.ToTable("Member");

                            b1.WithOwner()
                                .HasForeignKey("MemberId");
                        });

                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("MemberId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("longtext")
                                .HasColumnName("AddressValue");

                            b1.HasKey("MemberId");

                            b1.ToTable("Member");

                            b1.WithOwner()
                                .HasForeignKey("MemberId");
                        });

                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("MemberId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Name");

                            b1.HasKey("MemberId");

                            b1.ToTable("Member");

                            b1.WithOwner()
                                .HasForeignKey("MemberId");
                        });

                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Phone", "Phone", b1 =>
                        {
                            b1.Property<Guid>("MemberId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Phone");

                            b1.HasKey("MemberId");

                            b1.ToTable("Member");

                            b1.WithOwner()
                                .HasForeignKey("MemberId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Password")
                        .IsRequired();

                    b.Navigation("Phone")
                        .IsRequired();
                });

            modelBuilder.Entity("CustomKeyboardsWeb.Domain.Primitives.Entities.PuchaseHistory", b =>
                {
                    b.HasOne("CustomKeyboardsWeb.Domain.Primitives.Entities.Customers.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("IdCustomer")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CustomKeyboardsWeb.Domain.Primitives.Entities.Keyboards.Keyboard", "Keyboard")
                        .WithMany()
                        .HasForeignKey("IdKeyboard")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CustomKeyboardsWeb.Domain.Primitives.Entities.Suppliers.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("IdSupplier")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("PuchaseHistoryId")
                                .HasColumnType("char(36)");

                            b1.Property<double>("Value")
                                .HasPrecision(15, 4)
                                .HasColumnType("double")
                                .HasColumnName("Price");

                            b1.HasKey("PuchaseHistoryId");

                            b1.ToTable("PuchaseHistory");

                            b1.WithOwner()
                                .HasForeignKey("PuchaseHistoryId");
                        });

                    b.Navigation("Customer");

                    b.Navigation("Keyboard");

                    b.Navigation("Price")
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("CustomKeyboardsWeb.Domain.Primitives.Entities.Suppliers.Supplier", b =>
                {
                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("SupplierId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(40)
                                .HasColumnType("varchar(40)")
                                .HasColumnName("Address");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Supplier");

                            b1.WithOwner()
                                .HasForeignKey("SupplierId");
                        });

                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Cep", "Cep", b1 =>
                        {
                            b1.Property<Guid>("SupplierId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(15)
                                .HasColumnType("varchar(15)")
                                .HasColumnName("Cep");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Supplier");

                            b1.WithOwner()
                                .HasForeignKey("SupplierId");
                        });

                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.FantasyName", "FantasyName", b1 =>
                        {
                            b1.Property<Guid>("SupplierId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(40)
                                .HasColumnType("varchar(40)")
                                .HasColumnName("FantasyName");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Supplier");

                            b1.WithOwner()
                                .HasForeignKey("SupplierId");
                        });

                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.FederativeUnit", "FederativeUnit", b1 =>
                        {
                            b1.Property<Guid>("SupplierId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(5)
                                .HasColumnType("varchar(5)")
                                .HasColumnName("FederativeUnit");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Supplier");

                            b1.WithOwner()
                                .HasForeignKey("SupplierId");
                        });

                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("SupplierId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Name");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Supplier");

                            b1.WithOwner()
                                .HasForeignKey("SupplierId");
                        });

                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Phone", "Phone", b1 =>
                        {
                            b1.Property<Guid>("SupplierId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Phone");

                            b1.HasKey("SupplierId");

                            b1.ToTable("Supplier");

                            b1.WithOwner()
                                .HasForeignKey("SupplierId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Cep")
                        .IsRequired();

                    b.Navigation("FantasyName")
                        .IsRequired();

                    b.Navigation("FederativeUnit")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Phone");
                });

            modelBuilder.Entity("CustomKeyboardsWeb.Domain.Primitives.Entities.Switchies.Switch", b =>
                {
                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Color", "Color", b1 =>
                        {
                            b1.Property<Guid>("SwitchId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Color");

                            b1.HasKey("SwitchId");

                            b1.ToTable("Switch");

                            b1.WithOwner()
                                .HasForeignKey("SwitchId");
                        });

                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("SwitchId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(20)
                                .HasColumnType("varchar(20)")
                                .HasColumnName("Name");

                            b1.HasKey("SwitchId");

                            b1.ToTable("Switch");

                            b1.WithOwner()
                                .HasForeignKey("SwitchId");
                        });

                    b.OwnsOne("CustomKeyboardsWeb.Domain.Primitives.Common.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("SwitchId")
                                .HasColumnType("char(36)");

                            b1.Property<double>("Value")
                                .HasPrecision(15, 4)
                                .HasColumnType("double")
                                .HasColumnName("Price");

                            b1.HasKey("SwitchId");

                            b1.ToTable("Switch");

                            b1.WithOwner()
                                .HasForeignKey("SwitchId");
                        });

                    b.Navigation("Color")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
