using Postulate.Orm.Abstract;
using Postulate.Orm.Attributes;
using System.ComponentModel.DataAnnotations;

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
}
