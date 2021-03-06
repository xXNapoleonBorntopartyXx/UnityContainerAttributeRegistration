﻿using JetBrains.Annotations;

using Unity;

using UnityContainerAttributeRegistration.Adapter;
using UnityContainerAttributeRegistration.Populator;


namespace UnityContainerAttributeRegistration
{
    /// <summary>
    ///     Creates a populated or populates an <see cref="Unity.IUnityContainer" />, depending on the provided assemblies
    /// </summary>
    public sealed class UnityContainerPopulator
    {
        private readonly IAppDomainAdapter appDomain;
        private readonly IPopulator        TypePopulator;

        /// <summary>
        ///     Use <see cref="System.AppDomain.CurrentDomain" /> to populate an <see cref="Unity.IUnityContainer" />
        /// </summary>
        public UnityContainerPopulator() : this(new AppDomainAdapter())
        {
        }

        /// <summary>
        ///     Use <paramref name="appDomain" /> to populate an <see cref="Unity.IUnityContainer" />
        /// </summary>
        /// <param name="appDomain">Custom <see cref="UnityContainerAttributeRegistration.Adapter.IAppDomainAdapter" /></param>
        public UnityContainerPopulator([NotNull] IAppDomainAdapter appDomain)
        {
            this.appDomain = appDomain;

            TypePopulator = new TypePopulator(appDomain);
        }

        /// <summary>
        ///     Create and populate a new <see cref="Unity.UnityContainer" />
        /// </summary>
        /// <returns>New <see cref="Unity.UnityContainer" /> with registered types</returns>
        public IUnityContainer Populate()
        {
            return Populate(new UnityContainer());
        }

        /// <summary>
        ///     Populate <paramref name="container" />
        /// </summary>
        /// <param name="container"><see cref="Unity.IUnityContainer" /> to register types</param>
        /// <returns>
        ///     <paramref name="container" />
        /// </returns>
        public IUnityContainer Populate([NotNull] IUnityContainer container)
        {
            TypePopulator.Populate(container);

            return container;
        }
    }
}
