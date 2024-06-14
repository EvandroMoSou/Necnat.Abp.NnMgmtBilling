using AutoMapper;
using Necnat.Abp.NnMgmtBilling.Domains;
using System.Linq;
using Volo.Abp.AuditLogging;
using Volo.Abp.OpenIddict.Applications;

namespace Necnat.Abp.NnMgmtBilling;

public class NnMgmtBillingApplicationAutoMapperProfile : Profile
{
    public NnMgmtBillingApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<BillingClient, BillingClientDto>();
        CreateMap<BillingClientDto, BillingClient>()
            .ForMember(dest => dest.IdentityUserList, opt => opt.Ignore())
            .ForMember(dest => dest.OpenIddictApplicationList, opt => opt.Ignore())
            .ForMember(dest => dest.BillingContractList, opt => opt.Ignore())
            .ForMember(dest => dest.LastModificationTime, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifierId, opt => opt.Ignore())
            .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
            .ForMember(dest => dest.CreatorId, opt => opt.Ignore())
            .ForMember(dest => dest.ExtraProperties, opt => opt.Ignore())
            .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore());

        CreateMap<BillingContract, BillingContractDto>()
            .ForMember(dest => dest.SkuIdList, opt => opt.MapFrom(s => s.SkuList.Select(x => x.Id)));
        CreateMap<BillingContractDto, BillingContract>()
            .ForMember(dest => dest.SkuReferenceTime, opt => opt.MapFrom(s => (s.SkuReferenceTime ?? default).UtcDateTime))
            .ForMember(dest => dest.EffectiveTime, opt => opt.MapFrom(s => (s.EffectiveTime ?? default).UtcDateTime))
            .ForMember(dest => dest.AcceptanceTime, opt => opt.MapFrom((src, dest) => src.AcceptanceTime?.UtcDateTime))
            .ForMember(dest => dest.BillingClient, opt => opt.Ignore())
            .ForMember(dest => dest.SkuList, opt => opt.Ignore())
            .ForMember(dest => dest.LastModificationTime, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifierId, opt => opt.Ignore())
            .ForMember(dest => dest.CreationTime, opt => opt.Ignore())
            .ForMember(dest => dest.CreatorId, opt => opt.Ignore())
            .ForMember(dest => dest.ExtraProperties, opt => opt.Ignore())
            .ForMember(dest => dest.ConcurrencyStamp, opt => opt.Ignore());

        CreateMap<BillingEndpoint, BillingEndpointDto>();
        CreateMap<BillingEndpointDto, BillingEndpoint>()
            .ForMember(x => x.LastModificationTime, opt => opt.Ignore())
            .ForMember(x => x.LastModifierId, opt => opt.Ignore())
            .ForMember(x => x.CreationTime, opt => opt.Ignore())
            .ForMember(x => x.CreatorId, opt => opt.Ignore())
            .ForMember(x => x.ExtraProperties, opt => opt.Ignore())
            .ForMember(x => x.ConcurrencyStamp, opt => opt.Ignore());

        CreateMap<AuditLog, NnAuditLogDto>();
        CreateMap<NnAuditLogDto, AuditLog>()
            .ForMember(x => x.ExtraProperties, opt => opt.Ignore())
            .ForMember(x => x.ConcurrencyStamp, opt => opt.Ignore())
            .ForMember(x => x.EntityChanges, opt => opt.Ignore())
            .ForMember(x => x.Actions, opt => opt.Ignore());

        CreateMap<OpenIddictApplication, NnOpenIddictApplicationDto>();
        CreateMap<NnOpenIddictApplicationDto, OpenIddictApplication>()
            .ForMember(x => x.LastModificationTime, opt => opt.Ignore())
            .ForMember(x => x.LastModifierId, opt => opt.Ignore())
            .ForMember(x => x.CreationTime, opt => opt.Ignore())
            .ForMember(x => x.CreatorId, opt => opt.Ignore())
            .ForMember(x => x.ExtraProperties, opt => opt.Ignore())
            .ForMember(x => x.ConcurrencyStamp, opt => opt.Ignore())
            .ForMember(x => x.IsDeleted, opt => opt.Ignore())
            .ForMember(x => x.DeleterId, opt => opt.Ignore())
            .ForMember(x => x.DeletionTime, opt => opt.Ignore());
    }
}
