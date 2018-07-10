using System;

namespace DIApp.Plumbing
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MemCacheAttribute: Attribute
    {
        public int Seconds { get; set; }
    }
}