using System;
using System.Collections.Generic;
using System.Text;

namespace SegFyYoutube.Domain.Entities
{
    public abstract class BaseEntity
    {
        public virtual string Id { get; set; }
    }
}
