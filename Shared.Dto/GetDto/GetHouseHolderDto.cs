using Shared.Dto.CreateDto;

namespace Shared.Dto.GetDto
{
    public class GetHouseHolderDto: PersonDto
    {
        public HouseRequestDto HouseRequest { get; set; }
    }
}