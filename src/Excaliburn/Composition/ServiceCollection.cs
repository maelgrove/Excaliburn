#region

using System.Collections;
using System.Collections.Generic;

#endregion

namespace Excaliburn.Composition
{
    /// <summary>
    ///     Represents a default <see cref="IServiceCollection" />.
    /// </summary>
    public class ServiceCollection : IServiceCollection
    {
        private readonly List<ServiceRegistration> _registrations = new List<ServiceRegistration>();

        /// <inheritdoc />
        public int Count => _registrations.Count;

        /// <inheritdoc />
        bool ICollection<ServiceRegistration>.IsReadOnly { get; } = false;

        /// <inheritdoc />
        public ServiceRegistration this[int index]
        {
            get => _registrations[index];
            set => _registrations[index] = value;
        }

        /// <inheritdoc />
        public IEnumerator<ServiceRegistration> GetEnumerator() => _registrations.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        public void Add(ServiceRegistration item) => _registrations.Add(item);

        /// <inheritdoc />
        public void Clear() => _registrations.Clear();

        /// <inheritdoc />
        public bool Contains(ServiceRegistration item) => _registrations.Contains(item);

        /// <inheritdoc />
        public void CopyTo(ServiceRegistration[] array, int arrayIndex) => _registrations.CopyTo(array, arrayIndex);

        /// <inheritdoc />
        public bool Remove(ServiceRegistration item) => _registrations.Remove(item);

        /// <inheritdoc />
        public int IndexOf(ServiceRegistration item) => _registrations.IndexOf(item);

        /// <inheritdoc />
        public void Insert(int index, ServiceRegistration item) => _registrations.Insert(index, item);

        /// <inheritdoc />
        public void RemoveAt(int index) => _registrations.RemoveAt(index);
    }
}
