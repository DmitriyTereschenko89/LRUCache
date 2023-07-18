using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LRUCache
{
	internal class LRUCache
	{
		private class DoubleLinkedNode
		{
			public int key;
			public int val;
			public DoubleLinkedNode prev;
			public DoubleLinkedNode next;

			public DoubleLinkedNode(int key, int val, DoubleLinkedNode prev = null, DoubleLinkedNode next = null)
			{
				this.key = key;
				this.val = val;
				this.prev = prev;
				this.next = next;
			}

			public void RemoveBinding()
			{
				if (this.prev != null)
				{
					this.prev.next = this.next;
				}
				if (this.next != null)
				{
					this.next.prev = this.prev;
				}
				this.next = null;
				this.prev = null;
			}
		}

		private class DoubleLinkedList
		{
			public DoubleLinkedNode head;
			public DoubleLinkedNode tail;

			public void SetHead(DoubleLinkedNode node)
			{
				if (head == node)
				{
					return;
				}
				if (head is null)
				{
					head = node;
					tail = node;
				}
				else if (head == tail)
				{
					tail.prev = node;
					head = node;
					head.next = tail;
				}
				else
				{
					if (tail == node)
					{
						RemoveTail();
					}
					node.RemoveBinding();
					head.prev = node;
					node.next = head;
					head = node;
				}
			}

			public void RemoveTail()
			{
				if (tail is null)
				{
					return;
				}
				if (head == tail)
				{
					head = null;
					tail = null;
					return;
				}
				tail = tail.prev;
				tail.next = null;
			}
		}

		private readonly int capacity;
		private readonly Dictionary<int, DoubleLinkedNode> lruCache;
		private readonly DoubleLinkedList linkedList;

		private void Update(DoubleLinkedNode node)
		{
			linkedList.SetHead(node);
		}

		private void Remove()
		{
			int key = linkedList.tail.key;
			linkedList.RemoveTail();
			lruCache.Remove(key);
		}

		public LRUCache(int capacity)
		{
			this.capacity = capacity;
			lruCache = new Dictionary<int, DoubleLinkedNode>();
			linkedList = new DoubleLinkedList();
		}

		public int Get(int key)
		{
			if (!lruCache.ContainsKey(key))
			{
				return -1;
			}
			Update(lruCache[key]);
			return lruCache[key].val;
		}

		public void Put(int key, int value)
		{
			if (!lruCache.ContainsKey(key))
			{
				if (lruCache.Count == capacity)
				{
					Remove();
				}
				lruCache.Add(key, new DoubleLinkedNode(key,value));
			}
			else
			{
				lruCache[key].val = value;
			}
			Update(lruCache[key]);
		}
	}
}
