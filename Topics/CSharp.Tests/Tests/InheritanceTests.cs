namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates Inheritance with isolated, repeatable examples.</summary>
public class InheritanceTests
{
    /// <summary>Calls a derived override through a base variable.</summary>
    [Fact]
    public void OverrideUsesRuntimeType()
    {
        Animal animal = new Dog("Rex");
        Assert.Equal("Rex", animal.Name);
        Assert.Equal("Woof", animal.Speak());
    }

    /// <summary>Contrasts a hidden member through base and derived references.</summary>
    [Fact]
    public void HidingUsesDeclaredType()
    {
        var child = new Child();
        Parent parent = child;
        Assert.Equal("parent", parent.Label());
        Assert.Equal("child", child.Label());
    }

    private abstract class Animal(string name)
    {
        public string Name { get; } = name;
        public abstract string Speak();
    }
    private sealed class Dog(string name) : Animal(name)
    {
        public override string Speak() => "Woof";
    }
    private class Parent
    {
        public string Label() => "parent";
    }
    private sealed class Child : Parent
    {
        public new string Label() => "child";
    }
}
