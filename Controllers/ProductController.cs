using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    public class ProductController : ApiController
    {
        // Another approach to bounding the search result set to a fixed number is to
        // implement ISupportIncrementalLoading
        private const int MaxSearchResults = 1000;
        
        private IProductRepository _productRepository;

        public ProductController()
        {

            try
            {
                _productRepository = (IProductRepository) new ProductRepository();
            }
            catch (Exception ex)
            {
                throw new ProductControllerException(string.Format("Error en la construcción del objeto: {0}",ex.Message));
            }
            finally
            {

            }
        
        }

        public ProductController(IProductRepository productRepository)
        {
            try
            {
                if (productRepository == null)
                {
                    throw new ArgumentNullException();
                }
                else if (typeof(IProductRepository) == productRepository.GetType())
                {
                    _productRepository = productRepository;
                }
                else
                {
                    throw new ProductControllerException();
                }
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (InvalidCastException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ProductControllerException(string.Format("Error en la construcción del objeto: {0}", ex.Message));
            }
            finally
            {

            }
        }

        // GET /api/Product
        public IEnumerable<Product> GetProducts()
        {
            
            IEnumerable<Product> list_product = _productRepository.GetProducts();
            
            if(list_product == null)
            {
                throw new NullReferenceException();
            }

            return list_product;
        }

        // GET /api/Product/id
        public Product GetProduct(string id)
        {
            var item = _productRepository.GetProduct(id);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return item;
        }

        // GET /api/Product?queryString={queryString}
        public SearchResult GetSearchResults(string queryString)
        {
            var fullsearchResult = _productRepository.GetProducts().Where(p => p.Title.ToUpperInvariant().Contains(queryString.ToUpperInvariant()));

            var searchResult = new SearchResult
            {
                TotalCount = fullsearchResult.Count(),
                Products = fullsearchResult.Take(MaxSearchResults)
            };

            return searchResult;

        }

        // GET /api/Product?categoryId={categoryId}
        public IEnumerable<Product> GetProducts(int categoryId)
        {
            if (categoryId == 0)
            {
                return _productRepository.GetTodaysDealsProducts();
            }

            return _productRepository.GetProductsForCategory(categoryId);
        }
    }

    public class ProductControllerException : Exception
    {
       
        
        public ProductControllerException()
        {
            
        }

        public ProductControllerException(string descripcion)
        {
            
        }
        public override string Message
        {
            get { return Message; }
            
        }

    }
}
