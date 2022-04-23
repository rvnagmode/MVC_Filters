using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;
namespace FiltersInMvc.Models
{
    public class TrackExecutionTime : Attribute, IActionFilter, IResultFilter
    {
        public void GetMessage(string msg)
        {
            File.AppendAllText(Path.GetFullPath(@"D:\vs\FiltersInMvc\Test.txt"), msg);
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string msg = "\nOn action executed ->" + DateTime.Now.ToString()+"\n";
            GetMessage(msg);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string msg = "\nOn action executing ->" + DateTime.Now.ToString() + "\n";
            GetMessage(msg);
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            string msg = "\n On result executed->" + context.RouteData.Values["controller"].ToString() 
                + "->" + context.RouteData.Values["action"].ToString() + 
                " " + DateTime.Now.ToString() + "\n";
            GetMessage(msg);
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            string msg = "\n On result executing->" + context.RouteData.Values["controller"].ToString() +
                "->" + context.RouteData.Values["action"].ToString() + 
                 " " + DateTime.Now.ToString() + "\n";
            GetMessage(msg);
        }
    }
}
