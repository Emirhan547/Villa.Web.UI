using Villa.Business.Abstract;
using Villa.Business.Concrete;
using Villa.DataAccess.Abstract;
using Villa.DataAccess.EntityFramework;
using Villa.DataAccess.Repositories;

namespace Villa.Web.UI.Extensions
{
    public static class ServiceExtensions
    {
       
             public static void AddServiceExtensions(this IServiceCollection services)
        {
            services.AddScoped<IBannerDal, EfBannerDal>();
            services.AddScoped<IBannerService, BannerManager>();

            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<ICounterDal, EfCounterDal>();
            services.AddScoped<ICounterService, CounterManager>();

            services.AddScoped<IDealDal, EfDealDal>();
            services.AddScoped<IDealService, DealManager>();

            services.AddScoped<IFeatureDal, EfFeatureDal>();
            services.AddScoped<IFeatureService, FeatureManager>();

            services.AddScoped<IMessageDal, EfMessageDal>();
            services.AddScoped<IMessageService, MessageManager>();

            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<IProductService, ProductManager>();


            services.AddScoped<IQuestDal, EfQuestDal>();
            services.AddScoped<IQuestService, QuestManager>();


            services.AddScoped<IVideoDal, EfVideoDal>();
            services.AddScoped<IVideoService, VideoManager>();

            services.AddScoped<ISubHeaderDal, EfSubHeaderDal>();
            services.AddScoped<ISubHeaderService, SubHeaderManager>();

            services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
        }
    }
       
    }

