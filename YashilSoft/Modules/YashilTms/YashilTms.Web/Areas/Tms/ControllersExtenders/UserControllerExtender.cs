using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yashil.Common.Core.Classes;
using Yashil.Core.ControllersExtenders;
using Yashil.Core.CustomViewModels;
using Yashil.Core.Entities;
using YashilTms.Core.Services;

namespace YashilTms.Web.Areas.Tms.ControllersExtenders
{
    public class UserControllerExtender : IUserControllerExtender
    {
        private readonly IAdditionalUserPropService _additionalUserPropService;
        private readonly IUserPrincipal _userPrincipal;

        public UserControllerExtender(IAdditionalUserPropService additionalUserPropService,
            IUserPrincipal userPrincipal)
        {
            _additionalUserPropService = additionalUserPropService;
            _userPrincipal = userPrincipal;
        }

        public void BeforeUpdate(List<object> editModelKeyValues, int insertedUserId)
        {
            var additionalUserProp = _additionalUserPropService.GetByUserId(insertedUserId) ??
                                     new AdditionalUserProp { UserId = insertedUserId };

            SetAdditionalPropValue(additionalUserProp, editModelKeyValues);
            if (additionalUserProp.Id == 0)
                _additionalUserPropService.Add(additionalUserProp);
            else
                _additionalUserPropService.Update(additionalUserProp, additionalUserProp.Id);
        }

        private void SetAdditionalPropValue(AdditionalUserProp additionalUserProp,
            List<object> editModelKeyValues)
        {
            if (editModelKeyValues[0] == null)
            {
                var currentAdditionalUserProp = _additionalUserPropService.GetByUserId(_userPrincipal.Id);
                editModelKeyValues[0] = currentAdditionalUserProp.EducationalCenterId;
            }

            additionalUserProp.EducationalCenterId = Convert.ToInt32(editModelKeyValues[0].ToString());
            if (editModelKeyValues[1] != null)
                additionalUserProp.RepresentationId = Convert.ToInt32(editModelKeyValues[1].ToString());
            else
                additionalUserProp.RepresentationId = null;
        }

        public List<object> GetCustomProps(int userId)
        {
            var additionalInfos = new List<object>();
            var additionalUserProp = _additionalUserPropService.GetByUserId(userId);
            additionalInfos.Add(additionalUserProp?.EducationalCenterId);
            additionalInfos.Add(additionalUserProp?.RepresentationId);
            return additionalInfos;
        }

        public void BeforeInsert(User user, List<object> editModelKeyValues, int editModelId)
        {
            var additionalUserProp = new AdditionalUserProp { User = user };
            SetAdditionalPropValue(additionalUserProp, editModelKeyValues);
            _additionalUserPropService.Add(additionalUserProp);
        }
    }
}