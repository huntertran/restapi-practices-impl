using Microsoft.AspNetCore.Mvc;

namespace sampleApi.Utils.PostPutPatchReturn.Core
{
    public abstract class CommonControllerLogics : ControllerBase
    {
        public IActionResult HandleReturnObjectLogic(bool isSuccess,
                                                     bool isReturnObject,
                                                     object result,
                                                     string message)
        {
            if (isSuccess)
            {
                if (isReturnObject)
                {
                    return Ok(result);
                }
                else
                {
                    return Ok();
                }
            }

            return StatusCode(500, message);
        }
    }
}