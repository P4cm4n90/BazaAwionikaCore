
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class EltFunctionalTestConfiguration : IEntityTypeConfiguration<EltFunctionalTestModel>
    {


        public void Configure(EntityTypeBuilder<EltFunctionalTestModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}
