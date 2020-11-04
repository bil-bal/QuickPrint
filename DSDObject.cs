using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickPrint
{
    class DSDObject
    {
        public DSDObject()
        {

        }

        public string DWG { get; set; }
        public string Layout { get; set; }
        public string Setup { get; set; }
        public string DwgName { get; set; }
        public string CreateDSDEntry()
        {
            string sb = $"[DWF6Sheet: {this.DwgName}-{this.Layout}]\nDWG={this.DWG}\nLayout={this.Layout}\nSetup={this.Setup}";
            return sb;
        }
    }
}
