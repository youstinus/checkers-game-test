namespace checkers_test
{
    class Square
    {
        public int Color { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Checker Checker { get; set; }
        public Square(int color, int x, int y)
        {
            Color = color;
            X = x;
            Y = y;
        }

        public void SetChecker(Checker checker)
        {
            Checker = checker;
        }
    }
}
