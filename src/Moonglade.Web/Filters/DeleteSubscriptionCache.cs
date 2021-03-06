﻿using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Moonglade.Caching;

namespace Moonglade.Web.Filters
{
    public class DeleteSubscriptionCache : ActionFilterAttribute
    {
        protected readonly ILogger<DeleteSubscriptionCache> Logger;
        private readonly IBlogCache _cache;

        public DeleteSubscriptionCache(ILogger<DeleteSubscriptionCache> logger, IBlogCache cache)
        {
            Logger = logger;
            _cache = cache;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            try
            {
                _cache.Remove(CacheDivision.General, "rss");
                _cache.Remove(CacheDivision.General, "atom");
                _cache.Remove(CacheDivision.RssCategory);
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Error delete subscription cache");
            }
        }
    }
}
