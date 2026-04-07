using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SiteManagement.Data.UnitOfWorks;
using SiteManagement.Entity.DTOs.Sites;
using SiteManagement.Entity.DTOs.Users;
using SiteManagement.Entity.Entities;
using SiteManagement.Service.Services.Abstractions;


namespace SiteManagement.Service.Services.Concretes
{
    public class SiteService : ISiteService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;

        public SiteService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<List<SiteDto>> GetAllSitesWithManagerNameAsync()
        {
            var sites = await unitOfWork.GetRepository<Site>().GetAllAsync(x => !x.IsDeleted, s => s.Manager);
            var map = mapper.Map<List<SiteDto>>(sites);

            return map;
        }

        public async Task<IdentityResult> CreateSiteWithManagerAsync(SiteAddDto siteAddDto)
        {
            Guid? managerId = null;
            IdentityResult result = IdentityResult.Success;

            // Eğer yönetici bilgileri doldurulmuşsa kullanıcıyı oluştur
            if (siteAddDto.Manager != null && !string.IsNullOrEmpty(siteAddDto.Manager.Email))
            {
                var user = mapper.Map<AppUser>(siteAddDto.Manager);
                user.UserName = siteAddDto.Manager.Email;

                result = await userManager.CreateAsync(user, siteAddDto.Manager.Password ?? "");

                if (result.Succeeded)
                {
                    var managerRole = await roleManager.FindByNameAsync("Manager");
                    if (managerRole != null)
                    {
                        await userManager.AddToRoleAsync(user, managerRole.Name);
                    }
                    managerId = user.Id;
                }
                else
                {
                    return result; // Kullanıcı oluşturma hatalarını dön
                }
            }

            // Siteyi her durumda oluştur (managerId null kalabilir)
            var site = new Site
            {
                Name = siteAddDto.Name,
                Address = siteAddDto.Address,
                City = siteAddDto.City,
                ManagerId = managerId // Nullable Guid
            };

            await unitOfWork.GetRepository<Site>().AddAsync(site);
            await unitOfWork.SaveAsync();

            return result;
        }

        public async Task<IdentityResult> UpdateSiteWithManagerAsync(SiteUpdateDto siteUpdateDto)
        {
            var site = await unitOfWork.GetRepository<Site>().GetByGuidAsync(siteUpdateDto.Id);
            IdentityResult result = IdentityResult.Success;

            
            if (siteUpdateDto.ManagerId.HasValue && siteUpdateDto.ManagerId != Guid.Empty)
            {
                site.ManagerId = siteUpdateDto.ManagerId.Value;
            }
            
            else if (siteUpdateDto.NewManager != null && !string.IsNullOrEmpty(siteUpdateDto.NewManager.Email))
            {
                var newUser = mapper.Map<AppUser>(siteUpdateDto.NewManager);
                newUser.UserName = siteUpdateDto.NewManager.Email;

                result = await userManager.CreateAsync(newUser, siteUpdateDto.NewManager.Password ?? "");

                if (result.Succeeded)
                {
                    var role = await roleManager.FindByNameAsync("Manager");
                    await userManager.AddToRoleAsync(newUser, role.Name);

                    site.ManagerId = newUser.Id;
                }
                else
                {
                    return result; 
                }
            }

           
            site.Name = siteUpdateDto.Name;
            site.Address = siteUpdateDto.Address;
            site.City = siteUpdateDto.City;

            await unitOfWork.GetRepository<Site>().UpdateAsync(site);
            await unitOfWork.SaveAsync();

            return result;
        }

        public async Task SafeDeleteSiteAsync(Guid siteId)
        {
            var site = await unitOfWork.GetRepository<Site>().GetByGuidAsync(siteId);

            site.IsDeleted = true;
            site.DeletedDate = DateTime.Now;

            await unitOfWork.GetRepository<Site>().UpdateAsync(site);
            await unitOfWork.SaveAsync();
        }
    }


}
