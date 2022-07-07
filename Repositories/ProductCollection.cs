using MongoDB.Bson;
using MongoDB.Driver;
using MyGroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGroceryStoreAPI.Repositories
{
    public class ProductCollection : IProductCollection
    {

        #region [ VARIABLES GLOBALS ]
        internal MongoDbRepository mongoDbRepository = new MongoDbRepository();
        private readonly IMongoCollection<Product> mongoCollection;
        #endregion

        public ProductCollection()
        {
            mongoCollection = mongoDbRepository.database.GetCollection<Product>("Products");
        }



        /// <summary>
        /// Create New Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task CreateProduct(Product product)
        {

            await mongoCollection.InsertOneAsync(product);
        }


        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns> True </returns>
        public async Task DeleteProduct(string id)
        {

            var filter = Builders<Product>.Filter.Eq(p => p.Id, new ObjectId(id));

            await mongoCollection.DeleteOneAsync(filter);
        }



        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns> Products List </returns>
        public async Task<List<Product>> GetAllProducts()
        {

            return await mongoCollection.FindAsync(new BsonDocument()).Result.ToListAsync(); 
        }



        /// <summary>
        /// Get By Id Prodcut
        /// </summary>
        /// <param name="id"></param>
        /// <returns> Id </returns>
        public async Task<Product> GetProductById(string id)
        {

            return await mongoCollection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }



        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task UpdateProduct(Product product)
        {

            var filter = Builders<Product>.Filter.Eq(p => p.Id, product.Id);

            await mongoCollection.ReplaceOneAsync(filter, product);
        }
    }
}
