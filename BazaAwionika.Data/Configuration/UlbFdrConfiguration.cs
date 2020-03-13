
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class UlbFdrConfiguration : IEntityTypeConfiguration<UlbFdrModel>
    {


        public void Configure(EntityTypeBuilder<UlbFdrModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}