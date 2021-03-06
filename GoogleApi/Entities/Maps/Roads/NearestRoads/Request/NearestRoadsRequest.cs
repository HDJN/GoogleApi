﻿using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Maps.Roads.NearestRoads.Request
{
    /// <summary>
    /// NearestRoads Request.
    /// </summary>
    public class NearestRoadsRequest : BaseMapsRequest, IQueryStringRequest
    {
        /// <summary>
        /// points — A list of latitude/longitude pairs. Latitude and longitude values should be separated by commas. 
        /// Coordinates should be separated by the pipe character: "|". 
        /// For example: points=60.170880,24.942795|60.170879,24.942796|60.170877,24.942796.
        /// </summary>
        public virtual IEnumerable<Location> Points { get; set; }

        /// <summary>
        /// BaseUrl property overridden.
        /// </summary>
        protected internal override string BaseUrl => "roads.googleapis.com/v1/nearestRoads";

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        protected override QueryStringParametersList GetQueryStringParameters()
        {
            if (this.Points == null || !this.Points.Any())
                throw new ArgumentException("Points is required");

            var parameters = base.GetQueryStringParameters();

            parameters.Add("points", string.Join("|", this.Points));

            return parameters;
        }
    }
}