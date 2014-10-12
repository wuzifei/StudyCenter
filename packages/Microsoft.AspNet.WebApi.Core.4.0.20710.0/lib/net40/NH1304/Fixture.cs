<?xml version="1.0"?>
<!-- 

  This mapping demonstrates 
  
     (1) composite keys and one-to-many associations on 
         composite keys
      
     (2) use of insert="false" update="false" on an
         association mapping, when the foreign key is
         also part of the primary key
         
     (3) use of a derived property which performs a
         subselect against associated tables
         
     (4) use of <synchronize/> to ensure that auto-flush
         works correctly for an entity with a property
         derived from other tables
         
     
-->
<hibernate-mapping xmlns="urn:nhibernate-mapping-2.2"
				   namespace="NHibernate.Test.CompositeId"
				   assembly="NHibernate.Test"
				   default-access="field.camelcase">

    <class name="Order" table="CustomerOrder">
    	<synchronize table="LineItem"/>
    	<synchronize table="Product"/>