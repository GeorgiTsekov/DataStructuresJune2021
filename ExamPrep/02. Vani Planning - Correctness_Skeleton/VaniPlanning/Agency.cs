using System;
using System.Collections.Generic;
using System.Linq;

public class Agency : IAgency
{
    private Dictionary<string, Invoice> invocesDitctionary;

    public Agency()
    {
        this.invocesDitctionary = new Dictionary<string, Invoice>();
    }

    public bool Contains(string number)
    {
        return this.invocesDitctionary.ContainsKey(number);
    }

    public int Count()
    {
        return this.invocesDitctionary.Count;
    }

    public void Create(Invoice invoice)
    {
        if (this.invocesDitctionary.ContainsKey(invoice.SerialNumber))
        {
            throw new ArgumentException();
        }

        this.invocesDitctionary.Add(invoice.SerialNumber, invoice);
    }

    public void ExtendDeadline(DateTime dueDate, int days)
    {
        if (!this.invocesDitctionary.Any(x => x.Value.DueDate == dueDate))
        {
            throw new ArgumentException();
        }

        this.invocesDitctionary = this.invocesDitctionary
            .Where(x => x.Value.DueDate == dueDate.AddDays(days))
            .ToDictionary(x => x.Key, y => y.Value);
    }

    public IEnumerable<Invoice> GetAllByCompany(string company)
    {
        return this.invocesDitctionary
            .Where(x => x.Value.CompanyName == company)
            .OrderByDescending(x => x.Key)
            .ToDictionary(x => x.Key, y => y.Value).Values
            .ToList();
    }

    public IEnumerable<Invoice> GetAllFromDepartment(Department department)
    {
        return this.invocesDitctionary
            .Where(x => x.Value.Department == department)
            .OrderByDescending(x => x.Value.Subtotal)
            .ThenBy(x => x.Value.IssueDate)
            .ToDictionary(x => x.Key, y => y.Value).Values
            .ToList();
    }

    public IEnumerable<Invoice> GetAllInvoiceInPeriod(DateTime start, DateTime end)
    {
        return this.invocesDitctionary
            .Where(x => x.Value.DueDate >= start && x.Value.DueDate <= end)
            .OrderBy(x => x.Value.IssueDate)
            .ThenBy(x => x.Value.DueDate)
            .ToDictionary(x => x.Key, y => y.Value).Values
            .ToList();
    }

    public void PayInvoice(DateTime due)
    {
        if (!this.invocesDitctionary.Any(x => x.Value.DueDate == due))
        {
            throw new ArgumentException();
        }

        foreach (var invoice in this.invocesDitctionary.Values)
        {
            if (invoice.DueDate == due)
            {
                invoice.Subtotal = 0;
            }
        }
    }

    public IEnumerable<Invoice> SearchBySerialNumber(string serialNumber)
    {
        if (!this.invocesDitctionary.ContainsKey(serialNumber))
        {
            throw new ArgumentException();
        }

        var list = new List<Invoice>();
        list.Add(this.invocesDitctionary[serialNumber]);
        return list;
    }

    public void ThrowInvoice(string number)
    {
        if (!this.invocesDitctionary.ContainsKey(number))
        {
            throw new ArgumentException();
        }

        this.invocesDitctionary.Remove(number);
    }

    public IEnumerable<Invoice> ThrowInvoiceInPeriod(DateTime start, DateTime end)
    {
        if (!this.invocesDitctionary.Any(x => x.Value.DueDate >= start && x.Value.DueDate <= end))
        {
            throw new ArgumentException();
        }

        var list = this.invocesDitctionary
            .Where(x => x.Value.DueDate >= start && x.Value.DueDate <= end)
            .ToDictionary(x => x.Key, y => y.Value).Values
            .ToList();

        this.invocesDitctionary = this.invocesDitctionary
            .Where(x => x.Value.DueDate < start && x.Value.DueDate > end)
            .ToDictionary(x => x.Key, y => y.Value);

        return list;
    }

    public void ThrowPayed()
    {
        this.invocesDitctionary = this.invocesDitctionary
            .Where(x => x.Value.Subtotal > 0)
            .ToDictionary(x => x.Key, y => y.Value);
    }
}
