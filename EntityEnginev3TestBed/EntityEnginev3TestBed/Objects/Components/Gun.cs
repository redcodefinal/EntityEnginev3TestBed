using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityEnginev3.Components;
using EntityEnginev3.Components.Render;
using EntityEnginev3.Engine;
using Microsoft.Xna.Framework;

namespace EntityEnginev3TestBed.Objects.Components
{
    public class Gun : Weapon
    {
        public Gun(Entity parent, string name) : base(parent, name)
        {
        }

        public override void Fire()
        {
            Bullet b =  new Bullet(Parent.StateRef, "Bullet");
            b.Body.Angle = Parent.GetComponent<Body>().Angle;
            Vector2 position = Parent.GetComponent<Body>().Position;
            Vector2 scale = Parent.GetComponent<BaseRender>().Scale;

            var origin = position + Parent.GetComponent<BaseRender>().Origin * scale;
            var unrotatedposition = new Vector2(position.X + Parent.GetComponent<BaseRender>().Origin.X, position.Y);

            b.Body.Position = new Vector2(
                (float)(Math.Cos(b.Body.Angle) * (unrotatedposition.X - origin.X) - Math.Sin(b.Body.Angle) * (unrotatedposition.Y - origin.Y) + origin.X),
                (float)(Math.Sin(b.Body.Angle) * (unrotatedposition.X - origin.X) + Math.Cos(b.Body.Angle) * (unrotatedposition.Y - origin.Y) + origin.Y)
            );
            b.Physics.Thrust(4);
            Parent.StateRef.AddEntity(b);
        }
    }
}
