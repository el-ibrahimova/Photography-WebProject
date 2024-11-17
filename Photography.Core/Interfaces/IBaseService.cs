namespace Photography.Core.Interfaces
{
    public interface IBaseService
    {
        bool IsGuidValid(string? id, ref Guid parsedGuid);
        bool IsUserPhotographerAsync(string? userId);
    }
}
