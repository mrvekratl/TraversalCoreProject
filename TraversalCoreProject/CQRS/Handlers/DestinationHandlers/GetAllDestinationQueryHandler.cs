﻿using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProject.CQRS.Queries.DestinationQueries;
using TraversalCoreProject.CQRS.Results.DestinationResults;

namespace TraversalCoreProject.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;
        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                id = x.DestinationID,
                capacity = (int)x.Capacity,
                city = x.City,
                daynight = x.DayNight,
                price = (int)x.Price
            }).AsNoTracking().ToList();
            return values;
        }
    }
}
