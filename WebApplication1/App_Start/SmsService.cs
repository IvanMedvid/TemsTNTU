using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace WebApplication1
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // ���������� ����� ������ SMS, ����� ��������� ��������� ���������.
            return Task.FromResult(0);
        }

        public override bool Equals(object obj)
        {
            throw new System.NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}