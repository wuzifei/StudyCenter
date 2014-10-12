using System;

namespace StudyCenter.UI.ViewModel
{
    public class AjaxMessage
    {
        public AjaxMessage()
        {
            BackUrl = "/user/index";
            Message = "";
            Status = "";
            Data = null;
        }

        public string Status { get; set; }
        public string Message { get; set; }
        public string BackUrl { get; set; }
        public Object Data { get; set; }
    }
}