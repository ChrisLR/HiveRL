using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace HiveRL
{
    public class Keybindings
    {
        public Dictionary<Microsoft.Xna.Framework.Input.Keys, Actions.ActionBase> keyMap;
           
        public Keybindings()
        {
            this.keyMap = new Dictionary<Keys, Actions.ActionBase>();
            this.applyDefault();
        }

        public void applyDefault()
        {
            this.keyMap[Keys.W] = new Actions.Walk(Directions.North);
            this.keyMap[Keys.D] = new Actions.Walk(Directions.East);
            this.keyMap[Keys.S] = new Actions.Walk(Directions.South);
            this.keyMap[Keys.A] = new Actions.Walk(Directions.West);
            this.keyMap[Keys.NumPad8] = new Actions.Walk(Directions.North);
            this.keyMap[Keys.NumPad6] = new Actions.Walk(Directions.East);
            this.keyMap[Keys.NumPad2] = new Actions.Walk(Directions.South);
            this.keyMap[Keys.NumPad4] = new Actions.Walk(Directions.West);
        }

        public Actions.ActionBase GetAction(Keys key)
        {
            Actions.ActionBase action = null;
            this.keyMap.TryGetValue(key, out action);

            return action;
        }
    }
}
