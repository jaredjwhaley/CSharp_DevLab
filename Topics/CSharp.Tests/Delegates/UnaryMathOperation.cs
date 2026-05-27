using System.Numerics;

namespace DevLab.CSharp.Delegates
{
    public delegate T UnaryMathOperation<T>(T number) where T : INumber<T>;
}