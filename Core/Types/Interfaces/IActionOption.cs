using System.Collections.Generic;

namespace Core.Types.Interfaces
{
    /// <summary>
    /// This is attached to a funding campaign to determine user option: price
    /// </summary>
    public interface IActionOption : ICoreType
    {
        string Reference { get; }

        string Name { get; }

        string Description { get; }

        decimal Amount { get; }

        IList<IDynamicInfos> DynamicInfos { get; }
    }
}