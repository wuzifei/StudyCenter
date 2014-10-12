tem.Type"/>
            is assumed. This default
            <see cref="T:Spring.Context.IApplicationContext"/> <see cref="T:System.Type"/>
            is currently the <see cref="T:Spring.Context.Support.XmlApplicationContext"/>
            <see cref="T:System.Type"/>; please note the exact <see cref="T:System.Type"/>
            of this default <see cref="T:Spring.Context.IApplicationContext"/> is an
            implementation detail, that, while unlikely, may do so in the future.
            to
            </p>
            </remarks>
            <example>
            <p>
            This is an example of specifying a context that reads its resources from
            an embedded Spring.NET XML object configuration file...
            </p>
            <code escaped="true">
            <configuration>
                <configSections>
            	    <sectionGroup name="spring">
            		    <section name="context" type="Spring.Context.Support.ContextHandler, Spring.Core"/>
            	    </sectionGroup>
                </configSections>
                <spring>
            	    <context>
            		    <resource uri="assembly://MyAssemblyName/MyResourceNamespace/MyObjects.xml"/>
            	    </context>
                </spring>
            </configuration>
            </code>
            <p>
            This is an example of specifying a context that reads its resources from
            a custom configuration section within the same application / web
            configuration file and uses case insensitive object lookups. 
            </p>
            <p>
            Please note that you <b>must</b> adhere to the naming
            of the various sections (i.e. '&lt;sectionGroup name="spring"&gt;' and
            '&lt;section name="context"&gt;'.
            </p>
            <code escaped="true">
            <configuration>
                <configSections>
            	    <sectionGroup name="spring">
            		    <section name="context" type="Spring.Context.Support.ContextHandler, Spring.Core"/>
            		    <section name="objects" type="Spring.Context.Support.DefaultSectionHandler, Spring.Core"/>
            	    </sectionGroup>
                </configSections>
                <spring>
            	    <context caseSensitive="false" type="Spring.Context.Support.XmlApplicationContext, Spring.Core">
            		    <resource uri="config://spring/objects"/>
            	    </context>
            	    <objects xmlns="http://www.springframework.net">
            		    <!-- object definitions... -->
            	    </objects>
                </spring>
            </configuration>
            </code>
            <p>
            And this is an example of specifying a hierarchy of contexts. The
            hierarchy in this case is only a simple parent-&gt;child hierarchy, but
            hopefully it illustrates the nesting of context configurations. This
            nesting of contexts can be arbitrarily deep, and is one way... child
            contexts know about their parent contexts, but parent contexts do not
            know how many child contexts they have (if any), or have references
            to any such child contexts.
            </p>
            <code escaped="true">
            <configuration>
            	<configSections>
            		<sectionGroup name="spring">
            			<section name="context" type="Spring.Context.Support.ContextHandler, Spring.Core"/>
            			<section name="objects" type="Spring.Context.Support.DefaultSectionHandler, Spring.Core"/>
                        <sectionGroup name="child">
            			    <section name="objects" type="Spring.Context.Support.DefaultSectionHandler, Spring.Core"/>
                        </sectionGroup>
            		</sectionGroup>
            	</configSections>
            	
                <spring>
            		<context name="Parent">
            			<resource uri="config://spring/objects"/>
            		    <context name="Child">
            			    <resource uri="config://spring/childObjects"/>
            		    </context>
            		</context>
            		<!-- parent context's objects -->
            		<objects xmlns="http://www.springframework.net">
            			<object id="Parent" type="Spring.Objects.TestObject,Spring.Core.Tests">
                            <property name="name" value="Parent"/>
                        </object>
            		</objects>
            		<!-- child context's objects -->
                    <child>
            		    <objects xmlns="http://www.springframework.net">
            			    <object id="Child" type="Spring.Objects.TestObject,Spring.Core.Tests">
                                <property name="name" value="Child"/>
                            </object>
            		    </objects>
                    </child>
                </spring>
            </configuration>
            </code>
            </example>
            <author>Mark Pollack</author>
            <author>Aleksandar Seovic</author>
            <author>Rick Evans</author>
            <seealso cref="T:Spring.Context.Support.ContextRegistry"/>
        </member>
        <member name="M:Spring.Context.Support.ContextHandler.Create(System.Object,System.Object,System.Xml.XmlNode)">
            <summary>
            Creates an <see cref="T:Spring.Context.IApplicationContext"/> instance
            using the context definitions supplied in a custom
            configuration section.
            </summary>
            <remarks>
            <p>
            This <see cref="T:Spring.Context.IApplicationContext"/> instance is
            also used to configure the <see cref="T:Spring.Context.Support.ContextRegistry"/>.
            </p>
            </remarks>
            <param name="parent">
            The configuration settings in a corresponding parent
            configuration section.
            </param>
            <param name="configContext">
            The configuration context when called from the ASP.NET
            configuration system. Otherwise, this parameter is reserved and
            is <see langword="null"/>.
            </param>
            <param name="section">
            The <see cref="T:System.Xml.XmlNode"/> for the section.
            </param>
            <returns>
            An <see cref="T:Spring.Context.IApplicationContext"/> instance
            populated with the object definitions supplied in the configuration
            section.
            </returns>
        </member>
        <member name="M:Spring.Context.Support.ContextHandler.CreateChildContexts(Spring.Context.IApplicationContext,System.Object,System.Collections.Generic.IList{System.Xml.XmlNode})">
            <summary>
            Create all child-contexts in the given <see cref="T:System.Xml.XmlNodeList"/> for the given context.
            </summary>
            <param name="parentContext">The parent context to use</param>
            <param name="configContext">The current configContext <see cref="M:System.Configuration.IConfigurationSectionHandler.Create(System.Object,System.Object,System.Xml.XmlNode)"/></param>
            <param name="childContexts">The list of child context elements</param>
        </member>
        <member name="M:Spring.Context.Support.ContextHandler.InstantiateContext(Spring.Context.IApplicationContext,System.Object,System.String,System.Type,System.Boolean,System.Collections.Generic.IList{System.String})">
            <summary>
            Instantiates a new context.
            </summary>
        </member>
        <member name="M:Spring.Context.Support.ContextHandler.GetContextName(System.Object,System.Xml.XmlElement)">
            <summary>
            Gets the context's name specified in the name attribute of the context element.
            </summary>
            <param name="configContext">The current configContext <see cref="M:System.Configuration.IConfigurationSectionHandler.Create(System.Object,System.Object,System.Xml.XmlNode)"/></param>
            <param name="contextElement">The context element</param>
        </member>
        <member name="M:Spring.Context.Support.ContextHandler.GetContextType(System.Xml.XmlElement,Spring.Context.IApplicationContext)">
            <summary>
            Extracts the context-type from the context element. 
            If none is specified, returns the parent's type.
            </summary>
        </member>
        <member name="M:Spring.Context.Support.ContextHandler.GetCaseSensitivity(System.Xml.XmlElement)">
            <summary>
            Extracts the case-sensitivity attribute from the context element
            </summary>
        </member>
        <member name="M:Spring.Context.Support.ContextHandler.GetConfiguredContextType(System.Xml.XmlElement,System.Type)">
            <summary>
            Gets the context <see cref="T:System.Type"/> specified in the type
            attribute of the context element.
            </summary>
            <remarks>
            <p>
            If this attribute is not defined it defaults to the
            <see cref="T:Spring.Context.Support.XmlApplicationContext"/> type.
            </p>
            </remarks>
            <exception cref="T:Spring.Core.TypeMismatchException">
            If the context type does not implement the
            <see cref="T:Spring.Context.IApplicationContext"/> interface.
            </exception>
        </member>
        <member name="M:Spring.Context.Support.ContextHandler.GetResources(System.Xml.XmlElement)">
            <summary>
            Returns the array of resources containing object definitions for
            this context.
            </summary>
        </member>
        <member name="M:Spring.Context.Support.ContextHandler.GetChildContexts(System.Xml.XmlElement)">
            <summary>
            Returns the array of child contexts for this context.
            </summary>
        </member>
        <member name="P:Spring.Context.Support.ContextHandler.DefaultApplicationContextType">
            <summary>
            The <see cref="T:System.Type"/> of <see cref="T:Spring.Context.IApplicationContext"/>
            created if no <c>type</c> attribute is specified on a <c>context</c> element.
            </summary>
            <seealso cref="M:Spring.Context.Support.ContextHandler.GetContextType(System.Xml.XmlElement,Spring.Context.IApplicationContext)"/>
        </member>
        <member name="P:Spring.Context.Support.ContextHandler.DefaultCaseSensitivity">
            <summary>
            Get the context's case-sensitivity to use if none is specified
            </summary>
            <remarks>
            <p>
            Derived handlers may override this property to change their default case-sensitivity.
            </p>
            <p>
            Defaults to 'true'.
            </p>
            </remarks>
        </member>
        <member name="P:Spring.Context.Support.ContextHandler.AutoRegisterWithContextRegistry">
            <summary>
            Specifies, whether the instantiated context will be automatically registered in the 
            global <see cref="T:Spring.Context.Support.ContextRegistry"/>.
            </summary>
        </member>
        <member name="P:Spring.Context.Support.ContextHandler.IsLazy">
            <summary>
            Returns <see langword="true"/> if the context should be lazily
            initialized.
            </summary>
        </member>
        <member name="T:Spring.Context.Support.ContextHandler.ContextSchema">
            <summary>
            Constants defining the structure and values associated with the
            schema for laying out Spring.NET contexts in XML.
            </summary>
        </member>
        <member name="F:Spring.Context.Support.ContextHandler.ContextSchema.ContextElement">
            <summary>
            Defines a single
            <see cref="T:Spring.Context.IApplicationContext"/>.
            </summary>
        </member>
        <member name="F:Spring.Context.Support.ContextHandler.ContextSchema.NameAttribute">
            <summary>
            Specifies a context name.
            </summary>
        </member>
        <member name="F:Spring.Context.Support.ContextHandler.ContextSchema.CaseSensitiveAttribute">
            <summary>
            Specifies if context should be case sensitive or not. Default is <c>true</c>.
            </summary>
        </member>
        <member name="F:Spring.Context.Support.ContextHandler.ContextSchema.TypeAttribute">
            <summary>
            Specifies a <see cref="T:System.Type"/>.
            </summary>
            <remarks>
            <p>
            Does not have to be fully assembly qualified, but its generally regarded
            as better form if the <see cref="T:System.Type"/> names of one's objects
            are specified explicitly.
            </p>
            </remarks>
        </member>
        <member name="F:Spring.Context.Support.ContextHandler.ContextSchema.LazyAttribute">
            <summary>
            Specifies whether context should be lazy initialized.
            </summary>
        </member>
        <member name="F:Spring.Context.Support.ContextHandler.ContextSchema.ResourceElement">
            <summary>
            Defines an <see cref="T:Spring.Core.IO.IResource"/>
            </summary>
        </member>
        <member name="F:Spring.Context.Support.ContextHandler.ContextSchema.URIAttribute">
            <summary>
            Specifies the URI for an
            <see cref="T:Spring.Core.IO.IResource"/>.
            </summary>
        </member>
        <member name="T:Spring.Context.Support.ContextRegistry">
            <summary> 
            Provides access to a central registry of 
            <see cref="T:Spring.Context.IApplicationContext"/>s.
            </summary>
            <remarks>
            <p>
            A singleton implementation to access one or more application contexts.  Application
            context instances are cached.
            </p>
      