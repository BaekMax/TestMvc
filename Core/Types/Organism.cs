using System;
using Core.Types.Interfaces;

namespace Core.Types
{
    public class Organism : IOrganism
    {
        public string Reference { get; }

        public string Slug { get; }

        public string Name { get; }

        public string Description { get; }

        public string Picture { get; }

        public Organism(string reference, string slug, string name, string description, string picture)
        {
            this.Reference = reference;
            this.Slug = slug;
            this.Name = name;
            this.Description = description;
            this.Picture = picture;
        }
    }
}