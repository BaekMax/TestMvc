using System;
using System.Collections.Generic;
using Core.Types.Interfaces;

namespace Core.Types
{
    public class Fundraiser : IFundraiser
    {
        public string Reference { get; }

        public string Slug { get; }

        public string Name { get; }

        public string Description { get; }

        public string Picture { get; }

        public IList<IActionOption> ActionOptionsList { get; }

        public decimal CollectedAmount { get; }

        public Fundraiser(string reference, string slug, string name, string description, string picture, IList<IActionOption> options, decimal collectedAmount)
        {
            this.Reference = reference;
            this.Slug = slug;
            this.Name = name;
            this.Description = description;
            this.Picture = picture;
            this.ActionOptionsList = options;
            this.CollectedAmount = collectedAmount;
        }
    }
}