using System;
using System.Collections.Generic;
using System.Text;

namespace Delphin.Staff
{
    public class SimpleTools : Delphin.Abstraction.Staff.SimpleTools
    {
        static readonly Lazy<SimpleTools> LazyInstance = new Lazy<SimpleTools>(() => new SimpleTools(), true);
        public new static SimpleTools Instance => LazyInstance.Value;
    }
}
