﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Resource
{
    public override int GetHashCode()
    {
        return name.GetHashCode();
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() != this.GetType()) return false;
        return name == ((Resource)obj).name;
    }

    public override string ToString()
    {
        return name;
    }

    public readonly string name; // Must be unique
}