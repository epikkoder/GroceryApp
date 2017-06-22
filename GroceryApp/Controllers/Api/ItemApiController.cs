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
    [RoutePrefix("api/items")]
    public class ItemApiController : ApiController
    {
        [Route, HttpPost]
        public HttpResponseMessage Insert(ItemAddRequest item)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                try
                {
                    ItemService itemService = new ItemService();
                    int id = itemService.Create(item);
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
            ItemService itemService = new ItemService();
            try
            {
                List<Item> list = itemService.GetAll();
                ItemsResponse<Item> response = new ItemsResponse<Item>();
                response.Items = list;

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage Get(int id)
        {
            ItemService itemService = new ItemService();
            try
            {
                Item item = itemService.Get(id);
                ItemResponse<Item> response = new ItemResponse<Item>();
                response.Item = item;

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Update(ItemUpdateRequest item, int id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            else
            {
                try
                {
                    ItemService itemService = new ItemService();
                    itemService.Update(item, id);
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
                ItemService itemService = new ItemService();
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
