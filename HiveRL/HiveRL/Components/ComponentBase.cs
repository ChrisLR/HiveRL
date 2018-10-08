using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace HiveRL.Components
{
    public class ComponentBase
    {
        public ComponentBase(string name, GameObject host)
        {
            this.Host = host;
            this.Name = name;
        }

        public String Name { get; set; }
        public GameObject Host { get; set; }

        public virtual void Update(GameTime deltatime)
        {

        }
    }
}
