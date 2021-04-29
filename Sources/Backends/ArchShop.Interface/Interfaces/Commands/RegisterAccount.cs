using ArchShop.Models;
using MediatR;

namespace ArchShop.Interfaces.Commands
{
    public class RegisterAccount : IRequest<AccountDetailsModel>
    {
        public string FirstName { get; }
        public string LastName { get; }

        public RegisterAccount(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
