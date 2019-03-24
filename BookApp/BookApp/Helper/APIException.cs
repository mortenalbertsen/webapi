﻿using System;
using System.Net;
using System.Runtime.Serialization;

namespace BookApp.Helper {
    /// <summary>
    /// Api Exception
    /// </summary>
    [Serializable]
    [DataContract]
    public class APIException : Exception, IAPIException {
        #region Public Serializable properties.
        /// <summary>
        /// Error Code
        /// </summary>
        [DataMember]
        public int ErrorCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]

        public string ErrorDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public HttpStatusCode HttpStatus { get; set; }

        string reasonPhrase = "ApiException";
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ReasonPhrase {
            get { return this.reasonPhrase; }

            set { this.reasonPhrase = value; }
        }
        #endregion
    }
}