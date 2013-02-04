using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityEnginev3.Engine;

namespace EntityEnginev3TestBed.Objects.Components
{
    public abstract class Weapon : Component
    {
        protected Weapon(Entity parent, string name) : base(parent, name)
        {
        }

        public abstract void Fire();
    }
}
