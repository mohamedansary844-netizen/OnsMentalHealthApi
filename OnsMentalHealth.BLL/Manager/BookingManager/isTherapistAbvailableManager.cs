//using OnsMentalHealth.DAl.Reposatory;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace OnsMentalHealth.BLL.Manager
//{
//    public class isTherapistAbvailableManager : IisTherapistAbvailableManager
//    {

//        private readonly ITherapistAvailabilityRepo _therapistAvailabilityRepo;
//        private readonly IBookingRepo _bookingRepo;

//        public isTherapistAbvailableManager(ITherapistAvailabilityRepo therapistAvailabilityRepo, IBookingRepo bookingRepo)
//        {
//            _therapistAvailabilityRepo = therapistAvailabilityRepo;
//            _bookingRepo = bookingRepo;
//        }

//        public async Task<IEnumerable> GetAvailabilityByTherapistIdAsync(int therapistId, DateTime dateTime)
//        {
//            if (therapistId <= 0)
//                throw new ArgumentException("Invalid therapist ID");

//            var dateOnly = dateTime.Date;

//            return await _therapistAvailabilityRepo
//                .GetAvailabilityByTherapistIdAsync(therapistId, dateOnly);
//        }

        




//        public async Task<bool> IsTherapistAvailableAsync(int therapistId, DateTime dateTime)
//        {
//            // 1) Check availability for that day
//            var availability = await _therapistAvailabilityRepo
//                .GetAvailabilityByTherapistIdAsync(therapistId, dateTime);

//            bool inAvailableRange = availability.Any(a =>
//                a.TherapistId <= therapistId && a.AvailableDate > dateTime);



//            if (!inAvailableRange) return false;

//            else
//            {

//                // 2) Check existing bookings
//                var existingBookings = await _bookingRepo.GetBookingAsync();
//                bool conflict = existingBookings.Any(b =>
//                    b.TherapistId == therapistId &&
//                    b.AvailableDate == dateTime
//                );
//                if (!conflict) return false;

//            }
//            return true;
        
//        }

        
//    }


//    }

