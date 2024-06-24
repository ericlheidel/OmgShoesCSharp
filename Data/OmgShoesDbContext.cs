using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OmgShoes.Models;
using Microsoft.AspNetCore.Identity;

namespace OmgShoes.Data;

public class OmgShoesDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Condition> Conditions { get; set; }
    public DbSet<Friendship> Friendships { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Shoe> Shoes { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<UserShoe> UserShoes { get; set; }

    public OmgShoesDbContext(DbContextOptions<OmgShoesDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "rfv98hu4-3206-4gga-t8ws-457k5v543l6r"
        });

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
                Avatar = null,
                Bio = "I'm a bird!",
                IsAdmin = false
            },
            new UserProfile
            {
                Id = 2,
                IdentityUserId = "frt98wr5-0223-3ww7-t6rq-028g4r521d4e",
                Email = "dennis@reynolds.com",
                Name = "Dennis Reynolds",
                City = "Philadelphia",
                State = "PA",
                Avatar = null,
                Bio = "I'm a five star man!!!!",
                IsAdmin = false
            },
            new UserProfile
            {
                Id = 3,
                IdentityUserId = "hdp65oa9-3053-5ap0-z0hh-235t2a098h8q",
                Email = "frank@reynolds.com",
                Name = "Frank Reynolds",
                City = "Philadelphia",
                State = "PA",
                Avatar = null,
                Bio = "I'm gonna get real weird with it!!",
                IsAdmin = false
            },
            new UserProfile
            {
                Id = 4,
                IdentityUserId = "rse05dd6-2058-3bg0-a3oo-204t2l308f3p",
                Email = "ronald@macdonald.com",
                Name = "Ronald McDonald",
                City = "Philadelphia",
                State = "PA",
                Avatar = null,
                Bio = "I'm playing both sides`!",
                IsAdmin = false
            },
            new UserProfile
            {
                Id = 5,
                IdentityUserId = "wmo20ow7-0582-9pp1-i8sl-037h7w843j8r",
                Email = "charlie@kelly.com",
                Name = "Charlie Kelly",
                City = "Philadelphia",
                State = "PA",
                Avatar = null,
                Bio = "I hate Charlie work!!!!!!",
                IsAdmin = false
            },
            new UserProfile
            {
                Id = 6,
                IdentityUserId = "rfv98hu4-3206-4gga-t8ws-457k5v543l6r",
                Email = "the@waitress.com",
                Name = "The Waitress",
                City = "Philadelphia",
                State = "PA",
                Avatar = null,
                Bio = "Nobody knows my name!",
                IsAdmin = true
            },
        });

        modelBuilder.Entity<Shoe>().HasData(new Shoe[]
        {
            new Shoe{
                Id = ,
                Name = ,
                Style = ,
                Year = ,
                ModelNumber = ,
                Colorway = ,
                Image = ,
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

        modelBuilder.Entity<Comment>().HasData(new Comment[]
        {
            new Comment
            {
                Id = 1,
                UserId = 5,
                UserShoeId = 43,
                Text = "I love you!!",
                TimeStamp = DateTime.Now.AddDays(-50),
                IsEdited = false
            },
            new Comment
            {
                Id = 2,
                UserId = 5,
                UserShoeId = 43,
                Text = "WAITRESS!!!",
                TimeStamp = DateTime.Now.AddDays(-37),
                IsEdited = false
            },
            new Comment
            {
                Id = 3,
                UserId = 5,
                UserShoeId = 6,
                Text = "I AM THE RAT KING",
                TimeStamp = DateTime.Now.AddDays(-100),
                IsEdited = false
            },
            new Comment
            {
                Id = 4,
                UserId = 5,
                UserShoeId = 6,
                Text = "bustin rats is my gig",
                TimeStamp = DateTime.Now.AddDays(-99),
                IsEdited = false
            },
            new Comment
            {
                Id = 5,
                UserId = 6,
                UserShoeId = 6,
                Text = "did you seriously put nair in my shampoo?!",
                TimeStamp = DateTime.Now.AddDays(-65),
                IsEdited = false
            },
            new Comment
            {
                Id = 6,
                UserId = 4,
                UserShoeId = 6,
                Text = "I'm playing both sides!!!!",
                TimeStamp = DateTime.Now.AddDays(-34),
                IsEdited = false
            },
            new Comment
            {
                Id = 7,
                UserId = 6,
                UserShoeId = 43,
                Text = "LEAVE ME ALONE CHARLIE!!!",
                TimeStamp = DateTime.Now.AddDays(-64),
                IsEdited = false
            },
            new Comment
            {
                Id = 8,
                UserId = 2,
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
                UserId = 6,
                UserShoeId = 11
            },
            new Like
            {
                Id = 2,
                UserId = 6,
                UserShoeId = 12
            },
            new Like
            {
                Id = 3,
                UserId = 4,
                UserShoeId = 6
            },
            new Like
            {
                Id = 4,
                UserId = 6,
                UserShoeId = 6
            },
            new Like
            {
                Id = 5,
                UserId = 5,
                UserShoeId = 49
            },
            new Like
            {
                Id = 6,
                UserId = 5,
                UserShoeId = 50
            },
            new Like
            {
                Id = 7,
                UserId = 5,
                UserShoeId = 52
            },
            new Like
            {
                Id = 8,
                UserId = 5,
                UserShoeId = 36
            },
            new Like
            {
                Id = 9,
                UserId = 5,
                UserShoeId = 37
            },
        });

        modelBuilder.Entity<Friendship>().HasData(new Friendship[]
        {

        });
    }
}