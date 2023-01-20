
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld23123
{

    internal class PrograM                                      
    {
        class Person
        {
            public string name { get; protected set; }
            public int age { get; protected set; }

            public Person(string name, int age)
            {
                this.name = name;
                this.age = age;
            }

            public string returnDetails()
            {
                return name + " - " + age;
            }

            public void setName(string name)
            {
                this.name = name;
            }
            public void setAge(int age)
            {
                this.age = age;
            }

            class Manager
            {
                public List<Person> people;

                public Manager()
                {
                    people = new List<Person>();
                  
                    printMenu();
                }
                public void printMenu()
                {
                    Console.WriteLine("Welcome to my management system!" + Environment.NewLine);
                    Console.WriteLine("1. Print all users");
                    Console.WriteLine("2. Add user");
                    Console.WriteLine("3. Edit user");
                    Console.WriteLine("4. Search user");
                    Console.WriteLine("5. Remove user");
                    Console.WriteLine("6. Exit");

                    Console.Write("Enter your menu option: ");
                    bool tryParse = int.TryParse(Console.ReadLine(), out int menuOption);

                    if (tryParse)
                    {

                        if (menuOption == 1)
                        {
                            PrintAll();
                        }
                        else if (menuOption == 2)
                        {
                            AddPerson();
                        }
                        else if (menuOption == 3)
                        {
                            EditPerson();
                        }
                        else if (menuOption == 4)
                        {
                            SearchPerson();
                        }
                        else if (menuOption == 5)
                        {
                            RemovePerson();
                        }

                        if (menuOption >= 1 && menuOption <= 5)
                        {
                            printMenu();

                        }
                    }
                    else
                    {
                        OutputMessage("Incorrect menu choice.");

                        printMenu();
                    }



                }
                public void PrintAll()
                {
                    StartOption("Print all users:");

                    if (people.Count == 0)

                        Console.WriteLine("There are no users in the System, use option 1 to create a user ");
                    PrintAllUsers();


                    FinishOption();
                    
                }

                public void AddPerson()
                {

                    StartOption("Adding a  users:"); 


                    try
                    {
                        Person person = returnPerson();

                        if (person != null)
                        {
                            people.Add(person);
                            Console.WriteLine("Successfully added a person.");

                            FinishOption();
                        }
                        else
                        {
                            OutputMessage("Something has went wrong.");
                            AddPerson();
                        }
                    }
                    catch (Exception)
                    {
                        OutputMessage("Something has went wrong. ");

                        AddPerson();
                    }

                }

                public void EditPerson()
                {
                    StartOption("Editing a user: ");
                    //check if people in the system
                    //print all
                    //allow selection
                    //validate selection
                    //edit user, print message
                    //reduce back to menu


                    if (people.Count == 0)
                    {
                        Console.WriteLine("No users to edit. Use the menu to add a user");
                    }
                    else
                    {
                        PrintAllUsers();

                        try
                        {
                            Console.WriteLine("Enter an index");
                            int indexSelection = Convert.ToInt32(Console.ReadLine());
                            indexSelection--;

                            if (indexSelection >= 0 && indexSelection <= people.Count - 1)
                            {

                                try
                                {
                                    Person person = returnPerson();

                                    if (person != null)
                                    {
                                        people[indexSelection] = person;
                                        Console.WriteLine("Successfully edited a person.");

                                        FinishOption();
                                    }
                                    else
                                    {
                                        OutputMessage("Something has went wrong.");
                                        EditPerson();
                                    }
                                }
                                catch (Exception)
                                {
                                    OutputMessage("Something has went wrong. ");

                                    EditPerson();
                                }
                            }
                            else
                            {
                                OutputMessage("Enter a valid index range. ");
                                EditPerson();
                            }
                        }
                        catch (Exception)
                        {
                            OutputMessage("Something went wrong. ");
                            EditPerson();

                        }
                    }

                }
                public void SearchPerson()
                {
                    StartOption("Searching users:");

                    //check if people in system;
                    //get name input          
                    //validate name 
                    //loop and check for name 
                    // output results 
                    //return back to menu

                    if (people.Count == 0)
                    {
                        Console.WriteLine("There are no users in the system"); 
                    }
                    else
                    {
                        Console.WriteLine("Enter a name: "); 
                        string nameInput = Console.ReadLine();

                        bool bFound = false;

                        if (!string.IsNullOrEmpty(nameInput))  
                        {
                            for (int i = 0; i < people.Count; i++)
                            {
                                
                                if (people[i].name.ToLower().Contains(nameInput))
                                {
                                    bFound = true;
                                    Console.WriteLine(people[i].returnDetails());
                                }
                            }

                            if (!bFound)
                            {
                                Console.WriteLine("You did not find a user.");
                            }

                            FinishOption();
                        }
                        else
                        {
                            OutputMessage("Please enter a name.");
                            SearchPerson(); 
                        }
                    }
                }

                public void RemovePerson()
                {
                    StartOption("Removing a user:");

                    //check if people in system;
                    //output list of users
                    // intput selection
                    //validation selection
                    //print message
                    //return menu

                    if (people.Count == 0)
                    {
                        Console.WriteLine("There are no users in the system.");
                    }
                    else
                    {
                        PrintAllUsers(); 

                        Console.WriteLine("Enter an index: ");
                        int index = Convert.ToInt32(Console.ReadLine()); 
                        index--;
                        if (index >= 0 && index <= people.Count - 1) // validation selection
                        {
                            people.RemoveAt(index);
                            Console.WriteLine("Succesfully removed a person.");

                            FinishOption();
                        }
                        else
                        {
                            OutputMessage("Enter a valid index inside the range");
                            RemovePerson(); 
                        }
                    }
                }
                public void FinishOption()
                {
                    Console.WriteLine(Environment.NewLine + "You have finished this option.Press <Enter> to return to the menu");
                    Console.ReadLine();
                    Console.Clear();
                }

                public void StartOption(string message)
                {
                    Console.Clear();
                    Console.WriteLine(message + Environment.NewLine);
                }
                public void OutputMessage(string message)
                {
                    Console.WriteLine(message + "Press <Enter> to try again");
                    Console.ReadLine();
                    Console.Clear();
                }
                public void PrintAllUsers()
                {
                    for (int i = 0; i < people.Count; i++)
                    {
                        Console.WriteLine(i + 1 + ". " + people[i].returnDetails());
                    }
                }
                public Person returnPerson()
                {


                    Console.WriteLine("Enter a name: ");
                    string nameinput = Console.ReadLine();

                    Console.WriteLine("Enter a age");

                    int ageInput = Convert.ToInt32(Console.ReadLine());

                    if (!string.IsNullOrEmpty(nameinput)) 
                    {
                        if (ageInput >= 0 && ageInput <= 150)
                        {

                            return new Person(nameinput, ageInput);

                        }
                        else
                        {
                            OutputMessage("Enter a sensible age.");

                        }
                    }
                    else
                    {
                        OutputMessage("you didn't enter a name. ");

                    }
                    return null;
                }

            }

            static void Main(string[] args) 
            {

                Manager manager = new Manager();

                Console.WriteLine("Good bye!");
                Console.ReadLine();


            }
        }
    }
}
