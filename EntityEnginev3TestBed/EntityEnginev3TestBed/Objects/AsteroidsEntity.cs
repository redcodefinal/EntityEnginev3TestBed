using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityEnginev3.Components;
using EntityEnginev3.Engine;
using Microsoft.Xna.Framework;

namespace EntityEnginev3TestBed.Objects
{
    public class AsteroidsEntity : Entity
    {
        public AsteroidsEntity(EntityState stateref, string name) : base(stateref, name)
        {
        }

        public override void Update()
        {
            base.Update();
            const int buffer = 20;
            Vector2 position = GetComponent<Body>().Position;
            if (position.X < -buffer)
                position.X = EntityGame.Viewport.Right + buffer;
            else if (position.X > EntityGame.Viewport.Right + buffer)
                position.X = -buffer;

            if (position.Y < -buffer)
                position.Y = EntityGame.Viewport.Bottom + buffer;
            else if (position.Y > EntityGame.Viewport.Bottom + buffer)
                position.Y = -buffer;
            GetComponent<Body>().Position = position;
        }
    }
}
