﻿using System;

using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using WebApi.Repositories;



namespace WebApi.Controllers
{
    public class TileNotificationController : ApiController
    {

        private IProductRepository _productRepository;

        public TileNotificationController()
            
        {
            try
            {
                _productRepository = (IProductRepository) new ProductRepository();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }

        
        }

        public TileNotificationController(IProductRepository productRepository)
        {
            try
            {
                _productRepository = productRepository;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        public HttpResponseMessage GetTileNotification()
        {
            var tileXml = GetDefaultTileXml("http://localhost:57959/Images/Ordenadores1.jpg",
                                             "Computadora Sobremesa, 40");
            
            
            tileXml = string.Format(CultureInfo.InvariantCulture, tileXml, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());

            // create HTTP response
            var response = new HttpResponseMessage();

            // format response
            response.StatusCode = System.Net.HttpStatusCode.OK;
            response.Content = new StringContent(tileXml);

            //Need to return xml format to TileUpdater.StartPeriodicUpdate
            response.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("text/xml");
            return response;

        }

        public HttpResponseMessage GetSecondaryTileNotification(string id)
        {
            var product = _productRepository.GetProduct(id);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var tileXml = GetSecondaryTileXml(product.ImageUri.AbsoluteUri, product.Title);

            // Create HTTP response
            var response = new HttpResponseMessage();

            // Format response
            response.StatusCode = System.Net.HttpStatusCode.OK;
            response.Content = new StringContent(tileXml);

            // Need to return xml format to TileUpdater.StartPeriodicUpdate
            response.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue("text/xml");
            return response;
        }

        // GET /api/TileNotification

        private static string GetDefaultTileXml(string imageUri, string title)
        {
            var tileXml = @"<tile>
                                <visual>
                                <binding template=""TileWidePeekImage01"">
                                    <image id=""1"" src=""{0}"" alt=""alt text""/>
                                    <text id=""1"">Today's Deals</text>
                                    <text id=""2"">{1}. Updated: {2} {3}</text>
                                </binding>
                                <binding template=""TileSquarePeekImageAndText02"">
                                    <image id=""1"" src=""{0}"" alt=""alt text""/>
                                    <text id=""1"">Today's Deals</text>
                                    <text id=""2"">{1}. Updated: {2} {3}</text>
                                </binding> 
                                </visual>
                            </tile>";

            return string.Format(CultureInfo.InvariantCulture, tileXml, imageUri, title,
                DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString());
        }

        private static string GetSecondaryTileXml(string imageUri, string title)
        {
            var tileXml = @"<tile>
                                <visual>
                                <binding template=""TileWidePeekImage03"">
                                    <image id=""1"" src=""{0}"" alt=""alt text""/>
                                    <text id=""1"">{1}</text>
                                </binding>
                                <binding template=""TileSquarePeekImageAndText04"">
                                    <image id=""1"" src=""{0}"" alt=""alt text""/>
                                    <text id=""1"">{1}</text>
                                </binding> 
                                </visual>
                            </tile>";

            return string.Format(CultureInfo.InvariantCulture, tileXml, imageUri, title);
        }

  
    }

    

}
