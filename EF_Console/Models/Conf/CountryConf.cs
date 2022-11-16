using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Console.Models.Conf
{
    /// <summary>
    /// Конфигурации создания таблицы вынесены в отдельный класс
    /// </summary>
    public class CountryConf : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Table_Name").Property(c => c.Id).IsRequired();
            builder.Property(c => c.Name).HasColumnName("Name");
        }
    }
}
