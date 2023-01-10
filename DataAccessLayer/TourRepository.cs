using DataAccessLayer.Interfaces;
using Models.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TourRepository : ITourRepository
    {
        static List<Tour>? _data;

        static List<Tour>? Data
        {
            get
            {
                if (_data == null)
                {
                    _data = JsonConvert.DeserializeObject<Tours>(File.ReadAllText("activities.json"))?.tours;
                }
                return _data;
            }
        }

        public List<Tour>? Filter(string? Keyword)
        {
            if (string.IsNullOrEmpty(Keyword))
                return _data;

            return Data?.Where(r=>!string.IsNullOrEmpty(r.title) && r.title.ToLower().Contains(Keyword.ToLower())).ToList();
        }

        public Tour? Get(int id)
        {
            return _data?.FirstOrDefault(r => r.id == id);
        }
    }
}
