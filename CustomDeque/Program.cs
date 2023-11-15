using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib;

namespace CustomDeque
{
    class Program
    {
        static void Main(string[] args)
        {
            var CustomDeque = new CustomDeque<string>();


            void OnElementAdded(string data)
            {
                Console.WriteLine("\nEvent: Element added: " + data);
            }

            void OnElementRemoved(string data)
            {
                Console.WriteLine("\nEvent: Element deleted: " + data);
            }

            void OnCleared()
            {
                Console.WriteLine("\nEvent: Deque cleared");
            }

            CustomDeque.ElementAdded += OnElementAdded;
            CustomDeque.ElementRemoved += OnElementRemoved;
            CustomDeque.Cleared += OnCleared;



            while (true)
            {
                try
                {
                    Console.Clear();

                    Console.WriteLine("The number of elements in the deck: " + CustomDeque.Count);
                    Console.WriteLine("\nChose an action:");
                    Console.WriteLine("1. Show elements");
                    Console.WriteLine("2. Add an element to the front");
                    Console.WriteLine("3. Add an element to the back");
                    Console.WriteLine("4. Remove the element from the back of the deck");
                    Console.WriteLine("5. Remove the element from the front side of the deck");
                    Console.WriteLine("6. Clear deck");
                    Console.WriteLine("7. Checking for inclusion");
                    Console.WriteLine("8. Check if the deck is empty");

                    Console.WriteLine("9. Exit\n");

                    Console.WriteLine("Your action:");

                    string option = Console.ReadLine();

                    string inputedElement;
                    switch (option)
                    {
                        case "1":
                            Console.Clear();

                            bool isEmpty = true;

                            foreach (var item in CustomDeque)
                            {
                                Console.WriteLine(item);
                                isEmpty = false;
                            }

                            if (isEmpty == true)
                            {
                                Console.WriteLine("The deck is empty");
                            };

                            Console.ReadKey();
                            break;
                        case "2":
                            Console.Clear();
                            Console.WriteLine("Enter element:");
                            inputedElement = Console.ReadLine();
                            if (inputedElement == null)
                            {
                                Console.WriteLine("Incorect input");
                                Console.ReadKey();
                                continue;
                            }
                            CustomDeque.AddFirst(inputedElement);
                            break;
                        case "3":
                            Console.Clear();
                            Console.WriteLine("\"Enter element:");
                            inputedElement = Console.ReadLine();
                            if (inputedElement == null)
                            {
                                Console.WriteLine("Incorect input");
                                Console.ReadKey();
                                continue;
                            }
                            CustomDeque.AddLast(inputedElement);
                            break;
                        case "4":
                            Console.Clear();
                            CustomDeque.RemoveLast();
                            break;
                        case "5":
                            Console.Clear();
                            CustomDeque.RemoveFirst();
                            break;
                        case "6":
                            CustomDeque.Clear();
                            break;
                        case "7":
                            Console.Clear();
                            Console.WriteLine("Enter element");
                            inputedElement = Console.ReadLine();
                            if (CustomDeque.Contains(inputedElement) == true)
                            {
                                Console.WriteLine("Element " + inputedElement + " present in the deck");
                            }
                            else
                            {
                                Console.WriteLine("Element " + inputedElement + " absent from the deck");
                            }
                            Console.ReadKey();
                            break;
                        case "8":
                            Console.Clear();
                            if (CustomDeque.IsEmpty == true)
                            {
                                Console.WriteLine("The deck is empty");
                            }
                            else
                            {
                                Console.WriteLine("The deck is not empty");
                            }
                            Console.ReadKey();
                            break;
                        case "9":
                            CustomDeque.ElementAdded -= OnElementAdded;
                            CustomDeque.ElementRemoved -= OnElementRemoved;
                            CustomDeque.Cleared -= OnCleared;
                            return;
                        default:
                            break;
                    }

                    Console.ReadKey();
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Виникла помилка: " + ex.Message);
                    Console.ReadKey();
                };
            }
        }
    }
}
