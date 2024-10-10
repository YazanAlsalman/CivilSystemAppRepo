using CivilSystemApp_DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilSystemApp_DAL.Entities
{
    public class Citizen
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public CitizenGenderEnum Gender { get; set; }
        public byte[]? AttachmentData { get; set; }
        public bool IsDeleted { get; internal set; }
        #endregion
    }
}
