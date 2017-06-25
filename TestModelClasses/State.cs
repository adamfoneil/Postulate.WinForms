using Postulate.Orm;
using Postulate.Orm.Abstract;
using Postulate.Orm.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test2.Models
{
    public class State : Record<int>
    {
        [UniqueKey]
        [MaxLength(2)]
        public string Abbreviation { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
    }

    /*public class StateSeedData : SeedData<State, int>
    {
        public override string ExistsCriteria => "[dbo].[State] WHERE [Abbreviation]=@abbreviation";

        public override IEnumerable<State> Records => new State[]
            {
                new State() { Abbreviation = "SC", Name = "South Carolina"},
                new State() { Abbreviation = "NC", Name = "North Carolina"},
                new State() { Abbreviation = "GA", Name = "Georgia" },
                new State() { Abbreviation = "VA", Name = "Virginia" },
                new State() { Abbreviation = "TN", Name = "Tennessee" },
                new State() { Abbreviation = "AL", Name = "Alabama" },
                new State() { Abbreviation = "WY", Name = "Wyoming"}
            };
    }*/
}
