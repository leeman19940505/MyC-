﻿using MvcApiDemo.Controllers;
using MVCAPIDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCAPIDemo.Controllers
{
    public class NewsController : ApiController
    {
        /// <summary>
        /// GET获取全部新闻
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllNews()
        {
            var news = new NewsRepository().GetAllNews();
            return new HttpResponseMessage()
            {
                RequestMessage = Request,
                Content = new XmlContent(SimpleXmlConverter.ToXmlDocument<News>(news, "NewsRoot"))
            };
        }

        /// <summary>
        /// GET获取指定ID新闻
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetNewsByID(int ID)
        {
            var news = new NewsRepository().GetAllNews().Where((p) => p.Id == ID);
            return new HttpResponseMessage()
            {
                RequestMessage = Request,
                Content = new XmlContent(SimpleXmlConverter.ToXmlDocument<News>(news, "NewsRoot"))
            };
        }
    }
}
