using System.Numerics;

namespace DevLab.CSharp.Delegates
{
    /// <summary>
    /// Demonstrates passing numeric operations as delegates to reusable execution methods.
    /// </summary>
    /// <typeparam name="T">
    /// A numeric type whose INumber&lt;T&gt; implementation provides the arithmetic operators.
    /// </typeparam>
    /// <remarks>
    /// The static methods provide example operations. The Execute overloads invoke
    /// whichever compatible operation the caller supplies, without needing to know
    /// which calculation it performs.
    /// </remarks>
    public class Calculator<T> where T : INumber<T>
        {

        /// <summary>
        /// Adds two values; matches the binary operation delegate's signature.
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The sum of the operands.</returns>
        public static T Add(T a, T b) => a + b;

        /// <summary>
        /// Multiplies two values; matches the same delegate signature as Add.
        /// </summary>
        /// <param name="a">The first factor.</param>
        /// <param name="b">The second factor.</param>
        /// <returns>The product of the factors.</returns>
        public static T Multiply(T a, T b) => a * b;

        /// <summary>
        /// Applies unary negation to a value.
        /// </summary>
        /// <param name="a">The value to negate.</param>
        /// <returns>The result of the numeric type's unary negation operator.</returns>
        public static T Negate(T a) => -a;

        /// <summary>
        /// Squares a value; matches the same delegate signature as Negate.
        /// </summary>
        /// <param name="a">The value to square.</param>
        /// <returns>The value multiplied by itself.</returns>
        public static T Square(T a) => a * a;

        /// <summary>
        /// Invokes the supplied binary operation with two operands.
        /// </summary>
        /// <param name="num1">The first operand.</param>
        /// <param name="num2">The second operand.</param>
        /// <param name="operation">The operation to invoke. Must not be null.</param>
        /// <returns>The result returned by the supplied operation.</returns>
        public T Execute(T num1, T num2, BinaryMathOperation<T> operation)
        {
            return operation(num1, num2);
        }

        /// <summary>
        /// Invokes the supplied unary operation with one operand.
        /// </summary>
        /// <param name="number">The operand.</param>
        /// <param name="operation">The operation to invoke. Must not be null.</param>
        /// <returns>The result returned by the supplied operation.</returns>
        public T Execute(T number, UnaryMathOperation<T> operation)
        {
            return operation(number);
        }
    }
}
