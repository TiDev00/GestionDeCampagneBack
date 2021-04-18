using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace GestionDeCampagneBack.Models
{
    public partial class dbGestionDeCampagneContext : DbContext
    {
        public dbGestionDeCampagneContext()
        {
        }

        public dbGestionDeCampagneContext(DbContextOptions<dbGestionDeCampagneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Campagne> Campagnes { get; set; }
        public virtual DbSet<CanalEnvoi> CanalEnvois { get; set; }
        public virtual DbSet<CaptureOutputLog> CaptureOutputLogs { get; set; }
        public virtual DbSet<Catégorie> Catégories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactCanal> ContactCanals { get; set; }
        public virtual DbSet<ContactListeDiffusion> ContactListeDiffusions { get; set; }
        public virtual DbSet<InfosMessage> InfosMessages { get; set; }
        public virtual DbSet<ListeDeDiffusion> ListeDeDiffusions { get; set; }
        public virtual DbSet<ListeDffCampagne> ListeDffCampagnes { get; set; }
        public virtual DbSet<Modèle> Modèles { get; set; }
        public virtual DbSet<ModèleCampagne> ModèleCampagnes { get; set; }
        public virtual DbSet<NiveauDeVisibilite> NiveauDeVisibilites { get; set; }
        public virtual DbSet<PrivateAssertEqualsTableSchemaActual> PrivateAssertEqualsTableSchemaActuals { get; set; }
        public virtual DbSet<PrivateAssertEqualsTableSchemaExpected> PrivateAssertEqualsTableSchemaExpecteds { get; set; }
        public virtual DbSet<PrivateConfiguration> PrivateConfigurations { get; set; }
        public virtual DbSet<PrivateExpectException> PrivateExpectExceptions { get; set; }
        public virtual DbSet<PrivateNewTestClassList> PrivateNewTestClassLists { get; set; }
        public virtual DbSet<PrivateNullCellTable> PrivateNullCellTables { get; set; }
        public virtual DbSet<PrivateRenamedObjectLog> PrivateRenamedObjectLogs { get; set; }
        public virtual DbSet<PrivateSysIndex> PrivateSysIndexes { get; set; }
        public virtual DbSet<PrivateSysType> PrivateSysTypes { get; set; }
        public virtual DbSet<RegleDEnvoi> RegleDEnvois { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RunLastExecution> RunLastExecutions { get; set; }
        public virtual DbSet<SuiviCampagne> SuiviCampagnes { get; set; }
        public virtual DbSet<SuiviCampagneCampagne> SuiviCampagneCampagnes { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<TestClass> TestClasses { get; set; }
        public virtual DbSet<TestMessage> TestMessages { get; set; }
        public virtual DbSet<TestResult> TestResults { get; set; }
        public virtual DbSet<TypeDeCampagne> TypeDeCampagnes { get; set; }
        public virtual DbSet<Utilisateur> Utilisateurs { get; set; }
        public virtual DbSet<Variable> Variables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-LFQAKSS;Database=dbGestionDeCampagne;Trusted_Connection=True;");
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
                    .HasColumnName("Date_de_début");

                entity.Property(e => e.DateDeFin)
                    .HasColumnType("date")
                    .HasColumnName("Date_de_fin");

                entity.Property(e => e.Description).IsUnicode(false);

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

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Titre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CaptureOutputLog>(entity =>
            {
                entity.ToTable("CaptureOutputLog", "tSQLt");
            });

            modelBuilder.Entity<Catégorie>(entity =>
            {
                entity.ToTable("Catégorie");

                entity.Property(e => e.Libellé)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("Contact");

                entity.HasIndex(e => e.IdNiveauVisib, "IDX_Contact_Id_NiveauVisib");

                entity.Property(e => e.Adresse)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Anniverssaire).HasColumnType("date");

                entity.Property(e => e.IdNiveauVisib).HasColumnName("Id_NiveauVisib");

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

                entity.HasOne(d => d.IdNiveauVisibNavigation)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.IdNiveauVisib)
                    .HasConstraintName("FK_Contact");
            });

            modelBuilder.Entity<ContactCanal>(entity =>
            {
                entity.ToTable("Contact_Canal");

                entity.HasIndex(e => e.IdCanalEnvoie, "IDX_Contact_Canal_Id_Canal_Envoie");

                entity.HasIndex(e => e.IdContact, "IX_Contact_Canal_Id_Contact");

                entity.Property(e => e.DateDesa).HasColumnType("date");

                entity.Property(e => e.IdCanalEnvoie).HasColumnName("Id_Canal_Envoie");

                entity.Property(e => e.IdContact).HasColumnName("Id_Contact");

                entity.Property(e => e.Lien)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Raison)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCanalEnvoieNavigation)
                    .WithMany(p => p.ContactCanals)
                    .HasForeignKey(d => d.IdCanalEnvoie)
                    .HasConstraintName("FK_Contact_Canal2");

                entity.HasOne(d => d.IdContactNavigation)
                    .WithMany(p => p.ContactCanals)
                    .HasForeignKey(d => d.IdContact)
                    .HasConstraintName("FK_Contact_Canal");
            });

            modelBuilder.Entity<ContactListeDiffusion>(entity =>
            {
                entity.ToTable("Contact_Liste_diffusion");

                entity.HasIndex(e => e.IdNiveauVisib, "IDX_Contact_Liste_diffusion_Id_NiveauVisib");

                entity.HasIndex(e => e.IdContact, "IX_Contact_Liste_diffusion_Id_Contact");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateDesa).HasColumnType("date");

                entity.Property(e => e.IdContact).HasColumnName("Id_Contact");

                entity.Property(e => e.IdNiveauVisib).HasColumnName("Id_NiveauVisib");

                entity.Property(e => e.Raison)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdContactNavigation)
                    .WithMany(p => p.ContactListeDiffusions)
                    .HasForeignKey(d => d.IdContact)
                    .HasConstraintName("FK_Contact_Liste_diffusion_Contact");

                entity.HasOne(d => d.IdNiveauVisibNavigation)
                    .WithMany(p => p.ContactListeDiffusions)
                    .HasForeignKey(d => d.IdNiveauVisib)
                    .HasConstraintName("FK_Contact_Liste_diffusion");
            });

            modelBuilder.Entity<InfosMessage>(entity =>
            {
                entity.ToTable("Infos_Message");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.MessageAcheminés).HasColumnName("Message_Acheminés");

                entity.Property(e => e.MessageEnCours).HasColumnName("Message_en_cours");

                entity.Property(e => e.MessageErreur).HasColumnName("Message_erreur");

                entity.Property(e => e.MessagePrevu).HasColumnName("Message_Prevu");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.InfosMessage)
                    .HasForeignKey<InfosMessage>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
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
                entity.ToTable("ListeDffCampagne");

                entity.HasIndex(e => e.IdCampagne, "IX_ListeDffCampagne_Id_Campagne");

                entity.HasIndex(e => e.IdListe, "IX_ListeDffCampagne_Id_Liste");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdCampagne).HasColumnName("Id_Campagne");

                entity.Property(e => e.IdListe).HasColumnName("Id_Liste");

                entity.HasOne(d => d.IdCampagneNavigation)
                    .WithMany(p => p.ListeDffCampagnes)
                    .HasForeignKey(d => d.IdCampagne)
                    .HasConstraintName("FK_ListeDffCampagne");

                entity.HasOne(d => d.IdListeNavigation)
                    .WithMany(p => p.ListeDffCampagnes)
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

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Libellé)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ModèleCampagne>(entity =>
            {
                entity.ToTable("Modèle_campagne");

                entity.HasIndex(e => e.IdModèle, "IX_Modèle_campagne_Id_Modèle");

                entity.HasIndex(e => e.IdCampagne, "IX_Modèle_campagne_Id_campagne");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdCampagne).HasColumnName("Id_campagne");

                entity.Property(e => e.IdModèle).HasColumnName("Id_Modèle");

                entity.HasOne(d => d.IdCampagneNavigation)
                    .WithMany(p => p.ModèleCampagnes)
                    .HasForeignKey(d => d.IdCampagne)
                    .HasConstraintName("FK_Modèle_campagne");

                entity.HasOne(d => d.IdModèleNavigation)
                    .WithMany(p => p.ModèleCampagnes)
                    .HasForeignKey(d => d.IdModèle)
                    .HasConstraintName("FK_Modèle_campagne_Modèle_Id");
            });

            modelBuilder.Entity<NiveauDeVisibilite>(entity =>
            {
                entity.ToTable("Niveau_de_visibilite");

                entity.Property(e => e.Libellé)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrivateAssertEqualsTableSchemaActual>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Private_AssertEqualsTableSchema_Actual", "tSQLt");

                entity.Property(e => e.CollationName)
                    .HasMaxLength(256)
                    .HasColumnName("collation_name");

                entity.Property(e => e.IsIdentity).HasColumnName("is_identity");

                entity.Property(e => e.IsNullable).HasColumnName("is_nullable");

                entity.Property(e => e.MaxLength).HasColumnName("max_length");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.Property(e => e.Precision).HasColumnName("precision");

                entity.Property(e => e.RankColumnId).HasColumnName("RANK(column_id)");

                entity.Property(e => e.Scale).HasColumnName("scale");

                entity.Property(e => e.SystemTypeId).HasColumnName("system_type_id");

                entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");
            });

            modelBuilder.Entity<PrivateAssertEqualsTableSchemaExpected>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Private_AssertEqualsTableSchema_Expected", "tSQLt");

                entity.Property(e => e.CollationName)
                    .HasMaxLength(256)
                    .HasColumnName("collation_name");

                entity.Property(e => e.IsIdentity).HasColumnName("is_identity");

                entity.Property(e => e.IsNullable).HasColumnName("is_nullable");

                entity.Property(e => e.MaxLength).HasColumnName("max_length");

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .HasColumnName("name");

                entity.Property(e => e.Precision).HasColumnName("precision");

                entity.Property(e => e.RankColumnId).HasColumnName("RANK(column_id)");

                entity.Property(e => e.Scale).HasColumnName("scale");

                entity.Property(e => e.SystemTypeId).HasColumnName("system_type_id");

                entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");
            });

            modelBuilder.Entity<PrivateConfiguration>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Private___737584F7C9F8AAB4");

                entity.ToTable("Private_Configurations", "tSQLt");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Value).HasColumnType("sql_variant");
            });

            modelBuilder.Entity<PrivateExpectException>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Private_ExpectException", "tSQLt");

                entity.Property(e => e.I).HasColumnName("i");
            });

            modelBuilder.Entity<PrivateNewTestClassList>(entity =>
            {
                entity.HasKey(e => e.ClassName)
                    .HasName("PK__Private___F8BF561A26AE69A5");

                entity.ToTable("Private_NewTestClassList", "tSQLt");
            });

            modelBuilder.Entity<PrivateNullCellTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Private_NullCellTable", "tSQLt");
            });

            modelBuilder.Entity<PrivateRenamedObjectLog>(entity =>
            {
                entity.ToTable("Private_RenamedObjectLog", "tSQLt");

                entity.Property(e => e.OriginalName).IsRequired();
            });

            modelBuilder.Entity<PrivateSysIndex>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Private_SysIndexes", "tSQLt");

                entity.Property(e => e.AllowPageLocks).HasColumnName("allow_page_locks");

                entity.Property(e => e.AllowRowLocks).HasColumnName("allow_row_locks");

                entity.Property(e => e.AutoCreated).HasColumnName("auto_created");

                entity.Property(e => e.CompressionDelay).HasColumnName("compression_delay");

                entity.Property(e => e.DataSpaceId).HasColumnName("data_space_id");

                entity.Property(e => e.FillFactor).HasColumnName("fill_factor");

                entity.Property(e => e.FilterDefinition).HasColumnName("filter_definition");

                entity.Property(e => e.HasFilter).HasColumnName("has_filter");

                entity.Property(e => e.IgnoreDupKey).HasColumnName("ignore_dup_key");

                entity.Property(e => e.IndexId).HasColumnName("index_id");

                entity.Property(e => e.IsDisabled).HasColumnName("is_disabled");

                entity.Property(e => e.IsHypothetical).HasColumnName("is_hypothetical");

                entity.Property(e => e.IsIgnoredInOptimization).HasColumnName("is_ignored_in_optimization");

                entity.Property(e => e.IsPadded).HasColumnName("is_padded");

                entity.Property(e => e.IsPrimaryKey).HasColumnName("is_primary_key");

                entity.Property(e => e.IsUnique).HasColumnName("is_unique");

                entity.Property(e => e.IsUniqueConstraint).HasColumnName("is_unique_constraint");

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .HasColumnName("name");

                entity.Property(e => e.ObjectId).HasColumnName("object_id");

                entity.Property(e => e.OptimizeForSequentialKey).HasColumnName("optimize_for_sequential_key");

                entity.Property(e => e.SuppressDupKeyMessages).HasColumnName("suppress_dup_key_messages");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.TypeDesc)
                    .HasMaxLength(60)
                    .HasColumnName("type_desc")
                    .UseCollation("Latin1_General_CI_AS_KS_WS");
            });

            modelBuilder.Entity<PrivateSysType>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Private_SysTypes", "tSQLt");

                entity.Property(e => e.CollationName)
                    .HasMaxLength(128)
                    .HasColumnName("collation_name");

                entity.Property(e => e.DefaultObjectId).HasColumnName("default_object_id");

                entity.Property(e => e.IsAssemblyType).HasColumnName("is_assembly_type");

                entity.Property(e => e.IsNullable).HasColumnName("is_nullable");

                entity.Property(e => e.IsTableType).HasColumnName("is_table_type");

                entity.Property(e => e.IsUserDefined).HasColumnName("is_user_defined");

                entity.Property(e => e.MaxLength).HasColumnName("max_length");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("name");

                entity.Property(e => e.Precision).HasColumnName("precision");

                entity.Property(e => e.PrincipalId).HasColumnName("principal_id");

                entity.Property(e => e.RuleObjectId).HasColumnName("rule_object_id");

                entity.Property(e => e.Scale).HasColumnName("scale");

                entity.Property(e => e.SchemaId).HasColumnName("schema_id");

                entity.Property(e => e.SystemTypeId).HasColumnName("system_type_id");

                entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");
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
                entity.ToTable("Role");

                entity.Property(e => e.Libellé)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RunLastExecution>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Run_LastExecution", "tSQLt");

                entity.Property(e => e.LoginTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<SuiviCampagne>(entity =>
            {
                entity.ToTable("Suivi_campagne");

                entity.HasIndex(e => e.IdContact, "IX_Suivi_campagne_Id_Contact");

                entity.Property(e => e.Contenu).IsUnicode(false);

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
                entity.ToTable("SuiviCampagne_Campagne");

                entity.HasIndex(e => e.IdSuivi, "IX_SuiviCampagne_Campagne_Id_Suivi");

                entity.HasIndex(e => e.IdCampagne, "IX_SuiviCampagne_Campagne_Id_campagne");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdCampagne).HasColumnName("Id_campagne");

                entity.Property(e => e.IdSuivi).HasColumnName("Id_Suivi");

                entity.HasOne(d => d.IdCampagneNavigation)
                    .WithMany(p => p.SuiviCampagneCampagnes)
                    .HasForeignKey(d => d.IdCampagne)
                    .HasConstraintName("FK_SuiviCampagne_Campagne_Campagne_Id");

                entity.HasOne(d => d.IdSuiviNavigation)
                    .WithMany(p => p.SuiviCampagneCampagnes)
                    .HasForeignKey(d => d.IdSuivi)
                    .HasConstraintName("FK_SuiviCampagne_Campagne_Suivi_campagne_Id");
            });

            modelBuilder.Entity<Test>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Tests", "tSQLt");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.TestClassName)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<TestClass>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("TestClasses", "tSQLt");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<TestMessage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TestMessage", "tSQLt");
            });

            modelBuilder.Entity<TestResult>(entity =>
            {
                entity.ToTable("TestResult", "tSQLt");

                entity.Property(e => e.Class).IsRequired();

                entity.Property(e => e.Name)
                    .HasMaxLength(517)
                    .HasComputedColumnSql("((quotename([Class])+'.')+quotename([TestCase]))", false);

                entity.Property(e => e.TestCase).IsRequired();

                entity.Property(e => e.TestEndTime).HasColumnType("datetime");

                entity.Property(e => e.TestStartTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TranName).IsRequired();
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

                entity.HasIndex(e => e.IdRole, "IDX_Utilisateur_Id_Role");

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.IdRole).HasColumnName("Id_Role");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MotDePasse)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Mot_de_passe");

                entity.Property(e => e.Nom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Utilisateurs)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK_Utilisateur_Role_Id");
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
