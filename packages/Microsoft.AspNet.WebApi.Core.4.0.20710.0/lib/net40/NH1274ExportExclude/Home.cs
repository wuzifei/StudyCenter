<?xml version="1.0"?>

<hibernate-mapping xmlns="urn:nhibernate-mapping-2.2" default-lazy="false">

	<class 
		name="NHibernate.Test.CompositeId.ClassWithCompositeId, NHibernate.Test" 
		table="class_w_com_id"
	>
		<composite-id name="Id" class="NHibernate.Test.CompositeId.Id, NHibernate.Test" access="nosetter.camelcase-underscore">
			<key-property name="KeyString" column="string_" type="String(20)" length="20" />
			<key-property name="KeyShort" column="short_" access="field.camelcase-underscore"/>
			<key-property name="KeyDateTime" column="date_" type="DateTime" access="nosetter.camelcase-underscore"/>
		</composite-id>
		
		<property name="OneProperty" column="one_property"/>
	</class>
	
</hibernate-mapping>
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             