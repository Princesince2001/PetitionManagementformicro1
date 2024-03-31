using Microsoft.EntityFrameworkCore;
using PetitionManagementSystem.Models;
using System;

namespace PetitionManagementSystem.Connection
{
    public class PetitionManagementDBContext:DbContext
    {
        public PetitionManagementDBContext(DbContextOptions<PetitionManagementDBContext> options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Petition> Petition { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<PetitionHandler> PetitionHandlers { get; set; }
        public DbSet<PentitionPetitionHandler> pentitionPetitionHandlers { get; set; }
     
    }
}

