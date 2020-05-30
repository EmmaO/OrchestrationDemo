using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Orchestration
{
    public class CompensationContext : ICompensationContext
    {
        Stack<Func<Task>> _compensationActions = new Stack<Func<Task>>();

        public void AddCompensationAction(Func<Task> action)
        {
            _compensationActions.Push(action);
        }

        public async Task Rollback()
        {
            foreach (var action in _compensationActions)
            {
                await action();
            }
        }
    }
}
