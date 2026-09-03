using System.Numerics;

namespace DevLab.CSharp.Delegates
{
    /// <summary>
    /// Represents an operation that accepts two numeric values and returns a result
    /// of the same type.
    /// </summary>
    /// <typeparam name="T">A numeric type that implements INumber&lt;T&gt;.</typeparam>
    /// <param name="num1">The first operand.</param>
    /// <param name="num2">The second operand.</param>
    /// <returns>The result of applying the operation to both operands.</returns>
    /// <remarks>
    /// Defines the signature of an operation, not its implementation. Compatible
    /// methods or lambda expressions supply the behavior, such as addition or
    /// multiplication. "Binary" refers to the two operands.
    /// </remarks>
    public delegate T BinaryMathOperation<T>(T num1, T num2) where T: INumber<T>;
}
