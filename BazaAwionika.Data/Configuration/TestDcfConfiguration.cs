
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class TestDcfConfiguration : IEntityTypeConfiguration<TestDcfModel>
    {


        public void Configure(EntityTypeBuilder<TestDcfModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}