using GroceryApp.Domain;
using GroceryApp.Requests;
using GroceryApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WikiWebStarter.Web.Models.Responses;

namespace GroceryApp.Controllers.Api
{
    [RoutePrefix("api/groceryitems")]
    public class ItemApiController : ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage Insert(GroceryItemAddRequest groceryItem)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                try
                {
                    GroceryItemService itemService = new GroceryItemService();
                    int id = itemService.Create(groceryItem);
                    ItemResponse<int> response = new ItemResponse<int>();
                    response.Item = id;

                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }

        [Route, HttpGet]
        public HttpResponseMessage Get()
        {
            GroceryItemService itemService = new GroceryItemService();
            try
            {
                List<GroceryItem> list = itemService.GetAll();
                ItemsResponse<GroceryItem> response = new ItemsResponse<GroceryItem>();
                response.Items = list;

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage Get(int id)
        {
            GroceryItemService itemService = new GroceryItemService();
            try
            {
                GroceryItem groceryItem = itemService.Get(id);
                ItemResponse<GroceryItem> response = new ItemResponse<GroceryItem>();
                response.Item = groceryItem;

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Update(GroceryItemUpdateRequest groceryItem, int id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                try
                {
                    GroceryItemService itemService = new GroceryItemService();
                    itemService.Update(groceryItem, id);
                    ItemResponse<int> response = new ItemResponse<int>();
                    response.Item = id;

                    return Request.CreateResponse(HttpStatusCode.OK, response);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
                }
            }
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                GroceryItemService itemService = new GroceryItemService();
                itemService.Delete(id);
                ItemResponse<int> response = new ItemResponse<int>();
                response.Item = id;

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
