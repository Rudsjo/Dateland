namespace Dateland.Core
{
    // Required namespaces
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using System.IO.Compression;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System.Reflection.Metadata.Ecma335;
    using System.Xml.Schema;
    using System.Runtime.CompilerServices;
    using System;

    /// <summary>
    /// The global repository implementation
    /// </summary>
    /// <seealso cref="Dateland.Test2.Core.IRepository" />
    public class GlobalRepository : IRepository
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly AppDbContext Context;


        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GlobalRepository(AppDbContext context)
        {
            // Set the context
            this.Context = context;
        }



        #region Generic Add, Update, Delete

        /// <summary>
        /// Generic function to create a new entity
        /// </summary>
        /// <typeparam name="T">The class to base the object from</typeparam>
        /// <param name="entity">the name of the entity</param>
        /// <returns></returns>
        public async Task<T> Create<T>(T entity)
            where T : class
        {

            await Context.Set<T>().AddAsync(entity);          

            await Context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Generic function to update a new entity
        /// </summary>
        /// <typeparam name="T">the class of object to update</typeparam>
        /// <param name="entity">the object</param>
        /// <returns></returns>
        public async Task<T> Update<T>(T entity)
            where T : class
        {
            Context.Set<T>().Update(entity);

            await Context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Generic function to deleta an entity
        /// </summary>
        /// <typeparam name="T">the class of object to delete</typeparam>
        /// <param name="entity">the object</param>
        /// <returns></returns>
        public async Task<T> Delete<T>(T entity)
             where T : class
        {
            Context.Set<T>().Remove(entity);

            await Context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Generic function to get all objects of a specified type
        /// </summary>
        /// <typeparam name="T">the class of object to get</typeparam>
        /// <returns></returns>
        public async Task<ICollection<T>> GetAll<T>()
            where T : class
        {
            return await Context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Generic function to get a single object of a desired type
        /// </summary>
        /// <typeparam name="T">the class of object to return</typeparam>
        /// <param name="id">the identifier</param>
        /// <returns></returns>
        public async Task<T> GetByID<T>(int id)
            where T : class
        {
            return await Context.Set<T>().FindAsync(id);
        }

        /// <summary>
        /// Generic function to get a users relation of a specified type
        /// </summary>
        /// <typeparam name="T">the class of relation</typeparam>
        /// <param name="id">the identifier</param>
        /// <returns></returns>
        public async Task<ICollection<T>> GetRelation<T>(int id)
            where T : class
        {
            return await Context.Set<T>().ToListAsync();
        }

        /// <summary>
        /// Generic function to create a relation of a specified type
        /// </summary>
        /// <typeparam name="T">the class of relation</typeparam>
        /// <param name="relation">the relation object</param>
        /// <returns></returns>
        public async Task<T> CreateRelation<T>(T relation)
            where T : class
        {
            await Context.Set<T>().AddAsync(relation);

            await Context.SaveChangesAsync();

            return relation;
        }

        /// <summary>
        /// Generic function to remove a relation of a specified type
        /// </summary>
        /// <typeparam name="T">the class of relation</typeparam>
        /// <param name="relation">the relation object</param>
        /// <returns></returns>
        public async Task<T> RemoveRelation<T>(T relation)
            where T : class
        {
            Context.Set<T>().Remove(relation);

            await Context.SaveChangesAsync();

            return relation;
        }

        #endregion

       
    }
}
