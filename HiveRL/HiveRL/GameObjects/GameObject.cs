using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace HiveRL
{
    public class GameObject
    {
        private Dictionary<Type, Components.ComponentBase> components;
        public GameObject(string name, Maps.Map map)
        {
            this.Name = name;
            this.components = new Dictionary<Type, Components.ComponentBase>();
            this.Location = new Components.Location(this, map);
            this.RegisterComponent(this.Location);
            this.IsBlocking = true;
        }

        public Components.ComponentBase GetComponent(Type componentType)
        {
            if (this.components.ContainsKey(componentType))
                return this.components[componentType];

            return null;
        }

        public void RegisterComponent(Components.ComponentBase component)
        {
            this.components[component.GetType()] = component;
        }

        public String Name { get; set; }

        public void Update(GameTime deltatime)
        {
            var components = this.components.Values;
            for (var i = components.Count() - 1; i >= 0; i--)
            {
                var component = components.ElementAt(i);
                component.Update(deltatime);
            }
        }

        public Components.Location Location { get; set; }

        public bool IsBlocking { get; set; }
    }
}
