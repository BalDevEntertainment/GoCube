namespace GoCube.Infraestructure.PlayerEntity.Marker
{
    public struct MarkerDirection
    {
        private readonly int _value;

        private MarkerDirection(int value)
        {
            _value = value;
        }

        public static MarkerDirection Right()
        {
            return new MarkerDirection(1);
        }

        public static MarkerDirection Left()
        {
            return new MarkerDirection(-1);
        }

        public static MarkerDirection None()
        {
            return new MarkerDirection(0);
        }

        public static int operator *(MarkerDirection direction, int someInt)
        {
            return direction._value * someInt;
        }
    }
}