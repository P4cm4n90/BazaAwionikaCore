
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class TestTruConfiguration : IEntityTypeConfiguration<TestTruModel>
    {


        public void Configure(EntityTypeBuilder<TestTruModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}