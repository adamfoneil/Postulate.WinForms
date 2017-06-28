using Postulate.Orm.Abstract;
using Postulate.Orm.Attributes;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace Test2.Models
{
    public class Organization : Record<int>
    {
        [MaxLength(100)]
        [PrimaryKey]
        public string Name { get; set; }
        
        public decimal TaxRate { get; set; }
    }

    public class OrgSeedData : SeedData<Organization, int>
    {
        public override string ExistsCriteria => "[dbo].[Organization] WHERE [Name]=@Name";

        public override IEnumerable<Organization> Records => new Organization[]
        {
            new Organization() { Name = "Whatever", TaxRate = 0.1m },
            new Organization() { Name = "Another", TaxRate = 0 },
            new Organization() { Name = "Hello", TaxRate = 0.11m }
        };
    }
}
