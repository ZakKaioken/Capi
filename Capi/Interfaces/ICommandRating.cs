namespace Capi.Interfaces
{
    public enum CommandRatings
    {
        none = 0,
        cutie = 1,
        hot = 2,
        omy = 3,
        help = 4,
        admin = 5
    }
    public interface ICommandRating
    {
        CommandRatings Rating { get; set; }
    }
}