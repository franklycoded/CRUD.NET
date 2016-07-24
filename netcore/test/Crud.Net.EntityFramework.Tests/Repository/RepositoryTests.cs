using System;
using Crud.Net.Core.DataModel;
using Crud.Net.EntityFramework.Repository;
using NUnit.Framework;

namespace Crud.Net.EntityFramework.Tests.Repository
{
    [TestFixture]
    public class RepositoryTests
    {
        [Test]
        public void Test_ContextNull_ArgumentNullException(){
            Assert.Throws<ArgumentNullException>(() => {
                var repo = new CrudRepository<IEntity>(null);
            });
        }
    }
}
