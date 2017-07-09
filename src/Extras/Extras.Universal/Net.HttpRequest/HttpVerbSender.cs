//-----------------------------------------------------------------------
// <copyright file="HttpVerbSender.cs" company="Genesys Source">
//      Copyright (c) 2017 Genesys Source. All rights reserved.
//      All rights are reserved. Reproduction or transmission in whole or in part, in
//      any form or by any means, electronic, mechanical or otherwise, is prohibited
//      without the prior written consent of the copyright owner.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Threading.Tasks;
using Genesys.Extras.Text;
using Genesys.Extensions;

namespace Genesys.Extras.Net
{
    /// <summary>
    /// Handles sending HttpRequests to endpoints and receiving a response
    /// </summary>
    public class HttpVerbSender
    {
        /// <summary>
        /// Event Args for loading and binding new model data
        /// </summary>
        public class RequestEventArgs : EventArgs
        {
            /// <summary>
            /// New model data
            /// </summary>
            public HttpRequestClient Request { get; set; }
        }

        /// <summary>
        /// Send is about to begin
        /// </summary>
        public event SendBeginEventHandler SendBegin;

        /// <summary>
        /// Send is complete
        /// </summary>
        public event SendBeginEventHandler SendEnd;

        /// <summary>
        /// OnSendBegin()
        /// </summary>
        public virtual void OnSendBegin(HttpRequestClient request)
        {
            if (SendBegin != null)
            {
                SendBegin(this, new RequestEventArgs() { Request = request });
            }
            Request = request;
        }

        /// <summary>
        /// OnSendEnd()
        /// </summary>
        public virtual void OnSendEnd(HttpRequestClient request)
        {
            if (SendEnd != null)
            {
                SendEnd(this, new RequestEventArgs() { Request = request });
            }
            Request = request;
        }

        /// <summary>
        /// Workflow beginning. No custom to return.
        /// </summary>
        /// <param name="sender">Sender of event</param>
        /// <param name="e">Arguments passed to the event handler</param>
        public delegate void SendBeginEventHandler(object sender, RequestEventArgs e);

        /// <summary>
        /// Last HttpRequest
        /// </summary>
        public HttpRequestClient Request { get; protected set; }

        /// <summary>
        /// Parameterless constructor
        /// </summary>
        public HttpVerbSender()
            : base()
        {
        }
        
        /// <summary>
        /// Instantiates and transmits all data to the middle tier web service that will execute the workflow
        /// </summary>
        /// <returns></returns>
        public virtual async Task<TDataOut> SendGetAsync<TDataOut>(Uri fullUrl) where TDataOut : new()
        {
            var returnValue = default(TDataOut);
            var request = new HttpRequestGet<TDataOut>(fullUrl);

            OnSendBegin(request);
            returnValue = await request.SendAsync();
            OnSendEnd(request);

            return returnValue;
        }
        
        /// <summary>
        /// Instantiates and transmits all data to the middle tier web service that will execute the workflow
        /// </summary>
        /// <returns></returns>
        public virtual async Task<TDataOut> SendPostAsync<TDataIn, TDataOut>(Uri fullUrl, TDataIn itemToSend)
        {            
            var returnValue = default(TDataOut);
            var request = new HttpRequestPost<TDataIn, TDataOut>(fullUrl, itemToSend);

            OnSendBegin(request);
            returnValue = await request.SendAsync();
            OnSendEnd(request);

            return returnValue;
        }

        /// <summary>
        /// Instantiates and transmits all data to the middle tier web service that will execute the workflow
        /// </summary>
        /// <returns></returns>
        public virtual async Task<TDataInOut> SendPostAsync<TDataInOut>(Uri fullUrl, TDataInOut itemToSend)
        {
            return await SendPostAsync<TDataInOut, TDataInOut>(fullUrl, itemToSend);
        }
        
        /// <summary>
        /// Instantiates and transmits all data to the middle tier web service that will execute the workflow
        /// </summary>
        /// <returns></returns>
        public virtual async Task<TDataOut> SendPutAsync<TDataIn, TDataOut>(Uri fullUrl, TDataIn itemToSend)
        {            
            var returnValue = default(TDataOut);
            var request = new HttpRequestPut<TDataIn, TDataOut>(fullUrl, itemToSend);

            OnSendBegin(request);
            returnValue = await request.SendAsync();
            OnSendEnd(request);

            return returnValue;
        }

        /// <summary>
        /// Instantiates and transmits all data to the middle tier web service that will execute the workflow
        /// </summary>
        /// <returns></returns>
        public virtual async Task<TDataInOut> SendPutAsync<TDataInOut>(Uri fullUrl, TDataInOut itemToSend)
        {
            return await SendPutAsync<TDataInOut, TDataInOut>(fullUrl, itemToSend);
        }
        
        /// <summary>
        /// Instantiates and transmits all data to the middle tier web service that will execute the workflow
        /// </summary>
        /// <returns></returns>
        public virtual async Task<bool> SendDeleteAsync(Uri fullUrl)
        {
            var returnValue = TypeExtension.DefaultBoolean;
            var request = new HttpRequestDelete<bool>(fullUrl);

            OnSendBegin(request);
            returnValue = await request.SendAsync();
            OnSendEnd(request);

            return returnValue;
        }        
    }
}
