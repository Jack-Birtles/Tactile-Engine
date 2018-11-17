﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FEXNA.Graphics.Text;
using FEXNA.Graphics.Help;

namespace FEXNA.Windows.UserInterface.Command.Config
{
    abstract class ConfigUINode : CommandUINode
    {
        private bool Locked;

        internal bool locked
        {
            get { return Locked; }
            set
            {
                bool locked = Locked;
                Locked = value;
                if (locked != Locked)
                    set_label_color(Locked ? "Grey" : "White");
            }
        }

        protected ConfigUINode(string helpLabel) : base(helpLabel) { }

        protected virtual void set_label_color(string color)
        {
            set_text_color(color);
        }
    }
}
