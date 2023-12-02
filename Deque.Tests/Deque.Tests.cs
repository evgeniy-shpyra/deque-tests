using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lib;

namespace Deque.Tests
{
    [TestClass]
    public class EventRecorder<T>
    {
        public bool WasCalled { get; private set; }
        public T LastRecordedValue { get; private set; }

        public void Record(T value)
        {
            WasCalled = true;
            LastRecordedValue = value;
        }
        public void Record()
        {
            WasCalled = true;
        }
    }
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddFirst()
        {
            var deque = new CustomDeque<string>();
            var eventRecorder = new EventRecorder<string>();
            deque.ElementAdded += eventRecorder.Record;

            deque.AddFirst("first");
            deque.AddFirst("second");

            Assert.AreEqual("second", deque.First);
            Assert.AreEqual("first", deque.Last);
            Assert.AreEqual(2, deque.Count);

            Assert.IsTrue(eventRecorder.WasCalled);
            Assert.AreEqual("second", eventRecorder.LastRecordedValue);

            Assert.ThrowsException<InvalidOperationException>(() => deque.AddFirst(null));
        }

        [TestMethod]
        public void TestAddLast()
        {
            var deque = new CustomDeque<string>();
            var eventRecorder = new EventRecorder<string>();
            deque.ElementAdded += eventRecorder.Record;

            deque.AddLast("first");
            deque.AddLast("second");

            Assert.AreEqual("second", deque.Last);
            Assert.AreEqual("first", deque.First);
            Assert.AreEqual(2, deque.Count);

            Assert.IsTrue(eventRecorder.WasCalled);
            Assert.AreEqual("second", eventRecorder.LastRecordedValue);

            Assert.ThrowsException<InvalidOperationException>(() => deque.AddLast(null));
        }

        [TestMethod]
        public void TestRemoveFirst()
        {
            var deque = new CustomDeque<string>();
            var eventRecorder = new EventRecorder<string>();
            deque.ElementRemoved += eventRecorder.Record;

            deque.AddLast("first");
            deque.AddLast("second");

            deque.RemoveFirst();

            Assert.AreEqual("second", deque.First);
            Assert.AreEqual(1, deque.Count);

            Assert.IsTrue(eventRecorder.WasCalled);
            Assert.AreEqual("first", eventRecorder.LastRecordedValue);

            deque.RemoveFirst();
            var exception = Assert.ThrowsException<InvalidOperationException>(() => deque.RemoveFirst());
            Assert.AreEqual("Неможливо видалити елемент. Дек порожній.", exception.Message);

            Assert.AreEqual(0, deque.Count);
        }

        [TestMethod]
        public void TestRemoveLast()
        {
            var deque = new CustomDeque<string>();
            var eventRecorder = new EventRecorder<string>();
            deque.ElementRemoved += eventRecorder.Record;

            deque.AddLast("first");
            deque.AddLast("second");

            deque.RemoveLast();

            Assert.AreEqual("first", deque.Last);
            Assert.AreEqual(1, deque.Count);

            Assert.IsTrue(eventRecorder.WasCalled);
            Assert.AreEqual("second", eventRecorder.LastRecordedValue);

            deque.RemoveLast();
            var exception = Assert.ThrowsException<InvalidOperationException>(() => deque.RemoveLast());
            Assert.AreEqual("Неможливо видалити елемент. Дек порожній.", exception.Message);

            Assert.AreEqual(0, deque.Count);
        }

        [TestMethod]
        public void TestClear()
        {
            var deque = new CustomDeque<string>();
            var eventRecorder = new EventRecorder<string>();
            deque.Cleared += eventRecorder.Record;

            deque.AddLast("first");
            deque.AddLast("second");

            deque.Clear();

            Assert.AreEqual(0, deque.Count);
            Assert.IsTrue(deque.IsEmpty);
            Assert.IsTrue(eventRecorder.WasCalled);
        }

        [TestMethod]
        public void TestContains()
        {
            var deque = new CustomDeque<string>();

            deque.AddLast("first");
            deque.AddLast("second");

            Assert.IsTrue(deque.Contains("first"));
            Assert.IsFalse(deque.Contains("third"));

            deque.Clear();
            Assert.IsFalse(deque.Contains("first"));
        }

        [TestMethod]
        public void TestCliaring()
        {
            var deque = new CustomDeque<string>();

            deque.AddLast("first");
            deque.AddLast("second");

            deque.Clear();

            Assert.IsTrue(deque.IsEmpty);
        }

    }
}
