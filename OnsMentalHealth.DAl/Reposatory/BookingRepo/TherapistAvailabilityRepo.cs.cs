//using Microsoft.EntityFrameworkCore;
//using OnsMentalHealth.DAl.Entities;
//using OnsMentalHealthSolution.DAL.Context;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace OnsMentalHealth.DAl.Reposatory
//{
//    public class TherapistAvailabilityRepo : ITherapistAvailabilityRepo
//    {
//        private readonly OnsDbContext _onsDbContext;

//        public TherapistAvailabilityRepo(OnsDbContext onsDbContext)
//        {
//            _onsDbContext = onsDbContext;
//        }

//        public async Task<IEnumerable<TherapistAvailabilities>> GetAvailabilityByTherapistIdAsync(int therapistId, DateTime dateTime)
//        {
//            var dateOnly = dateTime.Date;   

//            return await _onsDbContext.TherapistAvailabilities
//                .Where(a => a.TherapistId == therapistId
//                         && a.AvailableDate.Date == dateOnly) 
//                .ToListAsync();

//        }

//        public async Task<bool> IsTherapistAvailableAsync(int therapistId, DateTime dateTime)
//        {
//            var dateOnly = dateTime.Date;  

//            return await _onsDbContext.TherapistAvailabilities
//                .AnyAsync(a => a.TherapistId == therapistId
//                            && a.AvailableDate.Date == dateOnly); 
//        }
//    }
//}