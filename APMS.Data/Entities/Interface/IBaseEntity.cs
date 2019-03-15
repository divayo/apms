using System;
using System.Collections.Generic;
using System.Text;

namespace APMS.Data.Entities.Interface
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
    }
}
