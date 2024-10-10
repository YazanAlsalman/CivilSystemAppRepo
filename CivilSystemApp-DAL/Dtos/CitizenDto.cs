using CivilSystemApp_DAL.Enums;

namespace CivilSystemApp_ApiLayer.Dtos
{
    public class CitizenDto
    {
        #region Properties
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDate { get; set; }
        public CitizenGenderEnum Gender { get; set; }
        public byte[]? AttachmentData { get; set; }
        #endregion
    }
}
