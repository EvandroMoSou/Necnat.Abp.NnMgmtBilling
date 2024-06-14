using System;
using Volo.Abp.Application.Dtos;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class NnOpenIddictApplicationDto : EntityDto<Guid>
    {
        public virtual string? ApplicationType { get; set; }
        public virtual string? ClientId { get; set; }
        public virtual string? ClientSecret { get; set; }
        public virtual string? ClientType { get; set; }
        public virtual string? ConsentType { get; set; }
        public virtual string? DisplayName { get; set; }
        public virtual string? DisplayNames { get; set; }
        public virtual string? JsonWebKeySet { get; set; }
        public virtual string? Permissions { get; set; }
        public virtual string? PostLogoutRedirectUris { get; set; }
        public virtual string? Properties { get; set; }
        public virtual string? RedirectUris { get; set; }
        public virtual string? Requirements { get; set; }
        public virtual string? Settings { get; set; }
        public virtual string? ClientUri { get; set; }
        public virtual string? LogoUri { get; set; }
    }
}
