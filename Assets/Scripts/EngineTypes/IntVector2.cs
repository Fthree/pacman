using UnityEngine;
using System.Collections;

public class IntVector2 {
    public int x { get; set; }
    public int z { get; set; }

    public IntVector2(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public static IntVector2 operator + (IntVector2 a, IntVector2 b)
    {
        return new IntVector2(a.x + b.x, a.z + b.z);
    }

    public Vector2 toVector2()
    {
        return new Vector2(this.x, this.z);
    }
}
