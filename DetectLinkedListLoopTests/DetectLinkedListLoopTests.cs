using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DetectLinkedListLoop;
using DetectLinkedListLoop.LinkedLists;
using NUnit.Framework;

namespace DetectLinkedListLoopTests {
    
    [TestFixture]
    public class DetectLinkedListLoopTests {

        [Test]
        public void HasLoop_EmptyList_ReturnsFalse() {
            /* arrange */
            SinglyLinkedList ll = new SinglyLinkedList();

            /* act */
            bool hasLoop = ll.HasLoop();

            /* assert */
            Assert.AreEqual(
                false,
                hasLoop
            );
        }

        [Test]
        public void HasLoop_ListHasOneNode_ReturnsFalse() {
            /* arrange */
            SinglyLinkedList ll = new SinglyLinkedList() {
                Head = new SinglyLinkedListNode()
            };

            /* act */
            bool hasLoop = ll.HasLoop();

            /* assert */
            Assert.AreEqual(
                false,
                hasLoop
            );
        }

        [TestCase( 2 )]
        [TestCase( 5 )]
        //[TestCase( int.MaxValue )] // Disabled for performance reasons
        public void HasLoop_LinearList_ReturnsFalse(int numNodes) {
            /* arrange */
            SinglyLinkedListNode head = new SinglyLinkedListNode();
            SinglyLinkedListNode previousNode = head;
            for( int i = 1; i < numNodes; i++ ) {
                previousNode.Next = new SinglyLinkedListNode();
                previousNode = previousNode.Next;
            }

            SinglyLinkedList ll = new SinglyLinkedList() {
                Head = head
            };

            /* act */
            bool hasLoop = ll.HasLoop();

            /* assert */
            Assert.AreEqual(
                false,
                hasLoop
            );
        }

        [TestCase( 2 )]
        [TestCase( 5 )]
        //[TestCase( int.MaxValue )] // Disabled for performance reasons
        public void HasLoop_FullLoop_ReturnsTrue(int numNodes) {
            /* arrange */
            SinglyLinkedListNode head = new SinglyLinkedListNode();
            SinglyLinkedListNode previousNode = head;
            for( int i = 1; i < numNodes; i++ ) {
                previousNode.Next = new SinglyLinkedListNode();
                previousNode = previousNode.Next;
            }
            previousNode.Next = head;

            SinglyLinkedList ll = new SinglyLinkedList() {
                Head = head
            };

            /* act */
            bool hasLoop = ll.HasLoop();

            /* assert */
            Assert.AreEqual(
                true,
                hasLoop
            );
        }

        [Test]
        [TestCase( 2, 7 )]
        [TestCase( 2, 10 )]
        [TestCase( 3, 7 )]
        [TestCase( 3, 10 )]
        public void HasLoop_PartialLoop_ReturnsTrue(int numNodesToLoop, int numNodesInLoop) {
            /* arrange */
            SinglyLinkedListNode subhead = new SinglyLinkedListNode();
            SinglyLinkedListNode previousNode = subhead;
            for( int i = 1; i < numNodesInLoop; i++ ) {
                previousNode.Next = new SinglyLinkedListNode();
                previousNode = previousNode.Next;
            }
            previousNode.Next = subhead;

            SinglyLinkedListNode head = new SinglyLinkedListNode();
            previousNode = head;
            for( int i = 1; i < numNodesToLoop; i++ ) {
                previousNode.Next = new SinglyLinkedListNode();
                previousNode = previousNode.Next;
            }
            previousNode.Next = subhead;

            SinglyLinkedList ll = new SinglyLinkedList() {
                Head = head
            };

            /* act */
            bool hasLoop = ll.HasLoop();

            /* assert */
            Assert.AreEqual(
                true,
                hasLoop
            );
        }
    }
}
