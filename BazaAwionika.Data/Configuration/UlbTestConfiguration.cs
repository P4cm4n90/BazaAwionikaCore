
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class UlbTestConfiguration : IEntityTypeConfiguration<UlbTestModel>
    {


        public void Configure(EntityTypeBuilder<UlbTestModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}