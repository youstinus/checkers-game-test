namespace checkers_test
{
    class Move
    {
        public int SourceX { get; set; }
        public int SourceY { get; set; }
        public int DestX { get; set; }
        public int DestY { get; set; }
        public bool Free { get; set; }
        public int KnockX { get; set; }
        public int KnockY { get; set; }
    }
}
