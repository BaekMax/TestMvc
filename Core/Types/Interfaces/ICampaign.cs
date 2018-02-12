namespace Core.Types.Interfaces
{
    /// <summary>
    /// This is a campaign !
    /// </summary>
    public interface ICampaign : ICoreType
    {
        string Reference { get; }

        string Slug { get; }

        string Name { get; }

        string Description { get; }

        string Picture { get; }
    }
}