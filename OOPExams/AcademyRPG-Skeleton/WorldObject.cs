using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public abstract class WorldObject : IWorldObject
    {
        public WorldObject(Point position, int owner)
        {
            this.Owner = owner;
            this.Position = position;
            this.HitPoints = 0;
        }
        public int HitPoints { get; set; }

        public int Owner { get; private set; }

        public Point Position { get; protected set; }

        public bool IsDestroyed
        {
            get
            {
                return this.HitPoints <= 0;
            }
        }
        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}
