using Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface ITourService
    {
        List<VmTour> Filter(string Keyword);
        VmTour Get(int Id);
    }
}
