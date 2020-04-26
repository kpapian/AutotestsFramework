using System;
using NUnit.Framework;

namespace CommonLib.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ApiAttribute : CategoryAttribute
    {
    }
}
