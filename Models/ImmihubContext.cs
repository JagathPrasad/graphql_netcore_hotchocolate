using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Models;

public partial class ImmihubContext : DbContext
{
    public ImmihubContext()
    {
    }

    public ImmihubContext(DbContextOptions<ImmihubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Community> Communities { get; set; }

    public virtual DbSet<CommunityRequst> CommunityRequsts { get; set; }

    public virtual DbSet<Faq> Faqs { get; set; }

    public virtual DbSet<Flag> Flags { get; set; }

    public virtual DbSet<Follow> Follows { get; set; }

    public virtual DbSet<Hashtag> Hashtags { get; set; }

    public virtual DbSet<Journey> Journeys { get; set; }

    public virtual DbSet<JourneyComment> JourneyComments { get; set; }

    public virtual DbSet<JourneyReaction> JourneyReactions { get; set; }

    public virtual DbSet<Lawyer> Lawyers { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostComment> PostComments { get; set; }

    public virtual DbSet<PostReaction> PostReactions { get; set; }

    public virtual DbSet<PostTopic> PostTopics { get; set; }

    public virtual DbSet<PostType> PostTypes { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }

    public virtual DbSet<ReactionType> ReactionTypes { get; set; }

    public virtual DbSet<Share> Shares { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserCommunity> UserCommunities { get; set; }

    public virtual DbSet<View> Views { get; set; }

    public virtual DbSet<VisaType> VisaTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-DVS65KG\\SQLEXPRESS;Database=Immihub;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admin__3214EC0712D12F74");

            entity.ToTable("Admin");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.MobileNo).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Password).HasMaxLength(500);
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appointm__3214EC07C7D596A4");

            entity.ToTable("Appointment");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AppointmentDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Lawyer).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.LawyerId)
                .HasConstraintName("FK__Appointme__Lawye__628FA481");

            entity.HasOne(d => d.User).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Appointme__UserI__6383C8BA");
        });

        modelBuilder.Entity<Community>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Communit__3214EC0701CB668E");

            entity.ToTable("Community");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Communities)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Community__Creat__37A5467C");
        });

        modelBuilder.Entity<CommunityRequst>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Communit__3214EC07B0CF97D7");

            entity.ToTable("CommunityRequst");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Community).WithMany(p => p.CommunityRequsts)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("FK__Community__Commu__3E52440B");

            entity.HasOne(d => d.RequestUser).WithMany(p => p.CommunityRequstRequestUsers)
                .HasForeignKey(d => d.RequestUserId)
                .HasConstraintName("FK__Community__Reque__403A8C7D");

            entity.HasOne(d => d.User).WithMany(p => p.CommunityRequstUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Community__UserI__3F466844");
        });

        modelBuilder.Entity<Faq>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FAQ__3214EC079B6BAE0E");

            entity.ToTable("FAQ");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Flag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Flag__3214EC07FEFB868A");

            entity.ToTable("Flag");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Comment).WithMany(p => p.Flags)
                .HasForeignKey(d => d.CommentId)
                .HasConstraintName("FK__Flag__CommentId__6E01572D");

            entity.HasOne(d => d.FlaggedUser).WithMany(p => p.Flags)
                .HasForeignKey(d => d.FlaggedUserId)
                .HasConstraintName("FK__Flag__FlaggedUse__5629CD9C");

            entity.HasOne(d => d.Post).WithMany(p => p.Flags)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__Flag__PostId__5535A963");
        });

        modelBuilder.Entity<Follow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Follow__3214EC07C8F3634E");

            entity.ToTable("Follow");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.FollowUser).WithMany(p => p.FollowFollowUsers)
                .HasForeignKey(d => d.FollowUserId)
                .HasConstraintName("FK__Follow__FollowUs__2A4B4B5E");

            entity.HasOne(d => d.User).WithMany(p => p.FollowUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Follow__UserId__29572725");
        });

        modelBuilder.Entity<Hashtag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hashtag__3214EC0789D7855D");

            entity.ToTable("Hashtag");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Journey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Journey__3214EC071918427B");

            entity.ToTable("Journey");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.VisaType).WithMany(p => p.Journeys)
                .HasForeignKey(d => d.VisaTypeId)
                .HasConstraintName("FK__Journey__VisaTyp__68487DD7");
        });

        modelBuilder.Entity<JourneyComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JourneyC__3214EC07C3C8D18B");

            entity.ToTable("JourneyComment");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.GroupId).HasMaxLength(100);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.CommentUser).WithMany(p => p.JourneyComments)
                .HasForeignKey(d => d.CommentUserId)
                .HasConstraintName("FK__JourneyCo__Comme__02FC7413");

            entity.HasOne(d => d.Journey).WithMany(p => p.JourneyComments)
                .HasForeignKey(d => d.JourneyId)
                .HasConstraintName("FK__JourneyCo__Journ__03F0984C");
        });

        modelBuilder.Entity<JourneyReaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__JourneyR__3214EC07B0353D4C");

            entity.ToTable("JourneyReaction");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.JourneyComment).WithMany(p => p.JourneyReactions)
                .HasForeignKey(d => d.JourneyCommentId)
                .HasConstraintName("FK__JourneyRe__Journ__09A971A2");

            entity.HasOne(d => d.Journey).WithMany(p => p.JourneyReactions)
                .HasForeignKey(d => d.JourneyId)
                .HasConstraintName("FK__JourneyRe__Journ__07C12930");

            entity.HasOne(d => d.ReactionType).WithMany(p => p.JourneyReactions)
                .HasForeignKey(d => d.ReactionTypeId)
                .HasConstraintName("FK__JourneyRe__React__06CD04F7");

            entity.HasOne(d => d.ReactionUser).WithMany(p => p.JourneyReactions)
                .HasForeignKey(d => d.ReactionUserId)
                .HasConstraintName("FK__JourneyRe__React__08B54D69");
        });

        modelBuilder.Entity<Lawyer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Lawyer__3214EC0795B38990");

            entity.ToTable("Lawyer");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Education).HasMaxLength(200);
            entity.Property(e => e.MobileNo).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Notifica__3214EC073B7AF425");

            entity.ToTable("Notification");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.MobileAddress).HasMaxLength(200);
            entity.Property(e => e.MobileNo).HasMaxLength(100);

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Notificat__UserI__267ABA7A");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3214EC07311AC669");

            entity.ToTable("Permission");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Faq).HasColumnName("FAQ");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Permissio__UserI__2D27B809");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3214EC073B257067");

            entity.ToTable("Post");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Hashtag).HasMaxLength(200);
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Community).WithMany(p => p.Posts)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("FK__Post__CommunityI__47DBAE45");

            entity.HasOne(d => d.PostTopic).WithMany(p => p.Posts)
                .HasForeignKey(d => d.PostTopicId)
                .HasConstraintName("FK__Post__PostTopicI__46E78A0C");

            entity.HasOne(d => d.PostType).WithMany(p => p.Posts)
                .HasForeignKey(d => d.PostTypeId)
                .HasConstraintName("FK__Post__PostTypeId__45F365D3");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Post__UserId__44FF419A");
        });

        modelBuilder.Entity<PostComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostComm__3214EC07B59B674C");

            entity.ToTable("PostComment");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.CommentUser).WithMany(p => p.PostComments)
                .HasForeignKey(d => d.CommentUserId)
                .HasConstraintName("FK__PostComme__Comme__4D94879B");

            entity.HasOne(d => d.Post).WithMany(p => p.PostComments)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__PostComme__PostI__4CA06362");
        });

        modelBuilder.Entity<PostReaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostReac__3214EC07F473F327");

            entity.ToTable("PostReaction");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Post).WithMany(p => p.PostReactions)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__PostReact__PostI__5165187F");

            entity.HasOne(d => d.ReactionType).WithMany(p => p.PostReactions)
                .HasForeignKey(d => d.ReactionTypeId)
                .HasConstraintName("FK__PostReact__React__5070F446");

            entity.HasOne(d => d.ReactionUser).WithMany(p => p.PostReactions)
                .HasForeignKey(d => d.ReactionUserId)
                .HasConstraintName("FK__PostReact__React__52593CB8");
        });

        modelBuilder.Entity<PostTopic>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostTopi__3214EC07FE39CB8C");

            entity.ToTable("PostTopic");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<PostType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PostType__3214EC07A85375FC");

            entity.ToTable("PostType");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Profile__3214EC0724103228");

            entity.ToTable("Profile");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.EmployerName).HasMaxLength(500);
            entity.Property(e => e.IsUsa).HasColumnName("IsUSA");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.PassportExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.PostTopicId).HasMaxLength(500);
            entity.Property(e => e.UniversityName).HasMaxLength(500);
            entity.Property(e => e.VisaEndDate).HasColumnType("datetime");
            entity.Property(e => e.VisaStartDate).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Profile__UserId__33D4B598");

            entity.HasOne(d => d.VisaType).WithMany(p => p.Profiles)
                .HasForeignKey(d => d.VisaTypeId)
                .HasConstraintName("FK__Profile__VisaTyp__34C8D9D1");
        });

        modelBuilder.Entity<ReactionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reaction__3214EC07323DE09B");

            entity.ToTable("ReactionType");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Share>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Share__3214EC0756F70736");

            entity.ToTable("Share");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Post).WithMany(p => p.Shares)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__Share__PostId__59063A47");

            entity.HasOne(d => d.ShareUser).WithMany(p => p.Shares)
                .HasForeignKey(d => d.ShareUserId)
                .HasConstraintName("FK__Share__ShareUser__59FA5E80");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC07C0D31626");

            entity.ToTable("User");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.MobileNo).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Password).HasMaxLength(500);
        });

        modelBuilder.Entity<UserCommunity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserComm__3214EC070681FD80");

            entity.ToTable("UserCommunity");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Community).WithMany(p => p.UserCommunities)
                .HasForeignKey(d => d.CommunityId)
                .HasConstraintName("FK__UserCommu__Commu__3A81B327");

            entity.HasOne(d => d.User).WithMany(p => p.UserCommunities)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserCommu__UserI__3B75D760");
        });

        modelBuilder.Entity<View>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__View__3214EC078BFC91B0");

            entity.ToTable("View");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

            entity.HasOne(d => d.Post).WithMany(p => p.Views)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__View__PostId__70DDC3D8");
        });

        modelBuilder.Entity<VisaType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VisaType__3214EC07E794027A");

            entity.ToTable("VisaType");

            entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            entity.Property(e => e.ModifiedOn).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
