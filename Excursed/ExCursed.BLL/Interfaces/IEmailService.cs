using System.Threading.Tasks;

namespace ExCursed.BLL.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(string receiver, string subject, string bodyHtml);
    }
}
