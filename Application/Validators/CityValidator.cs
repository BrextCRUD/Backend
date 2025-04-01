using Application.DTOs;

namespace Application.Validators
{
    public class CityValidator : GenericValidator<CityDTO>
    {
        public CityValidator() : base(x => x.Name, "El nombre de la ciudad")
        {
            
        }
    }
}
