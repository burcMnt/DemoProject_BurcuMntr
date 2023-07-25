using ApplicationCore.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Dtos
{
    public class BuildingDto
    {
        public Guid UserId { get; set; }
        public BuildingTypeEnum BuildingType { get; set; }
        public decimal BuildingCost { get; set; }
        public long ConstructionTime { get; set; }

    }
}
