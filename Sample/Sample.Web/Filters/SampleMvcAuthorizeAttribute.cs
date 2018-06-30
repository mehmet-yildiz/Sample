using System.Web.Mvc;

namespace Sample.Web.Filters
{
    public class SampleMvcAuthorizeAttribute : AuthorizeAttribute
    {
        public string[] Permissions { get; set; }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult
                {
                    Data = new
                    {
                        IsLoginRequired = true,
                        IsSuccess = false,
                        ReturnCode = 401,
                        ResultObject = filterContext.HttpContext.Request.Url?.PathAndQuery
                    },
                    ContentEncoding = System.Text.Encoding.UTF8,
                    JsonRequestBehavior = JsonRequestBehavior.DenyGet
                };
                filterContext.HttpContext.Response.StatusCode = 530;
                filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
                filterContext.HttpContext.Response.BufferOutput = true;
            }
            else
            {
                var redirectUrl = "~/Account/Login?returnURL=" + filterContext.HttpContext.Request.Url?.PathAndQuery;

                filterContext.Result = new RedirectResult(redirectUrl, false);
            }
        }
    }
}