namespace Test_DownloadVideo.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBEntities : DbContext
    {
        public DBEntities()
            : base("name=DBEntities")
        {
        }

        public virtual DbSet<VideoSteam> VideoSteams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoSteam>()
                .Property(e => e.Url)
                .IsUnicode(false);
        }
    }
}
