namespace Core.Types.Interfaces
{
    /// <summary>
    /// This is an organism !
    /// </summary>
    public interface IOrganism : ICoreType
    {
        string Reference { get; }

        string Slug { get; }

        string Name { get; }

        string Description { get; }

        string Picture { get; }
    }
}