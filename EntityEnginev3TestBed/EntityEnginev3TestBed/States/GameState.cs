using EntityEnginev3.Engine;
using EntityEnginev3TestBed.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EntityEnginev3TestBed.States
{
    public class GameState : EntityState
    {
        private Ship _ship;
        public GameState(EntityGame eg) : base(eg, "GameState")
        {
            eg.BackgroundColor = new Color(0, 0, 0);
        }

        public override void Start()
        {
            _ship = new Ship(this, "Ship");
            AddEntity(_ship);
        }

        public override void Show()
        {
            base.Show();
            Start();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }
    }
}
