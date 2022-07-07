using System.Threading.Tasks;

namespace Fizyka.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
