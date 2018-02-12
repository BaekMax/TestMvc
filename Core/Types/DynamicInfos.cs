using System;
using Core.Types.Interfaces;

namespace Core.Types
{
    public class DynamicInfos : IDynamicInfos
    {
        public string Reference { get; }

        public string Name { get; }

        public string Description { get; }

        public bool Required { get; }

        public DynamicInfos(string reference, string name, string description, bool required)
        {
            this.Reference = reference;
            this.Name = name;
            this.Description = description;
            this.Required = required;
        }
    }
}