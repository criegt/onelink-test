using System;

namespace OneLinkTest.Domain.Employees
{
    public readonly struct EmployeeId : IEquatable<EmployeeId>
    {
        public Guid Id { get; }

        public EmployeeId(Guid id) => Id = id;

        public override bool Equals(object? obj) => obj is EmployeeId o && Equals(o);

        public bool Equals(EmployeeId other) => Id == other.Id;

        public override int GetHashCode() => HashCode.Combine(Id);

        public static bool operator ==(EmployeeId left, EmployeeId right) => left.Equals(right);

        public static bool operator !=(EmployeeId left, EmployeeId right) => !(left == right);

        public override string ToString() => Id.ToString();
    }
}
