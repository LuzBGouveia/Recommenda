using Recommenda.Domain.Enums;

namespace Recommenda.Domain.Entities;

// public - Acesso total
// private - Acesso restrito
// protected - Acesso restrito até classe pai
// internal - Somente no Assembly

public class Movie(string name, string description, DateTime launchDate, bool winOscar, List<Genre> genres)
    : Content(name, description, launchDate, genres)
{
    public bool WinOscar { get; private set; } = winOscar;
}