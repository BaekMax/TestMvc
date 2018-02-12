using System;
using System.Collections.Generic;
using Core.Types.Interfaces;

namespace Core.Types
{
    public class ActionOption : IActionOption
    {
        public string Reference { get; }

        public string Name { get; }

        public string Description { get; }

        public decimal Amount { get; }

        public IList<IDynamicInfos> DynamicInfos { get; }

        public ActionOption(string reference, string name, string description, decimal amount, IList<IDynamicInfos> infos)
        {
            this.Reference = reference;
            this.Name = name;
            this.Description = description;
            this.Amount = amount;
            this.DynamicInfos = infos;
        }
    }
}