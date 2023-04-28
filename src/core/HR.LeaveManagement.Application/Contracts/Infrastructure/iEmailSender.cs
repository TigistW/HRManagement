using HR.LeaveManagement.Application.Models;

namespace HR.LeaveManagement.Application.Contracts.Infrastructure;

public interface iEmailSender
{
    Task<bool> SendEmail (Email email);
}
