using Observabilidade.Function.Model;
using System.Threading.Tasks;

namespace Observabilidade.Function.Data.Interfaces
{
    internal interface ILogRepository
    {
        Task Add(Log log);
    }
}
