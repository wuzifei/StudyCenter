using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StudyCenter.UI.ViewModel
{
    public class EasyUiTreeData
    {
        public EasyUiTreeData()
        {
            children = new List<EasyUiTreeData>();
        }

        public string id { get; set; }
        public string text { get; set; }
        public bool Checked { get; set; }
        public List<EasyUiTreeData> children { get; set; }
    }
}