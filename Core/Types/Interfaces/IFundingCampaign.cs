using System.Collections.Generic;

namespace Core.Types.Interfaces
{
    /// <summary>
    /// Like a campaign, but with action option so we can fund it
    /// </summary>
    public interface IFundingCampaign : ICampaign
    {
        IList<IActionOption> ActionOptionsList { get; }

        decimal CollectedAmount { get; }
    }
}