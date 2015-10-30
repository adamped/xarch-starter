using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Helper
{
    public static class OperationService
    {
        private static Dictionary<object, bool> _status = new Dictionary<object, bool>();
        public static async Task SingleRun(this object sender, Func<Task> operation)
        {

            lock (sender)
            {
                if (!_status.ContainsKey(sender))
                    _status.Add(sender, true);
                else if (_status[sender])
                    return;
                else
                    _status[sender] = true;
            }

            try
            {
                await operation();
            }
            catch
            {
                throw;
            }
            finally
            {
                lock (sender)
                {
                    _status.Remove(sender);
                }
            }
        }

    }
}
