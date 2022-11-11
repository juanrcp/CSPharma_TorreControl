﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityBasicoDAL.cspharma_operacional;

public partial class CspharmaOperacionalContext : DbContext
{
    public CspharmaOperacionalContext()
    {
    }

    public CspharmaOperacionalContext(DbContextOptions<CspharmaOperacionalContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=cspharma_operacional;User Id=postgres;Password=fp13DAW");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
