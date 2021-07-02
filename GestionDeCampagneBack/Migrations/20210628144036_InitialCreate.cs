using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionDeCampagneBack.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CanalEnvois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etat = table.Column<bool>(type: "bit", nullable: false),
                    IdEntite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanalEnvois", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Activite = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListeDeDiffusions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Etat = table.Column<bool>(type: "bit", nullable: false),
                    Statut = table.Column<bool>(type: "bit", nullable: false),
                    IdEntite = table.Column<int>(type: "int", nullable: false),
                    IdNiveauVisibilite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListeDeDiffusions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NiveauDeVisibilites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NiveauDeVisibilites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegleDEnvois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTentative = table.Column<int>(type: "int", nullable: true),
                    Frequence = table.Column<int>(type: "int", nullable: true),
                    DateExecution = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Expediteur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recepteur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuseauHoraire = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IdEntite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegleDEnvois", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeDeCampagnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdEntite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDeCampagnes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modeles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contenu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Statut = table.Column<bool>(type: "bit", nullable: false),
                    IdEntite = table.Column<int>(type: "int", nullable: false),
                    IdCanalEnvoi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modeles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modeles_CanalEnvois_IdCanalEnvoi",
                        column: x => x.IdCanalEnvoi,
                        principalTable: "CanalEnvois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etat = table.Column<bool>(type: "bit", nullable: false),
                    Statut = table.Column<bool>(type: "bit", nullable: false),
                    Ischange = table.Column<bool>(type: "bit", nullable: false),
                    IdRole = table.Column<int>(type: "int", nullable: false),
                    IdEntite = table.Column<int>(type: "int", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Entites_IdEntite",
                        column: x => x.IdEntite,
                        principalTable: "Entites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Utilisateurs_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Campagnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDeDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateDeFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Etat = table.Column<bool>(type: "bit", nullable: false),
                    Statut = table.Column<bool>(type: "bit", nullable: false),
                    IdUtilisateur = table.Column<int>(type: "int", nullable: false),
                    IdRegleEnvoi = table.Column<int>(type: "int", nullable: false),
                    IdNiveauVisibilite = table.Column<int>(type: "int", nullable: false),
                    IdTypeCampagne = table.Column<int>(type: "int", nullable: false),
                    IdEntite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campagnes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campagnes_NiveauDeVisibilites_IdNiveauVisibilite",
                        column: x => x.IdNiveauVisibilite,
                        principalTable: "NiveauDeVisibilites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campagnes_RegleDEnvois_IdRegleEnvoi",
                        column: x => x.IdRegleEnvoi,
                        principalTable: "RegleDEnvois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campagnes_TypeDeCampagnes_IdTypeCampagne",
                        column: x => x.IdTypeCampagne,
                        principalTable: "TypeDeCampagnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Campagnes_Utilisateurs_IdUtilisateur",
                        column: x => x.IdUtilisateur,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Matricule = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Etat = table.Column<bool>(type: "bit", nullable: false),
                    Statut = table.Column<bool>(type: "bit", nullable: false),
                    Pays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDeNaissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sexe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Situation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdNiveauVisibilite = table.Column<int>(type: "int", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_NiveauDeVisibilites_IdNiveauVisibilite",
                        column: x => x.IdNiveauVisibilite,
                        principalTable: "NiveauDeVisibilites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contacts_Utilisateurs_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Utilisateurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfosMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessagePrevu = table.Column<int>(type: "int", nullable: false),
                    MessageAchemines = table.Column<int>(type: "int", nullable: true),
                    MessageEnCours = table.Column<int>(type: "int", nullable: true),
                    MessageErreur = table.Column<int>(type: "int", nullable: true),
                    IdCampagne = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfosMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfosMessages_Campagnes_IdCampagne",
                        column: x => x.IdCampagne,
                        principalTable: "Campagnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListeDffCampagnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCampagne = table.Column<int>(type: "int", nullable: false),
                    IdListe = table.Column<int>(type: "int", nullable: false),
                    IdEntite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListeDffCampagnes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListeDffCampagnes_Campagnes_IdCampagne",
                        column: x => x.IdCampagne,
                        principalTable: "Campagnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListeDffCampagnes_ListeDeDiffusions_IdListe",
                        column: x => x.IdListe,
                        principalTable: "ListeDeDiffusions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModeleCampagnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCampagne = table.Column<int>(type: "int", nullable: false),
                    IdModele = table.Column<int>(type: "int", nullable: false),
                    IdEntite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeleCampagnes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeleCampagnes_Campagnes_IdCampagne",
                        column: x => x.IdCampagne,
                        principalTable: "Campagnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModeleCampagnes_Modeles_IdModele",
                        column: x => x.IdModele,
                        principalTable: "Modeles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactCanals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CanalDuContatct = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Etat = table.Column<bool>(type: "bit", nullable: false),
                    DateDesabonnement = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Raison = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdContact = table.Column<int>(type: "int", nullable: false),
                    IdCanalEnvoi = table.Column<int>(type: "int", nullable: false),
                    IdEntite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactCanals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactCanals_CanalEnvois_IdCanalEnvoi",
                        column: x => x.IdCanalEnvoi,
                        principalTable: "CanalEnvois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactCanals_Contacts_IdContact",
                        column: x => x.IdContact,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactListeDiffusions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Etat = table.Column<bool>(type: "bit", nullable: false),
                    DateDesa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Raison = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdContact = table.Column<int>(type: "int", nullable: false),
                    IdListeDiffusion = table.Column<int>(type: "int", nullable: false),
                    IdEntite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactListeDiffusions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactListeDiffusions_Contacts_IdContact",
                        column: x => x.IdContact,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactListeDiffusions_ListeDeDiffusions_IdListeDiffusion",
                        column: x => x.IdListeDiffusion,
                        principalTable: "ListeDeDiffusions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuiviCampagnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEnvoi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contenu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Statut = table.Column<bool>(type: "bit", nullable: false),
                    NombreDeTentative = table.Column<int>(type: "int", nullable: true),
                    IdContact = table.Column<int>(type: "int", nullable: false),
                    IdEntite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuiviCampagnes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuiviCampagnes_Contacts_IdContact",
                        column: x => x.IdContact,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Variables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomAffichage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NomTechnique = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valeur = table.Column<int>(type: "int", nullable: true),
                    TailleMax = table.Column<int>(type: "int", nullable: true),
                    IdContact = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variables_Contacts_IdContact",
                        column: x => x.IdContact,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InfosMessageCampagne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCampagne = table.Column<int>(type: "int", nullable: false),
                    IdCampagneNavigationId = table.Column<int>(type: "int", nullable: true),
                    IdInfosMessage = table.Column<int>(type: "int", nullable: false),
                    IdInfosMessageNavigationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfosMessageCampagne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfosMessageCampagne_Campagnes_IdCampagneNavigationId",
                        column: x => x.IdCampagneNavigationId,
                        principalTable: "Campagnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InfosMessageCampagne_InfosMessages_IdInfosMessageNavigationId",
                        column: x => x.IdInfosMessageNavigationId,
                        principalTable: "InfosMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SuiviCampagneCampagnes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCampagne = table.Column<int>(type: "int", nullable: false),
                    IdSuivi = table.Column<int>(type: "int", nullable: false),
                    IdCampagneNavigationId = table.Column<int>(type: "int", nullable: true),
                    IdSuiviNavigationId = table.Column<int>(type: "int", nullable: true),
                    IdEntite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuiviCampagneCampagnes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuiviCampagneCampagnes_Campagnes_IdCampagneNavigationId",
                        column: x => x.IdCampagneNavigationId,
                        principalTable: "Campagnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SuiviCampagneCampagnes_SuiviCampagnes_IdSuiviNavigationId",
                        column: x => x.IdSuiviNavigationId,
                        principalTable: "SuiviCampagnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campagnes_Code",
                table: "Campagnes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Campagnes_IdNiveauVisibilite",
                table: "Campagnes",
                column: "IdNiveauVisibilite");

            migrationBuilder.CreateIndex(
                name: "IX_Campagnes_IdRegleEnvoi",
                table: "Campagnes",
                column: "IdRegleEnvoi");

            migrationBuilder.CreateIndex(
                name: "IX_Campagnes_IdTypeCampagne",
                table: "Campagnes",
                column: "IdTypeCampagne");

            migrationBuilder.CreateIndex(
                name: "IX_Campagnes_IdUtilisateur",
                table: "Campagnes",
                column: "IdUtilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_ContactCanals_IdCanalEnvoi",
                table: "ContactCanals",
                column: "IdCanalEnvoi");

            migrationBuilder.CreateIndex(
                name: "IX_ContactCanals_IdContact",
                table: "ContactCanals",
                column: "IdContact");

            migrationBuilder.CreateIndex(
                name: "IX_ContactListeDiffusions_Code",
                table: "ContactListeDiffusions",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactListeDiffusions_IdContact",
                table: "ContactListeDiffusions",
                column: "IdContact");

            migrationBuilder.CreateIndex(
                name: "IX_ContactListeDiffusions_IdListeDiffusion",
                table: "ContactListeDiffusions",
                column: "IdListeDiffusion");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_IdNiveauVisibilite",
                table: "Contacts",
                column: "IdNiveauVisibilite");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_IdUser",
                table: "Contacts",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_Matricule",
                table: "Contacts",
                column: "Matricule",
                unique: true,
                filter: "[Matricule] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InfosMessageCampagne_IdCampagneNavigationId",
                table: "InfosMessageCampagne",
                column: "IdCampagneNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_InfosMessageCampagne_IdInfosMessageNavigationId",
                table: "InfosMessageCampagne",
                column: "IdInfosMessageNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_InfosMessages_IdCampagne",
                table: "InfosMessages",
                column: "IdCampagne");

            migrationBuilder.CreateIndex(
                name: "IX_ListeDeDiffusions_Reference",
                table: "ListeDeDiffusions",
                column: "Reference",
                unique: true,
                filter: "[Reference] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ListeDffCampagnes_IdCampagne",
                table: "ListeDffCampagnes",
                column: "IdCampagne");

            migrationBuilder.CreateIndex(
                name: "IX_ListeDffCampagnes_IdListe",
                table: "ListeDffCampagnes",
                column: "IdListe");

            migrationBuilder.CreateIndex(
                name: "IX_ModeleCampagnes_IdCampagne",
                table: "ModeleCampagnes",
                column: "IdCampagne");

            migrationBuilder.CreateIndex(
                name: "IX_ModeleCampagnes_IdModele",
                table: "ModeleCampagnes",
                column: "IdModele");

            migrationBuilder.CreateIndex(
                name: "IX_Modeles_IdCanalEnvoi",
                table: "Modeles",
                column: "IdCanalEnvoi");

            migrationBuilder.CreateIndex(
                name: "IX_NiveauDeVisibilites_Libelle",
                table: "NiveauDeVisibilites",
                column: "Libelle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Libelle",
                table: "Roles",
                column: "Libelle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SuiviCampagneCampagnes_IdCampagneNavigationId",
                table: "SuiviCampagneCampagnes",
                column: "IdCampagneNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_SuiviCampagneCampagnes_IdSuiviNavigationId",
                table: "SuiviCampagneCampagnes",
                column: "IdSuiviNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_SuiviCampagnes_IdContact",
                table: "SuiviCampagnes",
                column: "IdContact");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_IdEntite",
                table: "Utilisateurs",
                column: "IdEntite");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_IdRole",
                table: "Utilisateurs",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateurs_Login",
                table: "Utilisateurs",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Variables_IdContact",
                table: "Variables",
                column: "IdContact");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactCanals");

            migrationBuilder.DropTable(
                name: "ContactListeDiffusions");

            migrationBuilder.DropTable(
                name: "InfosMessageCampagne");

            migrationBuilder.DropTable(
                name: "ListeDffCampagnes");

            migrationBuilder.DropTable(
                name: "ModeleCampagnes");

            migrationBuilder.DropTable(
                name: "SuiviCampagneCampagnes");

            migrationBuilder.DropTable(
                name: "Variables");

            migrationBuilder.DropTable(
                name: "InfosMessages");

            migrationBuilder.DropTable(
                name: "ListeDeDiffusions");

            migrationBuilder.DropTable(
                name: "Modeles");

            migrationBuilder.DropTable(
                name: "SuiviCampagnes");

            migrationBuilder.DropTable(
                name: "Campagnes");

            migrationBuilder.DropTable(
                name: "CanalEnvois");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "RegleDEnvois");

            migrationBuilder.DropTable(
                name: "TypeDeCampagnes");

            migrationBuilder.DropTable(
                name: "NiveauDeVisibilites");

            migrationBuilder.DropTable(
                name: "Utilisateurs");

            migrationBuilder.DropTable(
                name: "Entites");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
