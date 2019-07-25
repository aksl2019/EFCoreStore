using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreStore.Models
{
    public partial class DbContextGenerator
    {
        public DbContextGenerator()
        {
            EFCoreStoreContext = new EFCoreStoreContext();
        }

        private EFCoreStoreContext EFCoreStoreContext { get;  }
    }
}
