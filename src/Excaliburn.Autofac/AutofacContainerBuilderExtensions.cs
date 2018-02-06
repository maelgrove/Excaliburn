#region

using Autofac;
using Autofac.Builder;
using Excaliburn.ComponentModel.Composition;

#endregion

namespace Excaliburn.Autofac
{
    internal static class AutofacContainerBuilderExtensions
    {
        public static void Populate(this ContainerBuilder builder, IServiceCollection services)
        {
            builder.RegisterType<AutofacCompositionContainer>().As<IServiceContainer>();
            foreach (var registration in services)
                switch (registration)
                {
                    case TypedServiceRegistration typedRegistration:
                        builder
                            .RegisterType(typedRegistration.ImplementationType)
                            .As(typedRegistration.ServiceType)
                            .ConfigureRegistration(typedRegistration);
                        break;
                    case FactoryComponentRegistration factoryRegistration:
                        var registrationBuilder = RegistrationBuilder.ForDelegate(factoryRegistration.ServiceType,
                                (context, parameters) =>
                                {
                                    var serviceContainer = context.Resolve<IServiceContainer>();
                                    return factoryRegistration.ImplementationFactory(serviceContainer);
                                })
                            .ConfigureRegistration(factoryRegistration)
                            .CreateRegistration();
                        builder.RegisterComponent(registrationBuilder);
                        break;
                    case InstanceServiceRegistration instanceRegistration:
                        builder
                            .RegisterInstance(instanceRegistration.ImplementationInstance)
                            .As(instanceRegistration.ServiceType)
                            .ConfigureRegistration(instanceRegistration);
                        break;
                }
        }

        private static IRegistrationBuilder<object, TActivatorData, TRegistrationStyle> ConfigureRegistration<
            TActivatorData, TRegistrationStyle>(
            this IRegistrationBuilder<object, TActivatorData, TRegistrationStyle> registrationBuilder,
            ServiceRegistration registration)
        {
            switch (registration.Lifetime)
            {
                case ServiceLifetime.Shared:
                    registrationBuilder.SingleInstance();
                    break;
                case ServiceLifetime.Scoped:
                    registrationBuilder.InstancePerLifetimeScope();
                    break;
                case ServiceLifetime.Transient:
                    registrationBuilder.InstancePerDependency();
                    break;
            }

            if (!string.IsNullOrEmpty(registration.Key))
                registrationBuilder.Keyed(registration.Key, registration.ServiceType);

            return registrationBuilder;
        }
    }
}
