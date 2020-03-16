using System;
using System.Collections.Generic;
using System.Linq;

namespace TasksPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> task = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            string command = null;

            while ((command = Console.ReadLine()) != "End")
            {
                switch (command.Split()[0])
                {
                    // Complete { index}
                    case "Complete":
                        int.TryParse(command.Split()[1], out int ri);
                        if (IndexExist(task, ri) && TimeIsValid(task[ri]))
                        {
                            task[ri] = 0;
                        }
                        break;
                    // Change {index} {time}   
                    case "Change":
                        int.TryParse(command.Split()[1], out int ci);
                        if (IndexExist(task, ci) && TimeIsValid(task[ci]) && TimeIsValid(int.Parse(command.Split()[2])))
                        {
                            task[ci] = int.Parse(command.Split()[2]);
                        }
                        break;
                    // Drop {index}
                    case "Drop":
                        int.TryParse(command.Split()[1], out int di);
                        if (IndexExist(task, di) && TimeIsValid(task[di]))
                        {
                            task[di] = -1;
                        }
                        break;
                    // Count Completed
                    // Count Incomplete
                    // Count Dropped
                    case "Count":
                        switch (command.Split()[1])
                        {
                            case "Completed":
                                Console.WriteLine(GetCount(task, command.Split()[1]));
                                break;
                            case "Incomplete":
                                Console.WriteLine(GetCount(task, command.Split()[1]));
                                break;
                            case "Dropped":
                                Console.WriteLine(GetCount(task, command.Split()[1]));
                                break;
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(" ",task.Where(x => x > 0 && x <= 5)));
        }

        private static bool TimeIsValid(int time)
        {
            if (time < 1 || time > 5)
                return false;

            return true;
        }

        private static bool IndexExist(List<int> task, int index)
        {
            if (index >= 0 && index < task.Count)
                return true;
            return false;
        }
        private static int GetCount(List<int> task, string command)
        {
            int result = 0;
            foreach (var time in task)
            {
                switch (command)
                {
                    case "Completed":
                        if(time == 0)
                            result++;
                        break;
                    case "Dropped":
                        if(time < 0)
                            result++;
                        break;
                    case "Incomplete":
                        if (time > 0 && time <= 5)
                            result++;
                        break;
                }
            }
            return result;
        }
    }
}
