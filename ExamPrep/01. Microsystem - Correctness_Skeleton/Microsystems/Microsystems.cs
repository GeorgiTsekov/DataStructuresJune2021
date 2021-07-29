using System;
using System.Collections.Generic;
using System.Linq;

public class Microsystems : IMicrosystem
{
    private Dictionary<int, Computer> computers;

    public Microsystems()
    {
        this.computers = new Dictionary<int, Computer>();
        this.computers = new Dictionary<int, Computer>();
    }

    public bool Contains(int number)
    {
        return this.computers.ContainsKey(number);
    }

    public int Count()
    {
        return this.computers.Count;
    }

    public void CreateComputer(Computer computer)
    {
        if (this.computers.ContainsKey(computer.Number))
        {
            throw new ArgumentException();
        }

        this.computers.Add(computer.Number, computer);
    }

    public IEnumerable<Computer> GetAllFromBrand(Brand brand)
    {
        return this.computers
            .Where(x => x.Value.Brand == brand)
            .OrderByDescending(x => x.Value.Price)
            .ToDictionary(x => x.Key, y => y.Value).Values
            .ToList();
    }

    public IEnumerable<Computer> GetAllWithColor(string color)
    {
        return this.computers
            .Where(x => x.Value.Color == color)
            .OrderByDescending(x => x.Value.Price)
            .ToDictionary(x => x.Key, y => y.Value).Values
            .ToList();
    }

    public IEnumerable<Computer> GetAllWithScreenSize(double screenSize)
    {
        return this.computers
            .Where(x => x.Value.ScreenSize == screenSize)
            .OrderByDescending(x => x.Value.Number)
            .ToDictionary(x => x.Key, y => y.Value).Values
            .ToList();
    }

    public Computer GetComputer(int number)
    {
        if (!this.computers.ContainsKey(number))
        {
            throw new ArgumentException();
        }

        return this.computers[number];
    }

    public IEnumerable<Computer> GetInRangePrice(double minPrice, double maxPrice)
    {
        return this.computers
            .Where(x => x.Value.Price >= minPrice && x.Value.Price <= maxPrice)
            .OrderByDescending(x => x.Value.Price)
            .ToDictionary(x => x.Key, y => y.Value).Values
            .ToList();
    }

    public void Remove(int number)
    {
        if (!this.computers.ContainsKey(number))
        {
            throw new ArgumentException();
        }

        this.computers.Remove(number);
    }

    public void RemoveWithBrand(Brand brand)
    {
        if (!this.computers.Any(x => x.Value.Brand == brand))
        {
            throw new ArgumentException();
        }

        this.computers = this.computers.Where(x => x.Value.Brand != brand).ToDictionary(x => x.Key, y => y.Value);
    }

    public void UpgradeRam(int ram, int number)
    {
        if (!this.computers.ContainsKey(number))
        {
            throw new ArgumentException();
        }

        if (this.computers[number].RAM < ram)
        {
            this.computers[number].RAM = ram;
        }
    }
}
