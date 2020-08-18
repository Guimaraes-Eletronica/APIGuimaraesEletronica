using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace ApiGuimaraesEletronica.Models
{
    public partial class guimaraeseletronicaContext : DbContext
    {
        public guimaraeseletronicaContext()
        {

            
        }

        public guimaraeseletronicaContext(DbContextOptions<guimaraeseletronicaContext> options)
            : base(options)

        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
