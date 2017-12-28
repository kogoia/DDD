namespace DiscriminatedUnion
{
    public class UnionBox<T1, T2> : Union<T1, T2>
        where T1 : class
        where T2 : class
    {
        public UnionBox(T1 t1) : base(t1)
        {
        }

        public UnionBox(T2 t2) : base(t2)
        {
        }
    }
}
