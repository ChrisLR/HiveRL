using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiveRL.Actions
{
    public class ActionBase
    {
        public virtual bool CanExecute(GameObject executor)
        {
            return true;
        }

        public virtual void Execute(GameObject executor)
        {

        }
    }
}
