using MediatR;
using poketra_vyrt_api.Application.User.Command;
using poketra_vyrt_api.Domain.Entity;
using poketra_vyrt_api.Infrastructure.Repository;

namespace poketra_vyrt_api.Application.User.CommandHandler;

public class SignUpHandler(UserRepository userRepository): IRequestHandler<SignUpCommand, Guid>
{
    public async Task<Guid> Handle(SignUpCommand cmd, CancellationToken cancellationToken)
    {
        var phoneNumberAlreadyUsed = await userRepository.CheckIfPhoneNumberAlreadyExist(cmd.PhoneNumber);
        if (phoneNumberAlreadyUsed) throw new Exception("Phone number already used");
        var newUser = WalletUser.Create
        (
            fullName: cmd.FullName,
            phoneNumber: cmd.PhoneNumber,
            password: cmd.Password
        );
        var savedUser = await userRepository.AddNewUser(newUser, cancellationToken);
        return savedUser.Id;
    }
}