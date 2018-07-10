using Castle.DynamicProxy;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;

namespace DIApp.Plumbing
{
    public class CacheAspect : IInterceptor
    {
        private bool hasCacheAttribute(MethodInfo targetMethod)
        {
            return targetMethod.CustomAttributes.Any(x => x.GetType() == typeof(MemCacheAttribute));
        }

        public void Intercept(IInvocation invocation)
        {
            if (this.hasCacheAttribute(invocation.GetConcreteMethodInvocationTarget()))
            {
                string keyName = invocation.Method.Name + string.Join(",", invocation.Arguments.Select(x => x.ToString()));
                var cached = MemoryCache.Default.Get(keyName);
                if (cached == null)
                {
                    invocation.Proceed();
                    var result = invocation.ReturnValue;
                    MemoryCache.Default.Add(keyName, result, new CacheItemPolicy());
                }
                else
                {
                    invocation.ReturnValue = cached;
                }
            }
            else
            {
                invocation.Proceed();
            }
        }
    }
}