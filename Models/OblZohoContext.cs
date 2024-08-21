using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OBL_Zoho.Models;

public partial class OblZohoContext : DbContext
{
    public OblZohoContext()
    {
    }

    public OblZohoContext(DbContextOptions<OblZohoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Obl> Obls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:obl-zoho.database.windows.net,1433;Database=obl-zoho;Persist Security Info=False;User ID=obl-zoho-admin;Password=0b!_@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Obl>(entity =>
        {
            entity.ToTable("obl");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.LeadId)
                .HasMaxLength(50)
                .HasColumnName("lead_id");
            entity.Property(e => e.Remarks).HasColumnName("remarks");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.DealName).HasColumnName("deal_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
