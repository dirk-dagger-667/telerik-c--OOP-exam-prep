﻿namespace AcademyRPG
{
    public class Rock: StaticObject, IResource
    {
        public Rock(int hitPoints, Point position)
            :base(position, 0)
        {
            this.HitPoints = hitPoints;
        }
        public int Quantity
        {
            get 
            {
                return this.HitPoints / 2;
            }
        }

        public ResourceType Type
        {
            get 
            {
                return ResourceType.Stone;
            }
        }
    }
}
