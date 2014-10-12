ontext"/>
            class.
            </p>
            </remarks>
            <returns>
            An array of resource locations, or <see langword="null"/> if none.
            </returns>
        </member>
        <member name="P:Spring.Context.Support.AbstractXmlApplicationContext.ConfigurationResources">
            <summary>
            An array of resources that this context is to be built with.
            </summary>
            <remarks>
            <p>
            Examples of the format of the various strings that would be
            returned by accessing this property can be found in the overview
            documentation of with the <see cref="T:Spring.Context.Support.XmlApplicationContext"/>
            class.
            </p>
            </remarks>
            <returns>
            An array of <see cref="T:Spring.Core.IO.IResource"/>s, or <see langword="null"/> if none.
            </returns>
        </member>
        <member name="P:Spring.Context.Support.AbstractXmlApplicationContext.ObjectFactory">
            <summary>
            Subclasses must return their internal object factory here.
            </summary>
            <returns>
            The internal object factory for the application context.
            </returns>
            <seealso cref="P:Spring.Context.Support.AbstractApplicationContext.ObjectFactory"/>
        </member>
        <member name="T:Spring.Context.Support.ApplicationContextAwareProcessor">
            <summary>
            <see cref="T:Spring.Objects.Factory.Config.IObjectPostProcessor"/>
            implementation that passes the application context to object that
            implement the
            <see cref="T:Spring.Context.IApplicationContextAware"/>,
            <see cref="T:Spring.Context.IMessageSourceAware"/>, and
            <see cref="T:Spring.Context.IResourceLoaderAware"/> interfaces. 
            </summary>
            <remarks>
            <p>
            If an object's class implements more than one of the
            <see cref="T:Spring.Context.IApplicationContextAware"/>,
            <see cref="T:Spring.Context.IMessageSourceAware"/>, and
            <see cref="T:Spring.Context.IResourceLoaderAware"/> interfaces, then the
            order in which the interfaces are satisfied is as follows...
            <list type="bullet">
            <item><description>
            <see cref="T:Spring.Context.IResourceLoaderAware"/>
            </description></item>
            <item><description>
            <see cref="T:Spring.Context.IMessageSourceAware"/>
            </description></item>
            <item><description>
            <see cref="T:Spring.Context.IApplicationContextAware"/>
            </description></item>
            </list>
            </p>
            <p>
            Application contexts will automatically register this with their
            underlying object factory. Applications should thus never need to use
            this class directly.
            </p>
            </remarks>
            <author>Juergen Hoeller</author>
            <author>Griffin Caprio (.NET)</author>
        </member>
        <member name="M:Spring.Context.Support.ApplicationContextAwareProcessor.#ctor(Spring.Context.IApplicationContext)">
            <summary>
            Creates a new instance of the
            <see cref="T:Spring.Context.Support.ApplicationContextAwareProcessor"/> class.
            </summary>
            <param name="applicationContext">
            The <see cref="T:Spring.Context.IApplicationContext"/> that this
            instance will work with.
            </param>
        </member>
        <member name="M:Spring.Context.Support.ApplicationContextAwareProcessor.PostProcessAfterInitialization(System.Object,System.String)">
            <summary>
            Apply this <see cref="T:Spring.Objects.Factory.Config.IObjectPostProcessor"/>
            to the given new object instance <i>before</i> any object
            initialization callbacks.
            </summary>
            <param name="obj">
            The new object instance.
            </param>
            <param name="objectName">
            The name of the object.
            </param>
            <returns>
            The the object instance to use, either the original or a wrapped one.
            </returns>
            <exception cref="T:Spring.Objects.ObjectsException">
            In case of errors.
            </exception>
            <seealso cref="M:Spring.Objects.Factory.Config.IObjectPostProcessor.PostProcessAfterInitialization(System.Object,System.String)"/>
        </member>
        <member name="M:Spring.Context.Support.ApplicationContextAwareProcessor.PostProcessBeforeInitialization(System.Object,System.String)">
            <summary>
            Apply this <see cref="T:Spring.Objects.Factory.Config.IObjectPostProcessor"/> to the
            given new object instance <i>after</i> any object initialization
            callbacks.
            </summary>
            <param name="obj">
            The new object instance.
            </param>
            <param name="name">
            The name of the object.
            </param>
            <returns>
            The object instance to use, either the original or a wrapped one.
            </returns>
            <exception cref="T:Spring.Objects.ObjectsException">
            In case of errors.
            </exception>
            <seealso cref="M:Spring.Objects.Factory.Config.IObjectPostProcessor.PostProcessBeforeInitialization(System.Object,System.String)"/>
        </member>
        <member name="T:Spring.Context.Support.ApplicationObjectSupport">
            <summary>
            Convenient superclass for application objects that want to be aware of
            the application context, e.g. for custom lookup of collaborating object
            or for context-specific resource access. 
            </summary>
            <remarks>
            <p>
            It saves the application context reference and provides an
            initialization callback method. Furthermore, it offers numerous
            convenience methods for message lookup.
            </p>
            <p>
            There is no requirement to subclass this class: it just makes things
            a little easier if you need access to the context, e.g. for access to
            file resources or to the message source. Note that many application
            objects do not need to be aware of the application context at all,
            as they can receive collaborating objects via object references.
            </p>
            </remarks>
            <author>Rod Johnson</author>
            <author>Juergen Hoeller</author>
            <author>Griffin Caprio (.NET)</author>
        </member>
        <member name="T:Spring.Context.IApplicationContextAware">
            <summary>
            To be implemented by any object that wishes to be notified
            of the <see cref="T:Spring.Context.IApplicationContext"/> that it runs in.
            </summary>
            <remarks>
            <p>
            Implementing this interface makes sense when an object requires access
            to a set of collaborating objects. Note that configuration via object
            references is preferable to implementing this interface just for object
            lookup purposes.
            </p>
            <p>
            This interface can also be implemented if an object needs access to
            file resources, i.e. wants to call
            <see cref="M:Spring.Core.IO.IResourceLoader.GetResource(System.String)"/>, or access to
            the <see cref="T:Spring.Context.IMessageSource"/>. However, it is
            preferable to implement the more specific
            <see cref="T:Spring.Context.IResourceLoaderAware"/>
            interface to receive a reference to the
            <see cref="T:Spring.Context.IMessageSource"/> object in that scenario.
            </p>
            <p>
            Note that <see cref="T:Spring.Core.IO.IResource"/> dependencies can also
            be exposed as object properties of the
            <see cref="T:Spring.Core.IO.IResource"/> type, populated via strings with
            automatic type conversion performed by an object factory. This obviates
            the need for implementing any callback interface just for the purpose
            of accessing a specific file resource.
            </p>
            <p>
            <see cref="T:Spring.Context.Support.ApplicationObjectSupport"/>
            is a convenience implementation of this interface for your
            application objects.
            </p>
            <p>
            For a list of all object lifecycle methods, see the overview for the 
            <see cref="T:Spring.Objects.Factory.IObjectFactory"/> interface.
            </p>
            </remarks>
            <author>Rod Johnson</author>
            <author>Mark Pollack (.NET)</author>
            <see cref="T:Spring.Objects.Factory.IObjectFactoryAware"/>
            <see cref="T:Spring.Objects.Factory.IInitializingObject"/>
            <see cref="T:Spring.Objects.Factory.IObjectFactory"/>
        </member>
        <member name="P:Spring.Context.IApplicationContextAware.ApplicationContext">
            <summary>
            Sets the <see cref="T:Spring.Context.IApplicationContext"/> that this
            object runs in.
            </summary>
            <remarks>
            <p>
            Normally this call will be used to initialize the object.
            </p>
            <p>
            Invoked after population of normal object properties but before an
            init callback such as
            <see cref="T:Spring.Objects.Factory.IInitializingObject"/>'s
            <see cref="M:Spring.Objects.Factory.IInitializingObject.AfterPropertiesSet"/>
            or a custom init-method. Invoked after the setting of any
            <see cref="T:Spring.Context.IResourceLoaderAware"/>'s
            <see cref="P:Spring.Context.IResourceLoaderAware.ResourceLoader"/>
            property.
            </p>
            </remarks>
            <exception cref="T:Spring.Context.ApplicationContextException">
            In the case of application context initialization errors.
            </exception>
            <exception cref="T:Spring.Objects.ObjectsException">
            If thrown by any application context methods.
            </exception>
            <exception cref="T:Spring.Objects.Factory.ObjectInitializationException"/>
        </member>
        <member name="M:Spring.Context.Support.ApplicationObjectSupport.#ctor">
            <summary>
            Creates a new instance of the
            <see cref="T:Spring.Context.Support.ApplicationObjectSupport"/> class.
            </summary>
            <remarks>
            <p>
            This is an <see langword="abstract"/> class, and as such exposes no
            public constructors.
            </p>
            </remarks>
        </member>
        <member name="M:Spring.Context.Support.ApplicationObjectSupport.#ctor(Spring.Context.IApplicationContext)">
            <summary>
            Creates a new instance of the
            <see cref="T:Spring.Context.Support.ApplicationObjectSupport"/> class.
            </summary>
            <remarks>
            <p>
            This is an <see langword="abstract"/> class, and as such exposes no
            public constructors.
            </p>
            </remarks>
            <param name="applicationContext">
            The <see cref="T:Spring.Context.IApplicationContext"/> that this
            object runs in.
            </param>
        </member>
        <member name="M:Spring.Context.Support.ApplicationObjectSupport.InitApplicationContext">
            <summary>
            Intializes the wrapped
            <see cref="T:Spring.Context.IApplicationContext"/>.
            </summary>
            <remarks>
            <p>
            This is a template method that subclasses can override for custom
            initialization behavior.
            </p>
            <p>
            Gets called by the
            <see cref="P:Spring.Context.Support.ApplicationObjectSupport.ApplicationContext"/>
            instance directly after setting the context instance.
            </p>
            <note type="caution">
            Does not get called on reinitialization of the context.
            </note>
            </remarks>
            <exception cref="T:Spring.Context.ApplicationContextException">
            In the case of any initialization errors.
            </exception>
            <exception cref="T:Spring.Objects.Objec