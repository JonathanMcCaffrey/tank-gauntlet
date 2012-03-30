using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Button
{
    public abstract class AbstractMenuScreen : AbstractGameScreen
    {
        #region Data
        private int mEntrySelected = 0;
        public int EntrySelected
        {
            get { return mEntrySelected; }
            set { mEntrySelected = value; }
        }

        private Color mSelectedColor = Color.White;
        private Color mUnselectedColor = Color.Gray;
        private SpriteFont mTextFont;

        private List<string> mMenuEntries = new List<string>();
        public List<string> MenuEntries
        {
            get { return mMenuEntries; }
        }

        public int Count
        {
            get { return mMenuEntries.Count; }
        }
        #endregion

        #region Construction
        public AbstractMenuScreen()
        {
            mTextFont = theFileManager.LoadFont(@"Title");
        }
        #endregion

        #region Methods
        protected virtual void MenuSelect(int aSelectedEntry) { }

        public override void Update(GameTime aGameTime)
        {
            if (theInputManager.SingleKeyPressInput(Keys.Enter) | theInputManager.SingleButtonPressInput(Buttons.Start))
            {
                MenuSelect(mEntrySelected);
            }

            if (theInputManager.SingleKeyPressInput(Keys.Left) | theInputManager.SingleKeyPressInput(Keys.Up) |
                theInputManager.SingleButtonPressInput(Buttons.DPadLeft) | theInputManager.SingleButtonPressInput(Buttons.DPadUp))
            {
                mEntrySelected--;

                if (mEntrySelected < 0)
                {
                    mEntrySelected = MenuEntries.Count - 1;
                }
            }
            if (theInputManager.SingleKeyPressInput(Keys.Right) | theInputManager.SingleKeyPressInput(Keys.Down) |
                theInputManager.SingleButtonPressInput(Buttons.DPadRight) | theInputManager.SingleButtonPressInput(Buttons.DPadDown))
        {
                mEntrySelected++;

                if (mEntrySelected >= MenuEntries.Count)
                {
                    mEntrySelected = 0;
                }
            }

            base.Update(aGameTime);
        }

        public override void Draw(GameTime aGameTime)
        {
            base.Draw(aGameTime);

            Vector2 textPosition = new Vector2(GraphicsDevice.Viewport.Width / 10, GraphicsDevice.Viewport.Height / 3);

            SpriteBatch.Draw(BackgroundTexture, theUtilityManager.GetRectangle(GraphicsDevice), BackgroundColor);

            for (int i = 0; i < MenuEntries.Count; i++)
            {
                bool isSelected = (i == mEntrySelected);
                DrawEntry(MenuEntries[i], textPosition, isSelected, aGameTime);
                textPosition.Y += mTextFont.LineSpacing * 2;
            }
        }

        private void DrawEntry(string aEntry, Vector2 aPosition, bool isSelected, GameTime aGameTime)
        {
            Vector2 textOrigin = new Vector2(mTextFont.LineSpacing, mTextFont.LineSpacing / 2);
            Color textColor = isSelected ? mSelectedColor : mUnselectedColor;
            float textSize = 1.0f;
            float textScale = isSelected ? textSize : textSize;
            aPosition = isSelected ? aPosition + new Vector2(10, 0) : aPosition;

            SpriteBatch.DrawString(mTextFont, aEntry, aPosition, textColor, 0, textOrigin, textScale, SpriteEffects.None, 0);
        }
        #endregion
    }
}
