﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using VideoWorld.Models;

namespace UnitTests.Models
{
    class StatementRepositoryTests
    {
        [Test]
        public void ShouldProvideStatementsForCustomer()
        {
            var repository = new StatementRepository();

            var c1 = new Customer("One");
            var c2 = new Customer("Two");
        	var o1 = new Order(new List<Rental>());
        	var o2 = new Order(new List<Rental>());

            var statement = new Statement(o1, c1);
            repository.Add(statement);

            repository.Add(new Statement(o2, c2));

            var c1statements = repository.FindByCustomer(c1);

            Assert.That(c1statements.Contains(statement));
            Assert.That(c1statements.Count(), Is.EqualTo(1));
        }
    }
}