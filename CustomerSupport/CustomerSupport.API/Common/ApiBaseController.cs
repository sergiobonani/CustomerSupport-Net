using CustomerSupport.Application.ViewModels.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSupport.API.Common
{
    [ApiExceptionFilterAttribute]
    public class ApiBaseController : Controller
    {
        //public IActionResult JsonOrError<T>(string result)
        //{
        //}
        public IActionResult JsonOrError<T>(ResultWrap<T> result)
        {
            if (result.IsSuccess)
            {
                if (result.Data != null)
                {
                    return Json(result.Data);
                }
                return Json(result);
            }
            else
            {
                var resultJson = Json(result.Errors);
                //Error Status 512 - Erro referente a negócio
                //
                switch (result.Error)
                {
                    case EKnowErrors.BusinessError:
                        resultJson.StatusCode = 512;
                        break;
                    case EKnowErrors.NotFoundError:
                        resultJson.StatusCode = 404;
                        break;
                    case EKnowErrors.PermissionError:
                        resultJson.StatusCode = 401;
                        break;
                    default:
                        resultJson.StatusCode = 501;
                        break;
                }

                return resultJson;
            }
        }

    }
}