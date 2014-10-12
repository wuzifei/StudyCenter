        <returns>
            The resolved message if the lookup was successful (see above for
            the return value in the case of an unsuccessful lookup).
            </returns>
            <exception cref="T:Spring.Context.NoSuchMessageException">
            If the message could not be resolved.
            </exception>
            <seealso cref="M:Spring.Context.IMessageSource.GetMessage(System.String)"/>
        </member>
        <member name="M:Spring.Context.Support.DelegatingMessageSource.GetMessage(System.String,System.Object[])">
            <summary>
            Resolve the message identified by the supplied
            <paramref name="name"/>.
            </summary>
            <param name="name">The name of the message to resolve.</param>
            <param name="arguments">
            The array of arguments that will be filled in for parameters within
            the message, or <see langword="null"/> if there are no parameters
            within the message. Parameters within a message should be
            referenced using the same syntax as the format string for the
            <see cref="M:System.String.Format(System.String,System.Object[])"/> method.
            </param>
            <returns>
            The resolved message if the lookup was successful (see above for
            the return value in the case of an unsuccessful lookup).
            </returns>
            <exception cref="T:Spring.Context.NoSuchMessageException">
            If the message could not be resolved.
            </exception>
            <seealso cref="M:Spring.Context.IMessageSource.GetMessage(System.String,System.Object[])"/>
        </member>
        <member name="M:Spring.Context.Support.DelegatingMessageSource.GetMessage(System.String,System.Globalization.CultureInfo)">
            <summary>
            Resolve the message identified by the supplied
            <paramref name="name"/>.
            </summary>
            <param name="name">The name of the message to resolve.</param>
            <param name="culture">
            The <see cref="T:System.Globalization.CultureInfo"/> that represents
            the culture for which the resource is localized.
            </param>
            <returns>
            The resolved message if the lookup was successful (see above for
            the return value in the case of an unsuccessful lookup).
            </returns>
            <exception cref="T:Spring.Context.NoSuchMessageException">
            If the message could not be resolved.
            </exception>
            <seealso cref="M:Spring.Context.IMessageSource.GetMessage(System.String,System.Globalization.CultureInfo)"/>
        </member>
        <member name="M:Spring.Context.Support.DelegatingMessageSource.GetMessage(System.String,System.Globalization.CultureInfo,System.Object[])">
            <summary>
            Resolve the message identified by the supplied
            <paramref name="name"/>.
            </summary>
            <param name="name">The name of the message to resolve.</param>
            <param name="culture">
            The <see cref="T:System.Globalization.CultureInfo"/> that represents
            the culture for which the resource is localized.
            </param>
            <param name="arguments">
            The array of arguments that will be filled in for parameters within
            the message, or <see langword="null"/> if there are no parameters
            within the message. Parameters within a message should be
            referenced using the same syntax as the format string for the
            <see cref="M:System.String.Format(System.String,System.Object[])"/> method.
            </param>
            <returns>
            The resolved message if the lookup was successful (see above for
            the return value in the case of an unsuccessful lookup).
            </returns>
            <exception cref="T:Spring.Context.NoSuchMessageException">
            If the message could not be resolved.
            </exception>
            <seealso cref="M:Spring.Context.IMessageSource.GetMessage(System.String,System.Globalization.CultureInfo,System.Object[])"/>
        </member>
        <member name="M:Spring.Context.Support.Delegating