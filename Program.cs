// See https://aka.ms/new-console-template for more information

LRUCache.LRUCache lRUCache1 = new(2);
lRUCache1.Put(1, 1); // cache is {1=1}
lRUCache1.Put(2, 2); // cache is {1=1, 2=2}
Console.WriteLine(lRUCache1.Get(1));    // return 1
lRUCache1.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
Console.WriteLine(lRUCache1.Get(2));     // returns -1 (not found)
lRUCache1.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
Console.WriteLine(lRUCache1.Get(1));    // return -1 (not found)
Console.WriteLine(lRUCache1.Get(3));    // return 3
Console.WriteLine(lRUCache1.Get(4));    // return 4
Console.WriteLine("=================");
LRUCache.LRUCache lRUCache2 = new(2);
lRUCache2.Put(1, 0); // cache is {1=0}
lRUCache2.Put(2, 2); // cache is {1=0, 2=2}
Console.WriteLine(lRUCache2.Get(1));    // return 0
lRUCache2.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=0, 3=3}
Console.WriteLine(lRUCache2.Get(2));     // returns -1 (not found)
lRUCache2.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
Console.WriteLine(lRUCache2.Get(1));    // return -1 (not found)
Console.WriteLine(lRUCache2.Get(3));    // return 3
Console.WriteLine(lRUCache2.Get(4));    // return 4
	
