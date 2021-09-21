using System;
using System.Collections.Generic;
using System.Linq;

public class Agency : IAgency
{
    private Dictionary<string, Invoice> invocesDictionary;

    public Agency()
    {
        this.invocesDictionary = new Dictionary<string, Invoice>();
    }

    public bool Contains(string number)
    {
        return this.invocesDictionary.ContainsKey(number);
    }

    public int Count()
    {
        return this.invocesDictionary.Count;
    }

    public void Create(Invoice invoice)
    {
        if (this.invocesDictionary.ContainsKey(invoice.SerialNumber))
        {
            throw new ArgumentException();
        }

        this.invocesDictionary.Add(invoice.SerialNumber, invoice);
    }

    public void ExtendDeadline(DateTime dueDate, int days)
    {
        var result = this.invocesDictionary
            .Values
            .Where(x => x.DueDate == dueDate);

        if (result.Count() == 0)
        {
            throw new ArgumentException();
        }

        foreach (var item in result)
        {
            item.DueDate = item.DueDate.AddDays(days);
        }
    }

    public IEnumerable<Invoice> GetAllByCompany(string company)
    {
        return this.invocesDictionary
            .Select(x => x.Value)
            .Where(x => x.CompanyName == company)
            .OrderByDescending(x => x.SerialNumber);
    }

    public IEnumerable<Invoice> GetAllFromDepartment(Department department)
    {
        return this.invocesDictionary
            .Select(x => x.Value)
            .Where(x => x.Department == department)
            .OrderByDescending(x => x.Subtotal)
            .ThenBy(x => x.IssueDate);
    }

    public IEnumerable<Invoice> GetAllInvoiceInPeriod(DateTime start, DateTime end)
    {
        return this.invocesDictionary
            .Select(x => x.Value)
            .Where(x => x.IssueDate >= start && x.IssueDate <= end)
            .OrderBy(x => x.IssueDate)
            .ThenBy(x => x.DueDate);
    }

    public void PayInvoice(DateTime due)
    {
        var result = this.invocesDictionary.Values.Where(x => x.DueDate == due);

        if (result.Count() == 0)
        {
            throw new ArgumentException();
        }

        foreach (var invoice in result)
        {
            invoice.Subtotal = 0;
        }
    }

    public IEnumerable<Invoice> SearchBySerialNumber(string serialNumber)
    {
        var keys = this.invocesDictionary.Keys.Where(x => x.Contains(serialNumber));
        if (keys.Count() == 0)
        {
            throw new ArgumentException();
        }

        return keys
            .OrderByDescending(x => x)
            .Select(x => this.invocesDictionary[x]);
    }

    public void ThrowInvoice(string number)
    {
        if (!this.invocesDictionary.ContainsKey(number))
        {
            throw new ArgumentException();
        }

        this.invocesDictionary.Remove(number);
    }

    public IEnumerable<Invoice> ThrowInvoiceInPeriod(DateTime start, DateTime end)
    {
        var result = this.invocesDictionary
            .Values
            .Where(x => x.DueDate.Date > start.Date && x.DueDate.Date < end.Date)
            .ToList();

        if (result.Count() == 0)
        {
            throw new ArgumentException();
        }

        foreach (var invoice in result)
        {
            this.ThrowInvoice(invoice.SerialNumber);
        }

        return result;
        //if (!this.invocesDictionary.Any(x => x.Value.DueDate >= start && x.Value.DueDate <= end))
        //{
        //    throw new ArgumentException();
        //}

        //var list = this.invocesDictionary
        //    .Where(x => x.Value.DueDate >= start && x.Value.DueDate <= end)
        //    .ToDictionary(x => x.Key, y => y.Value).Values
        //    .ToList();

        //this.invocesDictionary = this.invocesDictionary
        //    .Where(x => x.Value.DueDate < start && x.Value.DueDate > end)
        //    .ToDictionary(x => x.Key, y => y.Value);

        //return list;
    }

    public void ThrowPayed()
    {
        this.invocesDictionary = this.invocesDictionary
            .Select(x => x.Value)
            .Where(x => x.Subtotal > 0)
            .ToList()
            .ToDictionary(x => x.SerialNumber, x => x);

        var result = this.invocesDictionary
            .Values
            .Where(x => x.Subtotal == 0)
            .ToList();

        if (result.Count() == 0)
        {
            return;
        }

        foreach (var invoice in result)
        {
            this.ThrowInvoice(invoice.SerialNumber);
        }

        //this.invocesDictionary = this.invocesDictionary
        //    .Where(x => x.Value.Subtotal > 0)
        //    .ToDictionary(x => x.Key, y => y.Value);
    }
}
