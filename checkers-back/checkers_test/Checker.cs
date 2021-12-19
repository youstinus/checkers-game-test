namespace checkers_test
{
    class Checker
    {
        public int Color { get; set; } // white - 0, black - 1
        public bool Queen { get; set; }
        public Checker(int color)
        {
            Color = color;
            Queen = false;
        }
    }
}
