using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityEnginev3.Components;
using EntityEnginev3.Components.Collision;
using EntityEnginev3.Components.Render;
using EntityEnginev3.Engine;
using Microsoft.Xna.Framework.Graphics;

namespace EntityEnginev3TestBed.Objects
{
    public class Bullet : AsteroidsEntity
    {
        public Body Body;
        public Physics Physics;
        public ImageRender ImageRender;
        public Collision Collision;

        public int TimeToLive = 60;
        public int FadeAge = 5;

        public Bullet(EntityState stateref, string name) : base(stateref, name)
        {
            Body = new Body(this, "Body");
            AddComponent(Body);

            Physics = new Physics(this, "Physics");
            AddComponent(Physics);

            ImageRender = new ImageRender(this, "ImageRender");
            ImageRender.LoadTexture(@"Asteroids/bullet");
            ImageRender.Layer = .2f;
            AddComponent(ImageRender);
        }

        public override void Update()
        {
            base.Update();
            TimeToLive--;
            if (TimeToLive < FadeAge)
                ImageRender.Alpha -= 1f/FadeAge;
            if(TimeToLive <= 0)
                Destroy();
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }
    }
}
