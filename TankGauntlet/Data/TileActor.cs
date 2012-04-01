using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Data
{
    public class TileActor : BaseActor
    {
        public TileActor() { }
        public TileActor(string a_FilePathToModel, Vector2 a_Position, bool a_IsCollidable, bool a_IsDestructable)
            : base()
        {
            m_FilePathToTexture = a_FilePathToModel;
            m_Position = a_Position;
            m_IsCollidable = a_IsCollidable;
            m_IsDestructable = a_IsDestructable;
        }

        public TileActor Clone()
        {
            return new TileActor(m_FilePathToTexture, m_Position, m_IsCollidable, m_IsDestructable);
        }
    }
}
