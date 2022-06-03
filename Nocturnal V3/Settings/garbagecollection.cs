using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nocturnal.Settings
{
    internal class garbagecollection
    {
        internal static void clear()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

    }
}
