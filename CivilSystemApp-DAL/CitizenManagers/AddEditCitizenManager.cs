using CivilSystemApp_ApiLayer.Dtos;
using CivilSystemApp_DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilSystemApp_DAL.CitizenManagers
{
    public class CRUDCitizenManager
    {
        public readonly CivilContext _civilContext;
        #region Constructors 
        public CRUDCitizenManager(CivilContext civilContext)
        {
            _civilContext = civilContext;
        }
        #endregion

        #region Manager Methods
        public async Task<List<Citizen>> GetCitizensData()
        {
            var citizens = await _civilContext.Citizens.AsNoTracking().Where(c => !c.IsDeleted).ToListAsync();
            return citizens;
        }

        public async Task<bool> AddEditCitizenData(CitizenDto citizen)
        {
            if (citizen.Id != null && citizen.Id != null)
            {
                var newCitizen = new Citizen();
                newCitizen.Name = citizen.Name;
                newCitizen.Nationality = citizen.Nationality;
                newCitizen.BirthDate = citizen.BirthDate;
                newCitizen.Gender = citizen.Gender;
                newCitizen.AttachmentData = citizen.AttachmentData;
                newCitizen.CreatedDate = DateTime.Now;
                await _civilContext.Citizens.AddAsync(newCitizen);
                await _civilContext.SaveChangesAsync();
            }
            else
            {
                var existingCitizen = await _civilContext.Citizens.FirstOrDefaultAsync(c => c.Id == citizen.Id);
                if (existingCitizen != null)
                {
                    existingCitizen.Name = citizen.Name;
                    existingCitizen.Nationality = citizen.Nationality;
                    existingCitizen.BirthDate = citizen.BirthDate;
                    existingCitizen.Gender = citizen.Gender;
                    existingCitizen.AttachmentData = citizen.AttachmentData;
                    existingCitizen.ModifiedDate = DateTime.Now;
                    _civilContext.Citizens.Update(existingCitizen);
                    await _civilContext.SaveChangesAsync();
                }
                else
                    throw new Exception("the Citizen that request to deleted does not exist or deleted .. ");
            }
            return true;
        }

        public async Task<bool> DeleteCitizen(int CitizenId)
        {
            var citizen = await _civilContext.Citizens.FirstOrDefaultAsync(c => c.Id == CitizenId);
            if (citizen != null)
            {
                citizen.IsDeleted = true;
                citizen.DeletedDate = DateTime.Now;
                _civilContext.Citizens.Update(citizen);
                await _civilContext.SaveChangesAsync();
            }
            return true;
        }


        #endregion
    }
}
