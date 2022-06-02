using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCourseProject.Model
{
    public partial class Invoicing
    {
        Core db = new Core();
        int activeCost;
        
        public int CostServiceClient
        {
            get
            {
                int activeidRegion = Convert.ToInt32(db.context.House.Where(x => x.IdHouse == Flat.IdHouse).FirstOrDefault().IdRegion);
                if (ServicesRegion.IdServices == 4)
                {
                    activeCost = Convert.ToInt32(db.context.ServicesRegion
                   .Where(x => x.IdRegions == activeidRegion && x.IdServices == IdServicesRegion)
                   .FirstOrDefault()
                   .Cost) * (Flat.Area / 20);
                }
                else
                {
                    activeCost = Convert.ToInt32(db.context.ServicesRegion
                   .Where(x => x.IdRegions == activeidRegion && x.IdServices == IdServicesRegion)
                   .FirstOrDefault()
                   .Cost);
                }
               
                return activeCost;
            }
        }
    }
}
