using System.Collections.Generic;

namespace BL
{
    internal abstract class Ship : GameObject
    {
        public List<ShipModule> Modules { get; set; }

        internal Ship(int ore, ObjectView view, params ShipModule[] module)
            : base(ore, view)
        {
            AcceptModule(module);
        }

        private void AcceptModule(ShipModule[] module)
        {
            for (int i = 0; i < module.Length; i++)
            {
                Modules[i] = module[i];
            }
        }
    }
}
