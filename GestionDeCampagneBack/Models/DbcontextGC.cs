using Microsoft.EntityFrameworkCore;

namespace GestionDeCampagneBack.Models
{
    public class DbcontextGC : DbContext
    {

        public DbcontextGC(DbContextOptions<DbcontextGC> options)
           : base(options)
        {
           
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* modelBuilder.Entity<Utilisateur>()
                .HasKey(user => new { user.Email, user.Login });

            modelBuilder.Entity<Categorie>()
              .HasIndex(cat => cat.Libelle).IsUnique();*/
        }
        public virtual DbSet<Campagne> Campagnes { get; set; }
        public virtual DbSet<CanalEnvoi> CanalEnvois { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactCanal> ContactCanals { get; set; }
        public virtual DbSet<ContactListeDiffusion> ContactListeDiffusions { get; set; }
        public virtual DbSet<InfosMessage> InfosMessages { get; set; }
        public virtual DbSet<ListeDeDiffusion> ListeDeDiffusions { get; set; }
        public virtual DbSet<ListeDffCampagne> ListeDffCampagnes { get; set; }
        public virtual DbSet<Modele> Modeles { get; set; }
        public virtual DbSet<ModeleCampagne> ModeleCampagnes { get; set; }
        public virtual DbSet<NiveauDeVisibilite> NiveauDeVisibilites { get; set; }

        public virtual DbSet<RegleDEnvoi> RegleDEnvois { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<SuiviCampagne> SuiviCampagnes { get; set; }
        public virtual DbSet<SuiviCampagneCampagne> SuiviCampagneCampagnes { get; set; }
        public virtual DbSet<TypeDeCampagne> TypeDeCampagnes { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
        public virtual DbSet<Variable> Variables { get; set; }


    }
    
}
