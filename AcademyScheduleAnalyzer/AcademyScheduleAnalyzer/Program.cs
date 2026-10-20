namespace AcademyScheduleAnalyzer;

internal class Program
{
    static void Main(string[] args)
    {
        string[] sessionNames =
{
"C# Basics",
"Arrays",
"Functions",
"Date and Time",
"Exception Handling"
};
        DateTime[] sessionDates =
        {
new DateTime(2026, 9, 10, 18, 0, 0),
new DateTime(2026, 9, 13, 18, 0, 0),
new DateTime(2026, 9, 17, 18, 0, 0),
new DateTime(2026, 9, 20, 18, 0, 0),
new DateTime(2026, 9, 24, 18, 0, 0)
};
        int[] sessionDurations =
        {
180,
240,
180,
240,
180
};
        //DisplaySchedule(sessionNames, sessionDates, sessionDurations);
        //SearchSession(sessionNames, sessionDates, sessionDurations);


        string[] SortedSessionNames = new string[sessionNames.Length];
        Array.Copy(sessionNames, SortedSessionNames , sessionNames.Length);
        Array.Sort(SortedSessionNames, StringComparer.OrdinalIgnoreCase);

        Array.Reverse(SortedSessionNames);

        Console.WriteLine("Sorted and Reversed Session Names :");
        foreach (string name in SortedSessionNames)
        {
            Console.WriteLine($"- {name}");
        }

        //Console.WriteLine("Enter session name : ");
        //string enteredName = Console.ReadLine()!;


        //Console.WriteLine($"Session Index : {Array.IndexOf(SortedSessionNames, enteredName)}");

        //if (Array.Exists(SortedSessionNames, name => string.Equals(name, enteredName, StringComparison.OrdinalIgnoreCase)))
        //{
        //    Console.WriteLine("Session found.");
        //}
        //else
        //{
        //    Console.WriteLine("Session not found.");
        //}

        //Console.WriteLine(Array.Find(SortedSessionNames, name => string.Equals(name, enteredName, StringComparison.OrdinalIgnoreCase)));

        //Console.WriteLine(Array.FindIndex(SortedSessionNames, name => string.Equals(name, enteredName, StringComparison.OrdinalIgnoreCase)));




        string []arry2 = new string[sessionNames.Length];
        Array.Copy(sessionNames, arry2, sessionNames.Length);

        arry2[0] = "C# Basics - Updated";
        Console.WriteLine($"Original Array : {sessionNames[0]}");
        Console.WriteLine($"Copied Array : {arry2[0]}");









    }
    public static void DisplaySchedule(string[] sessionNames, DateTime[] sessionDates , int[] sessionDurations)
    {
        Console.WriteLine("Academy Schedule:");
        Console.WriteLine("-----------------");
        for(int i = 0; i< sessionNames.Length; i++)
        {
            Console.WriteLine($"{i+1}: {sessionNames[i]}");
            Console.WriteLine($"Date: {sessionDates[i].ToString("yyyy-MM-dd HH:mm")}");
            Console.WriteLine($"StartTime :  {sessionDates[i].ToString("hh:mm tt")}");
            Console.WriteLine($"Duration: {sessionDurations[i]} minutes");
            Console.WriteLine("");
        }
    }
    //This function is case-insensitive
    public static void SearchSession(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
    {
        Console.Write("Enter session name: ");
        string searchName = Console.ReadLine()!;

        int index = Array.FindIndex(
        sessionNames,
        name => string.Equals(
            name,
            searchName,
            StringComparison.OrdinalIgnoreCase)
    );


        if (index != -1)
        {
            Console.WriteLine($"{index + 1}. {sessionNames[index]}");
            Console.WriteLine($"Date: {sessionDates[index]:d MMMM yyyy}");
            Console.WriteLine($"StartTime :  {sessionDates[index].ToString("hh:mm tt")}");
            Console.WriteLine($"Duration: {sessionDurations[index]} minutes");
        }
        else
        {
            Console.WriteLine("Session not found.");
        }




    }





}
