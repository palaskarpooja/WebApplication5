using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication5.Models
{
    public partial class organisationContext : DbContext
    {
        public organisationContext()
        {
        }

        public organisationContext(DbContextOptions<organisationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Profilerdemo> Profilerdemos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=POOJAPALASKAR;Database=organisation;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.Bookingid)
                    .ValueGeneratedNever()
                    .HasColumnName("bookingid");

                entity.Property(e => e.Bookdate)
                    .HasColumnType("date")
                    .HasColumnName("bookdate");

                entity.Property(e => e.Flightid).HasColumnName("flightid");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.Flightid)
                    .HasConstraintName("FK__Booking__flighti__3C69FB99");
            });

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.HasKey(e => new { e.Bookingid, e.Passid })
                    .HasName("PK__Booking___FD982D1D973E19EE");

                entity.ToTable("Booking_details");

                entity.Property(e => e.Bookingid).HasColumnName("bookingid");

                entity.Property(e => e.Passid).HasColumnName("passid");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.Bookingid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking_d__booki__3F466844");

                entity.HasOne(d => d.Pass)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.Passid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking_d__passi__403A8C7D");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.Property(e => e.Companyid)
                    .ValueGeneratedNever()
                    .HasColumnName("companyid");

                entity.Property(e => e.Companyname)
                    .HasMaxLength(20)
                    .HasColumnName("companyname");

                entity.Property(e => e.Locationid).HasColumnName("locationid");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.Locationid)
                    .HasConstraintName("fk_locationid");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Deptid)
                    .HasName("PK__departme__BE2C1AEEA91AEE62");

                entity.ToTable("department");

                entity.Property(e => e.Deptid)
                    .ValueGeneratedNever()
                    .HasColumnName("deptid");

                entity.Property(e => e.Deptname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("deptname")
                    .HasDefaultValueSql("('IT')");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Employeeid)
                    .ValueGeneratedNever()
                    .HasColumnName("employeeid");

                entity.Property(e => e.Companyid).HasColumnName("companyid");

                entity.Property(e => e.Deptid).HasColumnName("deptid");

                entity.Property(e => e.Designation)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("designation");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Employeename)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Hiredate)
                    .HasColumnType("date")
                    .HasColumnName("hiredate");

                entity.Property(e => e.Managerid).HasColumnName("managerid");

                entity.Property(e => e.Salary)
                    .HasColumnType("money")
                    .HasColumnName("salary");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Companyid)
                    .HasConstraintName("FK__employee__compan__1920BF5C");

                entity.HasOne(d => d.Dept)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.Deptid)
                    .HasConstraintName("FK__employee__deptid__1A14E395");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.InverseManager)
                    .HasForeignKey(d => d.Managerid)
                    .HasConstraintName("FK__employee__manage__182C9B23");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("Flight");

                entity.Property(e => e.Flightid)
                    .ValueGeneratedNever()
                    .HasColumnName("flightid");

                entity.Property(e => e.Flightdate)
                    .HasColumnType("date")
                    .HasColumnName("flightdate");

                entity.Property(e => e.Flightdest)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("flightdest");

                entity.Property(e => e.Flightseat).HasColumnName("flightseat");

                entity.Property(e => e.Flightsource)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("flightsource");

                entity.Property(e => e.Ticketcost).HasColumnName("ticketcost");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("location");

                entity.Property(e => e.Locationid).HasColumnName("locationid");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.HasKey(e => e.Passid)
                    .HasName("PK__Passenge__B4B2A18210B6F17C");

                entity.ToTable("Passenger");

                entity.Property(e => e.Passid)
                    .ValueGeneratedNever()
                    .HasColumnName("passid");

                entity.Property(e => e.Passdob)
                    .HasColumnType("date")
                    .HasColumnName("passdob");

                entity.Property(e => e.Passemail)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("passemail");

                entity.Property(e => e.Passname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("passname");
            });

            modelBuilder.Entity<Profilerdemo>(entity =>
            {
                entity.HasKey(e => e.RowNumber)
                    .HasName("PK__Profiler__AAAC09D80EE61E70");

                entity.ToTable("Profilerdemo");

                entity.Property(e => e.ApplicationName).HasMaxLength(128);

                entity.Property(e => e.BinaryData).HasColumnType("image");

                entity.Property(e => e.ClientProcessId).HasColumnName("ClientProcessID");

                entity.Property(e => e.Cpu).HasColumnName("CPU");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.LoginName).HasMaxLength(128);

                entity.Property(e => e.NtuserName)
                    .HasMaxLength(128)
                    .HasColumnName("NTUserName");

                entity.Property(e => e.Spid).HasColumnName("SPID");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.TextData).HasColumnType("ntext");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
