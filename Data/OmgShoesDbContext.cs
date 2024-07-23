using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OmgShoes.Models;
using Microsoft.AspNetCore.Identity;

namespace OmgShoes.Data;

public class OmgShoesDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Shoe> Shoes { get; set; }
    public DbSet<Condition> Conditions { get; set; }
    public DbSet<UserShoe> UserShoes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Friendship> Friendships { get; set; }

    public OmgShoesDbContext(DbContextOptions<OmgShoesDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Friendship>()
        //     .HasOne(f => f.Initiator)
        //     .WithMany(up => up.InitiatedFriendships)
        //     .HasForeignKey(f => f.InitiatorId)
        //     .OnDelete(DeleteBehavior.Restrict);

        // modelBuilder.Entity<Friendship>()
        //     .HasOne(f => f.Recipient)
        //     .WithMany(up => up.ReceivedFriendships)
        //     .HasForeignKey(f => f.RecipientId)
        //     .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole[]
        {
            new IdentityRole
            {
                Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                Name = "Admin",
                NormalizedName = "admin"
            }
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser[]
        {
            new IdentityUser
            {
                Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                UserName = "Dee",
                Email = "dee@reynolds.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "frt98wr5-0223-3ww7-t6rq-028g4r521d4e",
                UserName = "Dennis",
                Email = "dennis@reynolds.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "hdp65oa9-3053-5ap0-z0hh-235t2a098h8q",
                UserName = "Frank",
                Email = "frank@reynolds.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "rse05dd6-2058-3bg0-a3oo-204t2l308f3p",
                UserName = "Ronald",
                Email = "ronald@macdonald.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "wmo20ow7-0582-9pp1-i8sl-037h7w843j8r",
                UserName = "Charlie",
                Email = "charlie@kelly.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "rfv98hu4-3206-4gga-t8ws-457k5v543l6r",
                UserName = "Waitress",
                Email = "the@waitress.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },

        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                UserId = "rfv98hu4-3206-4gga-t8ws-457k5v543l6r"
            },
            new IdentityUserRole<string>
            {
                RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                UserId = "wmo20ow7-0582-9pp1-i8sl-037h7w843j8r"
            }
        );

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile
            {
                Id = 1,
                IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                Email = "dee@reynolds.com",
                Name = "Dee Reynolds",
                City = "Philadelphia",
                State = "PA",
                Avatar = "/avatars/dee-reynolds.jpg",
                Bio = "I'm a bird!"
            },
            new UserProfile
            {
                Id = 2,
                IdentityUserId = "frt98wr5-0223-3ww7-t6rq-028g4r521d4e",
                Email = "dennis@reynolds.com",
                Name = "Dennis Reynolds",
                City = "Philadelphia",
                State = "PA",
                Avatar = "/avatars/dennis-reynolds.jpg",
                Bio = "I'm a five star man!!!!"
            },
            new UserProfile
            {
                Id = 3,
                IdentityUserId = "hdp65oa9-3053-5ap0-z0hh-235t2a098h8q",
                Email = "frank@reynolds.com",
                Name = "Frank Reynolds",
                City = "Philadelphia",
                State = "PA",
                Avatar = "/avatars/frank-reynolds.jpg",
                Bio = "I'm gonna get real weird with it!!"
            },
            new UserProfile
            {
                Id = 4,
                IdentityUserId = "rse05dd6-2058-3bg0-a3oo-204t2l308f3p",
                Email = "ronald@macdonald.com",
                Name = "Ronald McDonald",
                City = "Philadelphia",
                State = "PA",
                Avatar = "/avatars/ronald-mcdonald.jpg",
                Bio = "I'm playing both sides`!"
            },
            new UserProfile
            {
                Id = 5,
                IdentityUserId = "wmo20ow7-0582-9pp1-i8sl-037h7w843j8r",
                Email = "charlie@kelly.com",
                Name = "Charlie Kelly",
                City = "Philadelphia",
                State = "PA",
                Avatar = "/avatars/charlie-kelly.jpg",
                Bio = "I hate Charlie work!!!!!!"
            },
            new UserProfile
            {
                Id = 6,
                IdentityUserId = "rfv98hu4-3206-4gga-t8ws-457k5v543l6r",
                Email = "the@waitress.com",
                Name = "The Waitress",
                City = "Philadelphia",
                State = "PA",
                Avatar = "/avatars/the-waitress.jpg",
                Bio = "Nobody knows my name!"
            },
        });

        modelBuilder.Entity<Shoe>().HasData(new Shoe[]
        {
            new Shoe
            {
                Id = 1,
                Name = "Richard Mulder",
                Style = "Low",
                Year = 2002,
                ModelNumber = "304292-141",
                Colorway = "WHITE/ORION BLUE-WHITE",
                Image = "/shoes/mulder.jpg",
            },
            new Shoe
            {
                Id = 2,
                Name = "Danny Supa",
                Style = "Low",
                Year = 2002,
                ModelNumber = "304292-841",
                Colorway = "SAFETY ORANGE/HYPER BLUE-WHITE",
                Image = "/shoes/danny-supa.jpg",
            },
            new Shoe
            {
                Id = 3,
                Name = "Reese Forbes Wheat",
                Style = "Low",
                Year = 2002,
                ModelNumber = "304292-731",
                Colorway = "WHEAT/TWIG-DUNE",
                Image = "/shoes/reese-forbes-wheat.jpg",
            },
            new Shoe
            {
                Id = 4,
                Name = "Gino Iannucci 1",
                Style = "Low",
                Year = 2002,
                ModelNumber = "304292_401",
                Colorway = "OBSIDIAN/LIGHT GRAPHITE-BLACK",
                Image = "/shoes/gino-iannucci.jpg",
            },
            new Shoe
            {
                Id = 5,
                Name = "Zoo York",
                Style = "Low",
                Year = 2002,
                ModelNumber = "305162-201",
                Colorway = "PAUL BROWN/BLACK",
                Image = "/shoes/zoo-york.jpg",
            },
            new Shoe
            {
                Id = 6,
                Name = "Chocolate",
                Style = "Low",
                Year = 2002,
                ModelNumber = "305162-001",
                Colorway = "ANTHRACITE/BLACK",
                Image = "/shoes/chocolate.jpg",
            },
            new Shoe
            {
                Id = 7,
                Name = "Supreme Black",
                Style = "Low",
                Year = 2002,
                ModelNumber = "304292-131",
                Colorway = "BLACK/BLACK-CEMENT GREY",
                Image = "/shoes/supreme-black.jpg",
            },
            new Shoe
            {
                Id = 8,
                Name = "Supreme White",
                Style = "Low",
                Year = 2002,
                ModelNumber = "304292-001",
                Colorway = "WHITE/BLACK-CEMENT GREY",
                Image = "/shoes/supreme-white.jpg",
            },
            new Shoe
            {
                Id = 9,
                Name = "Loden",
                Style = "Low",
                Year = 2002,
                ModelNumber = "304292-301",
                Colorway = "DARK LODEN/BLACK",
                Image = "/shoes/loden.jpg",
            },
            new Shoe
            {
                Id = 10,
                Name = "Sharks",
                Style = "Low",
                Year = 2002,
                ModelNumber = "304292-361",
                Colorway = "NIGHTSHADE/TEAM RED-SHARK",
                Image = "/shoes/shark.jpg",
            },
            new Shoe
            {
                Id = 11,
                Name = "Flash",
                Style = "Low",
                Year = 2002,
                ModelNumber = "304292-801",
                Colorway = "ORANGE FLASH/BLACK",
                Image = "/shoes/flash.jpg",
            },
            new Shoe
            {
                Id = 12,
                Name = "Reese Forbes Denim",
                Style = "Low",
                Year = 2002,
                ModelNumber = "304292-441",
                Colorway = "DENIM/DENIM",
                Image = "/shoes/reese-forbes-denim.jpg",
            },
            new Shoe
            {
                Id = 13,
                Name = "Bison",
                Style = "Low",
                Year = 2003,
                ModelNumber = "304292-226",
                Colorway = "DARK CINDER/BISON/SPORT RED",
                Image = "/shoes/bison.jpg",
            },
            new Shoe
            {
                Id = 14,
                Name = "Takashi",
                Style = "Low",
                Year = 2003,
                ModelNumber = "304292-072",
                Colorway = "BLACK/METALLIC GOLD/BLACK",
                Image = "/shoes/takashi.jpg",
            },
            new Shoe
            {
                Id = 15,
                Name = "Futura",
                Style = "Low",
                Year = 2003,
                ModelNumber = "304292-013",
                Colorway = "BLACK/WHITE-NIGHTSHADE-SHARK",
                Image = "/shoes/futura.jpg",
            },
            new Shoe
            {
                Id = 16,
                Name = "Heineken",
                Style = "Low",
                Year = 2003,
                ModelNumber = "304292-302",
                Colorway = "CLASSIC GREEN/BLACK-WHITE-RED",
                Image = "/shoes/heineken.jpg",
            },
            new Shoe
            {
                Id = 17,
                Name = "True Red",
                Style = "Low",
                Year = 2003,
                ModelNumber = "304292-601",
                Colorway = "TRUE RED/BLACK",
                Image = "/shoes/true-red.jpg",
            },
            new Shoe
            {
                Id = 18,
                Name = "True Black",
                Style = "Low",
                Year = 2003,
                ModelNumber = "304292-061",
                Colorway = "BLACK/TRUE RED",
                Image = "/shoes/true-black.jpg",
            },
            new Shoe
            {
                Id = 19,
                Name = "Broncos",
                Style = "Low",
                Year = 2003,
                ModelNumber = "304292-184",
                Colorway = "WHITE/ORANGE BLAZE-MIDNIGHT NAVY",
                Image = "/shoes/bronco.jpg",
            },
            new Shoe
            {
                Id = 20,
                Name = "Barfs",
                Style = "Low",
                Year = 2003,
                ModelNumber = "304292-431",
                Colorway = "NAVY/OUTDOOR GREEN/LIGHT CHOCOLATE",
                Image = "/shoes/barf.jpg",
            },
            new Shoe
            {
                Id = 21,
                Name = "Ostrich",
                Style = "Low",
                Year = 2003,
                ModelNumber = "304292-003",
                Colorway = "BLACK/BLACK",
                Image = "/shoes/ostrich.jpg",
            },
            new Shoe
            {
                Id = 22,
                Name = "Brown Pack Low",
                Style = "Low",
                Year = 2003,
                ModelNumber = "304292-221",
                Colorway = "BAROQUE BROWN/HAY/MAPLE",
                Image = "/shoes/brown-pack-low.jpg",
            },
            new Shoe
            {
                Id = 23,
                Name = "Paris",
                Style = "Low",
                Year = 2003,
                ModelNumber = "308270-111",
                Colorway = "ROPE/SPECIAL CARDINAL",
                Image = "/shoes/paris.jpg",
            },
            new Shoe
            {
                Id = 24,
                Name = "Buck",
                Style = "Low",
                Year = 2003,
                ModelNumber = "304292-132",
                Colorway = "WHITE/CLASSIC GREEN-DEL SOL",
                Image = "/shoes/buck.jpg",
            },
            new Shoe
            {
                Id = 25,
                Name = "Blue Hemp",
                Style = "Low",
                Year = 2004,
                ModelNumber = "304292-741",
                Colorway = "JERSEY GOLD/CASCADE BLUE",
                Image = "/shoes/blue-hemp.jpg",
            },
            new Shoe
            {
                Id = 26,
                Name = "Burgundy Hemp",
                Style = "Low",
                Year = 2004,
                ModelNumber = "304292-761",
                Colorway = "JERSEY GOLD/RED MAHOGANY",
                Image = "/shoes/burgundy-hemp.jpg",
            },
            new Shoe
            {
                Id = 27,
                Name = "Green Hemp",
                Style = "Low",
                Year = 2004,
                ModelNumber = "304292-732",
                Colorway = "JERSEY GOLD/BONSAI",
                Image = "/shoes/green-hemp.jpg",
            },
            new Shoe
            {
                Id = 28,
                Name = "Homer",
                Style = "Low",
                Year = 2004,
                ModelNumber = "304292-173",
                Colorway = "WHITE/MEDIUM YELLOW-UNIVERSITY BLUE",
                Image = "/shoes/homer.jpg",
            },
            new Shoe
            {
                Id = 29,
                Name = "Jedi",
                Style = "Low",
                Year = 2004,
                ModelNumber = "304292-222",
                Colorway = "KHAKI/BAROQUE BROWN-SAFARI",
                Image = "/shoes/jedi.jpg",
            },
            new Shoe
            {
                Id = 30,
                Name = "Carhartt Shale",
                Style = "Low",
                Year = 2004,
                ModelNumber = "304292-224",
                Colorway = "SHALE/SHALE",
                Image = "/shoes/carhartt-shale.jpg",
            },
            new Shoe
            {
                Id = 31,
                Name = "Carhartt Black",
                Style = "Low",
                Year = 2004,
                ModelNumber = "304292-004",
                Colorway = "BLACK/BLACK",
                Image = "/shoes/carhartt-black.jpg"
            },
            new Shoe
            {
                Id = 32,
                Name = "Medicom 1",
                Style = "Low",
                Year = 2004,
                ModelNumber = "304292-142",
                Colorway = "WHITE/COLLEGE BLUE",
                Image = "/shoes/medicom-1.jpg"
            },
            new Shoe
            {
                Id = 33,
                Name = "Cali",
                Style = "Low",
                Year = 2004,
                ModelNumber = "304292-211",
                Colorway = "PECAN/WHITE",
                Image = "/shoes/cali.jpg"
            },
            new Shoe
            {
                Id = 34,
                Name = "Tokyo",
                Style = "Low",
                Year = 2004,
                ModelNumber = "308268-111",
                Colorway = "MUSLIN/MUSLIN",
                Image = "/shoes/tokyo.jpg"
            },
            new Shoe
            {
                Id = 35,
                Name = "London",
                Style = "Low",
                Year = 2004,
                ModelNumber = "308269-111",
                Colorway = "SOFT GREY/MAGNET",
                Image = "/shoes/london.jpg"
            },
            new Shoe
            {
                Id = 36,
                Name = "Tweed",
                Style = "Low",
                Year = 2004,
                ModelNumber = "304292-223",
                Colorway = "BAROQUE BROWN/MUSHROOM/TWEED",
                Image = "/shoes/tweed.jpg"
            },
            new Shoe
            {
                Id = 37,
                Name = "Reese Forbes Hunter",
                Style = "Low",
                Year = 2004,
                ModelNumber = "304292-281",
                Colorway = "NATURAL BURALAP/ORANGE BLAZE",
                Image = "/shoes/reese-forbes-hunter.jpg"
            },
            new Shoe
            {
                Id = 38,
                Name = "Shanghai 1",
                Style = "Low",
                Year = 2004,
                ModelNumber = "304292-112",
                Colorway = "WHITE/METALLIC GOLD0-REDWOOD",
                Image = "/shoes/shanghai-1.jpg"
            },
            new Shoe
            {
                Id = 39,
                Name = "Grits",
                Style = "Low",
                Year = 2004,
                ModelNumber = "304292-261",
                Colorway = "GRIT/TEAM RED",
                Image = "/shoes/grits.jpg"
            },
            new Shoe
            {
                Id = 40,
                Name = "Mocha",
                Style = "Low",
                Year = 2004,
                ModelNumber = "304292-225",
                Colorway = "DARK MOCHA/CHINO",
                Image = "/shoes/mocha.jpg"
            },
            new Shoe
            {
                Id = 41,
                Name = "NYC Pigeon",
                Style = "Low",
                Year = 2005,
                ModelNumber = "304292-011",
                Colorway = "MEDIUM GREY/WHITE-DARK GREY",
                Image = "/shoes/nyc-pigeon.jpg"
            },
            new Shoe
            {
                Id = 42,
                Name = "J-Pack Blue",
                Style = "Low",
                Year = 2005,
                ModelNumber = "304292-041",
                Colorway = "BLACK/BLACK-GAME ROYAL",
                Image = "/shoes/j-pack-blue.jpg"
            },
            new Shoe
            {
                Id = 43,
                Name = "Raygun Home",
                Style = "Low",
                Year = 2005,
                ModelNumber = "304292-803",
                Colorway = "ORANGE FLASH/BLACK-BLACK",
                Image = "/shoes/raygun-home-black.jpg"
            },
            new Shoe
            {
                Id = 44,
                Name = "Raygun Away",
                Style = "Low",
                Year = 2005,
                ModelNumber = "304292-802",
                Colorway = "ORANGE FLASH/BLACK-WHITE",
                Image = "/shoes/raygun-away-white.jpg"
            },
            new Shoe
            {
                Id = 45,
                Name = "Oompa Loompa",
                Style = "Low",
                Year = 2005,
                ModelNumber = "304292-228",
                Colorway = "LIGHT CHOCOLATE/WHITE",
                Image = "/shoes/oompa-loompa.jpg"
            },
            new Shoe
            {
                Id = 46,
                Name = "St. Patrick's Day",
                Style = "Low",
                Year = 2005,
                ModelNumber = "304292-133",
                Colorway = "WHITE/CLASSIC GREEN",
                Image = "/shoes/st-patricks-day.jpg"
            },
            new Shoe
            {
                Id = 47,
                Name = "Boca",
                Style = "Low",
                Year = 2005,
                ModelNumber = "304292-471",
                Colorway = "VARSITY ROYAL/LIGHTNING",
                Image = "/shoes/boca.jpg"
            },
            new Shoe
            {
                Id = 48,
                Name = "Band-Aid",
                Style = "Low",
                Year = 2005,
                ModelNumber = "304292-006",
                Colorway = "LIGHT BONE/FLINT GREY",
                Image = "/shoes/band-aid.jpg"
            },
            new Shoe
            {
                Id = 49,
                Name = "Cinco de Mayo",
                Style = "Low",
                Year = 2005,
                ModelNumber = "304292-113",
                Colorway = "WHITE/WHITE",
                Image = "/shoes/cinco-de-mayo.jpg"
            },
            new Shoe
            {
                Id = 50,
                Name = "Stussy Cherry",
                Style = "Low",
                Year = 2005,
                ModelNumber = "304292-671",
                Colorway = "SHY PINK/VANILLA",
                Image = "/shoes/stussy-cherry.jpg"
            },
            new Shoe
            {
                Id = 51,
                Name = "Tiffany",
                Style = "Low",
                Year = 2005,
                ModelNumber = "304292-402",
                Colorway = "AQUA/CHROME",
                Image = "/shoes/tiffany.jpg"
            },
            new Shoe
            {
                Id = 52,
                Name = "Vapor",
                Style = "Low",
                Year = 2005,
                ModelNumber = "304292-271",
                Colorway = "VAPOR/MINERAL YELLOW",
                Image = "/shoes/vapor.jpg"
            },
            new Shoe
            {
                Id = 53,
                Name = "Slam City",
                Style = "Low",
                Year = 2005,
                ModelNumber = "304292-201",
                Colorway = "LIGHT TAUPE/BLACK",
                Image = "/shoes/slam-city.jpg"
            },
            new Shoe
            {
                Id = 54,
                Name = "Shanghai 2",
                Style = "Low",
                Year = 2005,
                ModelNumber = "304292-721",
                Colorway = "LIGHT TAUPE/BLACK",
                Image = "/shoes/shanghai-2.jpg"
            },
            new Shoe
            {
                Id = 55,
                Name = "Halloween",
                Style = "Low",
                Year = 2005,
                ModelNumber = "304292-007",
                Colorway = "BLACK/BLACK",
                Image = "/shoes/halloween.jpg"
            },
            new Shoe
            {
                Id = 56,
                Name = "Medicom 2",
                Style = "Low",
                Year = 2005,
                ModelNumber = "304292-005",
                Colorway = "BLACK/BLACK",
                Image = "/shoes/medicom-2.jpg"
            },
            new Shoe
            {
                Id = 57,
                Name = "De La Soul",
                Style = "Low",
                Year = 2005,
                ModelNumber = "304292-171",
                Colorway = "WHITE/YELLOW",
                Image = "/shoes/de-la-soul.jpg"
            },
            new Shoe
            {
                Id = 58,
                Name = "Medicom 3",
                Style = "Low",
                Year = 2005,
                ModelNumber = "304292-008",
                Colorway = "SILVER/CHROME",
                Image = "/shoes/medicom-3.jpg"
            },
            new Shoe
            {
                Id = 59,
                Name = "Avenger (Blue)",
                Style = "Low",
                Year = 2005,
                ModelNumber = "304292-143",
                Colorway = "WHITE/MIDNIGHT NAVY-BLUE REEF",
                Image = "/shoes/avenger-blue.jpg"
            },
            new Shoe
            {
                Id = 60,
                Name = "Avenger (Purple)",
                Style = "Low",
                Year = 2005,
                ModelNumber = "304292-101",
                Colorway = "WHITE/BLACK-HYACINTH",
                Image = "/shoes/avenger-purple.jpg"
            },
            new Shoe
            {
                Id = 61,
                Name = "Pushead",
                Style = "Low",
                Year = 2005,
                ModelNumber = "313233-001",
                Colorway = "BLACK/BLACK-BLACK",
                Image = "/shoes/pushead.jpg"
            },
            new Shoe
            {
                Id = 62,
                Name = "Hawaii",
                Style = "Low",
                Year = 2006,
                ModelNumber = "313170-003",
                Colorway = "BLACK/BLACK-DEEP ORANGE",
                Image = "/shoes/hawaii.jpg"
            },
            new Shoe
            {
                Id = 63,
                Name = "High Hair",
                Style = "Low",
                Year = 2006,
                ModelNumber = "313170-142",
                Colorway = "WHITE/AQUA",
                Image = "/shoes/high-hair.jpg"
            },
            new Shoe
            {
                Id = 64,
                Name = "Lunar Eclipse East",
                Style = "Low",
                Year = 2006,
                ModelNumber = "313170-001",
                Colorway = "LIGHT GRAPHITE/ANTHRACITE",
                Image = "/shoes/lunar-eclipse-east.jpg"
            },
            new Shoe
            {
                Id = 65,
                Name = "Lunar Eclipse West",
                Style = "Low",
                Year = 2006,
                ModelNumber = "313170-002",
                Colorway = "STEALTH/BLACK",
                Image = "/shoes/lunar-eclipse-west.jpg"
            },
            new Shoe
            {
                Id = 66,
                Name = "Spanish Moss",
                Style = "Low",
                Year = 2006,
                ModelNumber = "304292-321",
                Colorway = "SPANISH MOSS/SANDALWOOD",
                Image = "/shoes/spanish-moss.jpg"
            },
            new Shoe
            {
                Id = 67,
                Name = "Crimson",
                Style = "Low",
                Year = 2006,
                ModelNumber = "304292-161",
                Colorway = "WHITE/VARSITY CRIMSON",
                Image = "/shoes/crimson.jpg"
            },
            new Shoe
            {
                Id = 68,
                Name = "Eire",
                Style = "Low",
                Year = 2006,
                ModelNumber = "304292-185",
                Colorway = "NET/DEEP ORANGE",
                Image = "/shoes/eire.jpg"
            },
            new Shoe
            {
                Id = 69,
                Name = "Brown Golf",
                Style = "Low",
                Year = 2006,
                ModelNumber = "313170-171",
                Colorway = "NET/MAIZE-BAROQUE BROWN",
                Image = "/shoes/brown-golf.jpg"
            },
            new Shoe
            {
                Id = 70,
                Name = "Blue Golf",
                Style = "Low",
                Year = 2006,
                ModelNumber = "313170-141",
                Colorway = "WHITE/MIDNIGHT NAVY-BLUE ICE",
                Image = "/shoes/blue-golf.jpg"
            },
            new Shoe
            {
                Id = 71,
                Name = "Neptune",
                Style = "Low",
                Year = 2006,
                ModelNumber = "304292-144",
                Colorway = "WHITE/NEPTUNE BLUE",
                Image = "/shoes/neptune.jpg"
            },
            new Shoe
            {
                Id = 72,
                Name = "Weiger",
                Style = "Low",
                Year = 2006,
                ModelNumber = "304292-014",
                Colorway = "BLACK/WHITE",
                Image = "/shoes/weiger.jpg"
            },
            new Shoe
            {
                Id = 73,
                Name = "Puff-N-Stuf",
                Style = "Low",
                Year = 2006,
                ModelNumber = "313170-341",
                Colorway = "OIL GREEN/INTERNATIONAL BLUE",
                Image = "/shoes/puff-n-stuf.jpg"
            },
            new Shoe
            {
                Id = 74,
                Name = "SBTG",
                Style = "Low",
                Year = 2006,
                ModelNumber = "313170-201",
                Colorway = "SABLE GREEN/METALLIC GOLD",
                Image = "/shoes/sbtg.jpg"
            },
            new Shoe
            {
                Id = 75,
                Name = "Bic",
                Style = "Low",
                Year = 2006,
                ModelNumber = "304292-701",
                Colorway = "VARSITY MAIZE/BLACK",
                Image = "/shoes/bic.jpg"
            },
            new Shoe
            {
                Id = 76,
                Name = "Aqua Chalk",
                Style = "Low",
                Year = 2006,
                ModelNumber = "304292-032",
                Colorway = "ASH/AQUA CHALK",
                Image = "/shoes/aqua-chalk.jpg"
            },
            new Shoe
            {
                Id = 77,
                Name = "Day of the Dead",
                Style = "Low",
                Year = 2006,
                ModelNumber = "313170-801",
                Colorway = "ORANGE BLAZE/BLACK-WHITE",
                Image = "/shoes/day-of-the-dead.jpg"
            },
            new Shoe
            {
                Id = 78,
                Name = "Baby Bear",
                Style = "Low",
                Year = 2006,
                ModelNumber = "313170-731",
                Colorway = "LIGHT UMBER/GRASSHOPPER TERSIE/STRELL",
                Image = "/shoes/baby-bear.jpg"
            },
            new Shoe
            {
                Id = 79,
                Name = "Purple Pigeon",
                Style = "Low",
                Year = 2006,
                ModelNumber = "304292-051",
                Colorway = "LIGHT GRAPHITE/PRISM VIOLET",
                Image = "/shoes/purple-pigeon.jpg"
            },
            new Shoe
            {
                Id = 80,
                Name = "Mafia",
                Style = "Low",
                Year = 2006,
                ModelNumber = "313170-004",
                Colorway = "BLACK/BLACK-TEAM RED",
                Image = "/shoes/mafia.jpg"
            },
            new Shoe
            {
                Id = 81,
                Name = "Tokyo Taxi Green",
                Style = "Low",
                Year = 2006,
                ModelNumber = "304292-311",
                Colorway = "GRASS GREEN/WHITE",
                Image = "/shoes/tokyo-taxi-green.jpg"
            },
            new Shoe
            {
                Id = 82,
                Name = "Tokyo Taxi Blue",
                Style = "Low",
                Year = 2006,
                ModelNumber = "313170-411",
                Colorway = "CHLORINE BLUE/WHITE",
                Image = "/shoes/tokyo-taxi-blue.jpg"
            },
            new Shoe
            {
                Id = 83,
                Name = "Michael Lau",
                Style = "Low",
                Year = 2006,
                ModelNumber = "316164-222",
                Colorway = "DARK COFFEE/DARK COFFEE",
                Image = "/shoes/michael-lau.jpg"
            },
            new Shoe
            {
                Id = 84,
                Name = "Tweed 2",
                Style = "Low",
                Year = 2007,
                ModelNumber = "304292-229",
                Colorway = "DARK MOCHA/TWEED",
                Image = "/shoes/tweed-2.jpg"
            },
            new Shoe
            {
                Id = 85,
                Name = "Mill Vanilli",
                Style = "Low",
                Year = 2007,
                ModelNumber = "304292-602",
                Colorway = "VARSITY CRIMSON/BLACK",
                Image = "/shoes/milli-vanilli.jpg"
            },
            new Shoe
            {
                Id = 86,
                Name = "Border Blue",
                Style = "Low",
                Year = 2007,
                ModelNumber = "304292-411",
                Colorway = "BORDER BLUE/WHITE",
                Image = "/shoes/border-blue.jpg"
            },
            new Shoe
            {
                Id = 87,
                Name = "Money Cat",
                Style = "Low",
                Year = 2007,
                ModelNumber = "304292-771",
                Colorway = "GOLD DUST/METALLIC GOLD",
                Image = "/shoes/money-cat.jpg"
            },
            new Shoe
            {
                Id = 88,
                Name = "Trail End",
                Style = "Low",
                Year = 2007,
                ModelNumber = "304292-102",
                Colorway = "WHITE/BLACK-TRAIL END BROWN",
                Image = "/shoes/trail-end.jpg"
            },
            new Shoe
            {
                Id = 89,
                Name = "C&K",
                Style = "Low",
                Year = 2007,
                ModelNumber = "313170-031",
                Colorway = "BLACK/ACID",
                Image = "/shoes/c-and-k.jpg"
            },
            new Shoe
            {
                Id = 90,
                Name = "Old Spice",
                Style = "Low",
                Year = 2007,
                ModelNumber = "304292-272",
                Colorway = "BUFF/METALLIC GOLD",
                Image = "/shoes/old-spice.jpg"
            },
            new Shoe
            {
                Id = 91,
                Name = "Coral Snake",
                Style = "Low",
                Year = 2007,
                ModelNumber = "313170-701",
                Colorway = "BRIGHT GOLDENROD/BLACK",
                Image = "/shoes/coral-snake.jpg"
            },
            new Shoe
            {
                Id = 92,
                Name = "Takashi 2",
                Style = "Low",
                Year = 2007,
                ModelNumber = "313170-005",
                Colorway = "BLACK/METALLIC SILVER",
                Image = "/shoes/takashi-2.jpg"
            },
            new Shoe
            {
                Id = 93,
                Name = "Strummer Before",
                Style = "Low",
                Year = 2007,
                ModelNumber = "304292-902",
                Colorway = "BLACK/METALLIC ZINC",
                Image = "/shoes/strummer-before.jpg"
            },
            new Shoe
            {
                Id = 94,
                Name = "Strummer After",
                Style = "Low",
                Year = 2007,
                ModelNumber = "313170-006",
                Colorway = "BLACK/METALLIC ZINC",
                Image = "/shoes/strummer-after.jpg"
            },
            new Shoe
            {
                Id = 95,
                Name = "What The Dunk",
                Style = "Low",
                Year = 2007,
                ModelNumber = "318403-141",
                Colorway = "WHITE/COLLEGE BLUE-CHROME-DEEP RED",
                Image = "/shoes/what-the-dunk.jpg"
            },
            new Shoe
            {
                Id = 96,
                Name = "Freddy Krueger",
                Style = "Low",
                Year = 2007,
                ModelNumber = "313170-202",
                Colorway = "TAUPE/CHROME",
                Image = "/shoes/freddy-krueger.jpg"
            },
            new Shoe
            {
                Id = 97,
                Name = "Gibson",
                Style = "Low",
                Year = 2008,
                ModelNumber = "313170-271",
                Colorway = "LIGHT BRITISH TAN/METALLIC GOLD",
                Image = "/shoes/gibson.jpg"
            },
            new Shoe
            {
                Id = 98,
                Name = "Skate or Die",
                Style = "Low",
                Year = 2008,
                ModelNumber = "304292-073",
                Colorway = "BLACK/NEON YELLOW",
                Image = "/shoes/skate-or-die.jpg"
            },
            new Shoe
            {
                Id = 99,
                Name = "Appetite for Destruction",
                Style = "Low",
                Year = 2008,
                ModelNumber = "304292 052",
                Colorway = "ANTHRACITE/DEEP VIOLET",
                Image = "/shoes/appetite-for-destruction.jpg"
            },
            new Shoe
            {
                Id = 100,
                Name = "720 Degrees",
                Style = "Low",
                Year = 2008,
                ModelNumber = "304292-062",
                Colorway = "DARK CHARCOAL/LIGHT PINK",
                Image = "/shoes/720-degrees.jpg"
            },
            new Shoe
            {
                Id = 101,
                Name = "Newcastle",
                Style = "Low",
                Year = 2008,
                ModelNumber = "313170-741",
                Colorway = "GOLD/ATLANTIC BLUE",
                Image = "/shoes/newcastle.jpg"
            },
            new Shoe
            {
                Id = 102,
                Name = "Red Lobster",
                Style = "Low",
                Year = 2008,
                ModelNumber = "313170-661",
                Colorway = "SPORT RED/PINK CLAY",
                Image = "/shoes/red-lobster.jpg"
            },
            new Shoe
            {
                Id = 103,
                Name = "Space Tiger",
                Style = "Low",
                Year = 2008,
                ModelNumber = "313170 071",
                Colorway = "BLACK/YELLOW OCHRE",
                Image = "/shoes/space-tiger.jpg"
            },
            new Shoe
            {
                Id = 104,
                Name = "Poison",
                Style = "Low",
                Year = 2008,
                ModelNumber = "304292-033",
                Colorway = "MAGNET/LIGHT POISON GREEN",
                Image = "/shoes/poison.jpg"
            },
            new Shoe
            {
                Id = 105,
                Name = "Gold Rail",
                Style = "Low",
                Year = 2008,
                ModelNumber = "304292-472",
                Colorway = "VARSITY ROYAL/METALLIC VEGAS GOLD",
                Image = "/shoes/gold-rail.jpg"
            },
            new Shoe
            {
                Id = 106,
                Name = "Piet Mondrian",
                Style = "Low",
                Year = 2008,
                ModelNumber = "304292-702",
                Colorway = "ZEST/BLACK",
                Image = "/shoes/piet-mondrian.jpg"
            },
            new Shoe
            {
                Id = 107,
                Name = "Blue Lobster",
                Style = "Low",
                Year = 2009,
                ModelNumber = "313170-342",
                Colorway = "NIGHTSHADE/DARK SLATE",
                Image = "/shoes/blue-lobster.jpg"
            },
            new Shoe
            {
                Id = 108,
                Name = "Ms. Pac Man",
                Style = "Low",
                Year = 2009,
                ModelNumber = "313170-461",
                Colorway = "CHLORINE BLUE/CERSIE",
                Image = "/shoes/ms-pac-man.jpg"
            },
            new Shoe
            {
                Id = 109,
                Name = "Patagonia",
                Style = "Low",
                Year = 2009,
                ModelNumber = "304292-042",
                Colorway = "BLACK/ACADEMY-BLUE",
                Image = "/shoes/patagonia.jpg"
            },
            new Shoe
            {
                Id = 110,
                Name = "Angel & Death",
                Style = "Low",
                Year = 2009,
                ModelNumber = "313170-041",
                Colorway = "BLACK/BALTIC BLUE",
                Image = "/shoes/angel-and-death.jpg"
            },
            new Shoe
            {
                Id = 111,
                Name = "Goofy Boy",
                Style = "Low",
                Year = 2009,
                ModelNumber = "304292-751",
                Colorway = "CHUTNEY/ABYSS",
                Image = "/shoes/goofy-boy.jpg"
            },
            new Shoe
            {
                Id = 112,
                Name = "Green Spark",
                Style = "Low",
                Year = 2009,
                ModelNumber = "313170-381",
                Colorway = "GREEN SPARK/HOOP ORANGE",
                Image = "/shoes/green-spark.jpg"
            },
            new Shoe
            {
                Id = 113,
                Name = "Top Ramen",
                Style = "Low",
                Year = 2009,
                ModelNumber = "313170-101",
                Colorway = "SAIL/BLACK",
                Image = "/shoes/top-ramen.jpg"
            },
            new Shoe
            {
                Id = 114,
                Name = "Asparagus",
                Style = "Low",
                Year = 2009,
                ModelNumber = "313170-302",
                Colorway = "ASPARAGUS/BLACK",
                Image = "/shoes/asparagus.jpg"
            },
            new Shoe
            {
                Id = 115,
                Name = "Toxic Avenger",
                Style = "Low",
                Year = 2009,
                ModelNumber = "313170-261",
                Colorway = "HAY/HOT RED-TERRA BROWN",
                Image = "/shoes/toxic-avenger.jpg"
            },
            new Shoe
            {
                Id = 116,
                Name = "Anchorman",
                Style = "Low",
                Year = 2009,
                ModelNumber = "3004292-672",
                Colorway = "TEAM RED/METALLIC GOLD",
                Image = "/shoes/anchorman.jpg"
            },
            new Shoe
            {
                Id = 117,
                Name = "Koston",
                Style = "Low",
                Year = 2010,
                ModelNumber = "313170-400",
                Colorway = "BLUE RIBBON/METALLIC VEGAS GOLD-VARSITY RED",
                Image = "/shoes/koston.jpg"
            },
            new Shoe
            {
                Id = 118,
                Name = "Yellow Curb",
                Style = "Low",
                Year = 2010,
                ModelNumber = "313170-010",
                Colorway = "MIDNIGHT FOG/BLACK-YELLOW OCHRE",
                Image = "/shoes/yellow-curb.jpg"
            },
            new Shoe
            {
                Id = 119,
                Name = "Chrome Ball Incident",
                Style = "Low",
                Year = 2010,
                ModelNumber = "304292-012",
                Colorway = "BLACK/RADIANT EMERALD-MEDIUM GREY",
                Image = "/shoes/chrome-ball-incident.jpg"
            },
            new Shoe
            {
                Id = 120,
                Name = "Loon",
                Style = "Low",
                Year = 2010,
                ModelNumber = "313170-011",
                Colorway = "NEUTRAL GREY/GREEN SPARK-BLACK",
                Image = "/shoes/loon.jpg"
            },
            new Shoe
            {
                Id = 121,
                Name = "Larry Perkins",
                Style = "Low",
                Year = 2010,
                ModelNumber = "313170-007",
                Colorway = "BLACK/BLACK-VARSITY RED",
                Image = "/shoes/larry-perkins.jpg"
            },
            new Shoe
            {
                Id = 122,
                Name = "Chun Li",
                Style = "Low",
                Year = 2010,
                ModelNumber = "304292-405",
                Colorway = "ARGON BLUE/WHITE",
                Image = "/shoes/chun-li.jpg"
            },
            new Shoe
            {
                Id = 123,
                Name = "Miller High Life",
                Style = "Low",
                Year = 2010,
                ModelNumber = "313170-008",
                Colorway = "BLACK/METALLIC GOLD-PINE GREEN",
                Image = "/shoes/miller-high-life.jpg"
            }
        });

        modelBuilder.Entity<Condition>().HasData(new Condition[]
        {
            new Condition
            {
                Id = 1,
                Description = "Deadstock"
            },
            new Condition
            {
                Id = 2,
                Description = "Worn 1-10x"
            },
            new Condition
            {
                Id = 3,
                Description = "Used"
            },
            new Condition
            {
                Id = 4,
                Description = "Very Used"
            },
            new Condition
            {
                Id = 5,
                Description = "Thrashed"
            },
        });

        modelBuilder.Entity<UserShoe>().HasData(new UserShoe[]
        {
            new UserShoe
            {
                Id = 1,
                UserProfileId = 5,
                ShoeId = 3,
                ShoeSize = "11.5",
                ConditionId = 4,
                Description = "Completely unwearable!!!"
            },
            new UserShoe
            {
                Id = 2,
                UserProfileId = 5,
                ShoeId = 9,
                ShoeSize = "11.5",
                ConditionId = 2,
                Description = "Great condition for age"
            },
            new UserShoe
            {
                Id = 3,
                UserProfileId = 5,
                ShoeId = 10,
                ShoeSize = "11.5",
                ConditionId = 3,
                Description = "Great condition, a bit faded"
            },
            new UserShoe
            {
                Id = 4,
                UserProfileId = 5,
                ShoeId = 19,
                ShoeSize = "11.5",
                ConditionId = 4,
                Description = "FOR SALE!!!"
            },
            new UserShoe
            {
                Id = 5,
                UserProfileId = 5,
                ShoeId = 24,
                ShoeSize = "11.5",
                ConditionId = 3,
                Description = "Soles have recently been replaced/swapped with brand new soles"
            },
            new UserShoe
            {
                Id = 6,
                UserProfileId = 5,
                ShoeId = 30,
                ShoeSize = "11.5",
                ConditionId = 1,
                Description = "Brand New"
            },
            new UserShoe
            {
                Id = 7,
                UserProfileId = 5,
                ShoeId = 36,
                ShoeSize = "11.5",
                ConditionId = 3,
                Description = "Good lookin shoe"
            },
            new UserShoe
            {
                Id = 8,
                UserProfileId = 5,
                ShoeId = 38,
                ShoeSize = "11",
                ConditionId = 3,
                Description = "Hard to find"
            },
            new UserShoe
            {
                Id = 9,
                UserProfileId = 5,
                ShoeId = 39,
                ShoeSize = "11",
                ConditionId = 3,
                Description = "Great Condition, fits like an 11.5"
            },
            new UserShoe
            {
                Id = 10,
                UserProfileId = 5,
                ShoeId = 48,
                ShoeSize = "11.5",
                ConditionId = 4,
                Description = "Kick around shoe"
            },
            new UserShoe
            {
                Id = 11,
                UserProfileId = 5,
                ShoeId = 52,
                ShoeSize = "11.5",
                ConditionId = 3,
                Description = "Good for everyday wear"
            },
            new UserShoe
            {
                Id = 12,
                UserProfileId = 5,
                ShoeId = 54,
                ShoeSize = "11.5",
                ConditionId = 3,
                Description = "Sock Liner Tears"
            },
            new UserShoe
            {
                Id = 13,
                UserProfileId = 5,
                ShoeId = 66,
                ShoeSize = "12",
                ConditionId = 2,
                Description = "Has 1 replacement insole from a pair of Blue Lobster"
            },
            new UserShoe
            {
                Id = 14,
                UserProfileId = 5,
                ShoeId = 68,
                ShoeSize = "11.5",
                ConditionId = 3,
                Description = "Great condition!"
            },
            new UserShoe
            {
                Id = 15,
                UserProfileId = 5,
                ShoeId = 73,
                ShoeSize = "11",
                ConditionId = 3,
                Description = "Very very faded"
            },
            new UserShoe
            {
                Id = 16,
                UserProfileId = 5,
                ShoeId = 75,
                ShoeSize = "11.5",
                ConditionId = 3,
                Description = "Runs a little big"
            },
            new UserShoe
            {
                Id = 17,
                UserProfileId = 5,
                ShoeId = 81,
                ShoeSize = "11.5",
                ConditionId = 2,
                Description = "Black laces only"
            },
            new UserShoe
            {
                Id = 18,
                UserProfileId = 5,
                ShoeId = 97,
                ShoeSize = "11",
                ConditionId = 4,
                Description = "These don't look very used at all"
            },
            new UserShoe
            {
                Id = 19,
                UserProfileId = 5,
                ShoeId = 99,
                ShoeSize = "11.5",
                ConditionId = 2,
                Description = "Almost brand new"
            },
            new UserShoe
            {
                Id = 20,
                UserProfileId = 5,
                ShoeId = 100,
                ShoeSize = "11.5",
                ConditionId = 3,
                Description = "Great condition, one tongue strap falling apart"
            },
            new UserShoe
            {
                Id = 21,
                UserProfileId = 5,
                ShoeId = 101,
                ShoeSize = "11.5",
                ConditionId = 2,
                Description = "$$$$$"
            },
            new UserShoe
            {
                Id = 22,
                UserProfileId = 5,
                ShoeId = 103,
                ShoeSize = "11.5",
                ConditionId = 4,
                Description = "Everyday work shoes, sock liner tears"
            },
            new UserShoe
            {
                Id = 23,
                UserProfileId = 5,
                ShoeId = 104,
                ShoeSize = "12",
                ConditionId = 2,
                Description = "Clean. No inner tag"
            },
            new UserShoe
            {
                Id = 24,
                UserProfileId = 5,
                ShoeId = 109,
                ShoeSize = "11.5",
                ConditionId = 5,
                Description = "Old and beat!"
            },
            new UserShoe
            {
                Id = 25,
                UserProfileId = 3,
                ShoeId = 108,
                ShoeSize = "14",
                ConditionId = 5,
                Description = "thrashed..."
            },
            new UserShoe
            {
                Id = 26,
                UserProfileId = 3,
                ShoeId = 113,
                ShoeSize = "7.5",
                ConditionId = 3,
                Description = "Great condition!"
            },
            new UserShoe
            {
                Id = 27,
                UserProfileId = 3,
                ShoeId = 87,
                ShoeSize = "9",
                ConditionId = 4,
                Description = "Need new soles"
            },
            new UserShoe
            {
                Id = 28,
                UserProfileId = 4,
                ShoeId = 73,
                ShoeSize = "8.5",
                ConditionId = 3,
                Description = "uesd!!@"
            },
            new UserShoe
            {
                Id = 29,
                UserProfileId = 5,
                ShoeId = 123,
                ShoeSize = "9",
                ConditionId = 1,
                Description = "testestest"
            },
            new UserShoe
            {
                Id = 30,
                UserProfileId = 5,
                ShoeId = 30,
                ShoeSize = "11.5",
                ConditionId = 1,
                Description = "Needs a re-glue"
            },
            new UserShoe
            {
                Id = 31,
                UserProfileId = 5,
                ShoeId = 123,
                ShoeSize = "10.5",
                ConditionId = 4,
                Description = "Too small!"
            },
            new UserShoe
            {
                Id = 32,
                UserProfileId = 6,
                ShoeId = 11,
                ShoeSize = "6.5",
                ConditionId = 3,
                Description = "Kick arounds!"
            },
            new UserShoe
            {
                Id = 33,
                UserProfileId = 6,
                ShoeId = 23,
                ShoeSize = "7.5",
                ConditionId = 1,
                Description = "1 of 202 ever made."
            },
            new UserShoe
            {
                Id = 34,
                UserProfileId = 1,
                ShoeId = 38,
                ShoeSize = "5.5",
                ConditionId = 3,
                Description = "Has the original box"
            },
            new UserShoe
            {
                Id = 35,
                UserProfileId = 6,
                ShoeId = 35,
                ShoeSize = "7",
                ConditionId = 1,
                Description = "Willing to trade"
            },
            new UserShoe
            {
                Id = 36,
                UserProfileId = 6,
                ShoeId = 120,
                ShoeSize = "7.5",
                ConditionId = 5,
                Description = "Heavily Skated"
            },
            new UserShoe
            {
                Id = 37,
                UserProfileId = 6,
                ShoeId = 23,
                ShoeSize = "7",
                ConditionId = 1,
                Description = "Another 1 of 202 ever made."
            },
            new UserShoe
            {
                Id = 38,
                UserProfileId = 2,
                ShoeId = 25,
                ShoeSize = "10.5",
                ConditionId = 1,
                Description = "Brand New"
            },
            new UserShoe
            {
                Id = 39,
                UserProfileId = 2,
                ShoeId = 26,
                ShoeSize = "10.5",
                ConditionId = 1,
                Description = "Brand New"
            },
            new UserShoe
            {
                Id = 40,
                UserProfileId = 2,
                ShoeId = 27,
                ShoeSize = "10.5",
                ConditionId = 1,
                Description = "Brand New"
            },
            new UserShoe
            {
                Id = 41,
                UserProfileId = 2,
                ShoeId = 7,
                ShoeSize = "10.5",
                ConditionId = 1,
                Description = "Brand New"
            },
            new UserShoe
            {
                Id = 42,
                UserProfileId = 2,
                ShoeId = 8,
                ShoeSize = "10.5",
                ConditionId = 1,
                Description = "Brand New"
            },
            new UserShoe
            {
                Id = 43,
                UserProfileId = 2,
                ShoeId = 59,
                ShoeSize = "10.5",
                ConditionId = 1,
                Description = "Brand New"
            },
            new UserShoe
            {
                Id = 44,
                UserProfileId = 2,
                ShoeId = 60,
                ShoeSize = "10.5",
                ConditionId = 1,
                Description = "Brand New"
            },
            new UserShoe
            {
                Id = 45,
                UserProfileId = 2,
                ShoeId = 44,
                ShoeSize = "10.5",
                ConditionId = 1,
                Description = "Brand New"
            },
            new UserShoe
            {
                Id = 46,
                UserProfileId = 2,
                ShoeId = 43,
                ShoeSize = "10.5",
                ConditionId = 1,
                Description = "Brand New"
            },
            new UserShoe
            {
                Id = 47,
                UserProfileId = 6,
                ShoeId = 34,
                ShoeSize = "6.5",
                ConditionId = 3,
                Description = "Needs a scrubbing"
            },
            new UserShoe
            {
                Id = 48,
                UserProfileId = 6,
                ShoeId = 75,
                ShoeSize = "5.5",
                ConditionId = 1,
                Description = "sffsa"
            },
            new UserShoe
            {
                Id = 49,
                UserProfileId = 6,
                ShoeId = 10,
                ShoeSize = "6.5",
                ConditionId = 1,
                Description = "Missing the box"
            },
            new UserShoe
            {
                Id = 50,
                UserProfileId = 6,
                ShoeId = 9,
                ShoeSize = "7",
                ConditionId = 4,
                Description = "Pretty torn apart"
            },
            new UserShoe
            {
                Id = 51,
                UserProfileId = 6,
                ShoeId = 102,
                ShoeSize = "6.5",
                ConditionId = 2,
                Description = "Has all the extras included! Looking to move!"
            },
            new UserShoe
            {
                Id = 52,
                UserProfileId = 6,
                ShoeId = 107,
                ShoeSize = "7",
                ConditionId = 2,
                Description = "Has all the extras included! Looking to move!"
            },
            new UserShoe
            {
                Id = 53,
                UserProfileId = 6,
                ShoeId = 106,
                ShoeSize = "7.5",
                ConditionId = 4,
                Description = "I bleached these and I like the way they turned out!"
            },
            new UserShoe
            {
                Id = 54,
                UserProfileId = 6,
                ShoeId = 96,
                ShoeSize = "7.5",
                ConditionId = 2,
                Description = "🔪🔪🔪"
            },
            new UserShoe
            {
                Id = 55,
                UserProfileId = 6,
                ShoeId = 77,
                ShoeSize = "6",
                ConditionId = 1,
                Description = "💰💰💰💃🏻🕺🏻💰💰💰"
            },
            new UserShoe
            {
                Id = 56,
                UserProfileId = 2,
                ShoeId = 18,
                ShoeSize = "11.5",
                ConditionId = 1,
                Description = "Brand New"
            },
            new UserShoe
            {
                Id = 57,
                UserProfileId = 2,
                ShoeId = 17,
                ShoeSize = "11.5",
                ConditionId = 1,
                Description = "Brand New"
            },
            new UserShoe
            {
                Id = 58,
                UserProfileId = 2,
                ShoeId = 31,
                ShoeSize = "11",
                ConditionId = 1,
                Description = "Brand New"
            },
            new UserShoe
            {
                Id = 59,
                UserProfileId = 2,
                ShoeId = 30,
                ShoeSize = "11",
                ConditionId = 1,
                Description = "Brand New"
            },
            new UserShoe
            {
                Id = 60,
                UserProfileId = 2,
                ShoeId = 102,
                ShoeSize = "10",
                ConditionId = 1,
                Description = "Brand New"
            },
            new UserShoe
            {
                Id = 61,
                UserProfileId = 2,
                ShoeId = 107,
                ShoeSize = "10",
                ConditionId = 1,
                Description = "Brand New"
            },
            new UserShoe
            {
                Id = 62,
                UserProfileId = 2,
                ShoeId = 94,
                ShoeSize = "10.5",
                ConditionId = 1,
                Description = "Brand New"
            },
            new UserShoe
            {
                Id = 63,
                UserProfileId = 2,
                ShoeId = 94,
                ShoeSize = "11",
                ConditionId = 1,
                Description = "Brand New"
            },
            new UserShoe
            {
                Id = 64,
                UserProfileId = 2,
                ShoeId = 64,
                ShoeSize = "12",
                ConditionId = 1,
                Description = "Brand New"
            },
            new UserShoe
            {
                Id = 65,
                UserProfileId = 2,
                ShoeId = 65,
                ShoeSize = "12",
                ConditionId = 1,
                Description = "Brand New"
            },
            new UserShoe
            {
                Id = 66,
                UserProfileId = 1,
                ShoeId = 54,
                ShoeSize = "6.5",
                ConditionId = 5,
                Description = "100% used"
            },
            new UserShoe
            {
                Id = 67,
                UserProfileId = 1,
                ShoeId = 19,
                ShoeSize = "7.5",
                ConditionId = 1,
                Description = "Great Condition!"
            },
            new UserShoe
            {
                Id = 68,
                UserProfileId = 6,
                ShoeId = 89,
                ShoeSize = "7",
                ConditionId = 3,
                Description = "🤑🤑🤑🤑🤑"
            },
        });

        modelBuilder.Entity<Comment>().HasData(new Comment[]
        {
            new Comment
            {
                Id = 1,
                UserProfileId = 5,
                UserShoeId = 43,
                Text = "I love you!!",
                TimeStamp = DateTime.Now.AddDays(-50),
                IsEdited = false
            },
            new Comment
            {
                Id = 2,
                UserProfileId = 5,
                UserShoeId = 43,
                Text = "WAITRESS!!!",
                TimeStamp = DateTime.Now.AddDays(-37),
                IsEdited = false
            },
            new Comment
            {
                Id = 3,
                UserProfileId = 5,
                UserShoeId = 6,
                Text = "I AM THE RAT KING",
                TimeStamp = DateTime.Now.AddDays(-100),
                IsEdited = false
            },
            new Comment
            {
                Id = 4,
                UserProfileId = 5,
                UserShoeId = 6,
                Text = "bustin rats is my gig",
                TimeStamp = DateTime.Now.AddDays(-99),
                IsEdited = false
            },
            new Comment
            {
                Id = 5,
                UserProfileId = 6,
                UserShoeId = 6,
                Text = "did you seriously put nair in my shampoo?!",
                TimeStamp = DateTime.Now.AddDays(-65),
                IsEdited = false
            },
            new Comment
            {
                Id = 6,
                UserProfileId = 4,
                UserShoeId = 6,
                Text = "I'm playing both sides!!!!",
                TimeStamp = DateTime.Now.AddDays(-34),
                IsEdited = false
            },
            new Comment
            {
                Id = 7,
                UserProfileId = 6,
                UserShoeId = 43,
                Text = "LEAVE ME ALONE CHARLIE!!!",
                TimeStamp = DateTime.Now.AddDays(-64),
                IsEdited = false
            },
            new Comment
            {
                Id = 8,
                UserProfileId = 2,
                UserShoeId = 49,
                Text = "I am a 5 ⭐️ man!!!",
                TimeStamp = DateTime.Now.AddDays(-30),
                IsEdited = false
            },
        });

        modelBuilder.Entity<Like>().HasData(new Like[]
        {
            new Like
            {
                Id = 1,
                UserShoeId = 11,
                UserProfileId = 6,
            },
            new Like
            {
                Id = 2,
                UserShoeId = 12,
                UserProfileId = 6,
            },
            new Like
            {
                Id = 3,
                UserShoeId = 6,
                UserProfileId = 4,
            },
            new Like
            {
                Id = 4,
                UserShoeId = 6,
                UserProfileId = 6,
            },
            new Like
            {
                Id = 5,
                UserShoeId = 49,
                UserProfileId = 5,
            },
            new Like
            {
                Id = 6,
                UserShoeId = 50,
                UserProfileId = 5,
            },
            new Like
            {
                Id = 7,
                UserShoeId = 52,
                UserProfileId = 5,
            },
            new Like
            {
                Id = 8,
                UserShoeId = 36,
                UserProfileId = 5,
            },
            new Like
            {
                Id = 9,
                UserShoeId = 38,
                UserProfileId = 5,
            },
            new Like
            {
                Id = 10,
                UserShoeId = 37,
                UserProfileId = 5,
            },
            new Like
            {
                Id = 11,
                UserShoeId = 36,
                UserProfileId = 6,
            },
            new Like
            {
                Id = 12,
                UserShoeId = 38,
                UserProfileId = 6,
            },
            new Like
            {
                Id = 13,
                UserShoeId = 43,
                UserProfileId = 1,
            },
            new Like
            {
                Id = 14,
                UserShoeId = 44,
                UserProfileId = 1,
            },
            new Like
            {
                Id = 15,
                UserShoeId = 46,
                UserProfileId = 1,
            },
            new Like
            {
                Id = 16,
                UserShoeId = 47,
                UserProfileId = 1,
            },
            new Like
            {
                Id = 17,
                UserShoeId = 48,
                UserProfileId = 1,
            },
            new Like
            {
                Id = 18,
                UserShoeId = 58,
                UserProfileId = 1,
            },
            new Like
            {
                Id = 19,
                UserShoeId = 59,
                UserProfileId = 1,
            },
            new Like
            {
                Id = 20,
                UserShoeId = 43,
                UserProfileId = 2,
            },
            new Like
            {
                Id = 21,
                UserShoeId = 44,
                UserProfileId = 2,
            },
            new Like
            {
                Id = 22,
                UserShoeId = 46,
                UserProfileId = 2,
            },
            new Like
            {
                Id = 23,
                UserShoeId = 47,
                UserProfileId = 2,
            },
            new Like
            {
                Id = 24,
                UserShoeId = 48,
                UserProfileId = 2,
            },
            new Like
            {
                Id = 25,
                UserShoeId = 58,
                UserProfileId = 2,
            },
            new Like
            {
                Id = 26,
                UserShoeId = 59,
                UserProfileId = 2,
            },
            new Like
            {
                Id = 27,
                UserShoeId = 43,
                UserProfileId = 5,
            },
            new Like
            {
                Id = 28,
                UserShoeId = 44,
                UserProfileId = 3,
            },
            new Like
            {
                Id = 29,
                UserShoeId = 46,
                UserProfileId = 3,
            },
            new Like
            {
                Id = 30,
                UserShoeId = 47,
                UserProfileId = 3,
            },
            new Like
            {
                Id = 31,
                UserShoeId = 48,
                UserProfileId = 3,
            },
            new Like
            {
                Id = 32,
                UserShoeId = 58,
                UserProfileId = 3,
            },
            new Like
            {
                Id = 33,
                UserShoeId = 59,
                UserProfileId = 3,
            },
        });

        modelBuilder.Entity<Friendship>().HasData(new Friendship[]
        {
            new Friendship
            {
                Id = 1,
                InitiatorId = 6,
                RecipientId = 2,
            },
            new Friendship
            {
                Id = 2,
                InitiatorId = 6,
                RecipientId = 3,
            },
            new Friendship
            {
                Id = 3,
                InitiatorId = 6,
                RecipientId = 4,
            },
            new Friendship
            {
                Id = 4,
                InitiatorId = 5,
                RecipientId = 1,
            },
            new Friendship
            {
                Id = 5,
                InitiatorId = 5,
                RecipientId = 3,
            },
            new Friendship
            {
                Id = 6,
                InitiatorId = 5,
                RecipientId = 2,
            },
            new Friendship
            {
                Id = 7,
                InitiatorId = 5,
                RecipientId = 4,
            },
            new Friendship
            {
                Id = 8,
                InitiatorId = 1,
                RecipientId = 6,
            },
            new Friendship
            {
                Id = 9,
                InitiatorId = 6,
                RecipientId = 5,
            },
        });
    }
}