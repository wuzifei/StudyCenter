 = 1;

			t.Commit();
			s.Close();

			s = OpenSession();
			t = s.BeginTransaction();
			c =
				(Customer)
				s.CreateQuery(
					"from Customer c left join fetch c.Orders o left join fetch o.LineItems li left join fetch li.Product p").
					UniqueResult();
			Assert.IsTrue(NHibernateUtil.IsInitialized(c.Orders));
			Assert.AreEqual(2, c.Orders.Count);
			Assert.IsTrue(NHibernateUtil.IsInitialized(((Order) c.Orders[0]).LineItems));
			Assert.IsTrue(NHibernateUtil.IsInitialized(((Order) c.Orders[1]).LineItems));
			Assert.AreEqual(((Order) c.Orders[0]).LineItems.Count, 2);
			Assert.AreEqual(((Order) c