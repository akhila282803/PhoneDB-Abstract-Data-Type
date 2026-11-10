using System;
using System.Collections.Generic;

class PhoneDB
{
    HashSet<string> members;
    Dictionary<string, HashSet<string>> telephones;

    public PhoneDB(IEnumerable<string> names)
    {
        members = new HashSet<string>(names);
        telephones = new Dictionary<string, HashSet<string>>();
    }

    public string AddEntry(string name, string newnumber)
    {
        if (members.Contains(name))
        {
            if (telephones.ContainsKey(name))
            {
                if (telephones[name].Contains(newnumber))
                {
                    return "number already exists";
                }
                else
                {
                    telephones[name].Add(newnumber);
                    return "ok";
                }
            }
            else
            {
                telephones[name] = new HashSet<string>();
                telephones[name].Add(newnumber);
                return "ok";
            }
        }
        else
        {
            return "unknown name";
        }
    }

    public string FindPhones(string name)
    {
        if (telephones.ContainsKey(name))
        {
            foreach (string number in telephones[name])
            {
                Console.WriteLine(number);
            }

            return "ok";
        }
        else
        {
            return "unknown name";
        }
    }

    public string RemoveEntry(string name, string oldnumber)
    {
        if (telephones.ContainsKey(name))
        {
            if (telephones[name].Contains(oldnumber))
            {
                telephones[name].Remove(oldnumber);

                if (telephones[name].Count == 0)
                {
                    telephones.Remove(name);
                }

                return "ok";
            }
            else
            {
                return "unknown number";
            }
        }
        else
        {
            return "unknown name";
        }
    }
}

class Program
{
    static void Main()
    {
        List<string> members =
            new List<string>() { "Akhila", "Sai" };

        PhoneDB phoneDB = new PhoneDB(members);

        string addResult1 = phoneDB.AddEntry("Akhila", "12213123");
        Console.WriteLine(addResult1);

        string addResult2 = phoneDB.AddEntry("Sai", "12341234");
        Console.WriteLine(addResult2);

        string addResult3 = phoneDB.AddEntry("Akhila", "13241234");
        Console.WriteLine(addResult3);

        Console.WriteLine("Akhila phone numbers");
        string findResult = phoneDB.FindPhones("Akhila");
        Console.WriteLine(findResult);

        Console.WriteLine("Sai phone number");
        phoneDB.FindPhones("Sai");

        string removeResult =
        phoneDB.RemoveEntry("Sai", "12341234");

        Console.WriteLine(removeResult);

        Console.WriteLine("Searching Sai after removing number");
        string saiResult = phoneDB.FindPhones("Sai");
        Console.WriteLine(saiResult);

        Console.WriteLine("Searching unknown person");
        string unknownResult = phoneDB.FindPhones("Shiva");
        Console.WriteLine(unknownResult);
    }
}