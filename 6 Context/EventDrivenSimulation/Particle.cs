namespace _6_Context.EventDrivenSimulation
{
    public class Particle
    {
        private double rx; // 粒子当前坐标的x分量
        private double ry; // 粒子当前坐标的y分量
        private double vx; // 粒子当前速度的x分量
        private double vy; // 粒子当前速度的y分量
        private double s; // 粒子的半径
        private double mass; // 粒子的质量

        /// <summary>
        /// 在空间中创建一个新的随机粒子，即位置、速度、半径和质量等属性的初始值都是随机的
        /// </summary>
        public Particle()
        {
        }

        /// <summary>
        /// 用给定的位置、速度、半径和质量创建一个新的粒子
        /// </summary>
        /// <param name="rx">粒子坐标x分量</param>
        /// <param name="ry">粒子坐标y分量</param>
        /// <param name="vx">粒子速度x分量</param>
        /// <param name="vy">粒子速度y分量</param>
        /// <param name="s">粒子半径</param>
        /// <param name="mass">粒子质量</param>
        public Particle(double rx, double ry, double vx, double vy, double s, double mass)
        {
            this.rx = rx;
            this.ry = ry;
            this.vx = vx;
            this.vy = vy;
            this.s = s;
            this.mass = mass;
        }

        /// <summary>
        /// 粒子参与的碰撞事件数
        /// </summary>
        public int CollisionEventCount { get; private set; }

        /// <summary>
        /// 画出粒子
        /// </summary>
        public void Draw()
        {
        }

        /// <summary>
        /// 根据流逝时间dt移动粒子
        /// </summary>
        /// <param name="dt">流逝的时间</param>
        public void Move(double dt)
        {
        }

        /// <summary>
        /// 当前粒子与目标粒子发生碰撞需要的时间
        /// </summary>
        /// <param name="b">要检测的目标粒子</param>
        /// <returns>如果可以发生碰撞，则返回需要的时间，如果两个粒子无法发生碰撞，则返回double.PositiveInfinity</returns>
        public double TimeToHit(Particle b)
        {
        }

        /// <summary>
        /// 当前粒子与水平的墙体发生碰撞需要的时间
        /// </summary>
        /// <returns></returns>
        public double TimeToHitHorizontalWall()
        {

        }

        /// <summary>
        /// 当前粒子与垂直的墙体发生碰撞需要的时间
        /// </summary>
        /// <returns></returns>
        public double TimeToHitVerticalWall()
        {

        }

        /// <summary>
        /// 与目标粒子碰撞后当前粒子的速度
        /// </summary>
        /// <param name="b"></param>
        /// <returns></returns>
        public double BounceOff(Particle b)
        {

        }

        public double BounceOffHorizontalWall()
        {

        }

        public double BounceOffVerticalWall()
        {

        }
    }
}
