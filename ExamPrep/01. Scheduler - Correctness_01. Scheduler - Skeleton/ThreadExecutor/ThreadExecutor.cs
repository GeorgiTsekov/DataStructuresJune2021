using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

/// <summary>
/// The ThreadExecutor is the concrete implementation of the IScheduler.
/// You can send any class to the judge system as long as it implements
/// the IScheduler interface. The Tests do not contain any <e>Reflection</e>!
/// </summary>
public class ThreadExecutor : IScheduler
{
    private List<Task> tasks;
    private Dictionary<int, Task> tasksDict;
  
    public ThreadExecutor()
    {
        this.tasks = new List<Task>();
        this.tasksDict = new Dictionary<int, Task>();
    }

    public int Count => this.tasksDict.Count;


    public void ChangePriority(int id, Priority newPriority)
    {
        if (!this.tasksDict.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        this.tasksDict[id].TaskPriority = newPriority;
        this.tasks.FirstOrDefault(x => x.Id == id).TaskPriority = newPriority;
    }

    public bool Contains(Task task)
    {
        if (!this.tasksDict.ContainsKey(task.Id))
        {
            return false;
        }

        return true;
    }

    public int Cycle(int cycles)
    {
        if (this.tasksDict.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var list = new List<Task>();
        var dict = new Dictionary<int, Task>();
        int count = 0;

        foreach (var task in this.tasks)
        {
            if (task.Consumption > cycles)
            {
                list.Add(task);
                dict.Add(task.Id, task);
            }
            else
            {
                count++;
            }
        }
        this.tasks = list;
        this.tasksDict = dict;

        return count;
    }

    public void Execute(Task task)
    {
        if (this.tasksDict.ContainsKey(task.Id))
        {
            throw new ArgumentException();
        }

        this.tasksDict.Add(task.Id, task);
        this.tasks.Add(task);
    }

    public IEnumerable<Task> GetByConsumptionRange(int lo, int hi, bool inclusive)
    {
        if (inclusive)
        {
            return this.tasks
                .Where(x => x.Consumption >= lo && x.Consumption <= hi)
                .OrderBy(x => x.Consumption)
                .ThenByDescending(x => x.TaskPriority);
        }
        else
        {
            return this.tasks
                .Where(x => x.Consumption > lo && x.Consumption < hi)
                .OrderBy(x => x.Consumption)
                .ThenByDescending(x => x.TaskPriority);
        }
    }

    public Task GetById(int id)
    {
        if (!this.tasksDict.ContainsKey(id))
        {
            throw new ArgumentException();
        }

        return this.tasksDict[id];
    }

    public Task GetByIndex(int index)
    {
        if (this.tasks.Count <= index || index < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        return this.tasks[index];
    }

    public IEnumerable<Task> GetByPriority(Priority type)
    {
        return this.tasks
                .Where(x => x.TaskPriority == type)
                .OrderByDescending(x => x.Id);
    }

    public IEnumerable<Task> GetByPriorityAndMinimumConsumption(Priority priority, int lo)
    {
        return this.tasks
                .Where(x => x.TaskPriority == priority && x.Consumption >= lo)
                .OrderByDescending(x => x.Id);
    }


    public IEnumerator<Task> GetEnumerator()
    {
        return this.tasks.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.tasks.GetEnumerator();
    }
}
