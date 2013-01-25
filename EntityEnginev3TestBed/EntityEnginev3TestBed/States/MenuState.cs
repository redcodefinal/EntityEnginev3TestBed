using EntityEnginev3.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EntityEnginev3TestBed.States
{
    public class MenuState :EntityState
    {
        public MenuState(EntityGame eg) : base(eg, "MenuState")
        {
            eg.BackgroundColor = new Color(0, 0, 0);
        }

        public override void Start()
        {
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
