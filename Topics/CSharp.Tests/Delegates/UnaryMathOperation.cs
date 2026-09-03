using System.Numerics;

namespace DevLab.CSharp.Delegates
{
    /// <summary>
    /// Represents an operation that accepts one numeric value and returns a result
    /// of the same type.
    /// </summary>
    /// <typeparam name="T">A numeric type that implements INumber&lt;T&gt;.</typeparam>
    /// <param name="number">The operand.</param>
    /// <returns>The result of applying the operation to the operand.</returns>
    /// <remarks>
    /// Compatible methods or lambda expressions supply the behavior, such as
    /// negation or squaring. "Unary" refers to the single operand.
    /// </remarks>
    public delegate T UnaryMathOperation<T>(T number) where T : INumber<T>;
}