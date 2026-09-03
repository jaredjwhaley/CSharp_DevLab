namespace DevLab.CSharp.Tests;

/// <summary>Demonstrates StacksAndQueues with isolated, repeatable examples.</summary>
public class StacksAndQueuesTests
{
    /// <summary>Reads the most recently pushed item first.</summary>
    [Fact]
    public void StackIsLastInFirstOut()
    {
        var stack = new Stack<int>();
        stack.Push(1); stack.Push(2);
        Assert.Equal(2, stack.Peek());
        Assert.Equal(2, stack.Count);
        Assert.Equal(2, stack.Pop());
        Assert.Equal(1, stack.Pop());
        Assert.False(stack.TryPop(out _));
    }

    /// <summary>Reads items in their arrival order.</summary>
    [Fact]
    public void QueueIsFirstInFirstOut()
    {
        var queue = new Queue<int>();
        queue.Enqueue(1); queue.Enqueue(2);
        Assert.Equal(1, queue.Peek());
        Assert.Equal(1, queue.Dequeue());
        Assert.Equal(2, queue.Dequeue());
        Assert.False(queue.TryDequeue(out _));
    }
}
