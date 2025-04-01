using Application.DTOs;

namespace Application.Validators
{
    public class RegionValidator : GenericValidator<RegionDTO>
    {
        public RegionValidator() : base(x => x.Name, "El nombre de la región")
        {
            
        }
    }
}
