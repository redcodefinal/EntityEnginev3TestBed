using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityEnginev3.Components;
using EntityEnginev3.Components.Render;
using EntityEnginev3.Engine;
using EntityEnginev3.Input;
using EntityEnginev3TestBed.Objects.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace EntityEnginev3TestBed.Objects
{
    public class Ship : AsteroidsEntity
    {
        public Body Body;
        public Physics Physics;
        public Health Health;
        public ImageRender ImageRender;
        public Weapon Weapon;

        private DoubleInput _attackkey, _upkey, _leftkey, _rightkey, _downkey, _debugkey;
        private GamePadAnalog _moveanalog, _aimanalog;
        private GamePadTrigger _shoottrigger;

        private const float SPEED = .3f;
        private const float TURNINGSPEED = .08f;
        private const int FIRINGSPEED = 100;
        public Ship(EntityState stateref, string name) : base(stateref, name)
        {
            Body = new Body(this, "Body", new Vector2(200,200));
            AddComponent(Body);

            Physics = new Physics(this, "Physics");
            Physics.Drag = 0.9f;
            AddComponent(Physics);

            ImageRender = new ImageRender(this, "ImageRender");
            ImageRender.LoadTexture(@"Asteroids/ship-small");
            ImageRender.Color = Color.White;
            ImageRender.Origin = new Vector2(ImageRender.Texture.Width * ImageRender.Scale.X / 2, ImageRender.Texture.Height * ImageRender.Scale.Y / 2);
            ImageRender.Scale = new Vector2(1, 1);
            AddComponent(ImageRender);

            Weapon = new Gun(this, "Weapon");
            AddComponent(Weapon);

            _attackkey = new DoubleInput(this, "AttackKey", Keys.Enter, Buttons.A, PlayerIndex.One);
            _upkey = new DoubleInput(this, "UpKey", Keys.W, Buttons.DPadUp, PlayerIndex.One);
            _downkey = new DoubleInput(this, "DownKey", Keys.S, Buttons.DPadDown, PlayerIndex.One);
            _leftkey = new DoubleInput(this, "LeftKey", Keys.A, Buttons.DPadLeft, PlayerIndex.One);
            _rightkey = new DoubleInput(this, "RightKey", Keys.D, Buttons.DPadRight, PlayerIndex.One);
            _debugkey = new DoubleInput(this, "DebugKey", Keys.P, Buttons.Start, PlayerIndex.One);

            AddComponent(_attackkey);
            AddComponent(_upkey);
            AddComponent(_downkey);
            AddComponent(_leftkey);
            AddComponent(_rightkey);
            AddComponent(_debugkey);

            _moveanalog = new GamePadAnalog(this, "MoveAnalog", Sticks.Left, PlayerIndex.One);
            AddComponent(_moveanalog);

            _aimanalog = new GamePadAnalog(this, "AimAnalog", Sticks.Right, PlayerIndex.One);
            AddComponent(_aimanalog);

            _shoottrigger = new GamePadTrigger(this, "ShootTrigger", Triggers.Right, PlayerIndex.One);
            AddComponent(_shoottrigger);
        }

        public override void Update()
        {
            base.Update();

            Physics.Thrust(-_moveanalog.Position.Y*SPEED);
            Body.Angle += _aimanalog.Position.X * TURNINGSPEED;

            if(_upkey.Down())
                Physics.Thrust(SPEED);
            else if (_downkey.Down())
                Physics.Thrust(-SPEED);
            if (_leftkey.Down())
                Body.Angle -= TURNINGSPEED;
            if (_rightkey.Down())
                Body.Angle += TURNINGSPEED;

            if(_attackkey.RapidFire(FIRINGSPEED) || _shoottrigger.RapidFire(FIRINGSPEED))
            {
                Weapon.Fire();
            }

            if (_debugkey.Pressed())
                Destroy();
        }
    }
}
