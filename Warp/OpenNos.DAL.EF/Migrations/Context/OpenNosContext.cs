        public virtual DbSet<WarpPoint> WarpPoint { get; set; }

            modelBuilder.Entity<Map>()
                .HasMany(e => e.WarpPoint)
                .WithRequired(e => e.Map)
                .WillCascadeOnDelete(false);