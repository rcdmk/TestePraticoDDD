using System.ComponentModel.DataAnnotations.Schema;
using TestePratico.Domain.Entities.Validation;
using TestePratico.Domain.Validation;

namespace TestePratico.Domain.Entities
{
    public class UF : EntityBase<UF>
    {
        public UF() : this(0, "") { }

        public UF(int UFId, string name) : this(UFId, name, new UFValidator()) { }

        public UF(int UFId, string name, Validator<UF> validator) : base(validator)
        {
            this.UFId = UFId;
            this.Name = name;
            this.People = new List<Person>();
            this.PeopleCount = 0;
        }

        public int UFId { get; set; }

        public string Name { get; set; }

        [NotMapped]
        public virtual int PeopleCount { get; set; }

        public virtual IList<Person> People { get; set; }

        public UF WithPeopleCount(int count)
        {
            this.PeopleCount = count;
            return this;
        }
    }
}
