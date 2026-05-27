using System.Numerics;

namespace DevLab.CSharp.Delegates
{
    public delegate T BinaryMathOperation<T>(T num1, T num2) where T: INumber<T>;
}
