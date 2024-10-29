namespace Krivodeling.Swinging
{
    public readonly struct SwingMultiplier
    {
        public readonly float Speed;
        public readonly float Evaluation;

        public SwingMultiplier(float speed, float evaluation)
        {
            Speed = speed;
            Evaluation = evaluation;
        }
    }
}
