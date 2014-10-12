ssary values needed to resolve
            messages from an <see cref="T:Spring.Context.IMessageSource"/>.
            </p>
            </remarks>
            <author>Juergen Hoeller</author>
            <author>Griffin Caprio (.NET)</author>
            <seealso cref="M:Spring.Context.IMessageSource.GetMessage(Spring.Context.IMessageSourceResolvable,System.Globalization.CultureInfo)"/>
        </member>
        <member name="T:Spring.Context.IMessageSourceResolvable">
            <summary>
            Describes objects that are suitable for message resolution in a
            <see cref="T:Spring.Context.IMessageSource"/>.
            </summary>
            <remarks>
            <p>
            Spring.NET's own validation error classes implement this interface.
            </p>
            </remarks>
            <author>Juergen Hoeller</author>
            <author>Mark Pollack (.NET)</author>
            <seealso cref="M:Spring.Context.IMessageSource.GetMessage(Spring.Context.IMessageSourceResolvable,System.Globalization.CultureInfo)"/>
            <seealso cref="T:Spring.Context.Support.DefaultMessageSourceResolvable"/>
        </member>
        <member name="M:Spring.Context.IMessageSourceResolvable.GetCodes">
            <summary>
            Return the codes to be used to resolve this message, in the order
            that they are to be tried.
            </summary>
            <remarks>
            <p>
            The last code will therefore be the default one.
            </p>
            </remarks>
            <returns>
            A <see cref="T:System.String"/> array of codes which are associated
            with this message.
            </returns>
        </member>
        <member name="M:Spring.Context.IMessageSourceResolvable.GetArguments">
            <summary>
            Return the array of arguments to be used to resolve this message.
            </summary>
            <returns>
            An array of objects to be used as parameters to replace
            placeholders within the message text.
            </returns>
        </member>
        <member name="P:Spring.Context.IMessageSourceResolvable.DefaultMessage">
            <summary>
            Return the default message to be used to resolve this message.
            </summary>
            <returns>
            The default message, or <see langword="null"/> if there is no
            default.
            </returns>
        </member>
        <member name="M:Spring.Context.Support.DefaultMessageSourceResolvable.#ctor(System.String)">
            <summary>
            Creates a new instance of the
            <see cref="T:Spring.Context.Support.DefaultMessageSourceResolvable"/> class
            using a single code.
            </summary>
            <param name="code">The message code to be resolved.</param>
        </member>
        <member name="M:Spring.Context.Support.DefaultMessageSourceResolvable.#ctor(System.String[])">
            <summary>
            Initializes a new instance of the <see cref="T:Spring.Context.Support.DefaultMessageSourceResolvable"/> class.
            </summary>
            <param name="codes">The codes to be used to resolve this message</param>
        </member>
        <member name="M:Spring.Context.Support.DefaultMessageSourceResolvable.#ctor(System.String[],System.Object[])">
            <summary>
            Creates a new instance of the
            <see cref="T:Spring.Context.Support.DefaultMessageSourceResolvable"/> class
            using multiple codes.
            </summary>
            <param name="codes">The message codes to be resolved.</param>
            <param name="arguments">
            The arguments used to resolve the supplied <paramref name="codes"/>.
            </param>
        </member>
        <member name="M:Spring.Context.Support.DefaultMessageSourceResolvable.#ctor(System.Collections.Generic.IList{System.String},System.Object[],System.String)">
            <summary>
            Creates a new instance of the
            <see cref="T:Spring.Context.Support.DefaultMessageSourceResolvable"/> class
            using multiple codes and a default message.
            </summary>
            <param name="codes">The message codes to be resolved.</param>
            <param name="arguments">
            The arguments used to resolve the supplied <paramref name="codes"/>.
            </param>
            <param name="defaultMessage">
            The default message used if no code could be resolved.
            </param>
        </member>
        <member name="M:Spring.Context.Support.DefaultMessageSourceResolvable.#ctor(Spring.Context.IMessageSourceResolvable)">
            <summary>
            Creates a new instance of the
            <see cref="T:Spring.Context.Support.DefaultMessageSourceResolvable"/> class
            from another resolvable.
            </summary>
            <remarks>
            <p>
            This is the <i>copy constructor</i> for the
            <see cref="T:Spring.Context.Support.DefaultMessageSourceResolvable"/> class.
            </p>
            </remarks>
            <param name="resolvable">
            The <see cref="T:Spring.Context.IMessageSourceResolvable"/> to be copied.
            </param>
            <exception cref="T:System.NullReferenceException">
            If the supplied <paramref name="resolvable"/> is <see langword="null"/>.
            </exception>
        </member>
        <member name="M:Spring.Context.Support.DefaultMessageSourceResolvable.ToString">
            <summary>
            Returns a <see cref="T:System.String"/> representation of this
            <see cref="T:Spring.Context.IMessageSourceResolvable"/>.
            </summary>
            <returns>
            A <see cref="T:System.String"/> representation of this
            <see cref="T:Spring.Context.IMessageSourceResolvable"/>.
            </returns>
        </member>
        <member name="M:Spring.Context.Support.DefaultMessageSourceResolvable.Accept(Spring.Context.Support.MessageSourceResolvableVisitor)">
            <summary>
            Calls the visit method on the supplied <paramref name="visitor"/>
            to output a <see cref="T:System.String"/> version of this class.
            </summary>
            <param name="visitor">The visitor to use.</param>
            <returns>
            A <see cref="T:System.String"/> representation of this
            <see cref="T:Spring.Context.IMessageSourceResolvable"/>.
            </returns>
        </member>
        <member name="M:Spring.Context.Support.DefaultMessageSourceResolvable.GetCodes">
            <summary>
            Return the codes to be used to resolve this message, in the order
            that they are to be tried.
            </summary>
            <returns>
            A <see cref="T:System.String"/> array of codes which are associated
            with this message.
            </returns>
            <seealso cref="M:Spring.Context.IMessageSourceResolvable.GetCodes"/>
        </member>
        <member name="M:Spring.Context.Support.DefaultMessageSourceResolvable.GetArguments">
            <summary>
            Return the array of arguments to be used to resolve this message.
            </summary>
            <returns>
            An array of objects to be used as parameters to replace
            placeholders within the message text.
            </returns>
            <seealso cref="M:Spring.Context.IMessageSourceResolvable.GetArguments"/>
        </member>
        <member name="P:Spring.Context.Support.DefaultMessageSourceResolvable.LastCode">
            <summary>
            Return the default code for this resolvable.
            </summary>
            <returns>
            The default code of this resolvable; this will be the last code in
            the codes array, or <see langword="null"/> if this instance has no
            codes.
            </returns>
            <seealso cref="M:Spring.Context.Support.DefaultMessageSourceResolvable.GetCodes"/>
        </member>
        <member name="P:Spring.Context.Support.DefaultMessageSourceResolvable.DefaultMessage">
            <summary>
            Return the default message to be used to resolve this message.
            </summary>
            <returns>
            The default message, or <see langword="null"/> if there is no
            default.
            </returns>
            <seealso cref="P:Spring.Context.IMessageSourceResolvable.DefaultMessage"/>
        </member>
        <member name="T:Spring.Context.Support.DefaultSectionHandler">
            <summary>
            Default section handler that can handle any configuration section.
            </summary>
            <remarks>
            <p>
            Simply returns the configuration section as an <see cref="T:System.Xml.XmlElement"/>.
            </p>
            </remarks>
            <author>Aleksandar Seo