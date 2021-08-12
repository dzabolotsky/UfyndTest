using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ufynd.Application.Task1.Enums;

namespace Ufynd.Application.Task1.DTO
{
    public class RoomCategoryDTO
    {
        /// <summary>
        /// Room category
        /// </summary>
        public RoomCategoryEnum Category { get; set; }
        /// <summary>
        /// Category description
        /// </summary>
        public string Description { get; set; }
    }
}
