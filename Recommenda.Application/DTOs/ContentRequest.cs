namespace Recommenda.Application.DTOs;

public abstract record ContentRequest(
    string Title, 
    string Description, 
    DateTime ReleaseDateTime);