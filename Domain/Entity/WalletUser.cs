using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace poketra_vyrt_api.Domain.Entity;

[Index(nameof(PhoneNumber), IsUnique = true)] 
public class WalletUser
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    [MaxLength(255)]
    public string FullName { get; private set; } = string.Empty;
    
    [MaxLength(15)]
    public string PhoneNumber { get; private set; } = string.Empty;
    
    [MaxLength(255)]
    public string Password { get; private set; } = string.Empty;
    
    public AccountStatus Status { get; private set; } = AccountStatus.NotVerified;

    public static WalletUser Create(string fullName, string phoneNumber, string password)
    {
        return new WalletUser
        {
            FullName = fullName,
            PhoneNumber = phoneNumber,
            Password = password
        };
    }
    
    public void Activate() => Status = AccountStatus.Active;
}