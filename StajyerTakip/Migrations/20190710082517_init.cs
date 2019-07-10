using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StajyerTakip.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Birim",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(nullable: true),
                    Aciklama = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birim", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hesaplar",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(nullable: true),
                    Soyad = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Sifre = table.Column<string>(nullable: true),
                    KullaniciAdi = table.Column<string>(nullable: true),
                    Resim = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    Adres = table.Column<string>(nullable: true),
                    Rol = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hesaplar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Proje",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ad = table.Column<string>(nullable: true),
                    Icerik = table.Column<string>(nullable: true),
                    TanimlananSure = table.Column<int>(nullable: false),
                    KullanilanTeknolojiler = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proje", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BirimKoordinatorleri",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProfilID = table.Column<int>(nullable: false),
                    BirimID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirimKoordinatorleri", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BirimKoordinatorleri_Birim_BirimID",
                        column: x => x.BirimID,
                        principalTable: "Birim",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BirimKoordinatorleri_Hesaplar_ProfilID",
                        column: x => x.ProfilID,
                        principalTable: "Hesaplar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stajyerler",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProfilID = table.Column<int>(nullable: false),
                    Okul = table.Column<string>(nullable: true),
                    Bolum = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stajyerler", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stajyerler_Hesaplar_ProfilID",
                        column: x => x.ProfilID,
                        principalTable: "Hesaplar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjeBirim",
                columns: table => new
                {
                    ProjeID = table.Column<int>(nullable: false),
                    BirimKoordinatoruID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjeBirim", x => new { x.ProjeID, x.BirimKoordinatoruID });
                    table.ForeignKey(
                        name: "FK_ProjeBirim_BirimKoordinatorleri_BirimKoordinatoruID",
                        column: x => x.BirimKoordinatoruID,
                        principalTable: "BirimKoordinatorleri",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjeBirim_Proje_ProjeID",
                        column: x => x.ProjeID,
                        principalTable: "Proje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Devamsizlik",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StajyerID = table.Column<int>(nullable: false),
                    Tarih = table.Column<DateTime>(nullable: false),
                    BirimKoordinatoruID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devamsizlik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Devamsizlik_BirimKoordinatorleri_BirimKoordinatoruID",
                        column: x => x.BirimKoordinatoruID,
                        principalTable: "BirimKoordinatorleri",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Devamsizlik_Stajyerler_StajyerID",
                        column: x => x.StajyerID,
                        principalTable: "Stajyerler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gunluk",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OgrenciID = table.Column<int>(nullable: false),
                    Baslik = table.Column<string>(nullable: true),
                    Bilgiler = table.Column<string>(nullable: true),
                    OnayDurumu = table.Column<bool>(nullable: false),
                    Tarih = table.Column<DateTime>(nullable: false),
                    BirimKoordinatoruID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gunluk", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Gunluk_BirimKoordinatorleri_BirimKoordinatoruID",
                        column: x => x.BirimKoordinatoruID,
                        principalTable: "BirimKoordinatorleri",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Gunluk_Stajyerler_OgrenciID",
                        column: x => x.OgrenciID,
                        principalTable: "Stajyerler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StajyerBirimK",
                columns: table => new
                {
                    StajyerID = table.Column<int>(nullable: false),
                    BirimKID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StajyerBirimK", x => new { x.StajyerID, x.BirimKID });
                    table.ForeignKey(
                        name: "FK_StajyerBirimK_BirimKoordinatorleri_BirimKID",
                        column: x => x.BirimKID,
                        principalTable: "BirimKoordinatorleri",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StajyerBirimK_Stajyerler_StajyerID",
                        column: x => x.StajyerID,
                        principalTable: "Stajyerler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StajyerProje",
                columns: table => new
                {
                    StajyerID = table.Column<int>(nullable: false),
                    ProjeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StajyerProje", x => new { x.StajyerID, x.ProjeID });
                    table.ForeignKey(
                        name: "FK_StajyerProje_Proje_ProjeID",
                        column: x => x.ProjeID,
                        principalTable: "Proje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StajyerProje_Stajyerler_StajyerID",
                        column: x => x.StajyerID,
                        principalTable: "Stajyerler",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EkDosya",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GunlukID = table.Column<int>(nullable: false),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EkDosya", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EkDosya_Gunluk_GunlukID",
                        column: x => x.GunlukID,
                        principalTable: "Gunluk",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BirimKoordinatorleri_BirimID",
                table: "BirimKoordinatorleri",
                column: "BirimID");

            migrationBuilder.CreateIndex(
                name: "IX_BirimKoordinatorleri_ProfilID",
                table: "BirimKoordinatorleri",
                column: "ProfilID");

            migrationBuilder.CreateIndex(
                name: "IX_Devamsizlik_BirimKoordinatoruID",
                table: "Devamsizlik",
                column: "BirimKoordinatoruID");

            migrationBuilder.CreateIndex(
                name: "IX_Devamsizlik_StajyerID",
                table: "Devamsizlik",
                column: "StajyerID");

            migrationBuilder.CreateIndex(
                name: "IX_EkDosya_GunlukID",
                table: "EkDosya",
                column: "GunlukID");

            migrationBuilder.CreateIndex(
                name: "IX_Gunluk_BirimKoordinatoruID",
                table: "Gunluk",
                column: "BirimKoordinatoruID");

            migrationBuilder.CreateIndex(
                name: "IX_Gunluk_OgrenciID",
                table: "Gunluk",
                column: "OgrenciID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjeBirim_BirimKoordinatoruID",
                table: "ProjeBirim",
                column: "BirimKoordinatoruID");

            migrationBuilder.CreateIndex(
                name: "IX_StajyerBirimK_BirimKID",
                table: "StajyerBirimK",
                column: "BirimKID");

            migrationBuilder.CreateIndex(
                name: "IX_Stajyerler_ProfilID",
                table: "Stajyerler",
                column: "ProfilID");

            migrationBuilder.CreateIndex(
                name: "IX_StajyerProje_ProjeID",
                table: "StajyerProje",
                column: "ProjeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devamsizlik");

            migrationBuilder.DropTable(
                name: "EkDosya");

            migrationBuilder.DropTable(
                name: "ProjeBirim");

            migrationBuilder.DropTable(
                name: "StajyerBirimK");

            migrationBuilder.DropTable(
                name: "StajyerProje");

            migrationBuilder.DropTable(
                name: "Gunluk");

            migrationBuilder.DropTable(
                name: "Proje");

            migrationBuilder.DropTable(
                name: "BirimKoordinatorleri");

            migrationBuilder.DropTable(
                name: "Stajyerler");

            migrationBuilder.DropTable(
                name: "Birim");

            migrationBuilder.DropTable(
                name: "Hesaplar");
        }
    }
}
