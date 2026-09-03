namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates PropertiesAndEncapsulation with isolated, repeatable examples.</summary>
public class PropertiesAndEncapsulationTests
{
    /// <summary>Accepts a valid deposit and rejects a negative amount without changing balance.</summary>
    [Fact]
    public void OperationsPreserveInvariant()
    {
        var account = new Account { Name = "Savings" };
        account.Deposit(25m);
        Assert.Equal(25m, account.Balance);
        Assert.Throws<ArgumentOutOfRangeException>(() => account.Deposit(-1));
        Assert.Equal(25m, account.Balance);
    }

    /// <summary>Shows init-only metadata and a calculated property.</summary>
    [Fact]
    public void InitializationAndComputedProperty()
    {
        var account = new Account { Name = "Travel" };
        Assert.Equal("Travel", account.Name);
        Assert.True(account.IsEmpty);
        account.Deposit(1);
        Assert.False(account.IsEmpty);
    }

    private sealed class Account
    {
        public string Name { get; init; } = "Unnamed";
        public decimal Balance { get; private set; }
        public bool IsEmpty => Balance == 0;
        public void Deposit(decimal amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount));
            Balance += amount;
        }
    }
}
