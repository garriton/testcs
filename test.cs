using System.Data.Entity;
using System.Linq;

public class EFDb : DbContext
{
    public EFDb() : base("YourConnectionStringName") { }

    public virtual DbSet<Table1> Table1
    {
        get; set;
    }
}

public class Table1
{
    public int A
    {
        get; set;
    }
}

public class YourClass
{
    protected void SQL(string strA)
    {
        using(var m_Db = new EFDb())
        {
            string commandText = string.Format("SELECT * FROM [Table1] WHERE [A] = '{0}'",strA);

            var listRS = m_Db.Database.SqlQuery<Table1>(commandText).ToList();
        }
    }
}
