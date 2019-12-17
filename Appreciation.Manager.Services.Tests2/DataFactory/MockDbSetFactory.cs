using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Appreciation.Manager.Services.Tests2.DataFactory
{
    // Provides a way to create mock DbSets
    public static class MockDbSetFactory
    {
        // Creates a mock DbSet from the specified data.
        public static void SetSource<T>(this Mock<DbSet<T>> mock, IList<T> data) where T : class
        {
            var queryable = data.AsQueryable();
            mock.As<IDbAsyncEnumerable<T>>()
               .Setup(m => m.GetAsyncEnumerator())
               .Returns(new TestDbAsyncEnumerator<T>(data.GetEnumerator()));
            mock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
        }
    }
}
