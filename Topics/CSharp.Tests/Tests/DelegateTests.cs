using Xunit;
using DevLab.CSharp.Delegates;
using System.Numerics;
using FluentAssertions;

namespace DevLab.CSharp.Tests
{

    public class DelegateTests
    {
        internal class Calculator<T> where T : INumber<T>
        {
            public static T Add(T a, T b) => a + b;
            public static T Multiply(T a, T b) => a * b;
            public static T Negate(T a) => -a;
            public static T Square(T a) => a * a;
            public T Execute(T num1, T num2, BinaryMathOperation<T> operation)
            {
                return operation(num1, num2);
            }
            public T Execute(T number, UnaryMathOperation<T> operation)
            {
                return operation(number);
            }
        }
        [Fact]
        public void Delegate_Should_Execute_Addition()
        {
            var calc = new Calculator<int>();

            var result = calc.Execute(2, 3, Calculator<int>.Add);

            Assert.Equal(5, result);
        }

        [Fact]
        public void Delegate_Should_Execute_Multiplication()
        {
            var calc = new Calculator<int>();

            var result = calc.Execute(2, 3, Calculator<int>.Multiply);

            Assert.Equal(6, result);
        }

        [Fact]
        public void Delegate_Should_Execute_Negation()
        {
            var calc = new Calculator<int>();
            var result = calc.Execute(5, Calculator<int>.Negate);
            result.Should().Be(-5);
        }

        [Fact]
        public void Delegate_Should_Execute_Square()
        {
            var calc = new Calculator<int>();
            var result = calc.Execute(4, Calculator<int>.Square);
            result.Should().Be(16);
        }
    }
}
