using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityEnginev3.Components;
using EntityEnginev3.Components.Render;
using EntityEnginev3.Engine;
using EntityEnginev3.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace EntityEnginev3TestBed.Objects
{
    public class Ship : Entity
    {
        public Body Body;
        public Physics Physics;
        public Health Health;
        public ImageRender ImageRender;

        public DoubleInput _attackkey, _upkey, _leftkey, _rightkey, _downkey;
        public GamePadAnalog _moveanalog, _aimanalog;

        private const float SPEED = .9f;
        private const float TURNINGSPEED = .08f;
        public Ship(IComponent parent, string name) : base(parent, name)
        {
            Body = new Body(this, "Body", new Vector2(200,200));
            AddComponent(Body);

            Physics = new Physics(this, "Physics");
            Physics.Drag = 0.9f;
            AddComponent(Physics);

            ImageRender = new ImageRender(this, "ImageRender");
            ImageRender.LoadTexture(@"Asteroids/ship");
            ImageRender.Color = Color.White;
            ImageRender.Origin = new Vector2(ImageRender.Texture.Width * ImageRender.Scale.X / 2, ImageRender.Texture.Height * ImageRender.Scale.Y / 2);
            AddComponent(ImageRender);

            _attackkey = new DoubleInput(this, "AttackKey", Keys.Enter, Buttons.A, PlayerIndex.One);
            _upkey = new DoubleInput(this, "UpKey", Keys.W, Buttons.DPadUp, PlayerIndex.One);
            _downkey = new DoubleInput(this, "DownKey", Keys.S, Buttons.DPadDown, PlayerIndex.One);
            _leftkey = new DoubleInput(this, "LeftKey", Keys.A, Buttons.DPadLeft, PlayerIndex.One);
            _rightkey = new DoubleInput(this, "RightKey", Keys.D, Buttons.DPadDown, PlayerIndex.One);

            AddComponent(_attackkey);
            AddComponent(_upkey);
            AddComponent(_downkey);
            AddComponent(_leftkey);
            AddComponent(_rightkey);

            _moveanalog = new GamePadAnalog(this, "MoveAnalog", Sticks.Left, PlayerIndex.One);
            AddComponent(_moveanalog);

            _aimanalog = new GamePadAnalog(this, "AimAnalog", Sticks.Right, PlayerIndex.One);
            AddComponent(_aimanalog);
        }

        public override void Update()
        {
            base.Update();

            Physics.Thrust(-_moveanalog.Position.Y*SPEED);
            Body.Angle += _aimanalog.Position.X * TURNINGSPEED;
        }
    }
}
