namespace Items
{
    public interface ICanRotate
    {
        public bool StartRotating();
        public bool StopRotating();
        void Rotate();
    }
}