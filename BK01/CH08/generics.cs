using System;
using System.Collections.Generic;

/*
Learning points from this program:
    1. The program uses a class built from a generic type ...
    2. ... but that generic type MUST be one that implements a specified interface
    3. Using an interface GUARANTEES that the class will work as the generic type
       will definitely have the desired properties and methods
*/

// PriorityQueue -- Demonstrates using low-level queue collection objects to
// implement a higher-level priority queue
class Program {

    // Main -- Fill a priority queue with packages, then remove a random number of them
    static void Main() {

        Console.WriteLine("Create a priority queue:");
        PriorityQueue<Package> pq = new PriorityQueue<Package>();
        Console.WriteLine("Add a random number (0 - 20) of random packages to the queue:");
        Package pack;
        PackageFactory fact = new PackageFactory();

        // Generate a random number less than 20
        Random rand = new Random();
        int numToCreate = rand.Next(20);  // Random int from 0 - 20
        Console.WriteLine("\tCreating {0} packages: ", numToCreate);

        for (int i = 0; i < numToCreate; i++) {
            Console.Write("\t\tGenerating and adding random package {0}", i);
            pack = fact.CreatePackage();
            Console.WriteLine(" with priority {0}", pack.Priority);
            pq.Enqueue(pack);
        }

        Console.WriteLine("See what we got:");
        int total = pq.Count;
        Console.WriteLine("Packages received: {0}", total);
        Console.WriteLine("Remove a random number of packages (0 - 20): ");
        int numToRemove = rand.Next(20);
        Console.WriteLine("\tRemoving up to {0} packages", numToRemove);

        for (int i = 0; i < numToRemove; i++) {
            pack = pq.Dequeue();
            if (pack != null) {
                Console.WriteLine("\t\tShipped package with priority {0}",
                    pack.Priority);
            }
        }

        // See how many were shipped
        Console.WriteLine("Shipped {0} packages", total - pq.Count);
    }


    // PriorityQueue -- A generic priority queue class
    // Types to add to the queue must impement IPrioritizable
    class PriorityQueue<T> where T : IPrioritizable {

        // The three queues - all generic
        private Queue<T> _queueHigh = new Queue<T>();
        private Queue<T> _queueMid = new Queue<T>();
        private Queue<T> _queueLow = new Queue<T>();

        // Enqueue -- Prioritize T and an item of type T to correct queue
        public void Enqueue(T item) {
            switch (item.Priority) {
                case Priority.High:
                    _queueHigh.Enqueue(item);
                    break;
                case Priority.Mid:
                    _queueMid.Enqueue(item);
                    break;
                case Priority.Low:
                    _queueLow.Enqueue(item);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        item.Priority.ToString(),
                        "bad priority in PriorityQueue.Enqueue");
            }
        }

        // Dequeue -- Get T from highest priority queue available
        public T Dequeue() {
            // Find highest priority queue with items
            Queue<T> queueTop = TopQueue();
            // If a non-empty queue is found
            if (queueTop != null & queueTop.Count >0) {
                return queueTop.Dequeue();  // Return its front item
            }
            // If all queues empty return null
            return default(T);
        }

        // TopQueue -- Return highest priority non-empty queue
        public Queue<T> TopQueue() {
            if (_queueHigh.Count > 0) return _queueHigh;
            if (_queueMid.Count > 0) return _queueMid;
            return _queueLow;  // Return whether or not it is empty...
        }

        // IsEmpty -- Check whether there is anything to dequeue
        public bool IsEmpty() {
            return (_queueHigh.Count == 0) & (_queueMid.Count == 0) &
                 (_queueLow.Count == 0);
        }

        // Count -- How many items are in all queues combined
        public int Count // implement this as a read-only property
        {
            get { return _queueHigh.Count + _queueMid.Count + _queueLow.Count; }
        }
    }


    // PackageFactory -- A class that knows how to generate a new package on
    // demand
    class PackageFactory {

        Random _randGen = new Random();  // C#'s random number generator

        // CreatePackage -- Select a random priority then create a package
        // with that priority
        public Package CreatePackage() {

            // generate a random number between 0 and 2 inclusive
            int rand = _randGen.Next(3);

            return new Package((Priority)rand);
        }
    }


    // Package -- An example of a prioritizable class that can be stored in the
    // queue and implements IPrioritizable
    class Package : IPrioritizable {

        private Priority _priority;

        // constructor
        public Package(Priority priority) {
            this._priority = priority;
        }

        // Priority -- Return package priority (read-only)
        public Priority Priority {
            get { return _priority; }
        }
    }


    // IPrioritizable -- Custom interface : Classes that can be added to a
    // priority queue must implement this interface
    interface IPrioritizable {
        Priority Priority { get; }
    }


    // Priority -- A custom enumeration
    enum Priority { Low, Mid, High }
}

