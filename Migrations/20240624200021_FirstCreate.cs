﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OmgShoes.Migrations
{
    /// <inheritdoc />
    public partial class FirstCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    FriendId = table.Column<int>(type: "integer", nullable: false),
                    FriendName = table.Column<string>(type: "text", nullable: true),
                    FriendAvatar = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserShoeId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Style = table.Column<string>(type: "text", nullable: true),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    ModelNumber = table.Column<string>(type: "text", nullable: true),
                    Colorway = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserShoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ShoeId = table.Column<int>(type: "integer", nullable: false),
                    Style = table.Column<string>(type: "text", nullable: true),
                    ShoeSize = table.Column<string>(type: "text", nullable: true),
                    ConditionId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserShoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    Avatar = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    IdentityUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    UserShoeId = table.Column<int>(type: "integer", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsEdited = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_UserProfiles_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", null, "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "f4781008-9c82-4392-8052-e33fee7a2ee3", "dee@reynolds.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEJQcAIfVWsNN3F8JcSbDk3xEf0CoZn8VQkSBCm7FzlwDZF811Rp5E5qHWyWMVrweaA==", null, false, "1697db45-9df4-482d-96e0-06eb5a695f22", false, "Dee" },
                    { "frt98wr5-0223-3ww7-t6rq-028g4r521d4e", 0, "f44b24eb-0a2b-4ddc-8f4a-9a747e8e57f5", "dennis@reynolds.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEIp9yfQCaRGhOKH8dG0pPLZAYLvzX8Xwir4ckGrnbTgIBcfKsVvOCrKMe8+GWWl82g==", null, false, "854d7289-dffc-411c-b634-c45338b1f9ee", false, "Dennis" },
                    { "hdp65oa9-3053-5ap0-z0hh-235t2a098h8q", 0, "f7cedff1-106e-4eb7-89da-8bf9b83d3e13", "frank@reynolds.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEGa07Y1EtXdqgSF1mID9FrvE3/7NvQUNf2oR4ltlfL/CQSAj1dsmqyOHptEcp2WIHA==", null, false, "1c32fa6e-b2e2-415a-aa3d-03b6e8b83dcb", false, "Frank" },
                    { "rfv98hu4-3206-4gga-t8ws-457k5v543l6r", 0, "893c85fc-4695-4489-ba0c-e68c42560edc", "the@waitress.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEE1YfnmAUIxcQV2EMGla+h0kGzDxs2zkUOBPWprdM1JlXdaaBCUe6IfNygvTVc8BJg==", null, false, "aa2500e0-fabb-4f30-93e6-6b90713c7a35", false, "Waitress" },
                    { "rse05dd6-2058-3bg0-a3oo-204t2l308f3p", 0, "f6bd1b8e-9133-4d72-8ab4-d3e15c3476da", "ronald@macdonald.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEBFGPkLBJznykA0ocv009Q2ofun7Af38LzVjIhxlLXNoYYMvIhpnzxnfOYsdABcxhA==", null, false, "32224a59-eff7-44a7-921b-7fc16a137ad9", false, "Ronald" },
                    { "wmo20ow7-0582-9pp1-i8sl-037h7w843j8r", 0, "b3315e3d-7621-413c-9176-484bd646fb8b", "charlie@kelly.com", false, false, null, null, null, "AQAAAAIAAYagAAAAEBzrM0Uh89FiVgnC0t138hNxMvlxBeqC2t3W+DC0fdAvYzmpJVdIDw8BbQdkp9vCmw==", null, false, "88b064da-5442-4d13-98db-42bb7cae428a", false, "Charlie" }
                });

            migrationBuilder.InsertData(
                table: "Conditions",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Deadstock" },
                    { 2, "Worn 1-10x" },
                    { 3, "Used" },
                    { 4, "Very Used" },
                    { 5, "Thrashed" }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "UserId", "UserShoeId" },
                values: new object[,]
                {
                    { 1, 6, 11 },
                    { 2, 6, 12 },
                    { 3, 4, 6 },
                    { 4, 6, 6 },
                    { 5, 5, 49 },
                    { 6, 5, 50 },
                    { 7, 5, 52 },
                    { 8, 5, 36 },
                    { 9, 5, 37 }
                });

            migrationBuilder.InsertData(
                table: "Shoes",
                columns: new[] { "Id", "Colorway", "Image", "ModelNumber", "Name", "Style", "Year" },
                values: new object[,]
                {
                    { 1, "WHITE/ORION BLUE-WHITE", "/shoes/mulder.jpg", "304292-141", "Richard Mulder", "Low", 2002 },
                    { 2, "SAFETY ORANGE/HYPER BLUE-WHITE", "/shoes/danny-supa.jpg", "304292-841", "Danny Supa", "Low", 2002 },
                    { 3, "WHEAT/TWIG-DUNE", "/shoes/reese-forbes-wheat.jpg", "304292-731", "Reese Forbes Wheat", "Low", 2002 },
                    { 4, "OBSIDIAN/LIGHT GRAPHITE-BLACK", "/shoes/gino-iannucci.jpg", "304292_401", "Gino Iannucci 1", "Low", 2002 },
                    { 5, "PAUL BROWN/BLACK", "/shoes/zoo-york.jpg", "305162-201", "Zoo York", "Low", 2002 },
                    { 6, "ANTHRACITE/BLACK", "/shoes/chocolate.jpg", "305162-001", "Chocolate", "Low", 2002 },
                    { 7, "BLACK/BLACK-CEMENT GREY", "/shoes/supreme-black.jpg", "304292-131", "Supreme Black", "Low", 2002 },
                    { 8, "WHITE/BLACK-CEMENT GREY", "/shoes/supreme-white.jpg", "304292-001", "Supreme White", "Low", 2002 },
                    { 9, "DARK LODEN/BLACK", "/shoes/loden.jpg", "304292-301", "Loden", "Low", 2002 },
                    { 10, "NIGHTSHADE/TEAM RED-SHARK", "/shoes/shark.jpg", "304292-361", "Sharks", "Low", 2002 },
                    { 11, "ORANGE FLASH/BLACK", "/shoes/flash.jpg", "304292-801", "Flash", "Low", 2002 },
                    { 12, "DENIM/DENIM", "/shoes/reese-forbes-denim.jpg", "304292-441", "Reese Forbes Denim", "Low", 2002 },
                    { 13, "DARK CINDER/BISON/SPORT RED", "/shoes/bison.jpg", "304292-226", "Bison", "Low", 2003 },
                    { 14, "BLACK/METALLIC GOLD/BLACK", "/shoes/takashi.jpg", "304292-072", "Takashi", "Low", 2003 },
                    { 15, "BLACK/WHITE-NIGHTSHADE-SHARK", "/shoes/futura.jpg", "304292-013", "Futura", "Low", 2003 },
                    { 16, "CLASSIC GREEN/BLACK-WHITE-RED", "/shoes/heineken.jpg", "304292-302", "Heineken", "Low", 2003 },
                    { 17, "TRUE RED/BLACK", "/shoes/true-red.jpg", "304292-601", "True Red", "Low", 2003 },
                    { 18, "BLACK/TRUE RED", "/shoes/true-black.jpg", "304292-061", "True Black", "Low", 2003 },
                    { 19, "WHITE/ORANGE BLAZE-MIDNIGHT NAVY", "/shoes/bronco.jpg", "304292-184", "Broncos", "Low", 2003 },
                    { 20, "NAVY/OUTDOOR GREEN/LIGHT CHOCOLATE", "/shoes/barf.jpg", "304292-431", "Barfs", "Low", 2003 },
                    { 21, "BLACK/BLACK", "/shoes/ostrich.jpg", "304292-003", "Ostrich", "Low", 2003 },
                    { 22, "BAROQUE BROWN/HAY/MAPLE", "/shoes/brown-pack-low.jpg", "304292-221", "Brown Pack Low", "Low", 2003 },
                    { 23, "ROPE/SPECIAL CARDINAL", "/shoes/paris.jpg", "308270-111", "Paris", "Low", 2003 },
                    { 24, "WHITE/CLASSIC GREEN-DEL SOL", "/shoes/buck.jpg", "304292-132", "Buck", "Low", 2003 },
                    { 25, "JERSEY GOLD/CASCADE BLUE", "/shoes/blue-hemp.jpg", "304292-741", "Blue Hemp", "Low", 2004 },
                    { 26, "JERSEY GOLD/RED MAHOGANY", "/shoes/burgundy-hemp.jpg", "304292-761", "Burgundy Hemp", "Low", 2004 },
                    { 27, "JERSEY GOLD/BONSAI", "/shoes/green-hemp.jpg", "304292-732", "Green Hemp", "Low", 2004 },
                    { 28, "WHITE/MEDIUM YELLOW-UNIVERSITY BLUE", "/shoes/homer.jpg", "304292-173", "Homer", "Low", 2004 },
                    { 29, "KHAKI/BAROQUE BROWN-SAFARI", "/shoes/jedi.jpg", "304292-222", "Jedi", "Low", 2004 },
                    { 30, "SHALE/SHALE", "/shoes/carhartt-shale.jpg", "304292-224", "Carhartt Shale", "Low", 2004 },
                    { 31, "BLACK/BLACK", "/shoes/carhartt-black.jpg", "304292-004", "Carhartt Black", "Low", 2004 },
                    { 32, "WHITE/COLLEGE BLUE", "/shoes/medicom-1.jpg", "304292-142", "Medicom 1", "Low", 2004 },
                    { 33, "PECAN/WHITE", "/shoes/cali.jpg", "304292-211", "Cali", "Low", 2004 },
                    { 34, "MUSLIN/MUSLIN", "/shoes/tokyo.jpg", "308268-111", "Tokyo", "Low", 2004 },
                    { 35, "SOFT GREY/MAGNET", "/shoes/london.jpg", "308269-111", "London", "Low", 2004 },
                    { 36, "BAROQUE BROWN/MUSHROOM/TWEED", "/shoes/tweed.jpg", "304292-223", "Tweed", "Low", 2004 },
                    { 37, "NATURAL BURALAP/ORANGE BLAZE", "/shoes/reese-forbes-hunter.jpg", "304292-281", "Reese Forbes Hunter", "Low", 2004 },
                    { 38, "WHITE/METALLIC GOLD0-REDWOOD", "/shoes/shanghai-1.jpg", "304292-112", "Shanghai 1", "Low", 2004 },
                    { 39, "GRIT/TEAM RED", "/shoes/grits.jpg", "304292-261", "Grits", "Low", 2004 },
                    { 40, "DARK MOCHA/CHINO", "/shoes/mocha.jpg", "304292-225", "Mocha", "Low", 2004 },
                    { 41, "MEDIUM GREY/WHITE-DARK GREY", "/shoes/nyc-pigeon.jpg", "304292-011", "NYC Pigeon", "Low", 2005 },
                    { 42, "BLACK/BLACK-GAME ROYAL", "/shoes/j-pack-blue.jpg", "304292-041", "J-Pack Blue", "Low", 2005 },
                    { 43, "ORANGE FLASH/BLACK-BLACK", "/shoes/raygun-home-black.jpg", "304292-803", "Raygun Home", "Low", 2005 },
                    { 44, "ORANGE FLASH/BLACK-WHITE", "/shoes/raygun-away-white.jpg", "304292-802", "Raygun Away", "Low", 2005 },
                    { 45, "LIGHT CHOCOLATE/WHITE", "/shoes/oompa-loompa.jpg", "304292-228", "Oompa Loompa", "Low", 2005 },
                    { 46, "WHITE/CLASSIC GREEN", "/shoes/st-patricks-day.jpg", "304292-133", "St. Patrick's Day", "Low", 2005 },
                    { 47, "VARSITY ROYAL/LIGHTNING", "/shoes/boca.jpg", "304292-471", "Boca", "Low", 2005 },
                    { 48, "LIGHT BONE/FLINT GREY", "/shoes/band-aid.jpg", "304292-006", "Band-Aid", "Low", 2005 },
                    { 49, "WHITE/WHITE", "/shoes/cinco-de-mayo.jpg", "304292-113", "Cinco de Mayo", "Low", 2005 },
                    { 50, "SHY PINK/VANILLA", "/shoes/stussy-cherry.jpg", "304292-671", "Stussy Cherry", "Low", 2005 },
                    { 51, "AQUA/CHROME", "/shoes/tiffany.jpg", "304292-402", "Tiffany", "Low", 2005 },
                    { 52, "VAPOR/MINERAL YELLOW", "/shoes/vapor.jpg", "304292-271", "Vapor", "Low", 2005 },
                    { 53, "LIGHT TAUPE/BLACK", "/shoes/slam-city.jpg", "304292-201", "Slam City", "Low", 2005 },
                    { 54, "LIGHT TAUPE/BLACK", "/shoes/shanghai-2.jpg", "304292-721", "Shanghai 2", "Low", 2005 },
                    { 55, "BLACK/BLACK", "/shoes/halloween.jpg", "304292-007", "Halloween", "Low", 2005 },
                    { 56, "BLACK/BLACK", "/shoes/medicom-2.jpg", "304292-005", "Medicom 2", "Low", 2005 },
                    { 57, "WHITE/YELLOW", "/shoes/de-la-soul.jpg", "304292-171", "De La Soul", "Low", 2005 },
                    { 58, "SILVER/CHROME", "/shoes/medicom-3.jpg", "304292-008", "Medicom 3", "Low", 2005 },
                    { 59, "WHITE/MIDNIGHT NAVY-BLUE REEF", "/shoes/avenger-blue.jpg", "304292-143", "Avenger (Blue)", "Low", 2005 },
                    { 60, "WHITE/BLACK-HYACINTH", "/shoes/avenger-purple.jpg", "304292-101", "Avenger (Purple)", "Low", 2005 },
                    { 61, "BLACK/BLACK-BLACK", "/shoes/pushead.jpg", "313233-001", "Pushead", "Low", 2005 },
                    { 62, "BLACK/BLACK-DEEP ORANGE", "/shoes/hawaii.jpg", "313170-003", "Hawaii", "Low", 2006 },
                    { 63, "WHITE/AQUA", "/shoes/high-hair.jpg", "313170-142", "High Hair", "Low", 2006 },
                    { 64, "LIGHT GRAPHITE/ANTHRACITE", "/shoes/lunar-eclipse-east.jpg", "313170-001", "Lunar Eclipse East", "Low", 2006 },
                    { 65, "STEALTH/BLACK", "/shoes/lunar-eclipse-west.jpg", "313170-002", "Lunar Eclipse West", "Low", 2006 },
                    { 66, "SPANISH MOSS/SANDALWOOD", "/shoes/spanish-moss.jpg", "304292-321", "Spanish Moss", "Low", 2006 },
                    { 67, "WHITE/VARSITY CRIMSON", "/shoes/crimson.jpg", "304292-161", "Crimson", "Low", 2006 },
                    { 68, "NET/DEEP ORANGE", "/shoes/eire.jpg", "304292-185", "Eire", "Low", 2006 },
                    { 69, "NET/MAIZE-BAROQUE BROWN", "/shoes/brown-golf.jpg", "313170-171", "Brown Golf", "Low", 2006 },
                    { 70, "WHITE/MIDNIGHT NAVY-BLUE ICE", "/shoes/blue-golf.jpg", "313170-141", "Blue Golf", "Low", 2006 },
                    { 71, "WHITE/NEPTUNE BLUE", "/shoes/neptune.jpg", "304292-144", "Neptune", "Low", 2006 },
                    { 72, "BLACK/WHITE", "/shoes/weiger.jpg", "304292-014", "Weiger", "Low", 2006 },
                    { 73, "OIL GREEN/INTERNATIONAL BLUE", "/shoes/puff-n-stuf.jpg", "313170-341", "Puff-N-Stuf", "Low", 2006 },
                    { 74, "SABLE GREEN/METALLIC GOLD", "/shoes/sbtg.jpg", "313170-201", "SBTG", "Low", 2006 },
                    { 75, "VARSITY MAIZE/BLACK", "/shoes/bic.jpg", "304292-701", "Bic", "Low", 2006 },
                    { 76, "ASH/AQUA CHALK", "/shoes/aqua-chalk.jpg", "304292-032", "Aqua Chalk", "Low", 2006 },
                    { 77, "ORANGE BLAZE/BLACK-WHITE", "/shoes/day-of-the-dead.jpg", "313170-801", "Day of the Dead", "Low", 2006 },
                    { 78, "LIGHT UMBER/GRASSHOPPER TERSIE/STRELL", "/shoes/baby-bear.jpg", "313170-731", "Baby Bear", "Low", 2006 },
                    { 79, "LIGHT GRAPHITE/PRISM VIOLET", "/shoes/purple-pigeon.jpg", "304292-051", "Purple Pigeon", "Low", 2006 },
                    { 80, "BLACK/BLACK-TEAM RED", "/shoes/mafia.jpg", "313170-004", "Mafia", "Low", 2006 },
                    { 81, "GRASS GREEN/WHITE", "/shoes/tokyo-taxi-green.jpg", "304292-311", "Tokyo Taxi Green", "Low", 2006 },
                    { 82, "CHLORINE BLUE/WHITE", "/shoes/tokyo-taxi-blue.jpg", "313170-411", "Tokyo Taxi Blue", "Low", 2006 },
                    { 83, "DARK COFFEE/DARK COFFEE", "/shoes/michael-lau.jpg", "316164-222", "Michael Lau", "Low", 2006 },
                    { 84, "DARK MOCHA/TWEED", "/shoes/tweed-2.jpg", "304292-229", "Tweed 2", "Low", 2007 },
                    { 85, "VARSITY CRIMSON/BLACK", "/shoes/milli-vanilli.jpg", "304292-602", "Mill Vanilli", "Low", 2007 },
                    { 86, "BORDER BLUE/WHITE", "/shoes/border-blue.jpg", "304292-411", "Border Blue", "Low", 2007 },
                    { 87, "GOLD DUST/METALLIC GOLD", "/shoes/money-cat.jpg", "304292-771", "Money Cat", "Low", 2007 },
                    { 88, "WHITE/BLACK-TRAIL END BROWN", "/shoes/trail-end.jpg", "304292-102", "Trail End", "Low", 2007 },
                    { 89, "BLACK/ACID", "/shoes/c-and-k.jpg", "313170-031", "C&K", "Low", 2007 },
                    { 90, "BUFF/METALLIC GOLD", "/shoes/old-spice.jpg", "304292-272", "Old Spice", "Low", 2007 },
                    { 91, "BRIGHT GOLDENROD/BLACK", "/shoes/coral-snake.jpg", "313170-701", "Coral Snake", "Low", 2007 },
                    { 92, "BLACK/METALLIC SILVER", "/shoes/takashi-2.jpg", "313170-005", "Takashi 2", "Low", 2007 },
                    { 93, "BLACK/METALLIC ZINC", "/shoes/strummer-before.jpg", "304292-902", "Strummer Before", "Low", 2007 },
                    { 94, "BLACK/METALLIC ZINC", "/shoes/strummer-after.jpg", "313170-006", "Strummer After", "Low", 2007 },
                    { 95, "WHITE/COLLEGE BLUE-CHROME-DEEP RED", "/shoes/what-the-dunk.jpg", "318403-141", "What The Dunk", "Low", 2007 },
                    { 96, "TAUPE/CHROME", "/shoes/freddy-krueger.jpg", "313170-202", "Freddy Krueger", "Low", 2007 },
                    { 97, "LIGHT BRITISH TAN/METALLIC GOLD", "/shoes/gibson.jpg", "313170-271", "Gibson", "Low", 2008 },
                    { 98, "BLACK/NEON YELLOW", "/shoes/skate-or-die.jpg", "304292-073", "Skate or Die", "Low", 2008 },
                    { 99, "ANTHRACITE/DEEP VIOLET", "/shoes/appetite-for-destruction.jpg", "304292 052", "Appetite for Destruction", "Low", 2008 },
                    { 100, "DARK CHARCOAL/LIGHT PINK", "/shoes/720-degrees.jpg", "304292-062", "720 Degrees", "Low", 2008 },
                    { 101, "GOLD/ATLANTIC BLUE", "/shoes/newcastle.jpg", "313170-741", "Newcastle", "Low", 2008 },
                    { 102, "SPORT RED/PINK CLAY", "/shoes/red-lobster.jpg", "313170-661", "Red Lobster", "Low", 2008 },
                    { 103, "BLACK/YELLOW OCHRE", "/shoes/space-tiger.jpg", "313170 071", "Space Tiger", "Low", 2008 },
                    { 104, "MAGNET/LIGHT POISON GREEN", "/shoes/poison.jpg", "304292-033", "Poison", "Low", 2008 },
                    { 105, "VARSITY ROYAL/METALLIC VEGAS GOLD", "/shoes/gold-rail.jpg", "304292-472", "Gold Rail", "Low", 2008 },
                    { 106, "ZEST/BLACK", "/shoes/piet-mondrian.jpg", "304292-702", "Piet Mondrian", "Low", 2008 },
                    { 107, "NIGHTSHADE/DARK SLATE", "/shoes/blue-lobster.jpg", "313170-342", "Blue Lobster", "Low", 2009 },
                    { 108, "CHLORINE BLUE/CERSIE", "/shoes/ms-pac-man.jpg", "313170-461", "Ms. Pac Man", "Low", 2009 },
                    { 109, "BLACK/ACADEMY-BLUE", "/shoes/patagonia.jpg", "304292-042", "Patagonia", "Low", 2009 },
                    { 110, "BLACK/BALTIC BLUE", "/shoes/angel-and-death.jpg", "313170-041", "Angel & Death", "Low", 2009 },
                    { 111, "CHUTNEY/ABYSS", "/shoes/goofy-boy.jpg", "304292-751", "Goofy Boy", "Low", 2009 },
                    { 112, "GREEN SPARK/HOOP ORANGE", "/shoes/green-spark.jpg", "313170-381", "Green Spark", "Low", 2009 },
                    { 113, "SAIL/BLACK", "/shoes/top-ramen.jpg", "313170-101", "Top Ramen", "Low", 2009 },
                    { 114, "ASPARAGUS/BLACK", "/shoes/asparagus.jpg", "313170-302", "Asparagus", "Low", 2009 },
                    { 115, "HAY/HOT RED-TERRA BROWN", "/shoes/toxic-avenger.jpg", "313170-261", "Toxic Avenger", "Low", 2009 },
                    { 116, "TEAM RED/METALLIC GOLD", "/shoes/anchorman.jpg", "3004292-672", "Anchorman", "Low", 2009 },
                    { 117, "BLUE RIBBON/METALLIC VEGAS GOLD-VARSITY RED", "/shoes/koston.jpg", "313170-400", "Koston", "Low", 2010 },
                    { 118, "MIDNIGHT FOG/BLACK-YELLOW OCHRE", "/shoes/yellow-curb.jpg", "313170-010", "Yellow Curb", "Low", 2010 },
                    { 119, "BLACK/RADIANT EMERALD-MEDIUM GREY", "/shoes/chrome-ball-incident.jpg", "304292-012", "Chrome Ball Incident", "Low", 2010 },
                    { 120, "NEUTRAL GREY/GREEN SPARK-BLACK", "/shoes/loon.jpg", "313170-011", "Loon", "Low", 2010 },
                    { 121, "BLACK/BLACK-VARSITY RED", "/shoes/larry-perkins.jpg", "313170-007", "Larry Perkins", "Low", 2010 },
                    { 122, "ARGON BLUE/WHITE", "/shoes/chun-li.jpg", "304292-405", "Chun Li", "Low", 2010 },
                    { 123, "BLACK/METALLIC GOLD-PINE GREEN", "/shoes/miller-high-life.jpg", "313170-008", "Miller High Life", "Low", 2010 }
                });

            migrationBuilder.InsertData(
                table: "UserShoes",
                columns: new[] { "Id", "ConditionId", "Description", "ShoeId", "ShoeSize", "Style", "UserId" },
                values: new object[,]
                {
                    { 1, 4, "Completely unwearable!!!", 3, "11.5", "Low", 5 },
                    { 2, 2, "Great condition for age", 9, "11.5", "Low", 5 },
                    { 3, 3, "Great condition, a bit faded", 10, "11.5", "Low", 5 },
                    { 4, 4, "FOR SALE!!!", 19, "11.5", "Low", 5 },
                    { 5, 3, "Soles have recently been replaced/swapped with brand new soles", 24, "11.5", "Low", 5 },
                    { 6, 1, "Brand New", 30, "11.5", "Low", 5 },
                    { 7, 3, "Good lookin shoe", 36, "11.5", "Low", 5 },
                    { 8, 3, "Hard to find", 38, "11", "Low", 5 },
                    { 9, 3, "Great Condition, fits like an 11.5", 39, "11", "Low", 5 },
                    { 10, 4, "Kick around shoe", 48, "11.5", "Low", 5 },
                    { 11, 3, "Good for everyday wear", 52, "11.5", "Low", 5 },
                    { 12, 3, "Sock Liner Tears", 54, "11.5", "Low", 5 },
                    { 13, 2, "Has 1 replacement insole from a pair of Blue Lobster", 66, "12", "Low", 5 },
                    { 14, 3, "Great condition!", 68, "11.5", "Low", 5 },
                    { 15, 3, "Very very faded", 73, "11", "Low", 5 },
                    { 16, 3, "Runs a little big", 75, "11.5", "Low", 5 },
                    { 17, 2, "Black laces only", 81, "11.5", "Low", 5 },
                    { 18, 4, "These don't look very used at all", 97, "11", "Low", 5 },
                    { 19, 2, "Almost brand new", 99, "11.5", "Low", 5 },
                    { 20, 3, "Great condition, one tongue strap falling apart", 100, "11.5", "Low", 5 },
                    { 21, 2, "$$$$$", 101, "11.5", "Low", 5 },
                    { 22, 4, "Everyday work shoes, sock liner tears", 103, "11.5", "Low", 5 },
                    { 23, 2, "Clean. No inner tag", 104, "12", "Low", 5 },
                    { 24, 5, "Old and beat!", 109, "11.5", "Low", 5 },
                    { 25, 5, "thrashed...", 108, "14", "Low", 3 },
                    { 26, 3, "Great condition!", 113, "7.5", "Low", 3 },
                    { 27, 4, "Need new soles", 87, "9", "Low", 3 },
                    { 28, 3, "uesd!!@", 73, "8.5", "Low", 4 },
                    { 29, 1, "testestest", 123, "9", "Low", 5 },
                    { 30, 1, "Needs a re-glue", 30, "11.5", "Low", 5 },
                    { 31, 4, "Too small!", 123, "10.5", "Low", 5 },
                    { 32, 3, "Kick arounds!", 11, "6.5", null, 6 },
                    { 33, 1, "1 of 202 ever made.", 23, "7.5", null, 6 },
                    { 34, 3, "Has the original box", 38, "5.5", null, 1 },
                    { 35, 1, "Willing to trade", 35, "7", null, 6 },
                    { 36, 5, "Heavily Skated", 120, "7.5", null, 6 },
                    { 37, 1, "Another 1 of 202 ever made.", 23, "7", null, 6 },
                    { 38, 1, "Brand New", 25, "10.5", null, 2 },
                    { 39, 1, "Brand New", 26, "10.5", null, 2 },
                    { 40, 1, "Brand New", 27, "10.5", null, 2 },
                    { 41, 1, "Brand New", 7, "10.5", null, 2 },
                    { 42, 1, "Brand New", 8, "10.5", null, 2 },
                    { 43, 1, "Brand New", 59, "10.5", null, 2 },
                    { 44, 1, "Brand New", 60, "10.5", null, 2 },
                    { 45, 1, "Brand New", 44, "10.5", null, 2 },
                    { 46, 1, "Brand New", 43, "10.5", null, 2 },
                    { 47, 3, "Needs a scrubbing", 34, "6.5", null, 6 },
                    { 48, 1, "sffsa", 75, "5.5", null, 6 },
                    { 49, 1, "Missing the box", 10, "6.5", null, 6 },
                    { 50, 4, "Pretty torn apart", 9, "7", null, 6 },
                    { 51, 2, "Has all the extras included! Looking to move!", 102, "6.5", null, 6 },
                    { 52, 2, "Has all the extras included! Looking to move!", 107, "7", null, 6 },
                    { 53, 4, "I bleached these and I like the way they turned out!", 106, "7.5", null, 6 },
                    { 54, 2, "🔪🔪🔪", 96, "7.5", null, 6 },
                    { 55, 1, "💰💰💰💃🏻🕺🏻💰💰💰", 77, "6", null, 6 },
                    { 56, 1, "Brand New", 18, "11.5", null, 2 },
                    { 57, 1, "Brand New", 17, "11.5", null, 2 },
                    { 58, 1, "Brand New", 31, "11", null, 2 },
                    { 59, 1, "Brand New", 30, "11", null, 2 },
                    { 60, 1, "Brand New", 102, "10", null, 2 },
                    { 61, 1, "Brand New", 107, "10", null, 2 },
                    { 62, 1, "Brand New", 94, "10.5", null, 2 },
                    { 63, 1, "Brand New", 94, "11", null, 2 },
                    { 64, 1, "Brand New", 64, "12", null, 2 },
                    { 65, 1, "Brand New", 65, "12", null, 2 },
                    { 66, 5, "100% used", 54, "6.5", null, 1 },
                    { 67, 1, "Great Condition!", 19, "7.5", null, 1 },
                    { 68, 3, "🤑🤑🤑🤑🤑", 89, "7", null, 6 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "rfv98hu4-3206-4gga-t8ws-457k5v543l6r" });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Avatar", "Bio", "City", "Email", "IdentityUserId", "IsAdmin", "Name", "State" },
                values: new object[,]
                {
                    { 1, null, "I'm a bird!", "Philadelphia", "dee@reynolds.com", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", false, "Dee Reynolds", "PA" },
                    { 2, null, "I'm a five star man!!!!", "Philadelphia", "dennis@reynolds.com", "frt98wr5-0223-3ww7-t6rq-028g4r521d4e", false, "Dennis Reynolds", "PA" },
                    { 3, null, "I'm gonna get real weird with it!!", "Philadelphia", "frank@reynolds.com", "hdp65oa9-3053-5ap0-z0hh-235t2a098h8q", false, "Frank Reynolds", "PA" },
                    { 4, null, "I'm playing both sides`!", "Philadelphia", "ronald@macdonald.com", "rse05dd6-2058-3bg0-a3oo-204t2l308f3p", false, "Ronald McDonald", "PA" },
                    { 5, null, "I hate Charlie work!!!!!!", "Philadelphia", "charlie@kelly.com", "wmo20ow7-0582-9pp1-i8sl-037h7w843j8r", false, "Charlie Kelly", "PA" },
                    { 6, null, "Nobody knows my name!", "Philadelphia", "the@waitress.com", "rfv98hu4-3206-4gga-t8ws-457k5v543l6r", true, "The Waitress", "PA" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "IsEdited", "Text", "TimeStamp", "UserId", "UserShoeId" },
                values: new object[,]
                {
                    { 1, false, "I love you!!", new DateTime(2024, 5, 5, 15, 0, 21, 275, DateTimeKind.Local).AddTicks(2810), 5, 43 },
                    { 2, false, "WAITRESS!!!", new DateTime(2024, 5, 18, 15, 0, 21, 275, DateTimeKind.Local).AddTicks(2870), 5, 43 },
                    { 3, false, "I AM THE RAT KING", new DateTime(2024, 3, 16, 15, 0, 21, 275, DateTimeKind.Local).AddTicks(2870), 5, 6 },
                    { 4, false, "bustin rats is my gig", new DateTime(2024, 3, 17, 15, 0, 21, 275, DateTimeKind.Local).AddTicks(2880), 5, 6 },
                    { 5, false, "did you seriously put nair in my shampoo?!", new DateTime(2024, 4, 20, 15, 0, 21, 275, DateTimeKind.Local).AddTicks(2890), 6, 6 },
                    { 6, false, "I'm playing both sides!!!!", new DateTime(2024, 5, 21, 15, 0, 21, 275, DateTimeKind.Local).AddTicks(2890), 4, 6 },
                    { 7, false, "LEAVE ME ALONE CHARLIE!!!", new DateTime(2024, 4, 21, 15, 0, 21, 275, DateTimeKind.Local).AddTicks(2890), 6, 43 },
                    { 8, false, "I am a 5 ⭐️ man!!!", new DateTime(2024, 5, 25, 15, 0, 21, 275, DateTimeKind.Local).AddTicks(2900), 2, 49 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Shoes");

            migrationBuilder.DropTable(
                name: "UserShoes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
