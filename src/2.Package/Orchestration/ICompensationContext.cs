using System;
using System.Threading.Tasks;

namespace Orchestration
{
    public interface ICompensationContext
    {
        void AddCompensationAction(Func<Task> action);
        Task Rollback();
    }
}