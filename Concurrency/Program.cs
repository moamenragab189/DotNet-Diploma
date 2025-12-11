using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Remoting.Services;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Concurrency
{
    internal class Program
    {
        class Thread_safe_Queue 
        {
                 Queue<int> queue=new Queue<int>();
            Mutex mutex=new Mutex();
         public   void Add(int value)
            {
                Console.WriteLine("thread " + Thread.CurrentThread.ManagedThreadId +"waiting");
                mutex.WaitOne();
                Console.WriteLine("thread " + Thread.CurrentThread.ManagedThreadId + "got the lock");
                queue.Enqueue(value);
              //  Thread.Sleep(3000);
                mutex.ReleaseMutex();
                Console.WriteLine("thread " + Thread.CurrentThread.ManagedThreadId + "lock released");
                
            }
          public void GetTop() 
            {
                Console.WriteLine("thread " + Thread.CurrentThread.ManagedThreadId + "waiting");
                mutex.WaitOne();
                Console.WriteLine("thread " + Thread.CurrentThread.ManagedThreadId + "got the lock");
                if (queue.Count > 0)
                {
                    int x = queue.Peek();
                    Console.WriteLine($"Peeked value: {x} (queue size: {queue.Count})");
                }
                else
                {
                    Console.WriteLine("Queue is empty, cannot Peek");
                }
                mutex.ReleaseMutex();
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "lock released");
               // Console.WriteLine(x);

            }
          public  void RemoveTop()
            {
                Console.WriteLine("thread "+Thread.CurrentThread.ManagedThreadId + "waiting");
                mutex.WaitOne();
                Console.WriteLine("thread " + Thread.CurrentThread.ManagedThreadId + "got the lock");
                if (queue.Count > 0)
                {
                    int x = queue.Dequeue();
                    Console.WriteLine($"Removed {x} (queue size: {queue.Count})");
                }
                else
                {
                    Console.WriteLine("Queue is empty, cannot Dequeue");
                }
                mutex.ReleaseMutex();
                Console.WriteLine("thread " + Thread.CurrentThread.ManagedThreadId + "lock released");
            }
        }


        class Online_Game
        {
         public Dictionary<int, int> Romes =new Dictionary<int,int>();
            object moni = new object();
            public Online_Game()
            {
                Romes[1] = 0;
                Romes[2] = 0;
                Romes[3] = 0;
                Romes[4] = 0;
                Romes[5] = 0;
                
            }
            public bool IsFull()
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (Romes[i] < 5)
                    {
                        //Romes[i]++;
                        //Console.WriteLine($"Player added to room {i}, total now: {Romes[i]}");
                        return false;
                    }
                }
                return true;
            }
            public bool IsEmpty()
            {
                for (int i = 1; i <= 5; i++)
                {
                    if (Romes[i] > 0)
                    {
                        //Romes[i]++;
                        //Console.WriteLine($"Player added to room {i}, total now: {Romes[i]}");
                        return false;
                    }
                }
                return true;
            }
            public void addplayer() 
            {
                lock (moni)
                {

                    while (IsFull())
                    {
                        Console.WriteLine(Thread.CurrentThread.ManagedThreadId+" waiting for empty place");
                        Monitor.Wait(moni);
                    }
                    for (int i = 1; i <= 5; i++)
                    {
                        if (Romes[i] < 5)
                        {
                            Romes[i]++;
                            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Player added to room {i}, total now: {Romes[i]}");
                            break;
                        }
                    }
                    Monitor.PulseAll(moni);
                }


            }
            public void remove_player()
            {
                lock (moni)
                {
                    while (IsEmpty()) 
                    {
                        Console.WriteLine(Thread.CurrentThread.ManagedThreadId + "rooms are empty");
                        Monitor.Wait(moni);
                    }
                    for (int i = 1; i <= 5; i++)
                    {
                        if (Romes[i]>0)
                        {
                            Romes[i]--;
                            Console.WriteLine($"Player removed from room {i}, total now: {Romes[i]}");
                            break;
                        }
                    }
                    Monitor.PulseAll(moni);
                }
            }
            public void PlayerGenerator() 
            {
                // Thread for generating new players (producers)
                new Thread(() =>
                {
                    Random rnd = new Random();
                    while (true)
                    {
                        new Thread(addplayer).Start();
                        Thread.Sleep(rnd.Next(300, 1000)); // new player every 0.3–1 sec
                    }
                }).Start();

                // Thread for removing players (consumers)
                new Thread(() =>
                {
                    Random rnd = new Random();
                    while (true)
                    {
                        new Thread(remove_player).Start();
                        Thread.Sleep(rnd.Next(1000, 2000)); // player leaves every 1–2 sec
                    }
                }).Start();

            }
        }

        static void Main(string[] args)
        {
            Thread_safe_Queue q= new Thread_safe_Queue();
            //Implement a Thread - safe Queue.
            #region Implement a Thread - safe Queue.
            /*  Thread th1 = new Thread(() => q.Add(2));
              Thread th2 = new Thread(() => q.GetTop());
              Thread th3 = new Thread(() => q.RemoveTop());
              Thread th4 = new Thread(() => q.Add(6));
              Thread th5 = new Thread(() => q.GetTop());
              Thread th6 = new Thread(() => q.RemoveTop());
              Thread th7 = new Thread(() => q.Add(8));
              Thread th8 = new Thread(() => q.GetTop());
              Thread th9 = new Thread(() => q.RemoveTop());
              th1.Start();
              th2.Start();
              th3.Start();
              th4.Start();
              th5.Start();
              th6.Start();
              th7.Start();
              th8.Start();
              th9.Start();

              th1.Join();
              th2.Join();
              th3.Join();
              th4.Join();
              th5.Join();
              th6.Join();
              th7.Join();
              th8.Join();
              th9.Join();*/
            #endregion





            //===========================================================




            /*   
                            Task 2 - Online Game
               Design a Thread-safe solution for the following problem.
               There is an online game which has the idea of a Room.
               A Room is a group of multiple players who can play together.
               The Game has 5 Rooms.
               The Room allows only 5 Players to be in, that’s a full Room.
               If a player tries to enter a Room with 5 players in, they must wait till some player
               leaves the room.
               Players who enter the game try to enter any Room that has available space, if no
               room has available space, they wait.
               As long as the Room has at least one player, the game is going in this room.
             */

            //Online_Game game = new Online_Game();
            //game.PlayerGenerator();
            //====================================================================================
        }
    }
}
