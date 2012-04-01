using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Data
{
    public enum AreaType
    {
        Start,
        Finish
    }

    public class AreaActor : BaseActor
    {
        private AreaType m_AreaType;
        public AreaType AreaType
        {
            get { return m_AreaType; }
            set { m_AreaType = value; }
        }

        public AreaActor() { }
        public AreaActor(Vector2 a_Position, int a_AreaType)
            : base()
        {
            m_AreaType = (AreaType)a_AreaType;

            if (m_AreaType == AreaType.Start)
            {
                m_FilePathToTexture = "Sprite/Area_Start";
            }
            if (m_AreaType == AreaType.Finish)
            {
                m_FilePathToTexture = "Sprite/Area_Finish";
            }
            m_Position = a_Position;

            m_SourceRectangle = new Rectangle(0, 0, 192, 192);
            m_Origin = new Vector2(92, 92);
        }
    }
}
