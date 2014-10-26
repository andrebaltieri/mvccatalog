using MvcCatalog.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace MvcCatalog.Data.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");

            HasKey(x => x.Id);

            Property(x => x.Email).IsRequired().HasMaxLength(160).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_USER_EMAIL") { IsUnique = true }));
            Property(x => x.Name).IsRequired().HasMaxLength(60);
            Property(x => x.Password).IsRequired().HasMaxLength(32).IsFixedLength();
            Property(x => x.Username).IsRequired().HasMaxLength(20).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_USER_USERNAME") { IsUnique = true }));
        }
    }
}
