﻿// <auto-generated />
using System;
using GestionDeCampagneBack.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestionDeCampagneBack.Migrations
{
    [DbContext(typeof(DbcontextGC))]
    partial class DbcontextGCModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GestionDeCampagneBack.Models.Campagne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DateDeDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDeFin")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Etat")
                        .HasColumnType("bit");

                    b.Property<int>("IdEntite")
                        .HasColumnType("int");

                    b.Property<int>("IdNiveauVisibilite")
                        .HasColumnType("int");

                    b.Property<int>("IdRegleEnvoi")
                        .HasColumnType("int");

                    b.Property<int>("IdTypeCampagne")
                        .HasColumnType("int");

                    b.Property<int>("IdUtilisateur")
                        .HasColumnType("int");

                    b.Property<bool>("Statut")
                        .HasColumnType("bit");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("IdNiveauVisibilite");

                    b.HasIndex("IdRegleEnvoi");

                    b.HasIndex("IdTypeCampagne");

                    b.HasIndex("IdUtilisateur");

                    b.ToTable("Campagnes");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.CanalEnvoi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Etat")
                        .HasColumnType("bit");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("CanalEnvois");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateDeNaissance")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Etat")
                        .HasColumnType("bit");

                    b.Property<int>("IdEntite")
                        .HasColumnType("int");

                    b.Property<int>("IdNiveauVisibilite")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("Matricule")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Pays")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Profession")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sexe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Situation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Statut")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdNiveauVisibilite");

                    b.HasIndex("IdUser");

                    b.HasIndex("Matricule")
                        .IsUnique()
                        .HasFilter("[Matricule] IS NOT NULL");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.ContactCanal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CanalDuContatct")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("DateDesabonnement")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Etat")
                        .HasColumnType("bit");

                    b.Property<int>("IdCanalEnvoi")
                        .HasColumnType("int");

                    b.Property<int>("IdContact")
                        .HasColumnType("int");

                    b.Property<int>("IdEntite")
                        .HasColumnType("int");

                    b.Property<string>("Lieuounumero")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Raison")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCanalEnvoi");

                    b.HasIndex("IdContact");

                    b.ToTable("ContactCanals");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.ContactListeDiffusion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("DateDesa")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Etat")
                        .HasColumnType("bit");

                    b.Property<int>("IdContact")
                        .HasColumnType("int");

                    b.Property<int>("IdEntite")
                        .HasColumnType("int");

                    b.Property<int>("IdListeDiffusion")
                        .HasColumnType("int");

                    b.Property<string>("Raison")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdContact");

                    b.HasIndex("IdListeDiffusion");

                    b.ToTable("ContactListeDiffusions");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.Entite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Activite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Entites");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.InfosMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCampagne")
                        .HasColumnType("int");

                    b.Property<int>("IdEntite")
                        .HasColumnType("int");

                    b.Property<int?>("MessageAchemines")
                        .HasColumnType("int");

                    b.Property<int?>("MessageEnCours")
                        .HasColumnType("int");

                    b.Property<int?>("MessageErreur")
                        .HasColumnType("int");

                    b.Property<int>("MessagePrevu")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCampagne");

                    b.ToTable("InfosMessages");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.InfosMessageCampagne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCampagne")
                        .HasColumnType("int");

                    b.Property<int?>("IdCampagneNavigationId")
                        .HasColumnType("int");

                    b.Property<int>("IdEntite")
                        .HasColumnType("int");

                    b.Property<int>("IdInfosMessage")
                        .HasColumnType("int");

                    b.Property<int?>("IdInfosMessageNavigationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCampagneNavigationId");

                    b.HasIndex("IdInfosMessageNavigationId");

                    b.ToTable("InfosMessageCampagne");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.ListeDeDiffusion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Etat")
                        .HasColumnType("bit");

                    b.Property<int>("IdEntite")
                        .HasColumnType("int");

                    b.Property<int>("IdNiveauVisibilite")
                        .HasColumnType("int");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Statut")
                        .HasColumnType("bit");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Reference")
                        .IsUnique();

                    b.ToTable("ListeDeDiffusions");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.ListeDffCampagne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCampagne")
                        .HasColumnType("int");

                    b.Property<int>("IdEntite")
                        .HasColumnType("int");

                    b.Property<int>("IdListe")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCampagne");

                    b.HasIndex("IdListe");

                    b.ToTable("ListeDffCampagnes");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.Modele", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contenu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCanalEnvoi")
                        .HasColumnType("int");

                    b.Property<int>("IdEntite")
                        .HasColumnType("int");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Statut")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdCanalEnvoi");

                    b.ToTable("Modeles");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.ModeleCampagne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCampagne")
                        .HasColumnType("int");

                    b.Property<int>("IdEntite")
                        .HasColumnType("int");

                    b.Property<int>("IdModele")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCampagne");

                    b.HasIndex("IdModele");

                    b.ToTable("ModeleCampagnes");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.NiveauDeVisibilite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Libelle")
                        .IsUnique();

                    b.ToTable("NiveauDeVisibilites");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.RegleDEnvoi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateExecution")
                        .HasColumnType("datetime2");

                    b.Property<string>("Expediteur")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Frequence")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("FuseauHoraire")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("IdEntite")
                        .HasColumnType("int");

                    b.Property<int?>("NombreTentative")
                        .HasColumnType("int");

                    b.Property<string>("Recepteur")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RegleDEnvois");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Libelle")
                        .IsUnique();

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.SuiviCampagne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contenu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateEnvoi")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdContact")
                        .HasColumnType("int");

                    b.Property<int>("IdEntite")
                        .HasColumnType("int");

                    b.Property<int?>("NombreDeTentative")
                        .HasColumnType("int");

                    b.Property<bool>("Statut")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdContact");

                    b.ToTable("SuiviCampagnes");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.SuiviCampagneCampagne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCampagne")
                        .HasColumnType("int");

                    b.Property<int?>("IdCampagneNavigationId")
                        .HasColumnType("int");

                    b.Property<int>("IdEntite")
                        .HasColumnType("int");

                    b.Property<int>("IdSuivi")
                        .HasColumnType("int");

                    b.Property<int?>("IdSuiviNavigationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCampagneNavigationId");

                    b.HasIndex("IdSuiviNavigationId");

                    b.ToTable("SuiviCampagneCampagnes");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.TypeDeCampagne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdEntite")
                        .HasColumnType("int");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TypeDeCampagnes");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.Utilisateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Etat")
                        .HasColumnType("bit");

                    b.Property<int>("IdEntite")
                        .HasColumnType("int");

                    b.Property<int>("IdRole")
                        .HasColumnType("int");

                    b.Property<bool>("Ischange")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Statut")
                        .HasColumnType("bit");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdEntite");

                    b.HasIndex("IdRole");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Utilisateurs");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.Variable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdContact")
                        .HasColumnType("int");

                    b.Property<string>("NomAffichage")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NomTechnique")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("TailleMax")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Valeur")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdContact");

                    b.ToTable("Variables");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.Campagne", b =>
                {
                    b.HasOne("GestionDeCampagneBack.Models.NiveauDeVisibilite", "IdNiveauVisibiliteNavigation")
                        .WithMany("Campagnes")
                        .HasForeignKey("IdNiveauVisibilite")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionDeCampagneBack.Models.RegleDEnvoi", "IdRegleEnvoiNavigation")
                        .WithMany("Campagnes")
                        .HasForeignKey("IdRegleEnvoi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionDeCampagneBack.Models.TypeDeCampagne", "IdTypeCampagneNavigation")
                        .WithMany("Campagnes")
                        .HasForeignKey("IdTypeCampagne")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionDeCampagneBack.Models.Utilisateur", "IdUtilisateurNavigation")
                        .WithMany("Campagnes")
                        .HasForeignKey("IdUtilisateur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdNiveauVisibiliteNavigation");

                    b.Navigation("IdRegleEnvoiNavigation");

                    b.Navigation("IdTypeCampagneNavigation");

                    b.Navigation("IdUtilisateurNavigation");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.Contact", b =>
                {
                    b.HasOne("GestionDeCampagneBack.Models.NiveauDeVisibilite", "IdNiveauVisibiliteNavigation")
                        .WithMany("Contacts")
                        .HasForeignKey("IdNiveauVisibilite")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionDeCampagneBack.Models.Utilisateur", "IdUserNavigation")
                        .WithMany("Contacts")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdNiveauVisibiliteNavigation");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.ContactCanal", b =>
                {
                    b.HasOne("GestionDeCampagneBack.Models.CanalEnvoi", "IdCanalEnvoiNavigation")
                        .WithMany("ContactCanals")
                        .HasForeignKey("IdCanalEnvoi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionDeCampagneBack.Models.Contact", "IdContactNavigation")
                        .WithMany("ContactCanals")
                        .HasForeignKey("IdContact")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdCanalEnvoiNavigation");

                    b.Navigation("IdContactNavigation");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.ContactListeDiffusion", b =>
                {
                    b.HasOne("GestionDeCampagneBack.Models.Contact", "IdContactNavigation")
                        .WithMany("ContactListeDiffusions")
                        .HasForeignKey("IdContact")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionDeCampagneBack.Models.ListeDeDiffusion", "IdIdListeDiffusionNavigation")
                        .WithMany("ContactListeDiffusions")
                        .HasForeignKey("IdListeDiffusion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdContactNavigation");

                    b.Navigation("IdIdListeDiffusionNavigation");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.InfosMessage", b =>
                {
                    b.HasOne("GestionDeCampagneBack.Models.Campagne", "Campagnes")
                        .WithMany()
                        .HasForeignKey("IdCampagne")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campagnes");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.InfosMessageCampagne", b =>
                {
                    b.HasOne("GestionDeCampagneBack.Models.Campagne", "IdCampagneNavigation")
                        .WithMany("InfosMessageCampagnes")
                        .HasForeignKey("IdCampagneNavigationId");

                    b.HasOne("GestionDeCampagneBack.Models.InfosMessage", "IdInfosMessageNavigation")
                        .WithMany("InfosMessageCampagnes")
                        .HasForeignKey("IdInfosMessageNavigationId");

                    b.Navigation("IdCampagneNavigation");

                    b.Navigation("IdInfosMessageNavigation");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.ListeDffCampagne", b =>
                {
                    b.HasOne("GestionDeCampagneBack.Models.Campagne", "IdCampagneNavigation")
                        .WithMany("ListeDffCampagnes")
                        .HasForeignKey("IdCampagne")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionDeCampagneBack.Models.ListeDeDiffusion", "IdListeNavigation")
                        .WithMany("ListeDffCampagnes")
                        .HasForeignKey("IdListe")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdCampagneNavigation");

                    b.Navigation("IdListeNavigation");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.Modele", b =>
                {
                    b.HasOne("GestionDeCampagneBack.Models.CanalEnvoi", "IdCanalEnvoiNavigation")
                        .WithMany("Modeles")
                        .HasForeignKey("IdCanalEnvoi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdCanalEnvoiNavigation");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.ModeleCampagne", b =>
                {
                    b.HasOne("GestionDeCampagneBack.Models.Campagne", "IdCampagneNavigation")
                        .WithMany("ModeleCampagnes")
                        .HasForeignKey("IdCampagne")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionDeCampagneBack.Models.Modele", "IdModeleNavigation")
                        .WithMany("ModeleCampagnes")
                        .HasForeignKey("IdModele")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdCampagneNavigation");

                    b.Navigation("IdModeleNavigation");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.SuiviCampagne", b =>
                {
                    b.HasOne("GestionDeCampagneBack.Models.Contact", "IdContactNavigation")
                        .WithMany("SuiviCampagnes")
                        .HasForeignKey("IdContact")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdContactNavigation");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.SuiviCampagneCampagne", b =>
                {
                    b.HasOne("GestionDeCampagneBack.Models.Campagne", "IdCampagneNavigation")
                        .WithMany("SuiviCampagneCampagnes")
                        .HasForeignKey("IdCampagneNavigationId");

                    b.HasOne("GestionDeCampagneBack.Models.SuiviCampagne", "IdSuiviNavigation")
                        .WithMany("SuiviCampagneCampagnes")
                        .HasForeignKey("IdSuiviNavigationId");

                    b.Navigation("IdCampagneNavigation");

                    b.Navigation("IdSuiviNavigation");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.Utilisateur", b =>
                {
                    b.HasOne("GestionDeCampagneBack.Models.Entite", "IdEntiteNavigation")
                        .WithMany("Utilisateurs")
                        .HasForeignKey("IdEntite")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionDeCampagneBack.Models.Role", "IdRoleNavigation")
                        .WithMany("Utilisateurs")
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdEntiteNavigation");

                    b.Navigation("IdRoleNavigation");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.Variable", b =>
                {
                    b.HasOne("GestionDeCampagneBack.Models.Contact", "IdContactNavigation")
                        .WithMany("Variables")
                        .HasForeignKey("IdContact")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdContactNavigation");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.Campagne", b =>
                {
                    b.Navigation("InfosMessageCampagnes");

                    b.Navigation("ListeDffCampagnes");

                    b.Navigation("ModeleCampagnes");

                    b.Navigation("SuiviCampagneCampagnes");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.CanalEnvoi", b =>
                {
                    b.Navigation("ContactCanals");

                    b.Navigation("Modeles");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.Contact", b =>
                {
                    b.Navigation("ContactCanals");

                    b.Navigation("ContactListeDiffusions");

                    b.Navigation("SuiviCampagnes");

                    b.Navigation("Variables");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.Entite", b =>
                {
                    b.Navigation("Utilisateurs");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.InfosMessage", b =>
                {
                    b.Navigation("InfosMessageCampagnes");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.ListeDeDiffusion", b =>
                {
                    b.Navigation("ContactListeDiffusions");

                    b.Navigation("ListeDffCampagnes");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.Modele", b =>
                {
                    b.Navigation("ModeleCampagnes");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.NiveauDeVisibilite", b =>
                {
                    b.Navigation("Campagnes");

                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.RegleDEnvoi", b =>
                {
                    b.Navigation("Campagnes");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.Role", b =>
                {
                    b.Navigation("Utilisateurs");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.SuiviCampagne", b =>
                {
                    b.Navigation("SuiviCampagneCampagnes");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.TypeDeCampagne", b =>
                {
                    b.Navigation("Campagnes");
                });

            modelBuilder.Entity("GestionDeCampagneBack.Models.Utilisateur", b =>
                {
                    b.Navigation("Campagnes");

                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}
