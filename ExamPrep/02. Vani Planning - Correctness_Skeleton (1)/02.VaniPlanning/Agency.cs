namespace _02.VaniPlanning
{
    using System;
    using System.Collections.Generic;

    public class Agency : IAgency
    {
        private readonly Dictionary<string, Invoice> invoices;

        public Agency()
        {
            this.invoices = new Dictionary<string, Invoice>();
        }

        public void Create(Invoice invoice)
        {
            if (this.invoices.ContainsKey(invoice.SerialNumber))
            {
                throw new ArgumentException();
            }

            this.invoices.Add(invoice.SerialNumber, invoice);
        }

        public void ThrowInvoice(string number)
        {
            if (this.invoices.ContainsKey(number))
            {
                throw new ArgumentException();
            }

            this.invoices.Remove(number);
        }

        public void ThrowPayed()
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            return this.invoices.Count;
        }

        public bool Contains(string number)
        {
            return this.invoices.ContainsKey(number);
        }

        public void PayInvoice(DateTime due)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invoice> GetAllInvoiceInPeriod(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invoice> SearchBySerialNumber(string serialNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invoice> ThrowInvoiceInPeriod(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invoice> GetAllFromDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Invoice> GetAllByCompany(string company)
        {
            throw new NotImplementedException();
        }

        public void ExtendDeadline(DateTime dueDate, int days)
        {
            throw new NotImplementedException();
        }
    }
}
