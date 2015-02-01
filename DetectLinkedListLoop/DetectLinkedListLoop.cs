using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DetectLinkedListLoop.LinkedLists;

namespace DetectLinkedListLoop {

    public static class DetectLinkedListLoop {

        public static bool HasLoop( this SinglyLinkedList linkedList ) {
            SinglyLinkedListNode slow = linkedList.Head;
            SinglyLinkedListNode fast = linkedList.Head;

            while( fast != null && fast.Next != null ) {
                slow = slow.Next;
                fast = fast.Next.Next;

                if( slow == fast ) {
                    return true;
                }
            }

            return false;
        }
    }
}
