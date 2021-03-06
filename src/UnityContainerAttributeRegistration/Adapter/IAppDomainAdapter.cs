﻿using System.Collections.Generic;
using System.Reflection;


namespace UnityContainerAttributeRegistration.Adapter
{
    /// <summary>
    ///     Wrapper to provide <see cref="IList{T}" /> instead of using <see cref="System.AppDomain" />.
    /// </summary>
    public interface IAppDomainAdapter
    {
        /// <summary>
        ///     Provide <see cref="Assembly" />s of an AppDomain.
        /// </summary>
        /// <returns><see cref="Assembly" />s which are used to populate.</returns>
        public IList<Assembly> GetAssemblies();
    }
}
