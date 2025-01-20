using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Yogagym.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aboutu> Aboutus { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Contactu> Contactus { get; set; }

    public virtual DbSet<Creditcarddetail> Creditcarddetails { get; set; }

    public virtual DbSet<Footer> Footers { get; set; }

    public virtual DbSet<Header> Headers { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MembersSubscription> MembersSubscriptions { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<Testimonial> Testimonials { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    public virtual DbSet<Userlogin> Userlogins { get; set; }

    public virtual DbSet<Workoutplan> Workoutplans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=Mram;Password=Mram;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1523))(CONNECT_DATA=(SERVICE_NAME=orclpdb)))");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("MRAM")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Aboutu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008568");

            entity.ToTable("ABOUTUS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Imagepath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IMAGEPATH");
            entity.Property(e => e.Text)
                .HasColumnType("CLOB")
                .HasColumnName("TEXT");
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Adminid).HasName("SYS_C008558");

            entity.ToTable("ADMINS");

            entity.Property(e => e.Adminid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ADMINID");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FNAME");
            entity.Property(e => e.Imagepath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IMAGEPATH");
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LNAME");
        });

        modelBuilder.Entity<Contactu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008574");

            entity.ToTable("CONTACTUS");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Message)
                .HasColumnType("CLOB")
                .HasColumnName("MESSAGE");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SUBJECT");
        });

        modelBuilder.Entity<Creditcarddetail>(entity =>
        {
            entity.HasKey(e => e.Cardid).HasName("SYS_C008592");

            entity.ToTable("CREDITCARDDETAILS");

            entity.Property(e => e.Cardid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("CARDID");
            entity.Property(e => e.Availablebalance)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("AVAILABLEBALANCE");
            entity.Property(e => e.Cardnumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CARDNUMBER");
            entity.Property(e => e.Cvv)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CVV");
            entity.Property(e => e.Expirydate)
                .HasColumnType("DATE")
                .HasColumnName("EXPIRYDATE");
            entity.Property(e => e.Memberid)
                .HasColumnType("NUMBER")
                .HasColumnName("MEMBERID");

            entity.HasOne(d => d.Member).WithMany(p => p.Creditcarddetails)
                .HasForeignKey(d => d.Memberid)
                .HasConstraintName("SYS_C008593");
        });

        modelBuilder.Entity<Footer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008562");

            entity.ToTable("FOOTER");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Copyright)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("COPYRIGHT");
            entity.Property(e => e.Linkfacebook)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("LINKFACEBOOK");
            entity.Property(e => e.Linkinstagram)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("LINKINSTAGRAM");
            entity.Property(e => e.Linkx)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("LINKX");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME");
        });

        modelBuilder.Entity<Header>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008565");

            entity.ToTable("HEADER");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Imagepath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IMAGEPATH");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Memberid).HasName("SYS_C008550");

            entity.ToTable("MEMBERS");

            entity.Property(e => e.Memberid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("MEMBERID");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FNAME");
            entity.Property(e => e.Imagepath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IMAGEPATH");
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LNAME");
        });

        modelBuilder.Entity<MembersSubscription>(entity =>
        {
            entity.HasKey(e => e.MembersSubscriptionsid).HasName("SYS_C008614");

            entity.ToTable("MEMBERS_SUBSCRIPTIONS");

            entity.Property(e => e.MembersSubscriptionsid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("MEMBERS_SUBSCRIPTIONSID");
            entity.Property(e => e.Memberid)
                .HasColumnType("NUMBER")
                .HasColumnName("MEMBERID");
            entity.Property(e => e.Planid)
                .HasColumnType("NUMBER")
                .HasColumnName("PLANID");
            entity.Property(e => e.Subscriptionid)
                .HasColumnType("NUMBER")
                .HasColumnName("SUBSCRIPTIONID");

            entity.HasOne(d => d.Member).WithMany(p => p.MembersSubscriptions)
                .HasForeignKey(d => d.Memberid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C008615");

            entity.HasOne(d => d.Plan).WithMany(p => p.MembersSubscriptions)
                .HasForeignKey(d => d.Planid)
                .HasConstraintName("SYS_C008617");

            entity.HasOne(d => d.Subscription).WithMany(p => p.MembersSubscriptions)
                .HasForeignKey(d => d.Subscriptionid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C008616");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Paymentid).HasName("SYS_C008599");

            entity.ToTable("PAYMENTS");

            entity.Property(e => e.Paymentid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("PAYMENTID");
            entity.Property(e => e.Amount)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("AMOUNT");
            entity.Property(e => e.Cardid)
                .HasColumnType("NUMBER")
                .HasColumnName("CARDID");
            entity.Property(e => e.Paymentdate)
                .HasColumnType("DATE")
                .HasColumnName("PAYMENTDATE");
            entity.Property(e => e.Subscriptionid)
                .HasColumnType("NUMBER")
                .HasColumnName("SUBSCRIPTIONID");

            entity.HasOne(d => d.Card).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Cardid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C008601");

            entity.HasOne(d => d.Subscription).WithMany(p => p.Payments)
                .HasForeignKey(d => d.Subscriptionid)
                .HasConstraintName("SYS_C008600");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("SYS_C008539");

            entity.ToTable("ROLES");

            entity.Property(e => e.Roleid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ROLEID");
            entity.Property(e => e.Rolename)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ROLENAME");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.Subscriptionid).HasName("SYS_C008584");

            entity.ToTable("SUBSCRIPTIONS");

            entity.Property(e => e.Subscriptionid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("SUBSCRIPTIONID");
            entity.Property(e => e.Enddate)
                .HasColumnType("DATE")
                .HasColumnName("ENDDATE");
            entity.Property(e => e.Memberid)
                .HasColumnType("NUMBER")
                .HasColumnName("MEMBERID");
            entity.Property(e => e.Planid)
                .HasColumnType("NUMBER")
                .HasColumnName("PLANID");
            entity.Property(e => e.Startdate)
                .HasColumnType("DATE")
                .HasColumnName("STARTDATE");

            entity.HasOne(d => d.Member).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.Memberid)
                .HasConstraintName("SYS_C008585");

            entity.HasOne(d => d.Plan).WithMany(p => p.Subscriptions)
                .HasForeignKey(d => d.Planid)
                .HasConstraintName("SYS_C008586");
        });

        modelBuilder.Entity<Testimonial>(entity =>
        {
            entity.HasKey(e => e.Testimonialid).HasName("SYS_C008606");

            entity.ToTable("TESTIMONIALS");

            entity.Property(e => e.Testimonialid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("TESTIMONIALID");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("SYSDATE")
                .HasColumnType("DATE")
                .HasColumnName("CREATEDAT");
            entity.Property(e => e.Memberid)
                .HasColumnType("NUMBER")
                .HasColumnName("MEMBERID");
            entity.Property(e => e.Reviewedby)
                .HasColumnType("NUMBER")
                .HasColumnName("REVIEWEDBY");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("'Pending' ")
                .HasColumnName("STATUS");
            entity.Property(e => e.Testimonialtext)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("TESTIMONIALTEXT");
            entity.Property(e => e.Updatedat)
                .HasColumnType("DATE")
                .HasColumnName("UPDATEDAT");

            entity.HasOne(d => d.Member).WithMany(p => p.Testimonials)
                .HasForeignKey(d => d.Memberid)
                .HasConstraintName("SYS_C008607");

            entity.HasOne(d => d.ReviewedbyNavigation).WithMany(p => p.Testimonials)
                .HasForeignKey(d => d.Reviewedby)
                .HasConstraintName("SYS_C008608");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.Trainerid).HasName("SYS_C008554");

            entity.ToTable("TRAINERS");

            entity.Property(e => e.Trainerid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("TRAINERID");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Fname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FNAME");
            entity.Property(e => e.Imagepath)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("IMAGEPATH");
            entity.Property(e => e.Lname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LNAME");
        });

        modelBuilder.Entity<Userlogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C008544");

            entity.ToTable("USERLOGIN");

            entity.HasIndex(e => e.Username, "SYS_C008545").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Adminid)
                .HasColumnType("NUMBER")
                .HasColumnName("ADMINID");
            entity.Property(e => e.Memberid)
                .HasColumnType("NUMBER")
                .HasColumnName("MEMBERID");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Roleid)
                .HasColumnType("NUMBER")
                .HasColumnName("ROLEID");
            entity.Property(e => e.Trainerid)
                .HasColumnType("NUMBER")
                .HasColumnName("TRAINERID");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USERNAME");

            entity.HasOne(d => d.Admin).WithMany(p => p.Userlogins)
                .HasForeignKey(d => d.Adminid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_USERLOGIN_ADMINS");

            entity.HasOne(d => d.Member).WithMany(p => p.Userlogins)
                .HasForeignKey(d => d.Memberid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_USERLOGIN_MEMBERS");

            entity.HasOne(d => d.Role).WithMany(p => p.Userlogins)
                .HasForeignKey(d => d.Roleid)
                .HasConstraintName("SYS_C008546");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Userlogins)
                .HasForeignKey(d => d.Trainerid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_USERLOGIN_TRAINERS");
        });

        modelBuilder.Entity<Workoutplan>(entity =>
        {
            entity.HasKey(e => e.Planid).HasName("SYS_C008578");

            entity.ToTable("WORKOUTPLANS");

            entity.Property(e => e.Planid)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("PLANID");
            entity.Property(e => e.Duration)
                .HasColumnType("NUMBER")
                .HasColumnName("DURATION");
            entity.Property(e => e.Imagepath)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("IMAGEPATH");
            entity.Property(e => e.Planname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PLANNAME");
            entity.Property(e => e.Price)
                .HasColumnType("NUMBER")
                .HasColumnName("PRICE");
            entity.Property(e => e.Trainerid)
                .HasColumnType("NUMBER")
                .HasColumnName("TRAINERID");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Workoutplans)
                .HasForeignKey(d => d.Trainerid)
                .HasConstraintName("SYS_C008579");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
