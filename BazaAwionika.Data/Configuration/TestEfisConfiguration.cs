
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class TestEfisConfiguration : IEntityTypeConfiguration<TestEfisModel>
    {


        public void Configure(EntityTypeBuilder<TestEfisModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}