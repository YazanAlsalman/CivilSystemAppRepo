using CivilSystemApp_DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilSystemApp_DAL.Entities
{
    public class Citizen : EntityBase
    {
        #region Properties
        public string Name { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDate { get; set; }
        public CitizenGenderEnum Gender { get; set; }
        public byte[]? AttachmentData { get; set; }
        #endregion
    }
}
