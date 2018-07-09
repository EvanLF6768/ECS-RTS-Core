using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public struct Pair<T, U>
{
    public Pair(T a, U b)
    {
        this.a = a;
        this.b = b;
    }

    public T a;
    public U b;
}