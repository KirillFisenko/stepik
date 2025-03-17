using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        //builder.HasKey(u => u.Id);
        //builder.Property(u => u.Id).HasColumnName("id");
        //builder.Property(u => u.FullName).HasColumnName("full_name").IsRequired().HasMaxLength(50);
        //builder.Property(u => u.Details).HasColumnName("details").HasMaxLength(50);
        //builder.Property(u => u.JoinDate).HasColumnName("join_date").IsRequired();
        //builder.Property(u => u.Avatar).HasColumnName("avatar");
        //builder.Property(u => u.IsActive).HasColumnName("is_active").IsRequired();
        //builder.Property(u => u.Knowledge).HasColumnName("knowledge").HasDefaultValue(0);
        //builder.Property(u => u.Reputation).HasColumnName("reputation").HasDefaultValue(0);
        //builder.Property(u => u.FollowersCount).HasColumnName("followers_count").HasDefaultValue(0);
        //builder.Property(u => u.DaysWithoutBreak).HasColumnName("days_without_break").HasDefaultValue(0);
        //builder.Property(u => u.DaysWithoutBreakMax).HasColumnName("days_without_break_max").HasDefaultValue(0);
        //builder.Property(u => u.SolvedTasks).HasColumnName("solved_tasks").HasDefaultValue(0);

        //builder.HasMany(u => u.UserCourses).WithOne(uc => uc.User).HasForeignKey(uc => uc.UserId);
        //builder.HasMany(u => u.CourseAuthors).WithOne(ca => ca.User).HasForeignKey(ca => ca.UserId);
        //builder.HasMany(u => u.Certificates).WithOne(c => c.User).HasForeignKey(c => c.UserId);
        //builder.HasMany(u => u.UserSocialProviders).WithOne(usp => usp.User).HasForeignKey(usp => usp.UserId);
        //builder.HasMany(u => u.Progresses).WithOne(p => p.User).HasForeignKey(p => p.UserId);
        //builder.HasMany(u => u.Comments).WithOne(c => c.User).HasForeignKey(c => c.UserId);
        //builder.HasMany(u => u.CourseReviews).WithOne(cr => cr.User).HasForeignKey(cr => cr.UserId);
    }
}
