#region

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using Caliburn.Micro;
using Excaliburn.ComponentModel.Composition;

#endregion

namespace Excaliburn
{
    /// <summary>
    ///     Represents the bootstrapper and main composition root of the application.
    /// </summary>
    public abstract class Bootstrapper : BootstrapperBase
    {
        /// <summary>
        ///     Returns the <see cref="IServiceContainer" /> of the application.
        /// </summary>
        protected IServiceContainer Container { get; private set; }

        /// <summary>
        ///     Creates a new <see cref="Bootstrapper" />.
        /// </summary>
        protected Bootstrapper()
        {
            PreInitialize();
            Initialize();
        }

        /// <inheritdoc />
        protected sealed override void Configure()
        {
            OnConfigureBootstrapper();
            var components = new ServiceCollection();
            RegisterBuiltInComponents(components);
            OnConfigureServices(components);
            Container = ConfigureServices(components);
        }

        /// <summary>
        ///     Invoked on pre-initialization of the framework.
        /// </summary>
        protected virtual void OnPreInitialize()
        {
        }

        /// <summary>
        ///     Invoked on configuring the bootstrapper.
        /// </summary>
        protected virtual void OnConfigureBootstrapper()
        {
        }

        /// <summary>
        ///     Invoked when configuring services.
        /// </summary>
        /// <param name="components">The <see cref="IServiceCollection" />.</param>
        protected virtual void OnConfigureServices(IServiceCollection components)
        {
        }

        /// <summary>
        ///     Invoked on starting the runtime mode.
        /// </summary>
        protected virtual void OnStartRuntime()
        {
        }

        /// <summary>
        ///     Invoked on starting the design time mode.
        /// </summary>
        protected virtual void OnStartDesignTime()
        {
        }

        /// <summary>
        ///     Invoked when terminating the application.
        /// </summary>
        protected virtual void OnShutdown()
        {
        }

        /// <summary>
        ///     Invoked when starting the application.
        /// </summary>
        /// <param name="args">The startup arguments.</param>
        protected virtual void OnStartup(string[] args)
        {
        }

        /// <summary>
        ///     Invoked when an unhandled exception occurs.
        /// </summary>
        /// <param name="exception">The exception object.</param>
        /// <param name="isHandled">Whether the exception is being handled.</param>
        protected virtual void OnUnhandledException(Exception exception, out bool isHandled)
        {
            isHandled = false;
        }

        /// <summary>
        ///     Creates a <see cref="IServiceContainer" /> using the specified <see cref="IServiceCollection" />.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection" />.</param>
        /// <returns>The <see cref="IServiceContainer" />.</returns>
        protected abstract IServiceContainer ConfigureServices(IServiceCollection services);

        /// <inheritdoc />
        protected sealed override void StartDesignTime()
        {
            base.StartDesignTime();
            OnStartDesignTime();
        }

        /// <inheritdoc />
        protected sealed override void StartRuntime()
        {
            base.StartRuntime();
            OnStartRuntime();
        }

        /// <inheritdoc />
        protected sealed override object GetInstance(Type service, string key) => Container.GetService(service, key);

        /// <inheritdoc />
        protected sealed override IEnumerable<object> GetAllInstances(Type service) => Container.GetServices(service);

        /// <inheritdoc />
        protected sealed override void BuildUp(object instance) => Container.BuildUp(instance);

        /// <inheritdoc />
        protected sealed override void OnExit(object sender, EventArgs args)
        {
            try
            {
                OnShutdown();
                (Container as IDisposable)?.Dispose();
            }
            catch
            {
                // ignore
                // TODO proper exception handling
            }
        }

        /// <inheritdoc />
        protected sealed override void PrepareApplication() => base.PrepareApplication();

        /// <inheritdoc />
        protected sealed override void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs args)
        {
            OnUnhandledException(args.Exception, out var isHandled);
            args.Handled = isHandled;
        }

        /// <inheritdoc />
        protected sealed override void OnStartup(object sender, StartupEventArgs args)
        {
            OnStartup(args?.Args ?? new string[0]);
            // TODO display root view -> mainwindow
            // DisplayRootViewFor<>();
        }

        private void PreInitialize()
        {
            // TODO internal stuff like language etc.

            OnPreInitialize();
        }

        private void RegisterBuiltInComponents(IServiceCollection components)
        {
            components.AddScoped<IWindowManager, WindowManager>();
            components.AddScoped<IEventAggregator, EventAggregator>();

            // TODO register
            //  - logging
            //  - command services
            //  - default vms
            //  - default commands, menus, themes
            // TODO configuration??
        }
    }
}
