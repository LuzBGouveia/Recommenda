using Recommenda.Domain.Commom;

namespace Recommenda.Domain.Entities;

public class UserConfiguration : BaseEntity
{
    public string Theme { get; private set; } = "Dark";

    public bool EnableNotifications { get; private set; }

    
    //1..1
    public Guid UserId { get; private set; }

    public UserConfiguration(Guid userId)
    {
        UserId = userId;
    }

}