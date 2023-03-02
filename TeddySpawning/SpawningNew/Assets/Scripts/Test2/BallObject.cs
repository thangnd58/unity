using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Test2
{
    public class BallObject
    {
        public int instanceId { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public int health { get; set; }

        public BallObject(float x, float y, float z, int health)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.health = health;
        }

        public BallObject()
        {
        }
    }
}
