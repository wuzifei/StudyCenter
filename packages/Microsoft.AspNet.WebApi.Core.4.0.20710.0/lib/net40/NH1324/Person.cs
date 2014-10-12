llableResults sr2 = s.CreateQuery("from Silly where name = 'silly'").Scroll();

		//    Assert.IsTrue(sr.next());
		//    Assert.AreEqual(silly, sr.get(0));
		//    Assert.IsTrue(sr2.next());
		//    Assert.AreEqual(silly, sr2.get(0));

		//    sr.Close();
		//    sr2.Close();

		//    s.Delete(silly);
		//    s.Flush();

		//    Release(s);
		//    Done();
		//}

		[Test]
		public void SuppliedConnection()
		{
			Prepare();

			IDbConnection originalConnection = sessions.ConnectionProvider.GetConnection();
			ISession session = sessions.OpenSession(originalConnection);

			Silly silly = new Silly("silly");
			session.Save(silly);

			// this will cause the connection manager to cycle through the aggressive Rele