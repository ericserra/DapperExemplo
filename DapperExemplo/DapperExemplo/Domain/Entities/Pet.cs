using System;
using Dapper.Contrib.Extensions;
using DapperExemplo.Domain.Fixed;

namespace DapperExemplo.Domain.Entities
{
    [Table(tableName:"[dbo].[Pet]")]
    public class Pet
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TypePet Type { get; set; }
    }
}
