﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FEXNA.Graphics.Text;

namespace FEXNA.Windows.UserInterface.Status
{
    class StatusHpUINode : StatusStatLargeLabelUINode
    {
        protected Func<Game_Unit, string> MaxStatFormula;
        private Func<Game_Unit, Color> LabelHueFormula;
        protected FE_Text SlashLabel, MaxHpText;
        private Color LabelTint = Color.White;

        internal StatusHpUINode(
            string helpLabel,
            string label,
            Func<Game_Unit, string> statFormula,
            Func<Game_Unit, string> maxStatFormula,
            Func<Game_Unit, Color> labelHueFormula)
                : base(helpLabel, label, statFormula, 32)
        {
            MaxStatFormula = maxStatFormula;
            LabelHueFormula = labelHueFormula;

            SlashLabel = new FE_Text();
            SlashLabel.draw_offset = new Vector2(32, 0);
            SlashLabel.Font = "FE7_Text";
            SlashLabel.texture = Global.Content.Load<Texture2D>(@"Graphics/Fonts/FE7_Text_Yellow");
            SlashLabel.text = "/";

            MaxHpText = new FE_Text_Int();
            MaxHpText.draw_offset = new Vector2(32 + 24, 0);
            MaxHpText.Font = "FE7_Text";
            MaxHpText.texture = Global.Content.Load<Texture2D>(@"Graphics/Fonts/FE7_Text_Blue");

            Size = new Vector2(32 + 24, 16);
        }

        internal override void refresh(Game_Unit unit)
        {
            base.refresh(unit);
            MaxHpText.text = MaxStatFormula(unit);
            refresh_label_hue(unit);
        }

        private void refresh_label_hue(Game_Unit unit)
        {
            if (LabelHueFormula != null)
                LabelTint = LabelHueFormula(unit);
        }

        private void apply_label_hue()
        {
            Label.tint = new Color(
                Label.tint.R * LabelTint.R / 255,
                Label.tint.G * LabelTint.G / 255,
                Label.tint.B * LabelTint.B / 255,
                Label.tint.A * LabelTint.A / 255);
        }

        protected override void update_graphics(bool activeNode)
        {
            base.update_graphics(activeNode);
            SlashLabel.update();
            MaxHpText.update();
        }

        protected override void mouse_off_graphic()
        {
            base.mouse_off_graphic();
            apply_label_hue();
            SlashLabel.tint = Color.White;
            MaxHpText.tint = Color.White;
        }
        protected override void mouse_highlight_graphic()
        {
            base.mouse_highlight_graphic();
            apply_label_hue();
            SlashLabel.tint = Config.MOUSE_OVER_ELEMENT_COLOR;
            MaxHpText.tint = Config.MOUSE_OVER_ELEMENT_COLOR;
        }
        protected override void mouse_click_graphic()
        {
            base.mouse_click_graphic();
            apply_label_hue();
            SlashLabel.tint = Config.MOUSE_PRESSED_ELEMENT_COLOR;
            MaxHpText.tint = Config.MOUSE_PRESSED_ELEMENT_COLOR;
        }

        public override void Draw(SpriteBatch sprite_batch, Vector2 draw_offset = default(Vector2))
        {
            SlashLabel.draw(sprite_batch, draw_offset - (loc + draw_vector()));
            MaxHpText.draw(sprite_batch, draw_offset - (loc + draw_vector()));

            base.Draw(sprite_batch, draw_offset);
        }
    }
}
