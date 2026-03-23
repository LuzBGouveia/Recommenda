using Recommenda.Domain.Commom;
using Recommenda.Domain.Helpers;

namespace Recommenda.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    private DateOnly SetBirhDate { get;  set; }
    public string Password { get; private set; }
    private string Salt { get; set; }

    //1..N
    public List<Rating> Ratings { get; private set; }

    //1..1
    public UserConfiguration Configuration { get; set; }

    public User(string name, string email, DateOnly dateBorn, string rawPassword)
    {
        UpdateName(name);
        UpdateEmail(email);
        SetBirthDate(dateBorn);
        ChangePassword(rawPassword);
    }
    
    public void UpdateName(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new Exception("Nome não pode ser vazio.");
        
        Name = newName;
    }

    public void UpdateEmail(string newEmail)
    {
        if (string.IsNullOrWhiteSpace(newEmail) || !newEmail.Contains("@"))
            throw new Exception("E-mail inválido.");
            
        Email = newEmail;
    }

    public void SetBirthDate(DateOnly newDate)
    {
        var age = CalculateAge(newDate);
        
        if (age < 13)
            throw new Exception("Usuário deve ter pelo menos 13 anos.");

        SetBirhDate = newDate;
    }

    public void ChangePassword(string newRawPassword)
    {
        if (string.IsNullOrWhiteSpace(newRawPassword) || newRawPassword.Length < 8)
            throw new Exception("A senha deve ter pelo menos 8 caracteres.");

        Salt = Guid.NewGuid().ToString("N"); 
        
        Password = HashHelper.Hash(newRawPassword, Salt);
    }
    
    public int Age => CalculateAge(SetBirhDate);

    private static int CalculateAge(DateOnly date)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        var age = today.Year - date.Year;
        if (date > today.AddYears(-age)) age--;
        return age;
    }
     
}