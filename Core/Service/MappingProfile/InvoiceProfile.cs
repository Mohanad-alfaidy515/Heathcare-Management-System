using Domain.Models;
using Shared;

namespace Service.MappingProfile
{
    public class InvoiceProfile : AutoMapper.Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Invoice, InvoiceDto>()
                .ForMember(d => d.Status, o => o.MapFrom(s => s.Status.ToString()));
        }
    }
}
