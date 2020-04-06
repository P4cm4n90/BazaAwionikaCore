
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class UlbCvrConfiguration : IEntityTypeConfiguration<UlbCvrModel>
    {


        public void Configure(EntityTypeBuilder<UlbCvrModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}