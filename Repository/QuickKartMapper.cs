using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using QuickKartDataAccessLayer.Models;
using QuickKartCoreMVCApp.Models;


namespace QuickKartCoreMVCApp.Repository
{
    public class QuickKartMapper : Profile
    {
        public QuickKartMapper()
        {
            CreateMap<QuickKartDataAccessLayer.Models.Products, Models.Products>();
            CreateMap<Models.Products, QuickKartDataAccessLayer.Models.Products>();
            CreateMap<QuickKartDataAccessLayer.Models.Categories, Models.Categories>();
            CreateMap<Models.Categories, QuickKartDataAccessLayer.Models.Categories>();
            CreateMap<Models.PurchaseDetails, QuickKartDataAccessLayer.Models.PurchaseDetails>();

        }
    }

}
