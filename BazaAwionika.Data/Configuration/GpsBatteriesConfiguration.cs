
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class GpsBatteriesConfiguration : IEntityTypeConfiguration<GpsBatteriesModel>
    {


        public void Configure(EntityTypeBuilder<GpsBatteriesModel> builder)
        {
            //throw new NotImplementedException();
        }
    }
}