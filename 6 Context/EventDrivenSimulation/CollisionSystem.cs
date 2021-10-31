using System;
using System.Collections.Generic;
using _2_Sort.PriorityQueue;

namespace _6_Context.EventDrivenSimulation
{
    public class CollisionSystem
    {
        private List<Particle> particles = new List<Particle>();
        private double currentTime;
        private PriorityQueue<CollisionEvent> eventQueue = new PriorityQueue<CollisionEvent>();

        public static void Test()
        {
            CollisionSystem collisionSystem = new CollisionSystem();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                collisionSystem.AddParticle(new Particle());
            }

            collisionSystem.Simulate(10000, 0.5);
        }

        public void AddParticle(Particle particle)
        {
            particles.Add(particle);
        }

        public void Simulate(double limit, double hz)
        {
            eventQueue.Enqueue(new CollisionEvent(0, null, null));
            for (int i = 0; i < particles.Count; i++)
            {
                PredictCollisions(particles[i], limit);
            }

            while (!eventQueue.IsEmpty)
            {
                CollisionEvent collisionEvent = eventQueue.Dequeue();
                if (!collisionEvent.IsValid) continue;

                for (int i = 0; i < particles.Count; i++)
                {
                    particles[i].Move(collisionEvent.Time - currentTime);
                }
                currentTime = collisionEvent.Time;

                Particle a = collisionEvent.A;
                Particle b = collisionEvent.B;
                if (a != null && b != null)
                {
                    a.BounceOff(b);
                }
                else if (a != null && b == null)
                {
                    a.BounceOffHorizontalWall();
                }
                else if (a == null && b != null)
                {
                    b.BounceOffVerticalWall();
                }
                else
                {
                    Draw(limit, hz);
                }
                PredictCollisions(a, limit);
                PredictCollisions(b, limit);
            }
        }

        public void Draw(double limit, double hz)
        {
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].Draw();
            }

            if (currentTime < limit)
            {
                eventQueue.Enqueue(new CollisionEvent(currentTime + 1.0 / hz, null, null));
            }
        }

        /// <summary>
        /// 检测粒子a在限制时间limit内所有可能发生的碰撞事件并将碰撞事件
        /// 加入事件队列中
        /// </summary>
        private void PredictCollisions(Particle a, double limit)
        {
            if (a == null) return;

            for (int i = 0; i < particles.Count; i++)
            {
                double dt = a.TimeToHit(particles[i]);
                if (currentTime + dt <= limit)
                {
                    eventQueue.Enqueue(new CollisionEvent(currentTime + dt, a, particles[i]));
                }
            }

            double dtX = a.TimeToHitVerticalWall();
            if (currentTime + dtX <= limit)
            {
                eventQueue.Enqueue(new CollisionEvent(currentTime + dtX, a, null));
            }

            double dtY = a.TimeToHitHorizontalWall();
            if (currentTime + dtY <= limit)
            {
                eventQueue.Enqueue(new CollisionEvent(currentTime + dtY, null, a));
            }
        }
    }
}
