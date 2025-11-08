using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities and dequeue all
    // Expected Result: Items are returned in descending priority order
    // Defect(s) Found: Ensures highest priority items are returned first
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        // Enqueue items with different priorities
        priorityQueue.Enqueue("A", 2);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 1);

        // Dequeue and verify order
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with same priority
    // Expected Result: FIFO order preserved for items with equal priority
    // Defect(s) Found: Ensures first-added item comes out first when priorities tie 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        // Enqueue items with same priority
        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);

        // Dequeue and verify order
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }
}