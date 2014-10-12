<?xml version="1.0"?>
<hibernate-mapping xmlns="urn:nhibernate-mapping-2.2" namespace="NHibernate.Test.CompositeCollection" assembly="NHibernate.Test">
	<class name="BaseClassB" table="bases">
		<id name="BaseID" column="baseid" unsaved-value="0">
			<generator class="sequence">
				<param name="sequence">baseids</param>
			</generator>
		</id>
		<bag name="Values" inverse="true" cascade="all-delete-orphan">
			<key column="baseid"/>
			<one-to-many class="ChildClassB"/>
		</bag>
	</class>
	<class name="ChildClassB" table="children">
		<id name="ChildID" column="childid" unsaved-value="0">
			<generator class="sequence">
				<param name="sequence">childids</param>
			</gener