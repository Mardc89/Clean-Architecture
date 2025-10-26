using App.DTO;
using App.Entities.POCO;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Mapping
{


    public static class MappingConfig
    {
        public static void RegisterMapping(TypeAdapterConfig config)
        {
            #region Person
            config.NewConfig<Person, PersonDTO>().TwoWays();
            #endregion

        }
    }

}
