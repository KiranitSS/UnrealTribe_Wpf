using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnrealTribe.InventoryResources
{
    public abstract class Item
    {
        public string Name { get; protected set; }
        public float Weight { get; protected set; }

        public bool IsCountable { get; protected set; }

        protected Item()
        {
            this.Name = string.Empty;
            this.Weight = 0;
        }

        protected Item(string name, float weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj is Item item)
            {
                return this.Name == item.Name && this.Weight == item.Weight && this.IsCountable == item.IsCountable;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            int nameHash = this.Name is null ? 0 : this.Name.GetHashCode();
            int widthHash = this.Weight.GetHashCode();
            int isEnumerableHash = this.IsCountable.GetHashCode();

            return nameHash ^ widthHash ^ isEnumerableHash;
        }
    }
}
