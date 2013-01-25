using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityEnginev3.Engine;
using EntityEnginev3TestBed.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EntityEnginev3TestBed
{
    public class TestGame : EntityGame
    {
        private MenuState _ms;
        private GameState _gs;

        public TestGame(Game game, GraphicsDeviceManager g, SpriteBatch spriteBatch) : base(game, g, spriteBatch, new Rectangle(0,0,600,600))
        {
            _ms = new MenuState(this);
            
            _gs = new GameState(this);
            _gs.Show();
        }
    }
}
