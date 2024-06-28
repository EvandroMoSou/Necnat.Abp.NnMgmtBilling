using Microsoft.EntityFrameworkCore;
using Necnat.Abp.NnMgmtBilling.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.OpenIddict.Applications;

namespace Necnat.Abp.NnMgmtBilling.Domains
{
    public class EfCoreBillingClientRepository : EfCoreRepository<INnMgmtBillingDbContext, BillingClient, Guid>, IBillingClientRepository
    {
        public EfCoreBillingClientRepository(IDbContextProvider<INnMgmtBillingDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        public async Task<bool> AnyUserIdAndClientIdAsync(Guid userId, string clientId)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(
                x => x.IdentityUserList.Any(x => x.Id == userId) 
                && x.OpenIddictApplicationList.Any(x => x.ClientId == clientId))
                .AnyAsync();
        }

        #region User

        public async Task<List<IdentityUser>> GetUsersAsync(Guid id)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(x => x.Id == id)
                .Select(x => x.IdentityUserList).FirstOrDefaultAsync() ?? throw new EntityNotFoundException(typeof(BillingClient), id);
        }

        public async Task<List<IdentityUser>> InsertUserAsync(Guid id, Guid userId, bool autosave = false)
        {
            var dbContext = await GetDbContextAsync();
            var user = await dbContext.BillingClient.Where(x => x.Id == id).Include(x => x.IdentityUserList).FirstOrDefaultAsync() ?? throw new EntityNotFoundException(typeof(BillingClient), id);
            
            user.IdentityUserList.Add(await dbContext.Users.Where(x => x.Id == userId).FirstOrDefaultAsync() ?? throw new EntityNotFoundException(typeof(IdentityUser), userId));

            if (autosave)
                await dbContext.SaveChangesAsync();

            return user.IdentityUserList;
        }

        public async Task<List<IdentityUser>> DeleteUserAsync(Guid id, Guid userId, bool autosave = false)
        {
            var dbContext = await GetDbContextAsync();
            var user = await dbContext.BillingClient.Where(x => x.Id == id).Include(x => x.IdentityUserList).FirstOrDefaultAsync() ?? throw new EntityNotFoundException(typeof(BillingClient), id);

            user.IdentityUserList.RemoveAll(x => x.Id == userId);

            if (autosave)
                await dbContext.SaveChangesAsync();

            return user.IdentityUserList;
        }

        #endregion

        #region OpenIddictApplication

        public async Task<List<OpenIddictApplication>> GetOpenIddictApplicationsAsync(Guid id)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(x => x.Id == id)
                .Select(x => x.OpenIddictApplicationList).FirstOrDefaultAsync() ?? throw new EntityNotFoundException(typeof(BillingClient), id);
        }

        public async Task<List<OpenIddictApplication>> InsertOpenIddictApplicationAsync(Guid id, Guid openIddictApplicationId, bool autosave = false)
        {
            var dbContext = await GetDbContextAsync();
            var user = await dbContext.BillingClient.Where(x => x.Id == id).Include(x => x.OpenIddictApplicationList).FirstOrDefaultAsync() ?? throw new EntityNotFoundException(typeof(BillingClient), id);

            user.OpenIddictApplicationList.Add(await dbContext.OpenIddictApplications.Where(x => x.Id == openIddictApplicationId).FirstOrDefaultAsync() ?? throw new EntityNotFoundException(typeof(OpenIddictApplication), openIddictApplicationId));

            if (autosave)
                await dbContext.SaveChangesAsync();

            return user.OpenIddictApplicationList;
        }

        public async Task<List<OpenIddictApplication>> DeleteOpenIddictApplicationAsync(Guid id, Guid openIddictApplicationId, bool autosave = false)
        {
            var dbContext = await GetDbContextAsync();
            var user = await dbContext.BillingClient.Where(x => x.Id == id).Include(x => x.OpenIddictApplicationList).FirstOrDefaultAsync() ?? throw new EntityNotFoundException(typeof(BillingClient), id);

            user.OpenIddictApplicationList.RemoveAll(x => x.Id == openIddictApplicationId);

            if (autosave)
                await dbContext.SaveChangesAsync();

            return user.OpenIddictApplicationList;
        }

        #endregion
    }
}
