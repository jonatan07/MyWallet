using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyWallet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWallet.Infrastructure.EntityTypeConfigurations
{
    public class OperationConfigurations : IEntityTypeConfiguration<Operations>
    {
        public void Configure(EntityTypeBuilder<Operations> builder)
        {
            builder.ToTable("operations");
        }
    }
}
