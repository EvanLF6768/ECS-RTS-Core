using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class IDGroup
{
    public bool Contains(int obj)
    {
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i] == obj) return true;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != this.GetType()) return false;
        return name == ((IDGroup)obj).name;
    }

    public override string ToString()
    {
        return name;
    }

    public readonly string name; // Must be unique
    public int[] objs;
}