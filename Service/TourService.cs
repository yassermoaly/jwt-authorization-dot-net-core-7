using AutoMapper;
using DataAccessLayer.Interfaces;
using Models.View;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class TourService : ITourService
    {
        private readonly ITourRepository _tourRepository;
        private readonly IMapper _mapper;
        public TourService(ITourRepository tourRepository,IMapper mapper)
        {
            _tourRepository = tourRepository;
            _mapper = mapper;
        }
        public List<VmTour> Filter(string? Keyword)
        {
            return _mapper.Map<List<VmTour>>(_tourRepository.Filter(Keyword));
        }
        public VmTour Get(int Id)
        {
            return _mapper.Map<VmTour>(_tourRepository.Get(Id));
        }
    }
}
