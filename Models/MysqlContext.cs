using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TodoApi.Models;


namespace TodoApi.Models
{
    public class MysqlContext : DbContext
    {
        public MysqlContext(DbContextOptions<MysqlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<addresses> addresses { get; set; }
        public virtual DbSet<building_details> building_details { get; set; }
        public DbSet<buildings> buildings { get; set; }
        public DbSet<columns> columns { get; set; }
        public DbSet<customers> customers { get; set; }
        public virtual DbSet<elevators> elevators { get; set; }
        public DbSet<employees> employees { get; set; }
        public virtual DbSet<leads> leads { get; set; }
        public virtual DbSet<batteries> batteries { get; set; }
        public virtual DbSet<quotes> quotes { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<Interventions> Interventions { get; set; }
    }
}