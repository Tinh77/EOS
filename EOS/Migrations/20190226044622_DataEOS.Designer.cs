﻿// <auto-generated />
using System;
using EOS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EOS.Migrations
{
    [DbContext(typeof(EOSContext))]
    [Migration("20190226044622_DataEOS")]
    partial class DataEOS
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EOS.Models.Account", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("Employee2Id")
                        .HasColumnName("Employee_2_Id");

                    b.Property<int>("EmployeeId")
                        .HasColumnName("Employee_Id");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<int>("RoleId")
                        .HasColumnName("Role_id");

                    b.Property<int>("Status");

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Employee2Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("EOS.Models.Company", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Logo")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("EOS.Models.Department", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("EOS.Models.Employee", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Avatar")
                        .IsRequired();

                    b.Property<int>("DepartmentId")
                        .HasColumnName("Department_Id");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<int>("Gender");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int>("PhoneNumber");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("EOS.Models.OrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id");

                    b.Property<DateTime>("FromDate")
                        .HasColumnType("datetime");

                    b.Property<int>("NumberOfEmployee");

                    b.Property<int>("OrderServiceId")
                        .HasColumnName("OrderService_Id");

                    b.Property<int>("ServiceId")
                        .HasColumnName("Service_Id");

                    b.Property<int>("Status");

                    b.Property<DateTime>("ToDate")
                        .HasColumnType("datetime");

                    b.Property<int>("UnitPrice");

                    b.HasKey("Id");

                    b.HasIndex("OrderServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("EOS.Models.OrderService", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("BillDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime");

                    b.Property<int>("PaymentMethod")
                        .HasColumnName("Payment_method");

                    b.Property<int>("Status");

                    b.Property<string>("TotalPrice")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("OrderService");
                });

            modelBuilder.Entity("EOS.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("id");

                    b.Property<string>("RoleName")
                        .IsRequired();

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("EOS.Models.Service", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("CompanyId")
                        .HasColumnName("Company_Id");

                    b.Property<string>("Descrition")
                        .IsRequired();

                    b.Property<int>("EmployeeId")
                        .HasColumnName("Employee_Id");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Price")
                        .IsRequired();

                    b.Property<int>("ServiceTypeId")
                        .HasColumnName("ServiceType_Id");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("EOS.Models.ServiceType", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1);

                    b.HasKey("Id");

                    b.ToTable("ServiceType");
                });

            modelBuilder.Entity("EOS.Models.Account", b =>
                {
                    b.HasOne("EOS.Models.Employee", "Employee2")
                        .WithMany("Account")
                        .HasForeignKey("Employee2Id")
                        .HasConstraintName("Account_Employee");

                    b.HasOne("EOS.Models.Role", "Role")
                        .WithMany("Account")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("Account_Role");
                });

            modelBuilder.Entity("EOS.Models.Employee", b =>
                {
                    b.HasOne("EOS.Models.Department", "Department")
                        .WithMany("Employee")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("Employee_Department");
                });

            modelBuilder.Entity("EOS.Models.OrderDetails", b =>
                {
                    b.HasOne("EOS.Models.OrderService", "OrderService")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderServiceId")
                        .HasConstraintName("OrderDetails_OrderService");

                    b.HasOne("EOS.Models.Service", "Service")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ServiceId")
                        .HasConstraintName("OrderDetails_Service");
                });

            modelBuilder.Entity("EOS.Models.Service", b =>
                {
                    b.HasOne("EOS.Models.Company", "Company")
                        .WithMany("Service")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("Service_Company");

                    b.HasOne("EOS.Models.Employee", "Employee")
                        .WithMany("Service")
                        .HasForeignKey("EmployeeId")
                        .HasConstraintName("Service_Employee");

                    b.HasOne("EOS.Models.ServiceType", "ServiceType")
                        .WithMany("Service")
                        .HasForeignKey("ServiceTypeId")
                        .HasConstraintName("Service_ServiceType");
                });
#pragma warning restore 612, 618
        }
    }
}
