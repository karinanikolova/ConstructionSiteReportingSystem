using ConstructionSiteReportingSystem.Infrastructure.Data.Utilities.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionSiteReportingSystem.Infrastructure.Data.Utilities
{
    public abstract class SoftDelete : ISoftDelete
    {
        public bool IsDeleted { get; private set; } = false;

        public DateTimeOffset? DeletedAt { get; private set; } = null;

        public void UndoDelete()
        {
            IsDeleted = false;
            DeletedAt = null;
        }
    }
}
