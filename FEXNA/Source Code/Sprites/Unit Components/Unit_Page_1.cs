﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FEXNA.Graphics.Text;

namespace FEXNA
{
    class Unit_Page_1 : Unit_Page
    {
        const int STATUS_ICONS_AT_ONCE = 3;

        protected FE_Text Class, Lvl, Exp, Hp, Slash, MaxHp;
        protected Icon_Sprite Affinity_Icon;
        protected List<Status_Icon_Sprite> Status_Icons;

        public Unit_Page_1(Game_Unit unit)
        {
            // Class
            Class = new FE_Text();
            Class.loc = new Vector2(0, 0);
            Class.Font = "FE7_Text";
            Class.texture = Global.Content.Load<Texture2D>(@"Graphics/Fonts/FE7_Text_White");
            Class.text = unit.actor.class_name;
            // Lvl
            Lvl = new FE_Text_Int();
            Lvl.loc = new Vector2(88, 0);
            Lvl.Font = "FE7_Text";
            Lvl.texture = Global.Content.Load<Texture2D>(@"Graphics/Fonts/FE7_Text_Blue");
            Lvl.text = unit.actor.level.ToString();
            // Exp
            Exp = new FE_Text_Int();
            Exp.loc = new Vector2(108, 0);
            Exp.Font = "FE7_Text";
            Exp.texture = Global.Content.Load<Texture2D>(@"Graphics/Fonts/FE7_Text_Blue");
            Exp.text = unit.actor.can_level() ? unit.actor.exp.ToString() : "--";
            // Hp
            Hp = new FE_Text_Int();
            Hp.loc = new Vector2(128, 0);
            Hp.Font = "FE7_Text";
            Hp.texture = Global.Content.Load<Texture2D>(@"Graphics/Fonts/FE7_Text_Blue");
            Hp.text = unit.actor.hp.ToString();
            // Slash
            Slash = new FE_Text();
            Slash.loc = new Vector2(129, 0);
            Slash.Font = "FE7_Text";
            Slash.texture = Global.Content.Load<Texture2D>(@"Graphics/Fonts/FE7_Text_White");
            Slash.text = "/";
            // MaxHp
            MaxHp = new FE_Text_Int();
            MaxHp.loc = new Vector2(152, 0);
            MaxHp.Font = "FE7_Text";
            MaxHp.texture = Global.Content.Load<Texture2D>(@"Graphics/Fonts/FE7_Text_Blue");
            MaxHp.text = unit.actor.maxhp.ToString();
            // Affinity
            Affinity_Icon = new Icon_Sprite();
            Affinity_Icon.texture = Global.Content.Load<Texture2D>(@"Graphics/Icons/Affinity Icons");
            Affinity_Icon.size = new Vector2(16, 16);
            Affinity_Icon.loc = new Vector2(160, 0);
            Affinity_Icon.index = (int)unit.actor.affin;
            // Status_Icons
            Status_Icons = new List<Status_Icon_Sprite>();
            for (int i = 0; i < Math.Min(STATUS_ICONS_AT_ONCE, unit.actor.states.Count); i++)
            {
                Status_Icons.Add(new Status_Icon_Sprite());
                Status_Icons[Status_Icons.Count - 1].texture = Global.Content.Load<Texture2D>(@"Graphics/Icons/Statuses");
                Status_Icons[Status_Icons.Count - 1].size = new Vector2(16, 16);
                Status_Icons[Status_Icons.Count - 1].loc = new Vector2(
                    175 + (i * 16) + ((STATUS_ICONS_AT_ONCE - Math.Min(STATUS_ICONS_AT_ONCE, unit.actor.states.Count)) * 8), 0);
                Status_Icons[Status_Icons.Count - 1].index = Global.data_statuses[unit.actor.states[i]].Image_Index;
                Status_Icons[Status_Icons.Count - 1].counter = unit.actor.state_turns_left(unit.actor.states[i]);
            }
        }

        public override void update()
        {
            Class.update();
            Lvl.update();
            Exp.update();
            Hp.update();
            Slash.update();
            MaxHp.update();
            Affinity_Icon.update();
            foreach (Icon_Sprite icon in Status_Icons)
                icon.update();
        }

        public override void draw(SpriteBatch sprite_batch, Vector2 draw_offset = default(Vector2))
        {
            Vector2 loc = this.loc + draw_vector();
            sprite_batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, Scissor_State);
            Class.draw(sprite_batch, draw_offset - loc);
            Lvl.draw(sprite_batch, draw_offset - loc);
            Exp.draw(sprite_batch, draw_offset - loc);
            Hp.draw(sprite_batch, draw_offset - loc);
            Slash.draw(sprite_batch, draw_offset - loc);
            MaxHp.draw(sprite_batch, draw_offset - loc);
            Affinity_Icon.draw(sprite_batch, draw_offset - loc);
            foreach (Status_Icon_Sprite icon in Status_Icons)
                icon.draw(sprite_batch, draw_offset - loc);
            sprite_batch.End();
        }
    }
}
