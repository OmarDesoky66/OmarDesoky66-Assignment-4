using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

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


        //string[] SortedSessionNames = new string[sessionNames.Length];
        //Array.Copy(sessionNames, SortedSessionNames, sessionNames.Length);
        //Array.Sort(SortedSessionNames, StringComparer.OrdinalIgnoreCase);

        //Array.Reverse(SortedSessionNames);

        //Console.WriteLine("Sorted and Reversed Session Names :");
        //foreach (string name in SortedSessionNames)
        //{
        //    Console.WriteLine($"- {name}");
        //}

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




        //string[] arry2 = new string[sessionNames.Length];
        //Array.Copy(sessionNames, arry2, sessionNames.Length);
        //arry2[0] = "C# Basics - Updated";
        //Console.WriteLine($"Original Array : {sessionNames[0]}");
        //Console.WriteLine($"Copied Array : {arry2[0]}");



        //DisplayDurationAnalysis(sessionDurations);
        //int[] sortedSessionDuration = new int[sessionDurations.Length];

        //Array.Copy(sessionDurations, sortedSessionDuration, sessionDurations.Length);
        //Array.Sort(sortedSessionDuration);

        //foreach (int item in sortedSessionDuration)
        //{
        //    Console.WriteLine(item);
        //}


        //int Number = 5;
        //Console.WriteLine($"Before ChangeValue : {Number}");
        //ChangeValue(ref Number);
        //Console.WriteLine($"After ChangeValue : {Number}");


        //Console.Write("Enter session name: ");
        //string searchName = Console.ReadLine()!;

        //if (FindSession(sessionNames, sessionDurations, searchName, out int sessionIndex, out int sessionDuration))
        //{
        //    Console.WriteLine($"Index :{sessionIndex}");
        //    Console.WriteLine($"Duration {sessionDuration} minutes");
        //}
        //else
        //{
        //    Console.WriteLine("Session not found.");
        //}



        ////Part 7

        //int[] arr = { 1, 2, 3, 4, 5 };
        //Console.WriteLine($"Before ChangeArrayWithoutRef : {arr[0]}");
        //foreach(int item in arr)
        //{
        //    Console.WriteLine(item);
        //}
        //ChangeArrayWithoutRef(arr);
        //Console.WriteLine($"After ChangeArrayWithoutRef : {arr[0]}");
        //foreach (int item in arr)
        //{
        //    Console.WriteLine(item);
        //}



        ////Part 8
        //Console.WriteLine(CalculateTotalDuration(120, 180));
        //Console.WriteLine(CalculateTotalDuration(120, 180, 240));
        //Console.WriteLine(CalculateTotalDuration(60, 90, 120, 180, 240));





        //Part 9
        SessionDateDetails(sessionNames, sessionDates, sessionDurations);

        //Part 10
        DateDifference(sessionNames, sessionDates);


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

    public static void DisplayDurationAnalysis(int[] sessionDurations)
    {
        int totalDuration = 0;
        int shortestDuration = int.MaxValue;
        int longestDuration = int.MinValue;
        int averageDuration = 0;

        for (int i = 0; i < sessionDurations.Length; i++)
        {
            totalDuration += sessionDurations[i];
            if (longestDuration < sessionDurations[i])
            {
                longestDuration = sessionDurations[i];
            }
            else if (shortestDuration > sessionDurations[i])
            {
                shortestDuration = sessionDurations[i];
            }
        }
        averageDuration = totalDuration / sessionDurations.Length;

        Console.WriteLine($"TotalDuration = {totalDuration}");
        Console.WriteLine($"longestDuration = {longestDuration}");
        Console.WriteLine($"shortestDuration = {shortestDuration}");
        Console.WriteLine($"AverageDuartion = {averageDuration}");

    }


    public static void DisplaySessions(string[] sessionNames)
    {
        foreach (string name in sessionNames)
        {
            Console.WriteLine($"- {name}");
        }
    }

    public static int GetTotalDuration(int[]sessionDurations)
    {
        int total=0;
        for (int i = 0; i < sessionDurations.Length; i++)
        {
            total += sessionDurations[i];
            
        }
        return total;
    }

    public static float GetAverageDuration(int[] sessionDurations)
    {
        int total = 0;
        for (int i = 0; i < sessionDurations.Length; i++)
        {
            total += sessionDurations[i];

        }
        return (float)total/sessionDurations.Length;
    }

    public static int GetLongestDuration(int[] sessionDurations)
    {
        int longestDuration = int.MinValue;

        for (int i = 0; i < sessionDurations.Length; i++)
        {
            if (longestDuration < sessionDurations[i])
            {
                longestDuration = sessionDurations[i];
            }

        }
        return longestDuration;
    }


    public static int GetShortestDuration(int[] sessionDurations)
    {
        int shortestDuration = int.MaxValue;

        for (int i = 0; i < sessionDurations.Length; i++)
        {
            if (shortestDuration > sessionDurations[i])
            {
                shortestDuration = sessionDurations[i];
            }

        }
        return shortestDuration;
    }

    public static DateTime GetSessionEndTime(DateTime sessionStart, int sessionDuration)
    {
        return sessionStart.AddMinutes(sessionDuration);
    }


    public static DateTime ReadSessionDate()
    {
        DateTime sessionDate;

        while (true)
        {
            Console.Write("Enter session date and time (e.g. 10/09/2026 18:00): ");

            if (DateTime.TryParse(Console.ReadLine(), out sessionDate))
            {
                return sessionDate;
            }

            Console.WriteLine("Invalid date or time. Please try again.");
        }
    }

    public static string BuildReportUsingString(string[] sessionNames,DateTime[] sessionDates,int[] sessionDurations)
    {
        string report = "ACADEMY SCHEDULE REPORT\n";
        report += "-----------------------\n";

        for (int i = 0; i < sessionNames.Length; i++)
        {
            report += $"Session: {sessionNames[i]}\n";
            report += $"Date: {sessionDates[i]:d MMMM yyyy}\n";
            report += $"Duration: {sessionDurations[i]} minutes\n";
            report += $"End Time: {GetSessionEndTime(sessionDates[i], sessionDurations[i]):hh:mm tt}\n";
            report += "\n";
        }

        report += $"Total Duration: {GetTotalDuration(sessionDurations)} minutes\n";
        report += $"Average Duration: {GetAverageDuration(sessionDurations):F2} minutes\n";

        return report;
    }

    public static string BuildReportUsingStringBuilder(string[] sessionNames,DateTime[] sessionDates,int[] sessionDurations)
    {
        StringBuilder report = new StringBuilder();

        report.AppendLine("ACADEMY SCHEDULE REPORT");
        report.AppendLine("-----------------------");

        for (int i = 0; i < sessionNames.Length; i++)
        {
            report.AppendLine($"Session: {sessionNames[i]}");
            report.AppendLine($"Date: {sessionDates[i]:d MMMM yyyy}");
            report.AppendLine($"Duration: {sessionDurations[i]} minutes");
            report.AppendLine(
                $"End Time: {GetSessionEndTime(sessionDates[i], sessionDurations[i]):hh:mm tt}");
            report.AppendLine();
        }

        report.AppendLine(
            $"Total Duration: {GetTotalDuration(sessionDurations)} minutes");

        report.AppendLine(
            $"Average Duration: {GetAverageDuration(sessionDurations):F2} minutes");

        return report.ToString();
    }

    //Part 7 
    public static void ChangeValue(ref int num)
    {
        num = 100;
    }

    public static bool FindSession(string[] sessionNames, int[] sessionDurations , string searchName, out int sessionIndex, out int sessionDuration)
    {
        
        
        sessionIndex = Array.FindIndex(sessionNames,name => string.Equals(name, searchName,StringComparison.OrdinalIgnoreCase));
        if (sessionIndex != -1)
        {
            sessionDuration = sessionDurations[sessionIndex];
            return true;
        }
        else
        {
            sessionDuration = 0;
            return false;
        }
    }


    public static void ChangeArrayWithoutRef(int[] arr)
    {
        arr[0] = 100;
    }


    //Part 8 
    public static int CalculateTotalDuration(params int[] durations)
    {
        int total = 0;

        foreach (int duration in durations)
        {
            total += duration;
        }

        return total;
    }


    //Part 9
    public static void DisplaySessionDetails(string sessionName,DateTime sessionDate,int sessionDuration)
    {
        Console.WriteLine($"Session: {sessionName}");
        Console.WriteLine($"Date: {sessionDate:dd MMMM yyyy}");
        Console.WriteLine($"Day: {sessionDate.DayOfWeek}");
        Console.WriteLine($"Year: {sessionDate.Year}");
        Console.WriteLine($"Month: {sessionDate.Month}");
        Console.WriteLine($"Day Number: {sessionDate.Day}");
        Console.WriteLine($"Start Time: {sessionDate:hh:mm tt}");
        Console.WriteLine($"Duration: {sessionDuration} minutes");

        DateTime endTime = GetSessionEndTime(sessionDate, sessionDuration);

        Console.WriteLine($"End Time: {endTime:hh:mm tt}");
    }
    public static void SessionDateDetails(string[] sessionNames, DateTime[] sessionDates, int[] sessionDurations)
    {
        Console.Write("Enter session name: ");
        string searchName = Console.ReadLine()!;

        int index = Array.FindIndex(
            sessionNames,
            name => string.Equals(name, searchName, StringComparison.OrdinalIgnoreCase));

        if (index != -1)
        {
            DisplaySessionDetails(
                sessionNames[index],
                sessionDates[index],
                sessionDurations[index]);
        }
        else
        {
            Console.WriteLine("Session not found.");
        }
    }

    //Part 10
    public static void DateDifference(string[] sessionNames, DateTime[] sessionDates)
    {
        Console.Write("Enter first session name: ");
        string firstSessionName = Console.ReadLine()!;
        Console.WriteLine("Enter second session name: ");
        string secondSessionName = Console.ReadLine()!;

        int firstIndex = Array.FindIndex(sessionNames, name => string.Equals(name, firstSessionName, StringComparison.OrdinalIgnoreCase));
        int secondIndex = Array.FindIndex(sessionNames, name => string.Equals(name, secondSessionName, StringComparison.OrdinalIgnoreCase));

        if (firstIndex == -1 || secondIndex == -1)
        {
            Console.WriteLine("Session not found.");
            return ;
        }

        TimeSpan difference =
            (sessionDates[firstIndex] - sessionDates[secondIndex]).Duration();

        Console.WriteLine("Difference:");
        Console.WriteLine($"{difference.TotalDays} days");
        Console.WriteLine($"{difference.TotalHours} hours");


    }


}
