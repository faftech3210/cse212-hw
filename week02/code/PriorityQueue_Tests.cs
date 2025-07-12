using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items and ensure Dequeue returns the item with highest priority.
    // Expected Result: "High" should be returned first.
    // Defect(s) Found:Initially, the Dequeue did not correctly prioritize. Fixed by adjusting priority comparison logic. 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Enqueue items with same priority and ensure FIFO ordering is respected.
    // Expected Result: "First" should be dequeued before "Second".
    // Defect(s) Found: Initially, items with equal priority were not dequeued in correct order. Corrected FIFO tracking.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 5);
        priorityQueue.Enqueue("Second", 5);

        var firstOut = priorityQueue.Dequeue();
        Assert.AreEqual("First", firstOut);

        var secondOut = priorityQueue.Dequeue();
        Assert.AreEqual("Second", secondOut);
    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Try to Dequeue from an empty queue.
    // Expected Result: An exception should be thrown.
    // Defect(s) Found: No exception was thrown initially. Fixed by adding a guard clause in Dequeue method.
    public void TestPriorityQueue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }
}