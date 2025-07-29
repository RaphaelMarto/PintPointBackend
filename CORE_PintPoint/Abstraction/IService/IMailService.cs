using CORE_PintPoint.Entities;

namespace CORE_PintPoint.Abstraction.IService
{
    public interface IMailService
    {
        Task<bool> SendEmail(MailData mailData);
        Task<bool> EmailData(string email, string code, int id, string subject, string textLink, string link);
    }
}
