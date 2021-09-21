using System;
using System.Collections.Generic;
using System.Linq;

public class Microsystems : IMicrosystem
{
    private Dictionary<int, Computer> computers;
    //private Dictionary<Brand, HashSet<Computer>> computersByBrand;
    //private Dictionary<string, HashSet<Computer>> computersByColor;

    public Microsystems()
    {
        this.computers = new Dictionary<int, Computer>();
        //this.computersByBrand = new Dictionary<Brand, HashSet<Computer>>();
        //this.computersByColor = new Dictionary<string, HashSet<Computer>>();
    }

    public bool Contains(int number)
    {
        if (this.computers.Count == 0)
        {
            return false;
        }

        return this.computers.ContainsKey(number);
    }

    public int Count()
    {
        return this.computers.Count;
    }

    public void CreateComputer(Computer computer)
    {
        var number = computer.Number;

        if (this.computers.ContainsKey(number))
        {
            throw new ArgumentException();
        }

        //if (!this.computersByBrand.ContainsKey(computer.Brand))
        //{
        //    this.computersByBrand.Add(computer.Brand, new HashSet<Computer>());
        //}

        //if (!this.computersByColor.ContainsKey(computer.Color))
        //{
        //    this.computersByColor.Add(computer.Color, new HashSet<Computer>());
        //}

        this.computers.Add(number, computer);
        //this.computersByBrand[computer.Brand].Add(computer);
        //this.computersByColor[computer.Color].Add(computer);
    }

    public IEnumerable<Computer> GetAllFromBrand(Brand brand)
    {
        var comps = this.computers
            .Select(x => x.Value)
            .Where(x => x.Brand == brand)
            .OrderByDescending(x => x.Price);

        if (comps.Count() == 0)
        {
            return new List<Computer>();
        }

        return comps;
    }

    public IEnumerable<Computer> GetAllWithColor(string color)
    {
        var comps = this.computers
            .Select(x => x.Value)
            .Where(x => x.Color == color)
            .OrderByDescending(x => x.Price);

        if (comps.Count() == 0)
        {
            return new List<Computer>();
        }

        return comps;
    }

    public IEnumerable<Computer> GetAllWithScreenSize(double screenSize)
    {
        return this.computers
            .Select(x => x.Value)
            .Where(x => x.ScreenSize == screenSize)
            .OrderByDescending(x => x.Number);
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
            .Select(x => x.Value)
            .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
            .OrderByDescending(x => x.Price);
    }

    public void Remove(int number)
    {
        if (this.computers.Count == 0)
        {
            throw new ArgumentException();
        }

        if (!this.computers.ContainsKey(number))
        {
            throw new ArgumentException();
        }
        //var brand = this.computers[number].Brand;
        //var color = this.computers[number].Color;
        //var computer = this.computers[number];
        this.computers.Remove(number);

        //this.computersByBrand[brand].Remove(computer);
        //this.computersByColor[color].Remove(computer);
        //if (this.computersByBrand[brand].Count == 0)
        //{
        //    this.computersByBrand.Remove(brand);
        //}
        //if (this.computersByColor[color].Count == 0)
        //{
        //    this.computersByColor.Remove(computer.Color);
        //}
    }

    public void RemoveWithBrand(Brand brand)
    {
        if (this.computers.Count == 0)
        {
            throw new ArgumentException();
        }

        if (!this.computers.Any(x => x.Value.Brand == brand))
        {
            throw new ArgumentException();
        }

        this.computers = this.computers
            .Where(x => x.Value.Brand != brand)
            .ToDictionary(x => x.Key,y => y.Value);

        //var computersForRemove = this.computersByBrand[brand].Select(x => x.Number).ToList();

        //foreach (var number in computersForRemove)
        //{
        //    Remove(number);
        //}
    }

    public void UpgradeRam(int ram, int number)
    {
        if (this.computers.Count == 0)
        {
            throw new ArgumentException();
        }

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
