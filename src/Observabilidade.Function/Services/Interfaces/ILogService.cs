using Observabilidade.Function.Model;
using System.Threading.Tasks;

namespace Observabilidade.Function.Services.Interfaces
{
    public interface ILogService
    {
        Task AddLog(Log log);
    }
}
