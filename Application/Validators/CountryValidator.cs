using Application.DTOs;

namespace Application.Validators
{
    public class CountryValidator : GenericValidator<CountryDTO>
    {
        public CountryValidator() : base(x => x.Name, "El nombre del país")
        {
            
        }
    }
}
