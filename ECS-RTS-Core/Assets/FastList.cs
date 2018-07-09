using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public unsafe class FastList<T> where T : IDeleteable
{
    public FastList(int size = 16)
    {
        buffer = new T[size];
    }

    public T Next()
    {
        current = current++ % Length;
        return buffer[current];
    }

    public T this[int index]
    {
        get { return buffer[index]; }
        set { buffer[index] = value; }
    }

    public void Resize(int size) // WARNING: Downsizing will cause undefined behavior
    {
        T[] newBuffer = new T[size];
        Array.Copy(buffer, 0, newBuffer, 0, Math.Min(size, Length));
        buffer.CopyTo(newBuffer, 0);
        buffer = newBuffer;
    }

    public void Add(T value)
    {
        if (buffer.Length <= Length) Resize(Length * 2);
        buffer[Length++] = value;
    }

    public void Remove(int index)
    {
        buffer[index].Delete();
        if (index == --Length) buffer[index] = default(T);
        else buffer[index] = buffer[Length];
    }

    private T[] buffer;
    private int current;
    public int Length { get; private set; }
}

public interface IDeleteable
{
    void Delete();
    bool GetDeleted();
}

public class DeleteableStructReference<T> : IDeleteable where T : IDeleteable
{
    public void Delete() { Value.Delete(); }
    public bool GetDeleted() { return Value.GetDeleted(); }

    public T Value;
}