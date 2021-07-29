﻿using NUnit.Framework;
using System;

public class Test06
{
    [TestCase]
    public void PayInvoice_Should_SetSubtotal_To_Zero()
    {
        //Arrange

        var agency = new Agency();
        var invoice = new Invoice("first", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 12, 28), new DateTime(2001, 10, 28));
        var invoice2 = new Invoice("second", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 11, 28), new DateTime(2001, 10, 28));
        var invoice3 = new Invoice("third", "SoftUni", 1200, Department.Incomes, new DateTime(2000, 10, 20), new DateTime(2000, 10, 28));


        //Act

        agency.Create(invoice);
        agency.Create(invoice2);
        agency.Create(invoice3);
        var expectedSubtotal = 0;
        agency.PayInvoice(new DateTime(2000, 10, 28));

        //Assert

        Assert.AreEqual(expectedSubtotal, invoice3.Subtotal);
    }
  
}
