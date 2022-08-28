
namespace mrpAccesLibrary
{
    public interface ISqlDataAccess
    {
        string ConnectionStringName { get; set; }

        Task<List<T>> Loaddata<T, U>(string sql, U paramaters);
        Task SaveData<T>(string sql, T paramaters);
        List<T> veri_getir<T, U>(string sql, U paramaters);
    }
}