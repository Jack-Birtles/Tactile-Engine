﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FEXNA.Graphics.Text;

namespace FEXNA.Windows.UserInterface.Command
{
    class ItemUINode : CommandUINode
    {
        protected Status_Item Text;
        protected FE_Text EquippedTag;

        internal ItemUINode(
                string helpLabel,
                Status_Item text,
                int width)
            : base(helpLabel)
        {
            Text = text;
            Size = new Vector2(width, 16);

            EquippedTag = new FE_Text();
            EquippedTag.draw_offset = new Vector2(width - 8, 0);
            EquippedTag.Font = "FE7_Text";
            EquippedTag.texture = Global.Content.Load<Texture2D>(
                @"Graphics/Fonts/FE7_Text_White");
            EquippedTag.text = "$";
            EquippedTag.visible = false;
        }

        internal override void set_text_color(string color)
        {
            Text.change_text_color(color);
            EquippedTag.texture = Global.Content.Load<Texture2D>(
                string.Format(@"Graphics/Fonts/FE7_Text_{0}", color));
        }

        internal void equip(bool value)
        {
            EquippedTag.visible = value;
        }

        protected override void update_graphics(bool activeNode)
        {
            Text.update();
        }

        protected override void mouse_off_graphic()
        {
            Text.tint = Color.White;
        }
        protected override void mouse_highlight_graphic()
        {
            Text.tint = FEXNA.Config.MOUSE_OVER_ELEMENT_COLOR;
        }
        protected override void mouse_click_graphic()
        {
            Text.tint = FEXNA.Config.MOUSE_PRESSED_ELEMENT_COLOR;
        }

        public override void Draw(SpriteBatch sprite_batch, Vector2 draw_offset = default(Vector2))
        {
            Text.draw(sprite_batch, draw_offset - (loc + draw_vector()));
            EquippedTag.draw(sprite_batch, draw_offset - (loc + draw_vector()));
        }
    }
}
