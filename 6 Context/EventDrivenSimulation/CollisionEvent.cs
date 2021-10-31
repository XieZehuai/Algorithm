using System;

namespace _6_Context.EventDrivenSimulation
{
    public class CollisionEvent : IComparable<CollisionEvent>
    {
        private readonly double time;
        private readonly Particle a;
        private readonly Particle b;
        private readonly int countA;
        private readonly int countB;

        /// <summary>
        /// <para>如果a和b均不为空：粒子与粒子碰撞</para>
        /// <para>如果a不为空b为空：粒子a和垂直墙体的碰撞</para>
        /// <para>如果a为空b不为空：粒子b和水平墙体的碰撞</para>
        /// <para>a和b均为空：重绘事件（画出所有粒子）</para>
        /// </summary>
        /// <param name="time">经过时间time后触发该事件</param>
        /// <param name="a">参与碰撞的粒子a，可以为空</param>
        /// <param name="b">参与碰撞的粒子b，可以为空</param>
        public CollisionEvent(double time, Particle a, Particle b)
        {
            this.time = time;
            this.a = a;
            this.b = b;
            countA = a != null ? a.CollisionEventCount : -1;
            countB = b != null ? b.CollisionEventCount : -1;
        }

        /// <summary>
        /// 碰撞事件是否有效
        /// </summary>
        public bool IsValid
        {
            get
            {
                if (a != null && a.CollisionEventCount != countA) return false;
                if (b != null && b.CollisionEventCount != countB) return false;
                return true;
            }
        }

        public double Time => time;

        public Particle A => a;

        public Particle B => b;

        public int CompareTo(CollisionEvent other)
        {
            if (time < other.time) return -1;
            if (time > other.time) return 1;
            return 0;
        }
    }
}
