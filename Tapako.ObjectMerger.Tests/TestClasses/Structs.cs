namespace Tapako.ObjectMergerTests.TestClasses
{
    struct Struct1
    {
        public Struct1(int a, int b, int c, string d, string e, string f, object g, object h, object i)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
            this.f = f;
            this.g = g;
            this.h = h;
            this.i = i;
        }

        int a, b, c;
        string d, e, f;
        object g, h, i;
    }

}
