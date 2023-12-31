﻿// <auto-generated />
using System;
using Library.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Library.Persistance.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20231122202555_GenreConverterAdded")]
    partial class GenreConverterAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthorsBook", b =>
                {
                    b.Property<int>("AuthorsId")
                        .HasColumnType("int");

                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex(new[] { "BooksId" }, "IX_AuthorBook_BooksId");

                    b.ToTable("AuthorBook", "Book");

                    b.HasData(
                        new
                        {
                            AuthorsId = -1,
                            BooksId = -1
                        });
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.BookSchema.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors", "Book");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Biography = "This author is very cool",
                            BirthDay = new DateTime(2002, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FName = "Michael",
                            LName = "Chernysh",
                            Nationality = "Ukrainian"
                        });
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.BookSchema.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("AvgRating")
                        .HasColumnType("float");

                    b.Property<string>("Categorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CopiesAvailable")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Genres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("ISBN");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.Property<int?>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("ShelfId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.HasIndex("ReservationId");

                    b.HasIndex("ShelfId");

                    b.HasIndex(new[] { "Isbn" }, "IX_Books_ISBN")
                        .IsUnique();

                    b.ToTable("Books", "Book");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            AvgRating = 3.0,
                            Categorie = "Adult",
                            CopiesAvailable = 100,
                            Description = "This book is not very popular and interesting",
                            Genres = "Action, Adventure, Drama",
                            Isbn = "123QWE",
                            Language = "Albanian",
                            PublicationDate = new DateTime(2023, 11, 22, 22, 25, 54, 770, DateTimeKind.Local).AddTicks(6585),
                            PublisherId = -1,
                            ShelfId = -1,
                            Title = "Not Interested in Habibi"
                        });
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.BookSchema.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(75)
                        .HasColumnType("nvarchar(75)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("WebSite")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Phone" }, "IX_Publishers_Phone")
                        .IsUnique();

                    b.ToTable("Publishers", "Book");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Name = "Super Publisher",
                            Phone = "111-222-33-44",
                            WebSite = "web.com.ua"
                        });
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.BookSchema.Shelf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shelves", "Book");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Description = "No desc for this",
                            Name = "Super annoying books"
                        });
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.Management.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Phone" }, "IX_Customers_Phone")
                        .IsUnique();

                    b.ToTable("Customers", "Management");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Email = "mail@gmail.com",
                            FName = "Misha",
                            LName = "Chernysh",
                            Phone = "111-223-33-44"
                        },
                        new
                        {
                            Id = -2,
                            Email = "notmain@gmail.com",
                            FName = "Yarik",
                            LName = "Bubkin",
                            Phone = "123-345-23-65"
                        },
                        new
                        {
                            Id = -3,
                            Email = "notmain@gmail.com",
                            FName = "Yarik",
                            LName = "Bubkin",
                            Phone = "123-345-23-11"
                        },
                        new
                        {
                            Id = -11,
                            Email = "notmain@gmail.com",
                            FName = "Yarik",
                            LName = "Bubkin",
                            Phone = "123-231-23-11"
                        });
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.Management.FinePayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("FinePayments", "Management");
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.Management.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("FineAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReturnedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Loans", "Management");
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.Management.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Reservations", "Management");
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.Management.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Reviews", "Management", t =>
                        {
                            t.HasCheckConstraint("CK_Review_Rating", "Rating >= 0 AND Rating <= 10");
                        });
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.Management.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Phone" }, "IX_Staffs_Phone")
                        .IsUnique();

                    b.ToTable("Staffs", "Management");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            FName = "BAM",
                            HireDate = new DateTime(2023, 11, 22, 22, 25, 54, 830, DateTimeKind.Local).AddTicks(3461),
                            LName = "BIM",
                            Phone = "111-222-88-44",
                            Position = "Manager",
                            Salary = 1000m
                        },
                        new
                        {
                            Id = -10,
                            FName = "BAMDAN",
                            HireDate = new DateTime(2023, 11, 22, 22, 25, 54, 830, DateTimeKind.Local).AddTicks(3591),
                            LName = "BIM",
                            Phone = "111-232-33-44",
                            Position = "Manager",
                            Salary = 2000m
                        });
                });

            modelBuilder.Entity("AuthorsBook", b =>
                {
                    b.HasOne("Library.Domain.Entities.Schemas.BookSchema.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Domain.Entities.Schemas.BookSchema.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.BookSchema.Book", b =>
                {
                    b.HasOne("Library.Domain.Entities.Schemas.BookSchema.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Domain.Entities.Schemas.Management.Reservation", null)
                        .WithMany("Books")
                        .HasForeignKey("ReservationId");

                    b.HasOne("Library.Domain.Entities.Schemas.BookSchema.Shelf", "Shelf")
                        .WithMany("Books")
                        .HasForeignKey("ShelfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");

                    b.Navigation("Shelf");
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.BookSchema.Publisher", b =>
                {
                    b.OwnsOne("Library.Domain.Entities.ComplexEntities.Address", "Address", b1 =>
                        {
                            b1.Property<int>("PublisherId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Country");

                            b1.Property<string>("Home")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Home");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Street");

                            b1.Property<string>("Zip")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Zip");

                            b1.HasKey("PublisherId");

                            b1.ToTable("Publishers", "Book");

                            b1.WithOwner()
                                .HasForeignKey("PublisherId");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.Management.Customer", b =>
                {
                    b.OwnsOne("Library.Domain.Entities.ComplexEntities.Address", "Address", b1 =>
                        {
                            b1.Property<int>("CustomerId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Country");

                            b1.Property<string>("Home")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Home");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Street");

                            b1.Property<string>("Zip")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Zip");

                            b1.HasKey("CustomerId");

                            b1.ToTable("Customers", "Management");

                            b1.WithOwner()
                                .HasForeignKey("CustomerId");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.Management.FinePayment", b =>
                {
                    b.HasOne("Library.Domain.Entities.Schemas.Management.Customer", "Customer")
                        .WithMany("FinePayments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.Management.Loan", b =>
                {
                    b.HasOne("Library.Domain.Entities.Schemas.BookSchema.Book", "Book")
                        .WithMany("Loans")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Domain.Entities.Schemas.Management.Customer", "Customer")
                        .WithMany("Loans")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.Management.Reservation", b =>
                {
                    b.HasOne("Library.Domain.Entities.Schemas.Management.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.Management.Review", b =>
                {
                    b.HasOne("Library.Domain.Entities.Schemas.BookSchema.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Domain.Entities.Schemas.Management.Customer", "Customer")
                        .WithMany("Reviews")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.Management.Staff", b =>
                {
                    b.OwnsOne("Library.Domain.Entities.ComplexEntities.Address", "Address", b1 =>
                        {
                            b1.Property<int>("StaffId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Country");

                            b1.Property<string>("Home")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Home");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Street");

                            b1.Property<string>("Zip")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Zip");

                            b1.HasKey("StaffId");

                            b1.ToTable("Staffs", "Management");

                            b1.WithOwner()
                                .HasForeignKey("StaffId");
                        });

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.BookSchema.Book", b =>
                {
                    b.Navigation("Loans");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.BookSchema.Publisher", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.BookSchema.Shelf", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.Management.Customer", b =>
                {
                    b.Navigation("FinePayments");

                    b.Navigation("Loans");

                    b.Navigation("Reservations");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Library.Domain.Entities.Schemas.Management.Reservation", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
