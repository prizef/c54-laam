﻿using c54_laam.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace c54_laam.Controllers
{
    public class VisaController : ApiController
    {
        [Route("api/visa/test"), HttpGet]
        public HttpResponseMessage Test()
        {
            var visaAPIClient = new VisaAPIClient();
            string strDate = DateTime.UtcNow.ToString("yyyy-MM-ddThh:mm:ss.fff");
            var searchRequest =
                 "{"
                        + "\"header\": {"
                        + "\"messageDateTime\": \"" + strDate + "\","
                        + "\"requestMessageId\": \"CDISI_GMR_001\","
                        + "\"startIndex\": \"1\""
                        + "},"
                        + "\"searchAttrList\": {"
                        + "\"merchantName\": \"ALOHA CAFE\","
                        + "\"merchantStreetAddress\": \"410 E 2ND ST\","
                        + "\"merchantCity\": \"LOS ANGELES\","
                        + "\"merchantState\": \"CA\","
                        + "\"merchantPostalCode\": \"90012\","
                        + "\"merchantCountryCode\": \"840\","
                        + "\"visaMerchantId\": \"11687107\","
                        + "\"visaStoreId\": \"125861096\","
                        + "\"businessRegistrationId\": \"196007747\","
                        + "\"acquirerCardAcceptorId\": \"191642760469222\","
                        + "\"acquiringBin\": \"486168\""
                        + "},"
                        + "\"responseAttrList\": ["
                        + "\"GNSTANDARD\""
                        + "],"
                        + "\"searchOptions\": {"
                        + "\"maxRecords\": \"2\","
                        + "\"matchIndicators\": \"true\","
                        + "\"matchScore\": \"true\""
                     + "}"
                   + "}";

            string baseUri = "merchantsearch/";
            string resourcePath = "v1/search";
            string status = visaAPIClient.DoMutualAuthCall(baseUri + resourcePath, "POST", "Merchant Search API Test", searchRequest);

            return Request.CreateResponse(System.Net.HttpStatusCode.OK, status);
        }
    }
}
