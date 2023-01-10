using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Data;
namespace DataAccessLayer.Interfaces
{
    public interface ITourRepository
    {
        List<Tour>? Filter(string? Keyword);
        Tour? Get(int id);
    }
}
