using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class Gestion_de_campagneDBContext : DbContext
    {

        public Gestion_de_campagneDBContext(DbContextOptions<Gestion_de_campagneDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Campagne> Campagnes { get; set; }
        public virtual DbSet<CanalEnvoi> CanalEnvois { get; set; }
        public virtual DbSet<Categorie> Catégories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactCanal> ContactCanals { get; set; }
        public virtual DbSet<ContactListeDiffusion> ContactListeDiffusions { get; set; }
        public virtual DbSet<InfosMessage> InfosMessages { get; set; }
        public virtual DbSet<ListeDeDiffusion> ListeDeDiffusions { get; set; }
        public virtual DbSet<ListeDffCampagne> ListeDffCampagnes { get; set; }
        public virtual DbSet<Modèle> Modèles { get; set; }
        public virtual DbSet<ModèleCampagne> ModèleCampagnes { get; set; }
        public virtual DbSet<NiveauDeVisibilite> NiveauDeVisibilites { get; set; }
        
        public virtual DbSet<RegleDEnvoi> RegleDEnvois { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
       
        public virtual DbSet<SuiviCampagne> SuiviCampagnes { get; set; }
        public virtual DbSet<SuiviCampagneCampagne> SuiviCampagneCampagnes { get; set; }
        public virtual DbSet<TypeDeCampagne> TypeDeCampagnes { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
        public virtual DbSet<Variable> Variables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-LFQAKSS;Database=Gestion_de_campagneDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<Campagne>(entity =>
            {
                entity.ToTable("Campagne");

                entity.HasIndex(e => e.IdCanalEnvoi, "IX_Campagne_Id_Canal_envoi");

                entity.HasIndex(e => e.IdCategorie, "IX_Campagne_Id_Categorie");

                entity.HasIndex(e => e.IdInfosMessage, "IX_Campagne_Id_Infos_message");

                entity.HasIndex(e => e.IdNiveauVisibilité, "IX_Campagne_Id_Niveau_visibilité");

                entity.HasIndex(e => e.IdRegleEnvoi, "IX_Campagne_Id_Regle_envoi");

                entity.HasIndex(e => e.IdTypeCampagne, "IX_Campagne_Id_Type_campagne");

                entity.HasIndex(e => e.IdUtilisateur, "IX_Campagne_Id_utilisateur");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateDeDébut)
                    .HasColumnType("date")
                    .HasColumnName("Date de début");

                entity.Property(e => e.DateDeFin)
                    .HasColumnType("date")
                    .HasColumnName("Date de fin");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.IdCanalEnvoi).HasColumnName("Id_Canal_envoi");

                entity.Property(e => e.IdCategorie).HasColumnName("Id_Categorie");

                entity.Property(e => e.IdInfosMessage).HasColumnName("Id_Infos_message");

                entity.Property(e => e.IdNiveauVisibilité).HasColumnName("Id_Niveau_visibilité");

                entity.Property(e => e.IdRegleEnvoi).HasColumnName("Id_Regle_envoi");

                entity.Property(e => e.IdTypeCampagne).HasColumnName("Id_Type_campagne");

                entity.Property(e => e.IdUtilisateur).HasColumnName("Id_utilisateur");

                entity.Property(e => e.Titre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCanalEnvoiNavigation)
                    .WithMany(p => p.Campagnes)
                    .HasForeignKey(d => d.IdCanalEnvoi)
                    .HasConstraintName("FK_Campagne_Canal_envoi");

                entity.HasOne(d => d.IdCategorieNavigation)
                    .WithMany(p => p.Campagnes)
                    .HasForeignKey(d => d.IdCategorie)
                    .HasConstraintName("FK_Campagne_Catégorie");

                entity.HasOne(d => d.IdInfosMessageNavigation)
                    .WithMany(p => p.Campagnes)
                    .HasForeignKey(d => d.IdInfosMessage)
                    .HasConstraintName("FK_Campagne_Infos_Message");

                entity.HasOne(d => d.IdNiveauVisibilitéNavigation)
                    .WithMany(p => p.Campagnes)
                    .HasForeignKey(d => d.IdNiveauVisibilité)
                    .HasConstraintName("FK_Campagne_Niveau_de_visibilite");

                entity.HasOne(d => d.IdRegleEnvoiNavigation)
                    .WithMany(p => p.Campagnes)
                    .HasForeignKey(d => d.IdRegleEnvoi)
                    .HasConstraintName("FK_Campagne_Regle_dEnvoi");

                entity.HasOne(d => d.IdTypeCampagneNavigation)
                    .WithMany(p => p.Campagnes)
                    .HasForeignKey(d => d.IdTypeCampagne)
                    .HasConstraintName("FK_Campagne_Type_de_campagne");

                entity.HasOne(d => d.IdUtilisateurNavigation)
                    .WithMany(p => p.Campagnes)
                    .HasForeignKey(d => d.IdUtilisateur)
                    .HasConstraintName("FK_Campagne_Utilisateur");
            });

            modelBuilder.Entity<CanalEnvoi>(entity =>
            {
                entity.ToTable("Canal_envoi");

                entity.HasIndex(e => e.IdConatctCanal, "IX_Canal_envoi_Id_Conatct_Canal");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdConatctCanal).HasColumnName("Id_Conatct_Canal");

                entity.Property(e => e.Titre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdConatctCanalNavigation)
                    .WithMany(p => p.CanalEnvois)
                    .HasForeignKey(d => d.IdConatctCanal)
                    .HasConstraintName("FK_Canal_envoi_Contact_Canal");
            });

            
           

            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.ToTable("Catégorie");

                entity.Property(e => e.Libellé)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.Property(e => e.Adresse)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Anniverssaire).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pays)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Profession)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Region)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tel).HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<ContactCanal>(entity =>
            {
                entity.ToTable("Contact_Canal");

                entity.HasIndex(e => e.IdContact, "IX_Contact_Canal_Id_Contact");

                entity.Property(e => e.DateDesa).HasColumnType("date");

                entity.Property(e => e.IdContact).HasColumnName("Id_Contact");

                entity.Property(e => e.Lien)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Raison)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdContactNavigation)
                    .WithMany(p => p.ContactCanals)
                    .HasForeignKey(d => d.IdContact)
                    .HasConstraintName("FK_Contact_Canal_Contact");
            });

            modelBuilder.Entity<ContactListeDiffusion>(entity =>
            {
                entity.ToTable("Contact_Liste_diffusion");

                entity.HasIndex(e => e.IdContact, "IX_Contact_Liste_diffusion_Id_Contact");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateDesa).HasColumnType("date");

                entity.Property(e => e.IdContact).HasColumnName("Id_Contact");

                entity.Property(e => e.Raison)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdContactNavigation)
                    .WithMany(p => p.ContactListeDiffusions)
                    .HasForeignKey(d => d.IdContact)
                    .HasConstraintName("FK_Contact_Liste_diffusion_Contact");
            });

            modelBuilder.Entity<InfosMessage>(entity =>
            {
                entity.ToTable("Infos_Message");

                entity.Property(e => e.MessageAcheminés).HasColumnName("Message_Acheminés");

                entity.Property(e => e.MessageEnCours).HasColumnName("Message_en_cours");

                entity.Property(e => e.MessageErreur).HasColumnName("Message_erreur");

                entity.Property(e => e.MessagePrevu).HasColumnName("Message_Prevu");
            });

            modelBuilder.Entity<ListeDeDiffusion>(entity =>
            {
                entity.ToTable("Liste_de_diffusion");

                entity.HasIndex(e => e.IdContactListeDiffusion, "IX_Liste_de_diffusion_Id_Contact_Liste_Diffusion");

                entity.Property(e => e.IdContactListeDiffusion).HasColumnName("Id_Contact_Liste_Diffusion");

                entity.Property(e => e.Reference)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Titre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdContactListeDiffusionNavigation)
                    .WithMany(p => p.ListeDeDiffusions)
                    .HasForeignKey(d => d.IdContactListeDiffusion)
                    .HasConstraintName("FK_Liste_de_diffusion_Contact_Liste_diffusion");
            });

            modelBuilder.Entity<ListeDffCampagne>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ListeDffCampagne");

                entity.Property(e => e.IdCampagne).HasColumnName("Id_Campagne");

                entity.Property(e => e.IdListe).HasColumnName("Id_Liste");

                entity.HasOne(d => d.IdCampagneNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCampagne)
                    .HasConstraintName("FK_ListeDffCampagne");

                entity.HasOne(d => d.IdListeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdListe)
                    .HasConstraintName("FK_ListeDffCampagne_Liste_de_diffusion_Id");
            });

            modelBuilder.Entity<Modèle>(entity =>
            {
                entity.ToTable("Modèle");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Contenu)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Libellé)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ModèleCampagne>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Modèle_campagne");

                entity.Property(e => e.IdCampagne).HasColumnName("Id_campagne");

                entity.Property(e => e.IdModèle).HasColumnName("Id_Modèle");

                entity.HasOne(d => d.IdCampagneNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCampagne)
                    .HasConstraintName("FK_Modèle_campagne");

                entity.HasOne(d => d.IdModèleNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdModèle)
                    .HasConstraintName("FK_Modèle_campagne_Modèle_Id");
            });

            modelBuilder.Entity<NiveauDeVisibilite>(entity =>
            {
                entity.ToTable("Niveau_de_visibilite");

                entity.HasIndex(e => e.IdConatct, "IX_Niveau_de_visibilite_Id_Conatct");

                entity.HasIndex(e => e.IdContactListeDiffusion, "IX_Niveau_de_visibilite_Id_Contact_Liste_diffusion");

                entity.Property(e => e.IdConatct).HasColumnName("Id_Conatct");

                entity.Property(e => e.IdContactListeDiffusion).HasColumnName("Id_Contact_Liste_diffusion");

                entity.Property(e => e.Libellé)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdConatctNavigation)
                    .WithMany(p => p.NiveauDeVisibilites)
                    .HasForeignKey(d => d.IdConatct)
                    .HasConstraintName("FK_Niveau_de_visibilite_Contact");

                entity.HasOne(d => d.IdContactListeDiffusionNavigation)
                    .WithMany(p => p.NiveauDeVisibilites)
                    .HasForeignKey(d => d.IdContactListeDiffusion)
                    .HasConstraintName("FK_Niveau_de_visibilite_Contact_Liste_diffusion");
            });

            

            

            modelBuilder.Entity<RegleDEnvoi>(entity =>
            {
                entity.ToTable("Regle_dEnvoi");

                entity.Property(e => e.DateExecution).HasColumnType("datetime");

                entity.Property(e => e.Expediteur)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FuseauHoraire).HasColumnName("Fuseau_horaire");

                entity.Property(e => e.NombreTentative).HasColumnName("Nombre_Tentative");

                entity.Property(e => e.Recepteur)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Role");

                entity.HasIndex(e => e.IdUtilisateur, "IX_Role_Id_utilisateur");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.IdUtilisateur).HasColumnName("Id_utilisateur");

                entity.Property(e => e.Libellé)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUtilisateurNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUtilisateur)
                    .HasConstraintName("FK_Role_Utilisateur");
            });

           

            modelBuilder.Entity<SuiviCampagne>(entity =>
            {
                entity.ToTable("Suivi_campagne");

                entity.HasIndex(e => e.IdContact, "IX_Suivi_campagne_Id_Contact");

                entity.Property(e => e.Contenu).HasColumnType("text");

                entity.Property(e => e.DateEnvoi).HasColumnType("datetime");

                entity.Property(e => e.DateReact).HasColumnType("datetime");

                entity.Property(e => e.IdContact).HasColumnName("Id_Contact");

                entity.Property(e => e.NombreDeTentative).HasColumnName("Nombre_de_tentative");

                entity.HasOne(d => d.IdContactNavigation)
                    .WithMany(p => p.SuiviCampagnes)
                    .HasForeignKey(d => d.IdContact)
                    .HasConstraintName("FK_Suivi_campagne_Contact");
            });

            modelBuilder.Entity<SuiviCampagneCampagne>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SuiviCampagne_Campagne");

                entity.Property(e => e.IdCampagne).HasColumnName("Id_campagne");

                entity.Property(e => e.IdSuivi).HasColumnName("Id_Suivi");

                entity.HasOne(d => d.IdCampagneNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCampagne)
                    .HasConstraintName("FK_SuiviCampagne_Campagne_Campagne_Id");

                entity.HasOne(d => d.IdSuiviNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdSuivi)
                    .HasConstraintName("FK_SuiviCampagne_Campagne_Suivi_campagne_Id");
            });


            modelBuilder.Entity<TypeDeCampagne>(entity =>
            {
                entity.ToTable("Type_de_campagne");

                entity.Property(e => e.Libellé)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.ToTable("Utilisateur");

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MotDePasse)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Mot de passe");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Variable>(entity =>
            {
                entity.ToTable("Variable");

                entity.HasIndex(e => e.IdContact, "IX_Variable_Id_Contact");

                entity.Property(e => e.IdContact).HasColumnName("Id_Contact");

                entity.Property(e => e.NomAffichage).HasMaxLength(50);

                entity.Property(e => e.NomTechnique)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdContactNavigation)
                    .WithMany(p => p.Variables)
                    .HasForeignKey(d => d.IdContact)
                    .HasConstraintName("FK_Variable_Contact");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
