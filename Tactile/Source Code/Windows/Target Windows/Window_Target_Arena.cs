﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tactile.Windows.Target
{
    class Window_Target_Arena : Window_Target_Combat
    {
        public Window_Target_Arena(int unit_id, int target_id, Vector2 loc)
        {
            Left_X = Right_X = (int)loc.X;
            initialize(loc);
            Unit_Id = unit_id;
            Targets = new List<int> { target_id };

            InitialTarget();

            Weapon_Name_Visible = false;
        }

        protected override void InitialTarget(int index = 0)
        {
            this.index = index;
            Temp_Index = this.index;
            initialize_images();
            refresh();
        }

        protected override bool cursor_not_on_target
        {
            get
            {
                return false;
            }
        }

        protected override CombatTargetPanel windowskin()
        {
            return new ArenaTargetPanel(Global.Content.Load<Texture2D>(@"Graphics/Windowskins/Combat_Window"));
        }

        protected override int combat_distance(int unit_id, int target_id)
        {
            return Global.game_system.Arena_Distance;
        }

        protected override List<int?> get_combat_stats(int unit_id, int target_id, int distance)
        {
            return Combat.combat_stats(unit_id, target_id, distance, null, true);
        }

        protected override bool can_counter(Game_Unit unit, Game_Unit target, TactileLibrary.Data_Weapon weapon, int distance)
        {
            return true;
        }

        protected override void reset_cursor() { }

        public override void accept() { }

        public override void cancel() { }
    }
}
