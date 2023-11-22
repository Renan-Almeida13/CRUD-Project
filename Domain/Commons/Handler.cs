using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commons
{
    public abstract class Handler
    {
        public List<string> Errors { get; set; }

        protected Handler() 
        { 
            Errors = new List<string>();
        }
    }
}
