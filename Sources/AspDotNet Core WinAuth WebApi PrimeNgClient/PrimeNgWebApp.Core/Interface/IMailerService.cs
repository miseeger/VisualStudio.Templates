using DotLiquid.Mailer.Core;

namespace $safeprojectname$.Interface
{
    public interface IMailerService
    {
        IMailEngine Engine { get; }
    }
}
