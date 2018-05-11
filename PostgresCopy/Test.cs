using LinqToDB;
using LinqToDB.Mapping;

namespace PostgresCopy
{
    [Table(Schema = "public", Name = "test")]
    public class Test
    {
        /* Важно указать DbType для некоторых типов, например, для string. */
        
        [Column("id", DbType = "bigint"), PrimaryKey]
        public long Id { get; set; }

        [Column("code", DbType = "character varying"), Nullable]
        public string Code { get; set; }
    }
}