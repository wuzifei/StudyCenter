using System.Collections.Generic;

namespace StudyCenter.Model.ViewModel
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