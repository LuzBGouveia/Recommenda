using Recommenda.Domain.Commom;

namespace Recommenda.Domain.Entities;

public class Rating : BaseEntity
{
    public Guid ContentId { get; private set; }

    public Guid UserId { get; private set; }

    public int Score { get; private set; }

    public Rating(Guid contentId, Guid userId, int score)
    {
        ContentId = contentId;
        UserId = userId;
        UpdateScore(score);
    }
    
    public void UpdateScore(int score)
    {
        if (score is < 1 or > 5) throw new Exception("Score must be between 1 and 5");
        Score = score;
    }
    
}