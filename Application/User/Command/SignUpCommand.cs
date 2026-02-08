using MediatR;

namespace poketra_vyrt_api.Application.User.Command;

public class SignUpCommand: IRequest<Guid>
{
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
}