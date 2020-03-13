
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class OxygenExchangeConfiguration : IEntityTypeConfiguration<OxygenExchangeModel>
    {


        public void Configure(EntityTypeBuilder<OxygenExchangeModel> builder)
        {
            builder.Property(c => c.AdditionalInformation).IsUnicode(false).HasMaxLength(100);
 
        }
    }
}