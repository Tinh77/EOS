using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EOS.Models
{
    public partial class EOSContext : DbContext
    {
        public EOSContext()
        {
        }

        public EOSContext(DbContextOptions<EOSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<OrderService> OrderService { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceType> ServiceType { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.RoleId).HasColumnName("Role_id");

                entity.Property(e => e.Username).IsRequired();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Account_Employee");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Account_Role");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Logo).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Phone).IsRequired();
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.Avatar).IsRequired();

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Employee_Department");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.OrderServiceId).HasColumnName("OrderService_Id");

                entity.Property(e => e.ServiceId).HasColumnName("Service_Id");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.HasOne(d => d.OrderService)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderDetails_OrderService");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("OrderDetails_Service");
            });

            modelBuilder.Entity<OrderService>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BillDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentMethod).HasColumnName("Payment_method");

                entity.Property(e => e.TotalPrice).IsRequired();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.RoleName).IsRequired();
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CompanyId).HasColumnName("Company_Id");

                entity.Property(e => e.Descrition).IsRequired();

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Price).IsRequired();

                entity.Property(e => e.ServiceTypeId).HasColumnName("ServiceType_Id");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Service_Company");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Service_Employee");

                entity.HasOne(d => d.ServiceType)
                    .WithMany(p => p.Service)
                    .HasForeignKey(d => d.ServiceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Service_ServiceType");
            });

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1);
            });
        }
    }
}
