using DataGridView_Shelkynov.Models;

namespace DataGridView_Shelkynov
{
    public static class ValidateConverter
    {
        /// <summary>
        /// Привести <see cref="Person"/> к <see cref="ValidatePerson"/>
        /// </summary>
        public static Person ToValidateApplicant(ValidatePerson validatePerson)
        {
            return new Person()
            {
                Id = validatePerson.Id,
                Name = validatePerson.Name,
                Gender = validatePerson.Gender,
                Birhday = validatePerson.Birhday,
                Education = validatePerson.Education,
                Value1 = validatePerson.Value1,
                Value2 = validatePerson.Value2,
                Value3 = validatePerson.Value3,
            };
        }

        /// <summary>
        /// Привести <see cref="ValidateApplicant"/> к <see cref="Applicant"/>
        /// </summary>
        public static ValidatePerson ToApplicant(Person person)
        {
            return new ValidatePerson()
            {
                Id = person.Id,
                Name = person.Name,
                Gender = person.Gender,
                Birhday = person.Birhday,
                Education = person.Education,
                Value1 = person.Value1,
                Value2 = person.Value2,
                Value3 = person.Value3,
            };
        }
    }
}
