me="name"/>.
            </summary>
            <param name="name">
            The name of the resource object to resolve.
            </param>
            <param name="culture">
            The <see cref="T:System.Globalization.CultureInfo"/> with which the
            resource is associated.
            </param>
            <returns>
            The resolved object, or <see langword="null"/> if not found.
            </returns>
            <seealso cref="M:Spring.Context.IMessageSource.GetResourceObject(System.String,System.Globalization.CultureInfo)"/>
        </member>
        <member name="M:Spring.Context.Support.DelegatingMessageSource.ApplyResources(System.Object,System.String,System.Globalization.CultureInfo)">
            <summary>
            Applies resources to object properties.
            </summary>
            <param name="value">
            An object that contains the property values to be applied.
            </param>
            <param name="objectName">
            The base name of the object to use for key lookup.
            </param>
            <param name="culture">
            The <see cref="T:System.Globalization.CultureInfo"/> with which the
            resource is associated.
            </param>
            <seealso cref="M:Spring.Context.IMessageSource.ApplyResources(System.Object,System.String,System.Globalization.CultureInfo)"/>
        </member>
        <member name="P:Spring.Context.Support.DelegatingMessageSource.ParentMessageSource">
            <summary>
            The parent message source used to try and resolve messages that
            this object can't resolve.
            </summary>
            <seealso cref="P:Spring.Context.IHierarchicalMessageSource.ParentMessageSource"/>
        </member>
        <member name="T:Spring.Context.Support.GenericApplicationContext">
            <summary>
            Generic ApplicationContext implementation that holds a single internal
            <see cref="P:Spring.Context.Support.GenericApplicationContext.DefaultListableObjectFactory"/>  instance and does not 
            assume a specific object definition format.
            </summary>
            <remarks>
            Implements the <see cref="T:Spring.Objects.Factory.Support.IObjectDefinitionRegistry"/> interface in order
            to allow for aplying any object definition readers to it.
            <para>Typical usage is to register a variety of object definitions via the
            <see cref="T:Spring.Objects.Factory.Support.IObjectDefinitionRegistry"/> interface and then call 
            <see cref="M:Spring.Context.IConfigurableApplicationContext.Refresh"/> to initialize those
            objects with application context semantics (handling 
            <see cref="T:Spring.Context.IApplicationContextAware"/>, auto-detecting 
            <see cref="T:Spring.Objects.Factory.Config.IObjectPostProcessor"/> ObjectFactoryPostProcessors, etc).
            </para>
            <para>In contrast to other IApplicationContext implementations that create a new internal
            IObjectFactory instance for each refresh, the internal IObjectFactory of this context
            is available right from the start, to be able to register object definitions on it.
            <see cref="M:Spring.Context.IConfigurableApplicationContext.Refresh"/> may only be called once</para>
            <para>Usage examples</para>
            <example>
            GenericApplicationContext ctx = new GenericApplicationContext();
            // register your objects and object definitions
            ctx.RegisterObjectDefinition(...)
            ctx.Refresh();
            </example>
            </remarks>
            <author>Mark Pollack</author>
        </member>
        <member name="M:Spring.Context.Support.GenericApplicationContext.#ctor">
            <summary>
            Initializes a new instance of the <see cref="T:Spring.Context.Support.GenericApplicationContext"/> class.
            </summary>
        </member>
        <member name="M:Spring.Context.Support.GenericApplicationContext.#ctor(System.Boolean)">
            <summary>
            Initializes a new instance of the <see cref="T:Spring.Context.Support.GenericApplicationContext"/> class.
            </summary>
            <param name="caseSensitive">if set to <c>true</c> names in the context are case sensitive.</param>
        </member>
        <member name="M:Spring.Context.Support.GenericApplicationContext.#ctor(Spring.Objects.Factory.Support.DefaultListableObjectFactory)">
            <summary>
            Initializes a new instance of the <see cref="T:Spring.Context.Support.GenericApplicationContext"/> class.
            </summary>
            <param name="objectFactory">The object factory instance to use for this context.</param>
        </member>
        <member name="M:Spring.Context.Support.GenericApplicationContext.#ctor(Spring.Context.IApplicationContext)">
            <summary>
            Initializes a new instance of the <see cref="T:Spring.Context.Support.GenericApplicationContext"/> class.
            </summary>
            <param name="parent">The parent application context.</param>
        </member>
        <member name="M:Spring.Context.Support.GenericApplicationContext.#ctor(System.String,System.Boolean,Spring.Context.IApplicationContext)">
            <summary>
            Initializes a new instance of the <see cref="T:Spring.Context.Support.GenericApplicationContext"/> class.
            </summary>
            <param name="name">The name of the application context.</param>
            <param name="caseSensitive">if set to <c>true</c> names in the context are case sensitive.</param>
            <param name="parent">The parent application context.</param>
        </member>
        <member name="M:Spring.Context.Support.GenericApplicationContext.#ctor(Spring.Objects.Factory.Support.DefaultListableObjectFactory,Spring.Context.IApplicationContext)">
            <summary>
            Initializes a new instance of the <see cref="T:Spring.Context.Support.GenericApplicationContext"/> class.
            </summary>
            <param name="objectFactory">The object factory to use for this context</param>
            <param name="parent">The parent applicaiton context.</param>
        </member>
        <member name="M:Spring.Context.Support.GenericApplicationContext.#ctor(System.String,System.Boolean,Spring.Context.IApplicationContext,Spring.Objects.Factory.Support.DefaultListableObjectFactory)">
            <summary>
            Initializes a new instance of the <see cref="T:Spring.Context.Support.GenericApplicationContext"/> class.
            </summary>
            <param name="name">The name of the application context.</param>
            <param name="caseSensitive">if set to <c>true</c> names in the context are case sensitive.</param>
            <param name="parent">The parent application context.</param>
            <param name="objectFactory">The object factory to use for this context</param>
        </member>
        <member name="M:Spring.Context.Support.GenericApplicationContext.RefreshObjectFactory">
            <summary>
            Do nothing operation.  We hold a single internal ObjectFactory and rely on callers
            to register objects throug our public methods (or the ObjectFactory's).
            </summary>
            <exception cref="T:Spring.Objects.ObjectsException">
            In the case of errors encountered while refreshing the object factory.
            </exception>
        </member>
        <member name="M:Spring.Context.Support.GenericApplicationContext.IsObjectNameInUse(System.String)">
            <summary>
            Determines whether the given object name is already in use within this factory,
            i.e. whether there is a local object or alias registered under this name or
            an inner object created with this name.
            </summary>
        </member>
        <member name="P:Spring.Context.Support.GenericApplicationContext.ObjectFactory">
            <summary>
            Return the internal object factory of this application context.
            </summary>
            <value></value>
        </member>
        <member name="P:Spring.Context.Support.GenericApplicationContext.DefaultListableObjectFactory">
            <summary>
            Gets the underlying object factory of this context, available for 
            registering object definitions.
            </summary>
            <remarks>You need to call <code>Refresh</code> to initialize the
            objects factory and its contained objects with application context
            semantics (autodecting IObjectFactoryPostProcessors, etc).</remarks>
            <value>The internal object factory (as DefaultListableObjectFactory).</value>
        </member>
        <member name="T:Spring.Context.Support.MessageSourceAccessor">
            <summary>
            Helper class for easy access to messages from an
            <see cref="T:Spring.Context.IMessageSource"/>, providing various
            overloaded <c>GetMessage</c> methods.
            </summary>
            <remarks>
            <p>
            Available from
            <see cref="T:Spring.Context.Support.ApplicationObjectSupport"/>, but also
            reusable as a standalone helper to delegate to in application objects.
            </p>
            </remarks>
            <author>Juergen Hoeller</author>
            <author>Griffin Caprio (.NET)</author>
            <seealso cref="T:Spring.Context.IMessageSource"/>
            <seealso cref="T:Spring.Context.Support.ApplicationObjectSupport"/>
        </member>
        <member name="M:Spring.Context.Support.MessageSourceAccessor.#ctor(Spring.Context.IMessageSource)">
            <summary>
            Creates a new instance of the
            <see cref="T:Spring.Context.Support.MessageSourceAccessor"/> class
            that uses the current <see cref="P:System.Globalization.CultureInfo.CurrentUICulture"/>
            for all locale specific lookups.
            </summary>
            <param name="messageSource">
            The <see cref="T:Spring.Context.IMessageSource"/> to use to locate messages.
            </param>
        </member>
        <member name="M:Spring.Context.Support.MessageSourceAccessor.#ctor(Spring.Context.IMessageSource,System.Globalization.CultureInfo)">
            <summary>
            Creates a new instance of the
            <see cref="T:Spring.Context.Support.Mes