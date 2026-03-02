using System.ComponentModel.DataAnnotations;
using Recommenda.Domain.Entities;
using Recommenda.Domain.Enums;

namespace Recommenda.Application.DTOs;

public record MovieRequest(

    //Fluent Validation - Package
    
    [Required(ErrorMessage = "The field title is required")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "The field title must be between 2 and 30 characters")]
    string title,

    [Required(ErrorMessage = "The field description is required")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "The field description must be between 2 and 100 characters")]
    string description,

    [Required(ErrorMessage = "The field releaseYear is required")]
    [Range(1888, 2025, ErrorMessage = "The field year must be between 2018 and 2018")]
    DateTime releaseDateTime,
    
    ContentTypeEnum contentType
    
) : ContentRequest(title, description, releaseDateTime)
{
    // poderiamos usar o AutoMapper, mas como será pago vamos usar na mao
    
    public Movie ToDomain() => new Movie(
                                    title,
                                    description,
                                    releaseDateTime,
                                    false,
                                    contentType);
}