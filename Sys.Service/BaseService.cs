using Sys.Common;
using Sys.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Service
{
    public abstract class BaseService
    {
        protected SysContext NewDB()
        {
            return new SysContext();
        }

        protected void Try(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                LogHelper.Default.Error("ServiceBase.Try", ex);
            }
        }
    }
}
