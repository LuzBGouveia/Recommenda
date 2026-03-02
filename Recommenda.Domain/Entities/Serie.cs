namespace Recommenda.Domain.Entities;

public class Serie : Content
{
    public int SeasonCount { get; private set; }

    public int EpisodeCount { get; private set; }
    
    public Serie(string name, string description, DateTime launchDate, int seasonCount, int episodeCount) : base(name, description, launchDate)
    {
        Validate(seasonCount, episodeCount);
        
        EpisodeCount = episodeCount;
        SeasonCount = seasonCount;
    }

    private static void Validate(int seasonCount, int episodeCount)
    {
        if (seasonCount < 1 || episodeCount < 1) throw new Exception("Invalid season/episode count.");
    }
}