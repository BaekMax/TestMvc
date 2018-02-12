namespace Core.Types.Interfaces
{
    /// <summary>
    /// Dynamic info are traditionnaly additionnal question asked to user
    /// </summary>
    public interface IDynamicInfos : ICoreType
    {
        string Reference { get; }

        string Name { get; }

        string Description { get; }

        bool Required { get; }
    }
}