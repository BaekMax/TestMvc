using System.Collections.Generic;
using Core.Types.Interfaces;
using System.Web.Script.Serialization;

namespace Service
{
    /// <summary>
    /// Transaction model
    /// </summary>
    public class Model
    {
        [ScriptIgnore]
        public IFundraiser Fundraiser { get; set; }
        public string OptionReference { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Dictionary<string, string> Infos { get; set; }
        public decimal Tip { get; set; }
    }
}