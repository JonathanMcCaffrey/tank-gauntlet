using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TankGauntlet
{
    public class PlayerActor : BaseActor
    {
        public PlayerActor(ContentManager a_ContentManager)
            : base(a_ContentManager)
        {
            m_Texture2D = a_ContentManager.Load<Texture2D>("Sprite/Tank_Base");
            m_Origin = new Vector2(32, 64 - 18);
        }
    }
}
