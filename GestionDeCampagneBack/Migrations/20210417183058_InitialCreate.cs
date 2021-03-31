using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionDeCampagneBack.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catégorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libellé = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catégorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Prenom = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Adresse = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Etat = table.Column<bool>(type: "bit", nullable: true),
                    Statut = table.Column<bool>(type: "bit", nullable: true),
                    Pays = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Region = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Anniverssaire = table.Column<DateTime>(type: "date", nullable: true),
                    Tel = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Sexe = table.Column<bool>(type: "bit", nullable: true),
                    Situation = table.Column<bool>(type: "bit", nullable: true),
                    Profession = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Infos_Message",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message_Prevu = table.Column<int>(type: "int", nullable: true),
                    Message_Acheminés = table.Column<int>(type: "int", nullable: true),
                    Message_en_cours = table.Column<int>(type: "int", nullable: true),
                    Message_erreur = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infos_Message", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modèle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libellé = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Contenu = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Statut = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modèle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regle_dEnvoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Tentative = table.Column<int>(type: "int", nullable: true),
                    Frequence = table.Column<int>(type: "int", nullable: true),
                    DateExecution = table.Column<DateTime>(type: "datetime", nullable: true),
                    Expediteur = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Recepteur = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Fuseau_horaire = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regle_dEnvoi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Type_de_campagne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libellé = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_de_campagne", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Prenom = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Login = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Motdepasse = table.Column<string>(name: "Mot de passe", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Etat = table.Column<bool>(type: "bit", nullable: true),
                    Statut = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact_Canal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lien = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Etat = table.Column<bool>(type: "bit", nullable: true),
                    DateDesa = table.Column<DateTime>(type: "date", nullable: true),
                    Raison = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Id_Contact = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact_Canal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Canal_Contact",
                        column: x => x.Id_Contact,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contact_Liste_diffusion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Etat = table.Column<bool>(type: "bit", nullable: true),
                    DateDesa = table.Column<DateTime>(type: "date", nullable: true),
                    Raison = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Id_Contact = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact_Liste_diffusion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Liste_diffusion_Contact",
                        column: x => x.Id_Contact,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Suivi_campagne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEnvoi = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateReact = table.Column<DateTime>(type: "datetime", nullable: true),
                    Reaction = table.Column<bool>(type: "bit", nullable: true),
                    Contenu = table.Column<string>(type: "text", nullable: true),
                    Statut = table.Column<bool>(type: "bit", nullable: true),
                    Nombre_de_tentative = table.Column<int>(type: "int", nullable: true),
                    Id_Contact = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suivi_campagne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suivi_campagne_Contact",
                        column: x => x.Id_Contact,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Variable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomAffichage = table.Column<byte[]>(type: "varbinary(50)", maxLength: 50, nullable: true),
                    NomTechnique = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Valeur = table.Column<int>(type: "int", nullable: true),
                    TailleMax = table.Column<int>(type: "int", nullable: true),
                    Id_Contact = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variable_Contact",
                        column: x => x.Id_Contact,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libellé = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Id_utilisateur = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Role_Utilisateur",
                        column: x => x.Id_utilisateur,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Canal_envoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Etat = table.Column<bool>(type: "bit", nullable: true),
                    Id_Conatct_Canal = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canal_envoi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Canal_envoi_Contact_Canal",
                        column: x => x.Id_Conatct_Canal,
                        principalTable: "Contact_Canal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Liste_de_diffusion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Reference = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Etat = table.Column<bool>(type: "bit", nullable: true),
                    Statut = table.Column<bool>(type: "bit", nullable: true),
                    Id_Contact_Liste_Diffusion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liste_de_diffusion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Liste_de_diffusion_Contact_Liste_diffusion",
                        column: x => x.Id_Contact_Liste_Diffusion,
                        principalTable: "Contact_Liste_diffusion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Niveau_de_visibilite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libellé = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: true),
                    Id_Conatct = table.Column<int>(type: "int", nullable: true),
                    Id_Contact_Liste_diffusion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveau_de_visibilite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Niveau_de_visibilite_Contact",
                        column: x => x.Id_Conatct,
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Niveau_de_visibilite_Contact_Liste_diffusion",
                        column: x => x.Id_Contact_Liste_diffusion,
                        principalTable: "Contact_Liste_diffusion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Campagne",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Titre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Code = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Datededébut = table.Column<DateTime>(name: "Date de début", type: "date", nullable: true),
                    Datedefin = table.Column<DateTime>(name: "Date de fin", type: "date", nullable: true),
                    Etat = table.Column<bool>(type: "bit", nullable: true),
                    Statut = table.Column<bool>(type: "bit", nullable: true),
                    Id_utilisateur = table.Column<int>(type: "int", nullable: true),
                    Id_Regle_envoi = table.Column<int>(type: "int", nullable: true),
                    Id_Niveau_visibilité = table.Column<int>(type: "int", nullable: true),
                    Id_Type_campagne = table.Column<int>(type: "int", nullable: true),
                    Id_Categorie = table.Column<int>(type: "int", nullable: true),
                    Id_Canal_envoi = table.Column<int>(type: "int", nullable: true),
                    Id_Infos_message = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campagne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campagne_Canal_envoi",
                        column: x => x.Id_Canal_envoi,
                        principalTable: "Canal_envoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campagne_Catégorie",
                        column: x => x.Id_Categorie,
                        principalTable: "Catégorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campagne_Infos_Message",
                        column: x => x.Id_Infos_message,
                        principalTable: "Infos_Message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campagne_Niveau_de_visibilite",
                        column: x => x.Id_Niveau_visibilité,
                        principalTable: "Niveau_de_visibilite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campagne_Regle_dEnvoi",
                        column: x => x.Id_Regle_envoi,
                        principalTable: "Regle_dEnvoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campagne_Type_de_campagne",
                        column: x => x.Id_Type_campagne,
                        principalTable: "Type_de_campagne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Campagne_Utilisateur",
                        column: x => x.Id_utilisateur,
                        principalTable: "Utilisateur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListeDffCampagne",
                columns: table => new
                {
                    Id_Campagne = table.Column<int>(type: "int", nullable: true),
                    Id_Liste = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ListeDffCampagne",
                        column: x => x.Id_Campagne,
                        principalTable: "Campagne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListeDffCampagne_Liste_de_diffusion_Id",
                        column: x => x.Id_Liste,
                        principalTable: "Liste_de_diffusion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Modèle_campagne",
                columns: table => new
                {
                    Id_campagne = table.Column<int>(type: "int", nullable: true),
                    Id_Modèle = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Modèle_campagne",
                        column: x => x.Id_campagne,
                        principalTable: "Campagne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Modèle_campagne_Modèle_Id",
                        column: x => x.Id_Modèle,
                        principalTable: "Modèle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SuiviCampagne_Campagne",
                columns: table => new
                {
                    Id_campagne = table.Column<int>(type: "int", nullable: true),
                    Id_Suivi = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_SuiviCampagne_Campagne_Campagne_Id",
                        column: x => x.Id_campagne,
                        principalTable: "Campagne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SuiviCampagne_Campagne_Suivi_campagne_Id",
                        column: x => x.Id_Suivi,
                        principalTable: "Suivi_campagne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campagne_Id_Canal_envoi",
                table: "Campagne",
                column: "Id_Canal_envoi");

            migrationBuilder.CreateIndex(
                name: "IX_Campagne_Id_Categorie",
                table: "Campagne",
                column: "Id_Categorie");

            migrationBuilder.CreateIndex(
                name: "IX_Campagne_Id_Infos_message",
                table: "Campagne",
                column: "Id_Infos_message");

            migrationBuilder.CreateIndex(
                name: "IX_Campagne_Id_Niveau_visibilité",
                table: "Campagne",
                column: "Id_Niveau_visibilité");

            migrationBuilder.CreateIndex(
                name: "IX_Campagne_Id_Regle_envoi",
                table: "Campagne",
                column: "Id_Regle_envoi");

            migrationBuilder.CreateIndex(
                name: "IX_Campagne_Id_Type_campagne",
                table: "Campagne",
                column: "Id_Type_campagne");

            migrationBuilder.CreateIndex(
                name: "IX_Campagne_Id_utilisateur",
                table: "Campagne",
                column: "Id_utilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Canal_envoi_Id_Conatct_Canal",
                table: "Canal_envoi",
                column: "Id_Conatct_Canal");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Canal_Id_Contact",
                table: "Contact_Canal",
                column: "Id_Contact");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Liste_diffusion_Id_Contact",
                table: "Contact_Liste_diffusion",
                column: "Id_Contact");

            migrationBuilder.CreateIndex(
                name: "IX_Liste_de_diffusion_Id_Contact_Liste_Diffusion",
                table: "Liste_de_diffusion",
                column: "Id_Contact_Liste_Diffusion");

            migrationBuilder.CreateIndex(
                name: "IX_ListeDffCampagne_Id_Campagne",
                table: "ListeDffCampagne",
                column: "Id_Campagne");

            migrationBuilder.CreateIndex(
                name: "IX_ListeDffCampagne_Id_Liste",
                table: "ListeDffCampagne",
                column: "Id_Liste");

            migrationBuilder.CreateIndex(
                name: "IX_Modèle_campagne_Id_campagne",
                table: "Modèle_campagne",
                column: "Id_campagne");

            migrationBuilder.CreateIndex(
                name: "IX_Modèle_campagne_Id_Modèle",
                table: "Modèle_campagne",
                column: "Id_Modèle");

            migrationBuilder.CreateIndex(
                name: "IX_Niveau_de_visibilite_Id_Conatct",
                table: "Niveau_de_visibilite",
                column: "Id_Conatct");

            migrationBuilder.CreateIndex(
                name: "IX_Niveau_de_visibilite_Id_Contact_Liste_diffusion",
                table: "Niveau_de_visibilite",
                column: "Id_Contact_Liste_diffusion");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Id_utilisateur",
                table: "Role",
                column: "Id_utilisateur");

            migrationBuilder.CreateIndex(
                name: "IX_Suivi_campagne_Id_Contact",
                table: "Suivi_campagne",
                column: "Id_Contact");

            migrationBuilder.CreateIndex(
                name: "IX_SuiviCampagne_Campagne_Id_campagne",
                table: "SuiviCampagne_Campagne",
                column: "Id_campagne");

            migrationBuilder.CreateIndex(
                name: "IX_SuiviCampagne_Campagne_Id_Suivi",
                table: "SuiviCampagne_Campagne",
                column: "Id_Suivi");

            migrationBuilder.CreateIndex(
                name: "IX_Variable_Id_Contact",
                table: "Variable",
                column: "Id_Contact");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListeDffCampagne");

            migrationBuilder.DropTable(
                name: "Modèle_campagne");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "SuiviCampagne_Campagne");

            migrationBuilder.DropTable(
                name: "Variable");

            migrationBuilder.DropTable(
                name: "Liste_de_diffusion");

            migrationBuilder.DropTable(
                name: "Modèle");

            migrationBuilder.DropTable(
                name: "Campagne");

            migrationBuilder.DropTable(
                name: "Suivi_campagne");

            migrationBuilder.DropTable(
                name: "Canal_envoi");

            migrationBuilder.DropTable(
                name: "Catégorie");

            migrationBuilder.DropTable(
                name: "Infos_Message");

            migrationBuilder.DropTable(
                name: "Niveau_de_visibilite");

            migrationBuilder.DropTable(
                name: "Regle_dEnvoi");

            migrationBuilder.DropTable(
                name: "Type_de_campagne");

            migrationBuilder.DropTable(
                name: "Utilisateur");

            migrationBuilder.DropTable(
                name: "Contact_Canal");

            migrationBuilder.DropTable(
                name: "Contact_Liste_diffusion");

            migrationBuilder.DropTable(
                name: "Contact");
        }
    }
}
