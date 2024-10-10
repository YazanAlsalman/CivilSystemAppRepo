
using System;
public class EntityBase
{
    #region Properties
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool IsDeleted { get; internal set; }
    #endregion
}
