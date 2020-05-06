using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sys.Common
{
    public static class ReflectionHelper
    {
        public static Type GetType(string assemblyName, string className)
        {
            Assembly assembly = Assembly.Load(assemblyName);
            Type type = assembly.GetType(className);
            return type;
        }
    }
}
