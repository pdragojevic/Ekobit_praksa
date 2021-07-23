using Data.DataContext;
using Data.Functions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Data.Functions.CRUD
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private LoginDBContext _context = null;
        private DbSet<T> table = null;
        public GenericRepository(LoginDBContext context)
        {
            this._context = context;
            table = _context.Set<T>();
        }
        #region CRUD
        /// <summary>
        /// Create a new record of type T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectForDb"></param>
        /// <returns></returns>
        public void Insert(T obj)
        {
            table.Add(obj);
        }

        /// <summary>
        /// Get a record from the database of Type T, by passing the Id(Primary Key) of the object type you want back. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public T GetById(object entityId)
        {
            return table.Find(entityId);
        }

        /// <summary>
        /// Gets all records from the database of Type T. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Generic List Object</returns>
        public IQueryable<T> GetAll()
        {
            return table.AsNoTracking();
        }

        /// <summary>
        /// Update a record in the database of Type T, by passing both updated value and the primary key. 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        /// <summary>
        /// Delete a record of Type T from the database by passing the primary key value of the object you want deleted for the specified type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public void Delete(object entityId)
        {
            T existing = table.Find(entityId);
            table.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        #region BASIC EXAMPLE WITHOUT - DI
        //CRUD crud = new CRUD();
        ////ADD
        //var addItemResult = await crud.Create<Grade>(new Grade
        //{
        //    Grade_Capacity = 11,
        //    Grade_Name = "Grade 7",
        //    Grade_Number = 7,
        //    Grade_ModifiedDate = DateTime.UtcNow
        //});
        ////UPDATE
        //addItemResult.Grade_Name = "Super Grade 7";
        //    var updateResult = await crud.Update<Grade>(addItemResult, addItemResult.Grade_ID);
        ////READ
        //var readResult = await crud.Read<Grade>(5);
        ////READ ALL FOR SPECIFIED ENTITY
        //var readAllResult = await crud.ReadAll<Grade>();
        ////DELETE
        //var deleted = await crud.Delete<Grade>(4);
        #endregion
        #endregion
    }
}
