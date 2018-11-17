﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FEXNA.Graphics.Text;

namespace FEXNA
{
    class Unit_Page_2 : Unit_Page
    {
        protected FE_Text Pow, Skl, Spd, Lck, Def, Res, Mov, Con, Aid;

        public Unit_Page_2(Game_Unit unit)
        {
            // Pow
            Pow = new FE_Text_Int();
            Pow.loc = new Vector2(16, 0);
            Pow.Font = "FE7_Text";
            Pow.texture = Global.Content.Load<Texture2D>(@"Graphics/Fonts/FE7_Text_" + (unit.actor.get_capped(Stat_Labels.Pow) ? "Green" : "Blue"));
            Pow.text = unit.stat(Stat_Labels.Pow).ToString();
            // Skl
            Skl = new FE_Text_Int();
            Skl.loc = new Vector2(40, 0);
            Skl.Font = "FE7_Text";
            Skl.texture = Global.Content.Load<Texture2D>(@"Graphics/Fonts/FE7_Text_" + (unit.actor.get_capped(Stat_Labels.Skl) ? "Green" : "Blue"));
            Skl.text = unit.stat(Stat_Labels.Skl).ToString();
            // Spd
            Spd = new FE_Text_Int();
            Spd.loc = new Vector2(64, 0);
            Spd.Font = "FE7_Text";
            Spd.texture = Global.Content.Load<Texture2D>(@"Graphics/Fonts/FE7_Text_" + (unit.actor.get_capped(Stat_Labels.Spd) ? "Green" : "Blue"));
            Spd.text = unit.stat(Stat_Labels.Spd).ToString();
            // Lck
            Lck = new FE_Text_Int();
            Lck.loc = new Vector2(88, 0);
            Lck.Font = "FE7_Text";
            Lck.texture = Global.Content.Load<Texture2D>(@"Graphics/Fonts/FE7_Text_" + (unit.actor.get_capped(Stat_Labels.Lck) ? "Green" : "Blue"));
            Lck.text = unit.stat(Stat_Labels.Lck).ToString();
            // Def
            Def = new FE_Text_Int();
            Def.loc = new Vector2(112, 0);
            Def.Font = "FE7_Text";
            Def.texture = Global.Content.Load<Texture2D>(@"Graphics/Fonts/FE7_Text_" + (unit.actor.get_capped(Stat_Labels.Def) ? "Green" : "Blue"));
            Def.text = unit.stat(Stat_Labels.Def).ToString();
            // Res
            Res = new FE_Text_Int();
            Res.loc = new Vector2(136, 0);
            Res.Font = "FE7_Text";
            Res.texture = Global.Content.Load<Texture2D>(@"Graphics/Fonts/FE7_Text_" + (unit.actor.get_capped(Stat_Labels.Res) ? "Green" : "Blue"));
            Res.text = unit.stat(Stat_Labels.Res).ToString();
            // Mov
            Mov = new FE_Text_Int();
            Mov.loc = new Vector2(168, 0);
            Mov.Font = "FE7_Text";
            Mov.texture = Global.Content.Load<Texture2D>(@"Graphics/Fonts/FE7_Text_" + (unit.is_mov_capped() ? "Green" : "Blue"));
            Mov.text = unit.mov.ToString();
            // Con
            Con = new FE_Text_Int();
            Con.loc = new Vector2(192, 0);
            Con.Font = "FE7_Text";
            Con.texture = Global.Content.Load<Texture2D>(@"Graphics/Fonts/FE7_Text_" + (unit.actor.get_capped(Stat_Labels.Con) ? "Green" : "Blue"));
            Con.text = unit.stat(Stat_Labels.Con).ToString();
            // Aid
            Aid = new FE_Text_Int();
            Aid.loc = new Vector2(216, 0);
            Aid.Font = "FE7_Text";
            Aid.texture = Global.Content.Load<Texture2D>(@"Graphics/Fonts/FE7_Text_Blue");
            Aid.text = unit.aid().ToString();
        }

        public override void update()
        {
            Pow.update();
            Skl.update();
            Spd.update();
            Lck.update();
            Def.update();
            Res.update();
            Mov.update();
            Con.update();
            Aid.update();
        }

        public override void draw(SpriteBatch sprite_batch, Vector2 draw_offset = default(Vector2))
        {
            Vector2 loc = this.loc + draw_vector();
            sprite_batch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, Scissor_State);
            Pow.draw(sprite_batch, draw_offset - loc);
            Skl.draw(sprite_batch, draw_offset - loc);
            Spd.draw(sprite_batch, draw_offset - loc);
            Lck.draw(sprite_batch, draw_offset - loc);
            Def.draw(sprite_batch, draw_offset - loc);
            Res.draw(sprite_batch, draw_offset - loc);
            Mov.draw(sprite_batch, draw_offset - loc);
            Con.draw(sprite_batch, draw_offset - loc);
            Aid.draw(sprite_batch, draw_offset - loc);
            sprite_batch.End();
        }
    }
}
