namespace AtmManagement.Api.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        // Verilen bir ID'ye ait varlığı asenkron olarak getirir. Dönen sonuç, veritabanından çekilen varlığın türüne (T) uygun olur.
        Task<T> GetByIdAsync(int id);
        //Tüm varlıkları asenkron olarak getirir. Dönen sonuç, varlıkların bir koleksiyonunu temsil eden bir IEnumerable<T> türüdür.
        Task<IEnumerable<T>> GetAllAsync();
        //Yeni bir varlığı asenkron olarak ekler. İşlem sonunda geriye bir değer döndürmez (Task).
        Task AddAsync(T entity);
        // Varlığın güncellenmiş halini veritabanına uygular. Geriye bir değer döndürmez (void).
        void Update(T entity);
        //Opsiyonel.Varlığı veritabanından siler. Geriye bir değer döndürmez (void).
        void Delete(T entity);
        //Opsiyonel.Yeni bir varlığı senkron olarak ekler. Hem senkron hem asenkron ekleme işlemlerini desteklemek için kullanılabilir.
        void Add(T entity);
        //Opsiyonel Değişiklikleri veritabanına asenkron olarak kaydeder. İşlem sonunda geriye bir değer döndürmez (Task).
        Task CommitAsync();
        
    }

}

