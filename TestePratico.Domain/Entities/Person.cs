using TestePratico.Domain.Entities.Validation;
using TestePratico.Domain.Interfaces.Validation;
using TestePratico.Domain.Validation;

namespace TestePratico.Domain.Entities
{
    public class Person : EntityBase<Person>
    {
        public Person() : this(0, "", "", "", "", null) { }

        public Person(int personId, string name, string areaCode, string phone, string email, int? UFId) : this(personId, name, areaCode, phone, email, UFId, new PersonValidator()) { }


        public Person(int personId, string name, string areaCode, string phone, string email, int? UFId, Validator<Person> validator) : base(validator)
        {
            this.PersonId = personId;
            this.Name = name;
            this.AreaCode = areaCode;
            this.Phone = phone;
            this.Email = email;
            this.UFId = UFId;
        }

        public int PersonId { get; set; }

        public string Name { get; set; }

        public DateOnly? Birthdate { get; set; }

        public string AreaCode { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public int? UFId { get; set; }

        public virtual UF? UF { get; set; }
    }
}
