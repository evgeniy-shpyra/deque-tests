using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib;

namespace Deque.Tests
{
    [TestClass]
    public class DoublyNodeTests
    {
        [TestMethod]
        public void TestDoublyNode_Constructor()
        {         
            var data = 42;
            var node = new DoublyNode<int>(data);

            Assert.AreEqual(data, node.Data);
            Assert.IsNull(node.Previous);
            Assert.IsNull(node.Next);
        }

        [TestMethod]
        public void TestDoublyNode_Properties()
        {
            var node = new DoublyNode<string>("FirstNode");

            node.Data = "Node";
            var previousNode = new DoublyNode<string>("Previous");
            var nextNode = new DoublyNode<string>("Next");
            node.Previous = previousNode;
            node.Next = nextNode;

            Assert.AreEqual("Node", node.Data);
            Assert.AreEqual(previousNode, node.Previous);
            Assert.AreEqual(nextNode, node.Next);
        }
    }
}