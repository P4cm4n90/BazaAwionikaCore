
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class EltOperationalTestConfiguration : IEntityTypeConfiguration<EltOperationalTestModel>
    {


        public void Configure(EntityTypeBuilder<EltOperationalTestModel> builder)
        {
           // throw new NotImplementedException();
        }
    }
}
